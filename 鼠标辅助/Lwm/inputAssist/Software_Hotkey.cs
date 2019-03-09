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
using System.Drawing;
using Lwm.DLL;

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
						break;
					}

				}
				return ret;
			}
		}

		/// <summary>
		/// 热键执行类
		/// </summary>
		[DataContract]
		public class HotKey_Execute {

			/// <summary>
			/// win32api 输入设备 设置为静态让其不被回收
			/// </summary>
			private static WinAPI.InputDevice WinApi_id = new WinAPI.InputDevice();
			private static WinAPI.Window WinApi_w = new WinAPI.Window();

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
				//private readonly Lwm.DLL.WinAPI.Window winApi = new WinAPI.Window();
				private static WinAPI.Message WinApi_m = new WinAPI.Message();

				private IntPtr handle = IntPtr.Zero;

				/// <summary>
				/// 是否已经正在执行,用于鼠标辅助键触发去除重复
				/// </summary>
				public Boolean be_execute = false;

				/// <summary>
				/// 是否正在模拟
				/// </summary>
				public Boolean be_simulate = false;

				/// <summary>
				/// 是否已锁定窗口句柄,用于锁定执行时鼠标所在窗口句柄,避免在执行过程中窗口句柄被修改
				/// </summary>
				public Boolean is_Lock_Handle = false;

				/// <summary>
				/// 要执行热键的窗口句柄
				/// </summary>
				public IntPtr Handle {
					get { return handle; }
					set {
						if (value != IntPtr.Zero) {
							handle = value;
							is_Lock_Handle = true;
						}
					}
				}

				/// <summary>
				/// 窗口标题
				/// </summary>
				public string titleName = "";

				/// <summary>
				/// 窗口类名
				/// </summary>
				public string className = "";

				public WinAPI.Window.GuiThreadInfo Lpgui {
					get { return Get_GuiThreadInfo(); }

				}

				private WinAPI.Window.GuiThreadInfo Get_GuiThreadInfo() {
					WinAPI.Window.GuiThreadInfo lpgui = new WinAPI.Window.GuiThreadInfo();
					lpgui.cbSize = Marshal.SizeOf( lpgui );
					return lpgui;
				}

				public override string ToString() {
					return new {
						this.be_execute,
						this.be_simulate,
						this.Handle,
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
					this.is_Lock_Handle = false;
					this.className = "";
					this.titleName = "";
					this.Handle = IntPtr.Zero;
				}

				/// <summary>
				/// 清除alt状态
				/// </summary>
				public void Clear_Alt_State() {
					//模拟点击
					//按下
					System.Threading.Thread.Sleep( 10 );
					WinApi_m.PostMessage(
						this.Handle,
						(int)WinAPI.Const.WM_LBUTTONDOWN,
						(int)WinAPI.Const.MK_LBUTTON,
						WinApi_m.MAKELONG( 50, 5 )
					);
					//弹起
					WinApi_m.PostMessage(
						this.Handle,
						(int)WinAPI.Const.WM_LBUTTONUP,
						(int)WinAPI.Const.MK_LBUTTON,
						WinApi_m.MAKELONG( 50, 5 )
					);
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
					WinApi_id.keybd_event( (byte)HotKey[index][i], 0, 0, 0 );

				}
			}

			/// <summary>
			/// 执行弹起 弹起的时候返过来弹起
			/// </summary>
			private void Execute_Up(int index) {
				for (var i = 0; i < this.HotKey[index].Count; i++) {
					WinApi_id.keybd_event( (byte)HotKey[index][i], 0, 2, 0 );
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

					System.Threading.Thread.Sleep( 10 );

					WinApi_w.SwitchToThisWindow( c_course.Handle, true );//设置焦点

					System.Threading.Thread.Sleep( 10 );

					c_course.Clear_Alt_State();//解除Alt状态

					System.Threading.Thread.Sleep( 10 );

					Execute_Dowm( 0 );//按下
					Execute_Up( 0 );//弹起

					System.Threading.Thread.Sleep( 10 );

					Execute_Dowm( 1 );//按下第二按键
					Execute_Up( 1 );//弹起第二按键

					c_course.Reinit();//重新初始化

					//new Thread( new ThreadStart( () => {} ) ).Start();

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
