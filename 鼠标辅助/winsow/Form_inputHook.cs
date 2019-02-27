using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardHook;
using System.Runtime.InteropServices;

namespace app {

	public partial class Form_inputHook : Form {

		private HotKeyState HKS = new HotKeyState();
		private InputDevice inputDevice = new InputDevice();
		public Form_inputHook() {
			InitializeComponent();
			//把按下和弹起加入热键状态方法,以便更新组合键母键状态
			inputDevice.OnMouseActivity += new MouseEventHandler( HKS.CallBack_MouseMove );
			inputDevice.OnKeyDown += new KeyEventHandler( HKS.CallBack_KeyDown );
			inputDevice.OnKeyUp += new KeyEventHandler( HKS.CallBack_KeyUp );
			HKS.Event_Keys += new HotKeyState.d_KeysEvent( KeyDown_And_KeyUp );
			HKS.Event_Mouse += new HotKeyState.d_MouseEvent( MouseEventHandler );

			//this.inputDevice.OnKeyPress += new KeyPressEventHandler( hook_MainKeyPress );//这个接口有点问题,控制台提示程序错误,但不停止运行
		}

		private void Form_inputHook_Load(object sender, EventArgs e) {/*点击主窗口*/
			button_start.PerformClick();//模拟点击 开始监控 //Button_Click( null, EventArgs.Empty );
										
		}
		/// <summary>
		/// 所有 Button 点击事件 都填这个方法,集中处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Click(object sender, EventArgs e) {
			Button btn = (Button)sender;
			switch (btn.Name) {
				case "button_start"://开始监控
					inputDevice.InstallHook( 1 );
					break;
				case "button_stop"://停止监控
					inputDevice.UnInstallHook();
					break;
				case "button_stopkeyboard"://屏蔽键盘
					inputDevice.InstallHook( 2 );
					break;
				case "button_truncate"://清空按钮
					textBox_resultinfo.Text = "";
					textBox_windowInfo.Text = "";
					break;
				case "button_unitTest"://单元测试
					UnitTest();
					break;
				case "button_setTopTier"://窗口置顶
					if (btn.Text == "窗口置顶") {
						this.TopMost = true;
						btn.Text = "取消置顶";
					} else {
						this.TopMost = false;
						btn.Text = "窗口置顶";
					}

					break;
				default:
					Console.WriteLine( "按钮方法未定义" );
					break;
			}//

		}

		private void UnitTest()
		{
			for (int i = 0; i < HKS.inputRecord.Length; i++)
			{
			 Console.WriteLine(HKS.inputRecord[i]);	
			}
			
		}
		

		//按键事件处理
		public void KeyDown_And_KeyUp(string Sender, KeyEventArgs key) {
			//只有窗口是正常状态才调试输出
			if (WindowState == FormWindowState.Normal) {
				var v = new {
					key.KeyValue,
					key.KeyCode,
					key.Modifiers,
					key.SuppressKeyPress
				};
				LogWrite( Sender + "\t" + v );
				Set_HotKeyState();
			}

			if (key.KeyCode == Keys.RMenu && Sender==HotKeyState.KeyDown) {
				Tuple<IntPtr, StringBuilder, StringBuilder> MousePositionInfo = HKS.Get_MousePositionInfo();
				SetFrom_textBox_windowInfo( MousePositionInfo.ToString() );
			}

		}
		//鼠标事件处理
		public void MouseEventHandler(MouseEventArgs e) {
			//只有窗口是正常状态才调试输出
			if (WindowState == FormWindowState.Normal) {
				label_MousePosition.Text = string.Format( "x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta );
				if (e.Clicks > 0) {
					LogWrite( "MouseButton\t" + e.Button.ToString() );
				}
				//Tuple<IntPtr, StringBuilder, StringBuilder> MousePositionInfo = HKS.Get_MousePositionInfo();
				//SetFrom_textBox_windowInfo( MousePositionInfo.ToString() );
			}
		}

		//按键事件写出数据到文本框
		private void LogWrite(string txt) {
			textBox_resultinfo.AppendText( txt + Environment.NewLine );
			textBox_resultinfo.SelectionStart = textBox_resultinfo.Text.Length;
		}
		//鼠标所在窗口信息
		private void SetFrom_textBox_windowInfo(string txt) {
			textBox_windowInfo.AppendText( txt + Environment.NewLine );
			textBox_windowInfo.SelectionStart = textBox_windowInfo.Text.Length;
		}
		//显示热键母键状态
		private void Set_HotKeyState() {
			lable_state_Alt.Text = "Alt 键状态 " + HKS.keyStateAll[Keys.LMenu];
			lable_state_Ctrl.Text = "Ctrl 键状态 " + HKS.keyStateAll[Keys.LControlKey];
			lable_state_Shift.Text = "Shift 键状态 " + HKS.keyStateAll[Keys.LShiftKey];
		}



	}
}
