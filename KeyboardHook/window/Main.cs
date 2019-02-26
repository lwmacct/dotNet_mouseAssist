using KeyboardHook;
using System;
using System.Windows.Forms;


namespace app {
	public partial class Hk_Form : Form {

		private InputDevice id = new InputDevice();
		public Hk_Form() {
			InitializeComponent();

			id.OnMouseActivity += new MouseEventHandler( hook_MainMouseMove );
			id.OnKeyDown += new KeyEventHandler( hook_MainKeyDown );
			id.OnKeyUp += new KeyEventHandler( hook_MainKeyUp );

			//this.id.OnKeyPress += new KeyPressEventHandler( hook_MainKeyPress );//这个接口有点问题,控制台提示程序错误,但不停止运行


		}
		private void Hk_Form_FormClosed(object sender, FormClosedEventArgs e) {
			id.UnInstallHook();
		}

		private void HookMain_OnKeyDown(object sender, KeyEventArgs e) {
			// MessageBox.Show("33");
			if (e.KeyCode == Keys.Escape && Control.ModifierKeys == Keys.Shift) {
				Close();
			}
		}

		private void start_Click(object sender, EventArgs e) {
			id.InstallHook( 1 );
		}

		private void stop_Click(object sender, EventArgs e) {
			id.UnInstallHook();
		}

		private void stopkeyboard_Click(object sender, EventArgs e) {
			id.InstallHook( 2 );
		}

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
			Console.WriteLine( v );
			LogWrite( "KeyUp " + v );
		}

		private void hook_MainKeyPress(object sender, KeyPressEventArgs e) {
			LogWrite( "KeyPress 	- " + e.KeyChar );
		}


		private void hook_MainMouseMove(object sender, MouseEventArgs e) {
			labelMousePosition.Text = string.Format( "x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta );
			if (e.Clicks > 0) {
				LogWrite( "MouseButton 	- " + e.Button.ToString() );
			}
		}

		private void Hk_Form_Load(object sender, EventArgs e) {

		}
	}
}