using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
namespace Lwm.inputAssist {
	/// <summary>
	/// 热键状态
	/// </summary>
	public class HotKeyState {

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
		public class ForegroundWindowInfo {
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
			public ForegroundWindowInfo() {
				this.IntPtr = GetForegroundWindow();//得到窗口句柄
				GetWindowText( this.IntPtr, this.title, this.title.Capacity );//得到窗口的标题
				GetClassName( this.IntPtr, this.className, this.className.Capacity );//得到窗口的类名
			}

			public string MytoString() {
				return new {
					this.IntPtr,
					this.title,
					this.className
				}.ToString();
			}
		}
		public enum Em {
			/// <summary>
			/// 按键按下
			/// </summary>
			KeyDown,
			/// <summary>
			/// 按键弹起
			/// </summary>
			KeyUp
		}

		#endregion 子类

		//事件委托
		/// <summary>
		/// 按下或者弹起某键
		/// </summary>
		/// <param name="KeyDown_And_KeyUp">按下或弹起,枚举Em</param>
		/// <param name="key"></param>
		public delegate void d_KeysEvent(Em KeyDown_And_KeyUp, KeyEventArgs key);
		/// <summary>
		/// 鼠标事件
		/// </summary>
		/// <param name="e"></param>
		public delegate void d_MouseEvent(MouseEventArgs e);

		//事件事件
		public event d_KeysEvent Event_Keys;
		public event d_MouseEvent Event_Mouse;

		#region 公有变量
		public Keys[] inputRecord = new Keys[5];
		/// <summary>
		/// 前台窗口信息
		/// </summary>
		public ForegroundWindowInfo foregroundWindowInfo;
		/// <summary>
		/// 按键状态集合
		/// </summary>
		public Dictionary<Keys, Boolean> keyStateAll = new Dictionary<Keys, Boolean>();
		/// <summary>
		/// 鼠标坐标
		/// </summary>
		public Point MousePosition;
		/// <summary>
		/// 是否正在模拟(防止嵌套模拟造成死循环循环)
		/// </summary>
		public Boolean is_simulated = false;
		#endregion

		#region 公有方法
		//按下处理
		public void CallBack_KeyDown(object sender, KeyEventArgs key) {
			this.keyStateAll[key.KeyCode] = true;//设置按键状态
			Set_inputRecord( key.KeyCode );//设置输入记录
			this.foregroundWindowInfo = new ForegroundWindowInfo();//设置前台窗口信息
			Event_Keys( Em.KeyDown, key );//发表事件
		}
		//弹起处理
		public void CallBack_KeyUp(object sender, KeyEventArgs key) {
			this.keyStateAll[key.KeyCode] = false;//设置按键状态
			Event_Keys( Em.KeyUp, key );//发表事件
		}
		//鼠标处理
		public void CallBack_MouseMove(object sender, MouseEventArgs e) {
			MousePosition = e.Location;//保存鼠标位置
			Event_Mouse( e );//发表事件
		}

		/// <summary>
		/// 获取鼠标所在位置窗口信息
		/// </summary>
		/// <returns></returns>
		public Tuple<IntPtr, StringBuilder, StringBuilder> Get_MousePositionInfo() {
			StringBuilder title = new StringBuilder( 256 );
			StringBuilder className = new StringBuilder( 256 );
			IntPtr formHandle = WindowFromPoint( MousePosition );//得到窗口句柄
			GetWindowText( formHandle, title, title.Capacity );//得到窗口的标题
			GetClassName( formHandle, className, className.Capacity );//得到窗口的类名
			Tuple<IntPtr, StringBuilder, StringBuilder> tup =
				new Tuple<IntPtr, StringBuilder, StringBuilder>( formHandle, title, className );
			return tup;
		}
		#endregion 公有方法

		#region 私有方法

		//设置上一次按下的键,最多保存5条记录
		private void Set_inputRecord(Keys KeyCode) {
			//数组后移
			for (int i = inputRecord.Length - 1; i >= 0; i--) {
				if (i - 1 >= 0) {
					inputRecord[i] = inputRecord[i - 1];
				}
			}
			//设置第一个值为最新值
			inputRecord[0] = KeyCode;
		}

		#endregion 私有方法

		public HotKeyState() {
			//把所有按键加进去,初始化为 false,以免访问不到造成报错
			foreach (Keys item in Enum.GetValues( typeof( Keys ) )) {
				keyStateAll[item] = false;
			}
			//对键值对进行遍历
			//foreach(KeyValuePair<Keys, Boolean> kv in keyStateAll) {
			//	Console.WriteLine("键为：{0}，值为：{1}", kv.Key, kv.Value);
			//}
		}

	}
}
