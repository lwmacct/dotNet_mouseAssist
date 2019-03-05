using Lwm.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwm.CustomForms;

namespace Add_Forms {
	public partial class Form_Main : Form {
		public Form_Main() {
			InitializeComponent();
			(new Form_List()).Show();
		}

		New_Window vEw1=new New_Window(new New_Window.Attr_C());
		private void button1_Click(object sender, EventArgs e) {
			vEw1.Show();
			
		}
	}
}
