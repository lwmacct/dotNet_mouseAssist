using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using KeyboardHook;

namespace Lwm.inputAssist {
	/// <summary>
	/// 热键状态
	/// </summary>
	public class InputHook {

		#region 导入 DLL
		/// <summary>
		/// 获取窗口标题
		/// </summary>
		/// <param name="hWnd">窗口句柄</param>
		/// <param name="lpString">标题</param>
		/// <param name="nMaxCount">最大值</param>
		/// <returns></returns>
		[DllImport( "user32", SetLastError = true )]
		public static extern int GetWindowText(
			IntPtr hWnd,
			StringBuilder lpString,
			int nMaxCount
		);
		/// <summary>
		/// 获取类的名字
		/// </summary>
		/// <param name="hWnd">句柄</param>
		/// <param name="lpString">类名</param>
		/// <param name="nMaxCount"></param>
		/// <returns>最大值</returns>
		[DllImport( "user32.dll" )]
		public static extern int GetClassName(
			IntPtr hWnd,
			StringBuilder lpString,
			int nMaxCount
		);

		/// <summary>
		/// 根据坐标获取窗口句柄
		/// </summary>
		/// <param name="Point">坐标</param>
		/// <returns></returns>
		[DllImport( "user32" )]
		public static extern IntPtr WindowFromPoint(
			Point Point
		);
		/// <summary>
		/// 获取前台窗口句柄
		/// </summary>
		/// <returns></returns>
		[DllImport( "user32.dll", CharSet = CharSet.Auto, ExactSpelling = true )]
		public static extern IntPtr GetForegroundWindow();
		/// <summary>
		/// 模拟键盘的方法
		/// </summary>
		/// <param name="bVk" >按键的虚拟键值</param>
		/// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
		/// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
		/// <param name= "dwExtraInfo">一般设置为0</param>
		[DllImport( "user32.dll" )]
		public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

		#endregion

		#region 子类
		/// <summary>
		/// 前台窗口信息类
		/// </summary>
		public class Foreground_Window_Info {
			/// <summary>
			/// 句柄
			/// </summary>
			public IntPtr IntPtr;
			/// <summary>
			/// 标题
			/// </summary>StringBuilder
			public StringBuilder title = new StringBuilder( 256 );
			/// <summary>
			/// 类名
			/// </summary>
			public StringBuilder className = new StringBuilder( 256 );
			public Foreground_Window_Info() {
				this.IntPtr = GetForegroundWindow();//得到窗口句柄
				GetWindowText( this.IntPtr, this.title, this.title.Capacity );//得到窗口的标题
				GetClassName( this.IntPtr, this.className, this.className.Capacity );//得到窗口的类名
			}
			/// <summary>
			/// 转为字符串
			/// </summary>
			/// <returns></returns>
			public string MytoString() {
				return new {
					this.IntPtr,
					this.title,
					this.className
				}.ToString();
			}
		}
		/// <summary>
		/// 鼠标所在窗口信息类
		/// </summary>
		public class Mouse_Window_Info {
			/// <summary>
			/// 句柄
			/// </summary>
			public IntPtr IntPtr;
			/// <summary>
			/// 标题
			/// </summary>StringBuilder
			public StringBuilder title = new StringBuilder( 256 );
			/// <summary>
			/// 类名
			/// </summary>
			public StringBuilder className = new StringBuilder( 256 );

			//public string toString;
			public Mouse_Window_Info(Point location) {
				IntPtr = WindowFromPoint( location );//得到窗口句柄
				GetWindowText( IntPtr, title, title.Capacity );//得到窗口的标题
				GetClassName( IntPtr, className, className.Capacity );//得到窗口的类名
			}
			/// <summary>
			/// 转为字符串
			/// </summary>
			/// <returns></returns>
			public string MytoString() {
				return new {
					this.IntPtr,
					this.title,
					this.className
				}.ToString();
			}
		}
		#endregion 子类

		#region 枚举

		/// <summary>
		/// 按钮动作
		/// </summary>
		public enum Action {
			/// <summary>
			/// 按键按下
			/// </summary>
			KeyDown,
			/// <summary>
			/// 按键弹起
			/// </summary>
			KeyUp
		}
		/// <summary>
		/// 安装钩子的枚举
		/// </summary>
		public enum IH {

			/// <summary>
			/// 勾住输入设备
			/// </summary>
			HookUp = 0,

			/// <summary>
			/// 卸载钩子
			/// </summary>
			UnLoad,

		}

		#endregion 枚举

		#region 事件委托

