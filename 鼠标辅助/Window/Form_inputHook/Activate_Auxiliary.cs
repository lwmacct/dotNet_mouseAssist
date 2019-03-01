using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using App;

namespace Lwm.inputAssist {
	/// <summary>
	/// 激活对应辅助窗口
	/// </summary>
	class Activate_Auxiliary {
		/// <summary>
		/// 按键信息
		/// </summary>
		private readonly InputHook vHks;
		/// <summary>
		/// 辅助窗口列表
		/// </summary>
		private readonly Auxiliary_Window_List vAwl;


		public Activate_Auxiliary(InputHook cHks, Auxiliary_Window_List cAwl) {
			this.vHks = cHks;
			this.vAwl = cAwl;
			VisualStudio2017();
			PhpStorm();
		}
		/// <summary>
		/// 判断前台窗口是否为 Visual Studio
		/// </summary>
		/// <returns></returns>
		public void VisualStudio2017() {
			
			Boolean default_return = false;
			string str = vHks.mouse_Window_Info.title.ToString();
			if (str.Length >= 14) {
				str = str.Substring( str.Length - 14 );
				if (str == "Visual Studio ") {
					default_return = true;
					vAwl.vs2017.Show();
				}
			}
			if (default_return) {
				vAwl.vs2017.Show();
				Console.WriteLine(222);
			}

			//Console.WriteLine( cHks.foregroundWindowInfo.title.ToString() );
		}
		public void PhpStorm() {
			System.Threading.Thread.Sleep( 1 );
			new Assist_PhpStorm( vHks );//加载 phpstorm 辅助类
		}
	}
}
