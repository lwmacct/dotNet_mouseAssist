using System;
using System.Collections;
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
using System.Security.Cryptography.X509Certificates;
using Lwm.inputAssist;
using System.Threading;


namespace App {

	public partial class Form_inputHook : Form {

		/// <summary>
		/// 输入钩子
		/// </summary>
		private InputHook vHks = new InputHook();

		/// <summary>
		/// 视图辅助窗口
		/// </summary>
		private Form_Auxiliary_Window vFwl = new Form_Auxiliary_Window();

		public Form_inputHook() {
			InitializeComponent();
			//init 窗口
			//this.ShowInTaskbar = false;
			//this.WindowState = FormWindowState.Minimized;
			//vFwl.Show();
			// vHks

			vHks.Event_Keys += new InputHook.D_KeysEvent( CallBack_KeyboardEvent );
			vHks.Event_Mouse += new InputHook.D_MouseEvent( CallBack_MouseEvent );
			//辅助窗口列表

			//this.vId.OnKeyPress += new KeyPressEventHandler( hook_MainKeyPress );//这个接口有点问题,控制台提示程序错误,但不停止运行
		}

		/// <summary>
		/// 窗口加载完毕
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
					vHks.Hooks_Install();
					break;
				case "button_stop"://停止监控
					vHks.Hooks_UnLoad();

					break;
				case "button_shield_keyboard"://屏蔽键盘
					vHks.Shield_keyboard();
					break;
				case "button_relieve_keyboard_shield"://解除键盘
					vHks.Relieve_keyboard_Shield();
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

		/// <summary>
		/// 单元测试
		/// </summary>
		private void UnitTest() {

		}

		/// <summary>
		/// 键盘事件处理
		/// </summary>
		/// <param name="Sender">可以忽略</param>
		/// <param name="key">按键信息</param>
		public void CallBack_KeyboardEvent(InputHook vIh, InputHook.Action Sender) {
			vFwl.Auxiliary_Window_Handler( vIh, Sender );//传递给视图辅助窗口

			KeyEventArgs key = vIh.keyboard_Input_Record[0];
			//如果是按弹起键
			if (Sender == InputHook.Action.KeyUp && vHks.is_simulated == false) {//使用多线程进行输入辅助处理,不影响主线程
				new MultiThread_InputAuxiliary( vHks );//开新线程辅助输入

			}

			System.Threading.Thread.Sleep( 1 );//不停不行

			if (WindowState == FormWindowState.Normal) { //只有窗口是正常状态才调试输出
				Show_HotKeyState();//显示状态键
				if (Sender == InputHook.Action.KeyUp) {
					textBox_foregroundWindowInfo.Text = vHks.window_Info_Foreground.ToString(); //显示前台窗口信息
					
					//显示鼠标所在窗口信息(按右侧 Alt 显示)
					if (key.KeyCode == Keys.RMenu && Sender == InputHook.Action.KeyUp) {
						SetFrom_textBox_windowInfo( vHks.window_Info_Mouse.ToString() );
						Console.WriteLine(vHks.window_Info_Foreground.title);
						Console.WriteLine(vHks.window_Info_Foreground.className);
					}
				}
				var v = new {
					key.KeyValue,
					key.KeyCode,
					key.Modifiers,
					key.SuppressKeyPress
				};
				textBox_foregroundWindowInfo.Text = vHks.window_Info_Foreground.ToString();

				LogWrite( Sender + "\t" + v );

			}
		}

		/// <summary>
		/// 鼠标事件处理
		/// </summary>
		/// <param name="e">鼠标信息</param>
		public void CallBack_MouseEvent(InputHook vIh, MouseEventArgs e) {
			vFwl.Auxiliary_Window_Handler( vIh, e );//传递给视图辅助窗口
			vHks.keyStateAll.TryGetValue( Keys.LMenu, out bool is_Press_LAlt );
			//只有窗口是正常状态才调试输出
			if (WindowState == FormWindowState.Normal) {
				label_MousePosition.Text = string.Format( "x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta );
				if (e.Clicks > 0) {
					LogWrite( "MouseButton\t" + e.Button.ToString() );
				}
			}
		}

		/// <summary>
		/// 按键事件写出数据到文本框
		/// </summary>
		/// <param name="txt"></param>
		private void LogWrite(string txt) {
			textBox_resultinfo.AppendText( txt + Environment.NewLine );
			textBox_resultinfo.SelectionStart = textBox_resultinfo.Text.Length;
		}

		/// <summary>
		/// 显示_鼠标所在窗口信息
		/// </summary>
		/// <param name="txt"></param>
		private void SetFrom_textBox_windowInfo(string txt) {
			textBox_windowInfo.AppendText( txt + Environment.NewLine );
			textBox_windowInfo.SelectionStart = textBox_windowInfo.Text.Length;
		}

		/// <summary>
		/// 显示_热键母键状态
		/// </summary>
		private void Show_HotKeyState() {
			lable_state_Alt.Text = "Alt 键状态 " + vHks.keyStateAll[Keys.LMenu];
			lable_state_Ctrl.Text = "Ctrl 键状态 " + vHks.keyStateAll[Keys.LControlKey];
			lable_state_Shift.Text = "Shift 键状态 " + vHks.keyStateAll[Keys.LShiftKey];
		}
	}
}
