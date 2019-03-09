using Lwm.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Lwm.ScreenShot;
using Lwm.Win32API;
using System.Drawing;

namespace Lwm.inputAssist {
	/// <summary>
	/// 软件热键类
	/// </summary>
	[DataContract]
	public class Software_Hotkey {

		#region 子类

		/// <summary>
		/// 构造函数时的配置类
		/// </summary>
		[DataContract]
		public class Setting {
			/// <summary>
			/// 软件名称
			/// </summary>
			[DataMember( IsRequired = true )]
			public string softwareName = "";

			/// <summary>
			/// 窗口标题 正则表达式
			/// </summary>
			[DataMember( IsRequired = true )]
			public string title_regexMatch = "";

			/// <summary>
			/// 匹配到的分组
			/// </summary>
			[DataMember( IsRequired = true )]
			public int title_MatchGroup = 0;

			/// <summary>
			/// 匹配到的值
			/// </summary>
			[DataMember( IsRequired = true )]
			public string title_MatchValue = "";

			/// <summary>
			/// 窗口类名 正则表达式,不需要验证类名无需填写
			/// </summary>
			[DataMember( IsRequired = true )]
			public string class_regexMatch = "";

			/// <summary>
			/// 窗口类名 匹配到的分组
			/// </summary>
			[DataMember( IsRequired = true )]
			public int class_MatchGroup = 0;

			/// <summary>
			/// 窗口类名 匹配到的值
			/// </summary>
			[DataMember( IsRequired = true )]
			public string class_MatchValue = "";

		}

		/// <summary>
		/// 提供用于管理当前类的子类
		/// </summary>
		public class Manage {

			/// <summary>
			/// 热键列表
			/// </summary>
			public List<Software_Hotkey> Software_Hotkey_List = new List<Software_Hotkey>();

			/// <summary>
			/// 加载配置
			/// </summary>
			/// <param name="filePath"></param>
			public void Load_Config(string filePath = @"Config\Software_List.json") {

				//如果文件存在的话
				if (File.Exists( filePath )) {
					String content = File.ReadAllText( filePath );
					Software_Hotkey_List = JSON.parse<List<Software_Hotkey>>( content );
				}

			}

			/// <summary>
			/// 保存配置
			/// </summary>
			/// <param name="filePath"></param>
			public void Save_Config(string filePath = @"Config\Software_List.json") {
				//如果目录不存在就创建目录
				if (!Directory.Exists( "Config" )) {
					Directory.CreateDirectory( "Config" );
				}
				String content = JSON.stringify( Software_Hotkey_List );
				File.WriteAllText( filePath, content );
			}

			/// <summary>
			/// 通知软件热键列表管理器,按下了 Alt + 鼠标辅助按键 Next,匹配成功则返回需要执行的热键
			/// </summary>
			/// <param name="window_titleName">窗口标题</param>
			/// <param name="window_className">窗口类名</param>
			/// <returns></returns>
			public HotKey_Execute Get_Next(string window_titleName, string window_className) {
				HotKey_Execute ret = null;
				for (var i = 0; i < Software_Hotkey_List.Count; i++) {
					if (Software_Hotkey_List[i].Perform_Matching( window_titleName, window_className )) {
						ret = Software_Hotkey_List[i].next;
						break;
					}
				}
				return ret;
			}

			/// <summary>
			/// 通知软件热键列表管理器,按下了 Alt + 鼠标辅助按键 Last,匹配成功则返回需要执行的热键
			/// </summary>
			/// <param name="window_titleName">窗口标题</param>
			/// <param name="window_className">窗口类名</param>
			/// <returns></returns>
			public HotKey_Execute Get_Last(string window_titleName, string window_className) {
				HotKey_Execute ret = null;
				for (var i = 0; i < Software_Hotkey_List.Count; i++) {
					if (Software_Hotkey_List[i].Perform_Matching( window_titleName, window_className )) {
						ret = Software_Hotkey_List[i].last;
						break;
					}

				}
				return ret;
			}

			/// <summary>
			/// 取得软件 快捷键列表 key_List(相当于右键菜单列表)
			/// </summary>
			/// <param name="window_titleName">窗口标题</param>
			/// <param name="window_className">窗口类名</param>
			/// <returns></returns>
			public List<HotKey_Execute> Get_Key_List(string window_titleName, string window_className) {

				List<HotKey_Execute> ret = new List<HotKey_Execute>();
				for (var i = 0; i < Software_Hotkey_List.Count; i++) {
					if (Software_Hotkey_List[i].Perform_Matching( window_titleName, window_className )) {
						ret = Software_Hotkey_List[i].key_List;
					}
					break;
				}
				return ret;
			}
		}

		/// <summary>
		/// 热键执行类
		/// </summary>
		[DataContract]
		public class HotKey_Execute {

