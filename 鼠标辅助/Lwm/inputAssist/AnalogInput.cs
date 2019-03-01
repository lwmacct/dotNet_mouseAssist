using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
using app;

namespace Lwm.inputAssist {
	/// <summary>
	/// 该类不能模拟输入正文中文会报错
	/// </summary>
	internal class AnalogInput {
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
		/// 方向
		/// </summary>
		public enum Direction {
			Up, Down, Left, Right, Home, End
		}
		/// <summary>
		/// 模拟删除
		/// </summary>
		/// <param name="count">删除次数</param>
		public void Delete(int count) {
			keybd_event( (int)Keys.Back, 0, 2, 0 );//放开删除
			for (int i = 0; i < count; i++) {
				keybd_event( (int)Keys.Back, 0, 0, 0 );//按下删除
			}
			keybd_event( (int)Keys.Back, 0, 2, 0 );//放开删除
		}
		/// <summary>
		/// 光标移动
		/// </summary>
		/// <param name="direction">方向[1,2,3,4]=[上,下,左,右]</param>
		/// <param name="count">移动次数</param>
		public void Move(Direction direction, int count) {
			int keyCode = 0;
			switch (direction) {
				case Direction.Up: keyCode = 38; break;
				case Direction.Down: keyCode = 40; break;
				case Direction.Left: keyCode = 37; break;
				case Direction.Right: keyCode = 39; break;
			}
			keybd_event( (byte)keyCode, 0, 2, 0 );//放开
			for (int i = 0; i < count; i++) {
				keybd_event( (byte)keyCode, 0, 0, 0 );//按下
			}
			keybd_event( (byte)keyCode, 0, 2, 0 );//放开
		}
		/// <summary>
		/// 首尾跳转
		/// </summary>
		/// <param name="direction">方向</param>

		public void HeadTail(Direction direction) {
			int keyCode = 0;
			switch (direction) {
				case Direction.Home: keyCode = 36; break;
				case Direction.End: keyCode = 35; break;
			}
			keybd_event( (byte)keyCode, 0, 2, 0 );//放开
			keybd_event( (byte)keyCode, 0, 0, 0 );//按下
			keybd_event( (byte)keyCode, 0, 2, 0 );//放开
		}

		/// <summary>
		/// 模拟输入
		/// </summary>
		/// <param name="inputStr"></param>
		public void Input(string inputStr) {
			Toggle_Input_State TIS = new Toggle_Input_State();
			TIS.ToEnglish();
			char[] charAll = inputStr.ToCharArray();
			//byte[] byteAll = Encoding.Default.GetBytes( inputStr );
			for (var i = 0; i < charAll.Length; i++) {
				this.CharInput( charAll[i] );
			}
			TIS.Restore();
		}

		private void CharInput(char strChar) {
			keybd_event( 160, 0, 2, 0 );//放开 shift //开始和结尾都要记得放开
										//!@#$%^&*()_+{}|:"<>?
			int[] needShift = new int[] { 33, 64, 35, 36, 37, 94, 38, 42, 40, 41, 95, 43, 123, 125, 124, 58, 34, 60, 62, 63 };
			int[] needShift_true = new int[] { 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 189, 187, 219, 221, 220, 186, 222, 188, 190, 191 };
			//-=[]\;',./
			int[] notNeedShift = new int[] { 45, 61, 91, 93, 92, 59, 39, 44, 46, 47 };
			int[] notNeedShift_true = new int[] { 189, 187, 219, 221, 220, 186, 222, 188, 190, 191 };
			//\n\t空格
			int[] special = new int[] { 10, 9, 32 };
			int[] special_true = new int[] { 13, 9, 32 };
			int i = 0;
			byte to16 = Convert.ToByte( strChar );
			//Console.WriteLine( (int)to16 );
			//return;
			//[0-9]
			if ((int)to16 >= 48 && (int)to16 <= 57) {
				keybd_event( to16, 0, 0, 0 );//放开删除
			} else
			//[A-Z]
			if ((int)to16 >= 65 && (int)to16 <= 90) {
				if (!Console.CapsLock) {
					keybd_event( 160, 0, 0, 0 );//按下 shift 删除
				}
				keybd_event( to16, 0, 0, 0 );//放开删除
			} else
			//[a-z]
			if ((int)to16 >= 97 && (int)to16 <= 122) {
				if (Console.CapsLock) {
					keybd_event( 160, 0, 0, 0 );//按下 shift 删除
				}
				keybd_event( Convert.ToByte( strChar.ToString().ToUpper().ToCharArray()[0] ), 0, 0, 0 );
			} else
			//处理 !@#$%^&*()_+{}|:\"<>?
			if (needShift.Contains( (int)to16 )) {
				for (i = 0; i < needShift.Length; i++) {
					if (needShift[i] == (int)to16) {
						break;
					}
				}
				keybd_event( 160, 0, 0, 0 );//按下 shift 删除
				keybd_event( (byte)needShift_true[i], 0, 0, 0 );
			} else
			if (notNeedShift.Contains( (int)to16 )) {
				for (i = 0; i < notNeedShift.Length; i++) {
					if (notNeedShift[i] == (int)to16) {
						break;
					}
				}
				keybd_event( (byte)notNeedShift_true[i], 0, 0, 0 );//
			} else
			if (special.Contains( (int)to16 )) {
				for (i = 0; i < special.Length; i++) {
					if (special[i] == (int)to16) {
						break;
					}
				}
				keybd_event( (byte)special_true[i], 0, 0, 0 );//
			}
			keybd_event( 160, 0, 2, 0 );//放开 shift //开始和结尾都要记得放开
		}
	}
}
