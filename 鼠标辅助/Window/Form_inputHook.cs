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
using Lwm.inputAssist;
using System.Threading;


namespace App {

	public partial class Form_inputHook : Form {
		/// <summary>
		/// //输入设备
		/// </summary>
		private InputDevice vId = new InputDevice();
		/// <summary>
		/// 输入钩子
		/// </summary>
		private InputHook vHks = new InputHook();
		/// <summary>
		/// 有可能弹出的辅助窗口列表
		/// </summary>
		Auxiliary_Window_List vAwl = new Auxiliary_Window_List();
		public Form_inputHook() {
			InitializeComponent();

			#region init 窗口
			//this.ShowInTaskbar = false;
			//this.WindowState = FormWindowState.Minimized;
			#endregion
			//把按下和弹起加入热键状态方法,以便更新组合键母键状态
			vId.OnMouseActivity += new MouseEventHandler( vHks.CallBack_MouseMove );
			vId.OnKeyDown += new KeyEventHandler( vHks.CallBack_KeyDown );
			vId.OnKeyUp += new KeyEventHandler( vHks.CallBack_KeyUp );
			vHks.Event_Keys += new InputHook.d_KeysEvent( KeyDown_And_KeyUp );
			vHks.Event_Mouse += new InputHook.d_MouseEvent( MouseEventHandler );
			//辅助窗口列表

			//this.vId.OnKeyPress += new KeyPressEventHandler( hook_MainKeyPress );//这个接口有点问题,控制台提示程序错误,但不停止运行

		}

		/// <summary>
		/// 初始化控件属性
		/// </summary>

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
					vId.InstallHook( 1 );
					break;
				case "button_stop"://停止监控
					vId.UnInstallHook();
					break;
				case "button_stopkeyboard"://屏蔽键盘
					vId.InstallHook( 2 );
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
			}
		}
		private void UnitTest() {


		}
		/// <summary>
		/// 键盘事件处理
		/// </summary>
		/// <param name="Sender">可以忽略</param>
		/// <param name="key">按键信息</param>
		public void KeyDown_And_KeyUp(InputHook.Em Sender, KeyEventArgs key) {
			if (Sender == InputHook.Em.KeyUp && vHks.is_simulated == false) {//使用多线程进行输入辅助处理,不影响主线程
				new MultiThread_InputAuxiliary( vHks );
			}
			System.Threading.Thread.Sleep( 1 );//不加不行
			if (WindowState == FormWindowState.Normal) { //只有窗口是正常状态才调试输出
				textBox_foregroundWindowInfo.Text = vHks.foregroundWindowInfo.MytoString();
				Show_HotKeyState();//显示状态键
				textBox_foregroundWindowInfo.Text = vHks.foregroundWindowInfo.MytoString(); //显示前台窗口信息
																							//显示鼠标所在窗口信息(按右侧 Alt 显示)
				if (key.KeyCode == Keys.RMenu && Sender == InputHook.Em.KeyUp) {
					SetFrom_textBox_windowInfo( vHks.mouse_Window_Info.MytoString() );

				}
				var v = new {
					key.KeyValue,
					key.KeyCode,
					key.Modifiers,
					key.SuppressKeyPress
				};
				textBox_foregroundWindowInfo.Text = vHks.foregroundWindowInfo.MytoString();

				LogWrite( Sender + "\t" + v );
			}
		}
		/// <summary>
		/// 鼠标事件处理
		/// </summary>
		/// <param name="e">鼠标信息</param>
		public void MouseEventHandler(MouseEventArgs e) {
			if (e.Delta != 0) {
				new Activate_Auxiliary( vHks, vAwl );
			}
			//只有窗口是正常状态才调试输出
			if (WindowState == FormWindowState.Normal) {
				label_MousePosition.Text = string.Format( "x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta );
				if (e.Clicks > 0) {
					LogWrite( "MouseButton\t" + e.Button.ToString() );
				}
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
		private void Show_HotKeyState() {
			lable_state_Alt.Text = "Alt 键状态 " + vHks.keyStateAll[Keys.LMenu];
			lable_state_Ctrl.Text = "Ctrl 键状态 " + vHks.keyStateAll[Keys.LControlKey];
			lable_state_Shift.Text = "Shift 键状态 " + vHks.keyStateAll[Keys.LShiftKey];
		}



	}
}
