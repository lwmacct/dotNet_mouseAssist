using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lwm.Win32API {
	public class Win32_API {
		public class InputDevice {
			[DllImport( "User32.dll" )]
			public extern static void SetCursorPos(int x, int y);

			[DllImport( "user32.dll", CharSet = CharSet.Auto )]
			public static extern bool GetCursorPos(out Point pt);

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
			private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtralnfo);

		}



	}
}
