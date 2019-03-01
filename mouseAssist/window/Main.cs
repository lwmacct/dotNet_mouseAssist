using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App {
	public partial class Main : Form {
		Form_hotKeyReg fhkr = new Form_hotKeyReg();//new 一个热键注册窗口
		public Main() {
			InitializeComponent();
			fhkr.Show();//显示
			//hotkeyReg.Hide();
			//this.Hide();
		}

		#region 控件方法
		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e) {
			//关闭窗口产考 https://www.cnblogs.com/testsec/p/6142752.html
			Application.Exit();
		}
		#endregion 控件方法

	}
}