			#region 导入Dll

			/// <summary>
			/// 模拟键盘的方法
			/// </summary>
			/// <param name="bVk" >按键的虚拟键值</param>
			/// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
			/// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
			/// <param name= "dwExtraInfo">一般设置为0</param>
			[DllImport( "user32.dll" )]
			private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

			/// <summary>
			/// 激活指定窗口(无论是否最小化) 
			/// 想要将最小化的窗口还原并使其在屏幕最前，只要向fAltTab参数传入TRUE就可以了。
			/// </summary>
			/// <param name="hWnd">要激活的窗口句柄</param>
			/// <param name="fAltTab">是否使最小化的窗口还原</param>
			/// <returns></returns>
			[DllImport( "user32.dll" )]
			private static extern void SwitchToThisWindow(IntPtr hWnd, Boolean fAltTab);//设定焦点

			#endregion 导入Dll

			/// <summary>
			///组合键数据,数组类型,分别储存第一次按下按键和第二次按下键
			/// </summary>
			[DataMember( IsRequired = true )]
			public List<Keys>[] HotKey = new List<Keys>[]{
				new List<Keys>(), new List<Keys>(),
			};

			/// <summary>
			/// 过程类
			/// </summary>
			public class Course {

				#region 导入Dll

				/// <summary>
				/// 对指定的窗口设置键盘焦点。该窗口必须与调用线程的消息队列相关
				/// </summary>
				/// https://baike.baidu.com/item/SetFocus
				/// <param name="hWnd">接收键盘输入的窗口指针</param>
				/// <returns>一个布尔值；如果获得焦点成功，则为 true；如果失败，则为 false。</returns>
				[DllImport( "user32.dll" )]
				private static extern Boolean SetFocus(IntPtr hWnd);//设定焦点


				/// <summary>
				/// 该函数获取窗口客户区的大小(桌面大小)
				/// 需要关键字 out
				/// </summary>
				/// https://baike.baidu.com/item/GetWindowRect/6376447?fr=aladdin
				/// 使用示例 GetClientRect( (IntPtr)66778, out ipRect )
				/// <param name="hWnd">窗口句柄</param>
				/// <param name="lpRect">是一个指针，指向一个RECT类型的rectangle结构。该结构有四个LONG字段,分别为left、top、right和bottom。GetClientRect将这四个字段设定为窗口显示区域的尺寸。left和top字段通常设定为0。right和bottom字段设定为显示区域的宽度和高度（像素点数）。 也可以是一个CRect对象指针。CRect对象有多个参数，与RECT用法相同</param>
				/// <returns>如果函数成功，返回一个非零值。</returns>
				[DllImport( "user32.dll" )]
				private static extern int GetClientRect(IntPtr hWnd, out RECT lpRect);

				/// <summary>
				/// 该函数返回指定窗口的边框矩形的尺寸。该尺寸以相对于屏幕坐标左上角的屏幕坐标给出。
				/// 需要关键字 out
				/// </summary>
				/// 使用示例 GetWindowRect ( (IntPtr)66778, out ipRect )
				/// <param name="hWnd">窗口句柄</param>
				/// <param name="lpRect">是一个指针，指向一个RECT类型的rectangle结构。该结构有四个LONG字段,分别为left、top、right和bottom。GetClientRect将这四个字段设定为窗口显示区域的尺寸。left和top字段通常设定为0。right和bottom字段设定为显示区域的宽度和高度（像素点数）。 也可以是一个CRect对象指针。CRect对象有多个参数，与RECT用法相同</param>
				/// <returns>如果函数成功，返回一个非零值。</returns>
				[DllImport( "user32.dll" )]
				private static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);

				/// <summary>
				/// 鼠标模拟
				/// </summary>
				/// https://baike.baidu.com/item/mouse_event
				/// <param name="dwFlags">标志位集，指定点击按钮和鼠标动作的多种情况。此参数可以是下列值的某种组合：</param>>
				/// <param name="dx">指定鼠标沿x轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOUSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际X坐标；给出的相对数据作为移动的mickeys数。一个mickey表示鼠标移动的数量，表明鼠标已经移动。</param>
				/// <param name="dy">指定鼠标沿y轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOUSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际y坐标，给出的相对数据作为移动的mickeys数。</param>
				/// <param name="dwData">如果dwFlags为MOUSEEVENTF_WHEEL，则dwData指定鼠标轮移动的数量。正值表明鼠标轮向前转动，即远离用户的方向；负值表明鼠标轮向后转动，即朝向用户。一个轮击定义为WHEEL_DELTA，即120。如果dwFlagsS不是MOUSEEVENTF_WHEEL，则dWData应为零。</param>
				/// <param name="dwExtralnfo">指定与鼠标事件相关的附加32位值。应用程序调用函数GetMessageExtraInfo来获得此附加信息。</param>
				/// <returns></returns>
				[DllImport( "user32.dll" )]
				private static extern int mouse_event(byte dwFlags, int dx, int dy, byte dwData, byte dwExtralnfo);


