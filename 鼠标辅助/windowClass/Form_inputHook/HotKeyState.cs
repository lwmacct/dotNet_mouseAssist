using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
namespace app {
	/// <summary>
	/// 热键状态
	/// </summary>
	class HotKeyState {
		#region 导入 DLL
		/// <summary>
		/// 获取窗口标题
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="lpString"></param>
		/// <param name="nMaxCount"></param>
		/// <returns></returns>
		[DllImport( "user32", SetLastError = true )]
		private static extern int GetWindowText(
			IntPtr hWnd,//窗口句柄
			StringBuilder lpString,//标题
			int nMaxCount //最大值
		);
		/// <summary>
		/// 获取类的名字
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="lpString"></param>
		/// <param name="nMaxCount"></param>
		/// <returns></returns>
		[DllImport( "user32.dll" )]
		private static extern int GetClassName(
			IntPtr hWnd,//句柄
			StringBuilder lpString, //类名
			int nMaxCount //最大值
		);

		/// <summary>
		/// 根据坐标获取窗口句柄
		/// </summary>
		/// <param name="Point">坐标</param>
		/// <returns></returns>
		[DllImport( "user32" )]
		private static extern IntPtr WindowFromPoint(
			Point Point
		);
		#endregion

		/// <summary>
		/// 按键状态集合
		/// </summary>
		public Dictionary<Keys, Boolean> keyStateAll = new Dictionary<Keys, Boolean>();
		//事件委托
		public delegate void d_KeysEvent(string KeyDown_And_KeyUp, KeyEventArgs key);
		public delegate void d_MouseEvent(MouseEventArgs e);

		//事件事件
		public event d_KeysEvent Event_Keys;
		public event d_MouseEvent Event_Mouse;

		#region 公有变量

		/// <summary>
		/// 按键按下
		/// </summary>
		public const string KeyDown = "KeyDown";
		/// <summary>
		/// 按键弹起
		/// </summary>
		public const string KeyUp = "KeyUp";
		/// <summary>
		/// 输入记录
		/// </summary>
		public Keys[] inputRecord = new Keys[10];

		#endregion
		/// <summary>
		/// 鼠标坐标
		/// </summary>
		private Point MousePosition;
		//设置上一次按下的键,最多保存10条记录
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
		#region 公有方法
		//按下处理
		public void CallBack_KeyDown(object sender, KeyEventArgs key) {
			this.keyStateAll[key.KeyCode] = true;//设置按键状态
			Set_inputRecord( key.KeyCode );

			Event_Keys( KeyDown, key );//发表事件
		}
		//弹起处理
		public void CallBack_KeyUp(object sender, KeyEventArgs key) {
			this.keyStateAll[key.KeyCode] = false;//设置按键状态
			Event_Keys( KeyUp, key );//发表事件
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
