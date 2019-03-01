using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App {
	/// <summary>
	/// 窗口类表类,有可能会激活的窗口存在这里,这些窗口生命周期都很短
	/// </summary>
	public class Auxiliary_Window_List {
		public Form_Auxiliary_vs2017 vs2017;

		public Auxiliary_Window_List() {
			vs2017 = new Form_Auxiliary_vs2017();
		}
	}
}
