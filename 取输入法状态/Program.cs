using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 取输入法状态 {
	class Program {
		static void Main(string[] args) {
			new Myclass();
			Console.ReadLine(); //等待用户按一个回车

		}

	}

	public class Myclass {
		public IntPtr Handle { get; private set; }

		[DllImport( "user32.dll", EntryPoint = "GetKeyboardLayout" )]
		public static extern ulong GetKeyboardLayout(ulong dwLayout);

		[DllImport( "imm32.dll", EntryPoint = "ImmSimulateHotKey" )]
		public static extern Boolean immsimulatehotkey(
			IntPtr hwnd,
			IntPtr dwhotkeyid
		);

		[DllImport( "imm32.dll", EntryPoint = "ImmIsIME" )]
		public static extern Boolean ImmIsIME(
			ulong hklKeyboardLayout
		);

		public Myclass() {
			foreach (InputLanguage iL in InputLanguage.InstalledInputLanguages)
			{
				Console.WriteLine(iL.LayoutName);
				InputLanguage.CurrentInputLanguage = iL;
				if (iL.LayoutName == "智能ABC")
				{
					InputLanguage.CurrentInputLanguage = iL;
					break;
				}
			}
		}

	}

}
