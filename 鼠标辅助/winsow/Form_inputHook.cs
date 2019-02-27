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

namespace app {
	public partial class Form_inputHook : Form {
		private InputDevice id = new InputDevice();
		private Hoock_CallBack HC = new Hoock_CallBack();

		public Form_inputHook() {
			InitializeComponent();
			id.OnMouseActivity += new MouseEventHandler( hook_MainMouseMove );
			id.OnKeyDown += new KeyEventHandler( hook_MainKeyDown );
			id.OnKeyUp += new KeyEventHandler( hook_MainKeyUp );
			//this.id.OnKeyPress += new KeyPressEventHandler( hook_MainKeyPress );//这个接口有点问题,控制台提示程序错误,但不停止运行
		}
		/// <summary>
		/// 所有 Button 点击事件 都填这个方法,集中处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Click(object sender, EventArgs e) {
			Button btn = (Button)sender;
			switch (btn.Name) {
				case "button_start":
					id.InstallHook( 1 );
					break;
				case "button_stop":
					id.UnInstallHook();
					break;
				case "button_stopkeyboard":
					id.InstallHook( 2 );
					break;
				default:
					Console.WriteLine( "按钮方法未定义" );
					break;
			}

		}

		//写出数据
		private void LogWrite(string txt) {
			resultinfo.AppendText( txt + Environment.NewLine );
			resultinfo.SelectionStart = resultinfo.Text.Length;
		}
		//按下处理
		private void hook_MainKeyDown(object sender, KeyEventArgs e) {
			var v = new {
				e.KeyCode,
				e.KeyValue,
				e.Alt,
				e.Control,
				e.Handled,
				e.KeyData,
				e.Modifiers,
				e.Shift,
				e.SuppressKeyPress
			};
			Console.WriteLine( v );
			LogWrite( "KeyDown " + v );
		}
		//弹起处理
		private void hook_MainKeyUp(object sender, KeyEventArgs e) {
			var v = new {
				e.KeyCode,
				e.KeyValue,
				e.Alt,
				e.Control,
				e.Handled,
				e.KeyData,
				e.Modifiers,
				e.Shift,
				e.SuppressKeyPress
			};
			Console.WriteLine( sender );
			LogWrite( "KeyUp " + v );
		}
		//这个事件不好用
		private void hook_MainKeyPress(object sender, KeyPressEventArgs e) {
			LogWrite( "KeyPress 	- " + e.KeyChar );
		}

		//鼠标移动处理
		private void hook_MainMouseMove(object sender, MouseEventArgs e) {
			label_MousePosition.Text = string.Format( "x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta );
			if (e.Clicks > 0) {
				LogWrite( "MouseButton 	- " + e.Button.ToString() );
			}
		}

		private void Form_inputHook_Load(object sender, EventArgs e) {

		}


	}
}
