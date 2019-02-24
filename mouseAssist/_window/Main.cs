using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mouseAssist {
	public partial class Main : Form {
		HotkeyReg hotkeyReg = new HotkeyReg();
		public Main() {
			InitializeComponent();

		}

		#region 控件方法


		private void Main_Load(object sender, EventArgs e) {
			hotkeyReg.Show();
			//hotkeyReg.Hide();
			//this.Hide();
		}
		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e) {
			//关闭窗口产考 https://www.cnblogs.com/testsec/p/6142752.html
			Application.Exit();
		}
		#endregion 控件方法

	}
}
