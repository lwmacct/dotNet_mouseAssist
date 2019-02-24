using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using KeyboardHook;


namespace app {
	public partial class Hk_Form : Form {
		private InputDevice id = new InputDevice();

		public Hk_Form() {
			InitializeComponent();

			this.id.OnMouseActivity += new MouseEventHandler( hook_MainMouseMove );
			this.id.OnKeyDown += new KeyEventHandler( hook_MainKeyDown );
			this.id.OnKeyPress += new KeyPressEventHandler( hook_MainKeyPress );
			this.id.OnKeyUp += new KeyEventHandler( hook_MainKeyUp );

		}
		private void Hk_Form_FormClosed(object sender, FormClosedEventArgs e) {
			this.id.UnInstallHook();
		}
		private void HookMain_OnKeyDown(object sender, KeyEventArgs e) {
			// MessageBox.Show("33");
			if (e.KeyCode == Keys.Escape && Control.ModifierKeys == Keys.Shift) {
				this.Close();
			}
		}

		private void start_Click(object sender, EventArgs e) {
			id.InstallHook( "1" );
		}

		private void stop_Click(object sender, EventArgs e) {
			this.id.UnInstallHook();
		}

		private void stopkeyboard_Click(object sender, EventArgs e) {
			id.InstallHook( "2" );
		}

		private void LogWrite(string txt) {

			this.resultinfo.AppendText( txt + Environment.NewLine );
			this.resultinfo.SelectionStart = this.resultinfo.Text.Length;
		}

		private void hook_MainKeyDown(object sender, KeyEventArgs e) {
			LogWrite( "KeyDown 	- " + e.KeyData.ToString() );
		}

		private void hook_MainKeyPress(object sender, KeyPressEventArgs e) {
			LogWrite( "KeyPress 	- " + e.KeyChar );
		}

		private void hook_MainKeyUp(object sender, KeyEventArgs e) {
			LogWrite( "KeyUp 		- " + e.KeyData.ToString() );
		}

		private void hook_MainMouseMove(object sender, MouseEventArgs e) {
			labelMousePosition.Text = String.Format( "x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta );
			if (e.Clicks > 0) LogWrite( "MouseButton 	- " + e.Button.ToString() );
		}


	}
}