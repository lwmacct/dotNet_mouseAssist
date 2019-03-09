using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lwm.DLL {

	/// <summary>
	/// win32API
	/// </summary>
	public class WinAPI {
		public enum Const {

			/// <summary>
			/// 按下鼠标左键
			/// </summary>
			WM_LBUTTONDOWN = 513,

			/// <summary>
			/// 弹起鼠标左键
			/// </summary>
			WM_LBUTTONUP = 514,

			/// <summary>
			/// 鼠标左键
			/// </summary>
			MK_LBUTTON = 1,

			/// <summary>
			/// 鼠标右键
			/// </summary>
			MK_RBUTTON = 2,
		}
		/// <summary>
		/// 输入设备
		/// </summary>
		public class InputDevice {


			private const int ddd = 333;
			[StructLayout( LayoutKind.Sequential )]
			public struct GuiThreadInfo {
				public int cbSize;
				public int flags;

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
				public Rectangle rectCaret;
			}

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
			public int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtralnfo) {
				return _mouse_event( dwFlags, dx, dy, dwData, dwExtralnfo );
			}
			[DllImport( "user32.dll", EntryPoint = "mouse_event", CharSet = CharSet.Auto )]
			private static extern int _mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtralnfo);

			/// <summary>
			/// 模拟键盘的方法
			/// </summary>
			/// <param name="bVk" >按键的虚拟键值</param>
			/// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
			/// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
			/// <param name= "dwExtraInfo">一般设置为0</param>
			public void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo) {
				_keybd_event( bVk, bScan, dwFlags, dwExtraInfo );
			}
			[DllImport( "user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto )]
			private static extern void _keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);



			/// <summary>
			/// 设置鼠标光标位置
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			[DllImport( "User32.dll", EntryPoint = "SetCursorPos", CharSet = CharSet.Auto )]
			private extern static void _SetCursorPos(int x, int y);

		}

		/// <summary>
		/// 窗口
		/// </summary>
		public class Window {

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
				public Rectangle rectCaret;
			}

			/// <summary>
			/// 取得顶级窗口
			/// </summary>
			/// https://baike.baidu.com/item/GetAncestor/9391878?fr=aladdin
			/// <param name="hWnd"></param>
			/// <param name="gaFlags"></param>
			/// <returns></returns>
			public IntPtr GetAncestor(IntPtr hWnd, int gaFlags) {
				return _GetAncestor( hWnd, gaFlags );


			}
			[DllImport( "user32.dll", EntryPoint = "GetAncestor", CharSet = CharSet.Auto )]
			private static extern IntPtr _GetAncestor(IntPtr hWnd, int gaFlags);

			/// <summary>
			/// 激活指定窗口(无论是否最小化) 
			/// 想要将最小化的窗口还原并使其在屏幕最前，只要向fAltTab参数传入TRUE就可以了。
			/// </summary>
			/// <param name="hWnd">要激活的窗口句柄</param>
			/// <param name="fAltTab">是否使最小化的窗口还原</param>
			/// <returns></returns>
			public void SwitchToThisWindow(IntPtr hWnd, Boolean fAltTab) {
				_SwitchToThisWindow( hWnd, fAltTab );
			}
			[DllImport( "user32.dll", EntryPoint = "SwitchToThisWindow", CharSet = CharSet.Auto )]
			private static extern void _SwitchToThisWindow(IntPtr hWnd, Boolean fAltTab);//设定焦点




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

			private static extern int GetClientRect(IntPtr hWnd, out Rectangle lpRect);

			/// <summary>
			/// 该函数返回指定窗口的边框矩形的尺寸。该尺寸以相对于屏幕坐标左上角的屏幕坐标给出。
			/// 需要关键字 out
			/// </summary>
			/// 使用示例 GetWindowRect ( (IntPtr)66778, out ipRect )
			/// <param name="hWnd">窗口句柄</param>
			/// <param name="lpRect">是一个指针，指向一个RECT类型的rectangle结构。该结构有四个LONG字段,分别为left、top、right和bottom。GetClientRect将这四个字段设定为窗口显示区域的尺寸。left和top字段通常设定为0。right和bottom字段设定为显示区域的宽度和高度（像素点数）。 也可以是一个CRect对象指针。CRect对象有多个参数，与RECT用法相同</param>
			/// <returns>如果函数成功，返回一个非零值。</returns>
			[DllImport( "user32.dll" )]

			private static extern int GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

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


			[DllImport( "User32.dll" )]
			private extern static void SetCursorPos(int x, int y);

			[DllImport( "user32.dll", CharSet = CharSet.Auto )]
			private static extern bool GetCursorPos(out Point pt);


		}

		/// <summary>
		/// 信息
		/// </summary>
		public class Message {

			/// <summary>
			/// 将两个16位的数联合成一个的32位的LONG型的数
			/// </summary>
			/// <param name="value1"></param>
			/// <param name="value2"></param>
			/// <returns></returns>
			public long MAKELONG(short value1, short value2) {
				short[] to = new[] { value1, value2 };
				//Array.Sort( to );
				//Array.Reverse( to );
				//short a = 50;
				//short b = 30;
				long c = to[1] * 65536 + (ushort)to[0];
				//int c = a * 65536 + (ushort)b;
				return c;
			}

			/// <summary>
			/// 该函数将一个消息放入（寄送）到与指定窗口创建的线程相联系消息队列里，
			///		不等待线程处理消息就返回。
			/// 消息队列里的消息通过调用GetMessage和PeekMessage取得。
			/// </summary>
			/// <param name="hWnd">信息发往的窗口的句柄</param>
			/// <param name="Msg">消息ID</param>
			/// <param name="wParam">参数1</param>
			/// <param name="lParam"> 参数2</param>
			/// <returns></returns>
			public int PostMessage(IntPtr hWnd, int Msg, long wParam, long lParam) {
				return _PostMessage( hWnd, Msg, wParam, lParam );
			}
			[DllImport( "User32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto )]
			private static extern int _PostMessage(IntPtr hWnd, int Msg, long wParam, long lParam);

		}




	}
}
