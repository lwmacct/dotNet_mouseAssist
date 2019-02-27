using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app {
	public partial class Main : Form
	{
		private Form_hotKeyReg fhkr = new Form_hotKeyReg();//new 一个热键注册窗口
		private Form_inputHook fih = new Form_inputHook();//new 一个输入设备钩子
		public Main() {
			InitializeComponent();
			fhkr.Show();//显示出来
			fih.Show();
		}

		private void Main_Load(object sender, EventArgs e) {
			
		}
	}
}