		/// <summary>
		/// 按下或者弹起某键
		/// </summary>
		/// <param name="KeyDown_And_KeyUp">按下或弹起,枚举Em</param>
		/// <param name="key"></param>
		public delegate void d_KeysEvent(Action KeyDown_And_KeyUp, KeyEventArgs key);

		/// <summary>
		/// 鼠标事件
		/// </summary>
		/// <param name="e"></param>
		public delegate void d_MouseEvent(MouseEventArgs e);

		#endregion 事件委托

		#region 事件

		/// <summary>
		/// 按下或者弹起某键
		/// </summary>
		public event d_KeysEvent Event_Keys;

		/// <summary>
		/// 鼠标事件
		/// </summary>
		public event d_MouseEvent Event_Mouse;

		#endregion 事件

		#region 公有方法

		/// <summary>
		/// 安装钩子
		/// </summary>
		public void Hooks_Install() {
			vId.InstallHook( 1 );
		}

		/// <summary>
		/// 卸载钩子
		/// </summary>
		/// <param name="type"></param>
		public void Hooks_UnLoad() {
			vId.InstallHook( 0 );
		}

		/// <summary>
		/// 屏蔽键盘
		/// </summary>
		public void Shield_keyboard() {
			vId.InstallHook( 2 );
		}
		#endregion 公有方法

		#region 私有方法

		/// <summary>
		/// 设置上一次按下的键,最多保存5条记录
		/// </summary>
		/// <param name="KeyCode"></param>
		private void Set_inputRecord(Keys KeyCode) {
			//数组后移
			for (int i = inputRecord.Length - 1; i >= 0; i--) {
				if (i - 1 >= 0) {
					inputRecord[i] = inputRecord[i - 1];
				}
			}
			inputRecord[0] = KeyCode;//设置第一个值为最新值
		}

		/// <summary>
		/// 按下处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="key"></param>
		private void CallBack_KeyDown(object sender, KeyEventArgs key) {
			this.window_Info_Foreground = new Foreground_Window_Info();//更新前台窗口信息
			this.keyStateAll[key.KeyCode] = true;//设置按键状态
			Set_inputRecord( key.KeyCode );//设置输入记录
			Event_Keys( Action.KeyDown, key );//发表事件
		}

		/// <summary>
		/// 弹起处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="key"></param>
		private void CallBack_KeyUp(object sender, KeyEventArgs key) {
			this.keyStateAll[key.KeyCode] = false;//设置按键状态
			Event_Keys( Action.KeyUp, key );//发表事件
		}

		/// <summary>
		/// 鼠标处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CallBack_MouseMove(object sender, MouseEventArgs e) {
			last_mouse_record = e;//最后一次的鼠标记录
			this.window_Info_Mouse = new Mouse_Window_Info( e.Location );//更新鼠标所在窗口信息
			Event_Mouse( e );//发表事件
		}

		#endregion 私有方法

		#region 公有变量

		/// <summary>
		/// 输入记录
		/// </summary>
		public Keys[] inputRecord = new Keys[5];

		/// <summary>
		/// 前台窗口信息
		/// </summary>
		public Foreground_Window_Info window_Info_Foreground;

		/// <summary>
		/// 鼠标所在窗口信息
		/// </summary>
		public Mouse_Window_Info window_Info_Mouse;

		/// <summary>
		/// 按键状态集合
		/// </summary>
		public Dictionary<Keys, Boolean> keyStateAll = new Dictionary<Keys, Boolean>();

		/// <summary>
		/// 是否正在模拟(防止嵌套模拟造成死循环循环)
		/// </summary>
		public Boolean is_simulated = false;


		#endregion 公有变量

		#region 私有变量

		/// <summary>
		/// 最后一次的鼠标记录
		/// </summary>
		private MouseEventArgs last_mouse_record;

		/// <summary>
		/// //输入设备
		/// </summary>
		private InputDevice vId;
		#endregion 私有变量
	
		public InputHook() {
			//把按下和弹起加入热键状态方法,以便更新组合键母键状态
			vId = new InputDevice();
			vId.OnMouseActivity += new MouseEventHandler( CallBack_MouseMove );
			vId.OnKeyDown += new KeyEventHandler( CallBack_KeyDown );
			vId.OnKeyUp += new KeyEventHandler( CallBack_KeyUp );
			//把所有按键加进去,初始化为 false,以免访问不到造成报错
			foreach (Keys item in Enum.GetValues( typeof( Keys ) )) {
				keyStateAll[item] = false;
			}
		}

	}
}