				/// <summary>
				/// 向api发送信息
				/// </summary>
				/// <param name="hWnd">信息发往的窗口的句柄</param>
				/// <param name="Msg">消息ID</param>
				/// <param name="wParam">参数1</param>
				/// <param name="lParam"> 参数2</param>
				/// <returns></returns>
				[DllImport( "User32.dll", EntryPoint = "PostMessage" )]
				private static extern int PostMessage(IntPtr hWnd, int Msg, long wParam, long lParam);

				[DllImport( "User32.dll" )]
				private extern static void SetCursorPos(int x, int y);

				[DllImport( "user32.dll", CharSet = CharSet.Auto )]
				private static extern bool GetCursorPos(out Point pt);


				[DllImport( "user32.dll", SetLastError = true )]
				private static extern bool GetGUIThreadInfo(uint idThread, ref GuiThreadInfo lpgui);

				[StructLayout( LayoutKind.Sequential )]
				public struct GuiThreadInfo {
					public int cbSize;
					public int flags;

					/// <summary>
					/// 个人理解为顶级窗口
					/// </summary>
					public IntPtr hwndActive;

					/// <summary>
					/// 获得焦点的窗口句柄
					/// </summary>
					public IntPtr hwndFocus;
					public IntPtr hwndCapture;
					public IntPtr hwndMenuOwner;
					public IntPtr hwndMoveSize;

					/// <summary>
					/// 插入符所在句柄
					/// </summary>
					public IntPtr hwndCaret;
					public RECT rectCaret;
				}

				#endregion

				/// <summary>
				/// 是否已经正在执行,用于鼠标辅助键触发去除重复
				/// </summary>
				public Boolean be_execute = false;

				/// <summary>
				/// 是否正在模拟
				/// </summary>
				public Boolean be_simulate = false;

				/// <summary>
				/// 要执行热键的窗口句柄
				/// </summary>
				public IntPtr handle = IntPtr.Zero;

				/// <summary>
				/// 窗口标题
				/// </summary>
				public string titleName = "";

				/// <summary>
				/// 窗口类名
				/// </summary>
				public string className = "";

				public GuiThreadInfo Lpgui {
					get { return Get_GuiThreadInfo(); }

				}

				private GuiThreadInfo Get_GuiThreadInfo() {
					GuiThreadInfo lpgui = new GuiThreadInfo();
					lpgui.cbSize = Marshal.SizeOf( lpgui );
					GetGUIThreadInfo( 0, ref lpgui );
					return lpgui;
				}

				public override string ToString() {
					return new {
						this.be_execute,
						this.be_simulate,
						this.handle,
						this.titleName,
						this.className
					}.ToString();
				}

				/// <summary>
				/// 重新初始化
				/// </summary>
				public void Reinit() {
					this.be_execute = false;
					this.be_simulate = false;
					this.className = "";
					this.titleName = "";
					this.handle = IntPtr.Zero;
				}

				/// <summary>
				/// 清除alt状态
				/// </summary>
				public void Clear_Alt_State() {

					//模拟点击
					PostMessage( Lpgui.hwndActive, 513, 1, MAKELONG( 50, 5 ) );
					System.Threading.Thread.Sleep( 10 );
					PostMessage( Lpgui.hwndActive, 512, 1, MAKELONG( 50, 5 ) );
				}

				private long MAKELONG(short x, short y) {
					short[] to = new[] { y, x };
					//Array.Sort( to );
					//Array.Reverse( to );
					//short a = 50;
					//short b = 30;
					long c = to[0] * 65536 + (ushort)to[1];
					//int c = a * 65536 + (ushort)b;
					return c;
				}
			}


			/// <summary>
			/// 注释
			/// </summary>
			[DataMember( IsRequired = true )]
			public string comment = "";

			/// <summary>
			/// 组合键的文本表示
			/// </summary>
			public string Key_Text {
				get { return Create_Key_Text(); }
			}

			/// <summary>
			/// 执行按下 按顺序按下
			/// </summary>
			private void Execute_Dowm(int index) {
				for (var i = 0; i < this.HotKey[index].Count; i++) {
					keybd_event( (byte)HotKey[index][i], 0, 0, 0 );
				}
			}

			/// <summary>
			/// 执行弹起 弹起的时候返过来弹起
			/// </summary>
			private void Execute_Up(int index) {
				for (var i = 0; i < this.HotKey[index].Count; i++) {
					keybd_event( (byte)HotKey[index][i], 0, 2, 0 );
				}
			}

