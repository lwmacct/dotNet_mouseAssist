using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lwm.ScreenShot;
using Lwm.Md5;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lwm.inputAssist {
	/// <summary>
	/// 切换到英文状态
	/// </summary>
	public class Toggle_Input_State {
		/// <summary>
		/// 模拟键盘的方法
		/// </summary>
		/// <param name="bVk" >按键的虚拟键值</param>
		/// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
		/// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
		/// <param name= "dwExtraInfo">一般设置为0</param>
		[DllImport( "user32.dll" )]
		public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

		/// <summary>
		/// 是否切换过输入状态
		/// </summary>
		public Boolean is_Switch_Over = false;
		/// <summary>
		/// 调整到输入法到英文状态,返回是否被切换过
		/// </summary>
		public void ToEnglish() {
			Boolean is_English = false;
			ScreenCapture SC = new ScreenCapture();

			Image image = SC.CaptureScreen( 2414, 1411, 20, 20 );//抓取屏幕(层叠的窗口)
			Get_Md5 gm = new Get_Md5();
			string md5 = gm.Get_imageMd5( image );
			//07b48a26a5f2a8880e3c7de8352eedfc 英文
			//0aae315c797b865c53fd40393540afea 中文
			switch (md5) {
				case "07b48a26a5f2a8880e3c7de8352eedfc":
					is_English = true;
					break;
				default:
					break;
			}
			if (is_English == false) {
				keybd_event( (byte)Keys.RShiftKey, 0, 0, 0 );//放开删除
				keybd_event( (byte)Keys.RShiftKey, 0, 2, 0 );//放开删除
				this.is_Switch_Over = true;
			}
		}
		/// <summary>
		/// 还原状态
		/// </summary>
		public void Restore() {
			if (is_Switch_Over) {
				keybd_event( (byte)Keys.RShiftKey, 0, 0, 0 );//放开删除
				keybd_event( (byte)Keys.RShiftKey, 0, 2, 0 );//放开删除
				is_Switch_Over = true;
			}
		}

	}
}