			/// <summary>
			/// 清除热键
			/// </summary>
			public void ClearKey() {
				for (var i = 0; i < HotKey.Length; i++) {
					HotKey[i] = new List<Keys>();
				}
			}

			/// <summary>
			/// 创建组合键的文本表示
			/// </summary>
			/// <returns></returns>
			private string Create_Key_Text() {
				//这算法,我看着都懵
				List<string> ret = new List<string>();
				List<string>[] str = new List<string>[HotKey.Length];
				for (var i = 0; i < HotKey.Length; i++) {

					str[i] = new List<string>();
					for (var i1 = 0; i1 < HotKey[i].Count; i1++) {

						str[i].Add( To_Normal_key( HotKey[i][i1] ) );
					}
					ret.Add( string.Join( "+", str[i].ToArray() ) );
				}

				return string.Join( ", ", ret.ToArray() ).Trim( new char[] { ',', ' ' } );
			}

			/// <summary>
			/// 将 LshiftKey 之类的文本转为 Shift
			/// </summary>
			/// <param name="str"></param>
			private string To_Normal_key(Keys key) {
				string str = key.ToString();
				switch (key) {
					case Keys.LShiftKey:
					case Keys.RShiftKey:
						str = "Shift";
						break;
					case Keys.LControlKey:
					case Keys.RControlKey:
						str = "Ctrl";
						break;
					case Keys.LMenu:
					case Keys.RMenu:
						str = "Alt";
						break;

				}
				return str;
			}

			/// <summary>
			/// 开始执行热键
			/// </summary>
			/// <param name="is_simulated">用于标记为已模拟完成</param>
			public void Execute(Course c_course) {

				//我们需要开一个新线程来执行,避免执行下面这句的时候 Alt 按键还是按着的
				new Thread( new ThreadStart( () => {

					new Thread( new ThreadStart( () => {
						System.Threading.Thread.Sleep( 10 );
						SwitchToThisWindow( c_course.Lpgui.hwndActive, true );//设置焦点
						System.Threading.Thread.Sleep( 10 );
						c_course.Clear_Alt_State();//解除Alt状态

					} ) ).Start();
					System.Threading.Thread.Sleep( 10 );
					Execute_Dowm( 0 );//按下
					Execute_Up( 0 );//弹起
					System.Threading.Thread.Sleep( 10 );
					Execute_Dowm( 1 );//按下第二按键
					Execute_Up( 1 );//弹起第二按键

					c_course.Reinit();//重新初始化
					SwitchToThisWindow( c_course.Lpgui.hwndActive, true );//设置焦点

				} ) ).Start();

			}
		}

		#endregion

		/// <summary>
		/// 构造函数时的配置
		/// </summary>
		[DataMember( IsRequired = true )]
		public Setting setting;

		/// <summary>
		/// 滚轮快捷键列表
		/// </summary>
		[DataMember( IsRequired = true )]
		public List<HotKey_Execute> key_List = new List<HotKey_Execute>();

		/// <summary>
		/// 鼠标辅助键 上一个 
		/// </summary>
		[DataMember( IsRequired = true )]
		public HotKey_Execute last = new HotKey_Execute();

		/// <summary>
		/// 鼠标辅助键 下一个 
		/// </summary>
		[DataMember( IsRequired = true )]
		public HotKey_Execute next = new HotKey_Execute();

		/// <summary>
		/// 执行匹配
		/// </summary>
		/// <returns></returns>
		public Boolean Perform_Matching(string window_title, string window_class) {
			Match mat_title = Regex.Match( window_title, setting.title_regexMatch );//标题正则
			Match mat_class;//类名正则
			Boolean title_bool = false;//标题是否匹配成功
			Boolean class_bool = false;//类名是否匹配成功
			Boolean ret_bool = false;//最终匹配结果

			//匹配标题
			if (mat_title.Groups.Count >= setting.title_MatchGroup) {
				if (mat_title.Groups[setting.title_MatchGroup].Value == setting.title_MatchValue) {
					title_bool = true;
				}
			}
			//如果要求类名匹配
			if (setting.class_regexMatch != null) {
				mat_class = Regex.Match( window_class, setting.class_regexMatch );
				//匹配标题
				if (mat_class.Groups.Count >= setting.class_MatchGroup) {
					if (mat_class.Groups[setting.class_MatchGroup].Value == setting.class_MatchValue) {
						class_bool = true;
					}
				}

			} else { //否则默认为真
				class_bool = true;
			}
			//计算最终返回
			if (class_bool && title_bool) {
				ret_bool = true;
			}
			return ret_bool;
		}

		public Software_Hotkey(Setting setting) {
			this.setting = setting;
		}
	}
}
