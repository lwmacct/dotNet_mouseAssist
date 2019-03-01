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
	public class Activate_Auxiliary_Window {
		#region 枚举

		/// <summary>
		/// 鼠标所在 窗口类型
		/// </summary>
		private enum Window_Type {
			/// <summary>
			/// Microsoft Visual Studio 2017
			/// </summary>
			VisualStudio2017
		}

		#endregion  枚举

		#region 私有变量

		/// <summary>
		/// 按键信息
		/// </summary>
		private readonly InputHook vHks;

		/// <summary>
		/// 辅助窗口列表
		/// </summary>
		private readonly Auxiliary_Window_List vAwl;
		

		#endregion 私有变量

		#region 私有方法

		/// <summary>
		/// 判断窗口类型
		/// </summary>
		/// <returns></returns>
		private Window_Type Determine_Window_Type() {
			if (VisualStudio2017()) {

			}
			return Window_Type.VisualStudio2017;
		}

		/// <summary>
		/// 判断是否为 Visual Studio 2017
		/// </summary>
		/// <returns></returns>
		public Boolean VisualStudio2017() {
			Boolean default_return = false;
			string str = vHks.window_Info_Mouse.title.ToString();
			if (str.Length >= 14) {
				str = str.Substring( str.Length - 14 );
				if (str == "Visual Studio ") {
					default_return = true;
					vAwl.vs2017.Show();
				}
			}
			//如果是 Visual Studio 2017
			if (default_return) {
				vAwl.vs2017.Show();
			}
			//Console.WriteLine( cHks.window_Info_Foreground.title.ToString() );
			return default_return;
		}

		/// <summary>
		/// 判断是否为 PhpStorm
		/// </summary>
		public void PhpStorm() {
			System.Threading.Thread.Sleep( 1 );
			new Assist_PhpStorm( vHks );//加载 phpstorm 辅助类
		}


		#endregion 私有方法

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="cHks"></param>
		/// <param name="cAwl"></param>
		public Activate_Auxiliary_Window(InputHook cHks, Auxiliary_Window_List cAwl) {
			this.vHks = cHks;
			this.vAwl = cAwl;
			Window_Type vWt = Determine_Window_Type();
			switch (vWt) {
				case Window_Type.VisualStudio2017:
					vAwl.vs2017.Show();
					break;
				default:

					break;
			}
			VisualStudio2017();
			//PhpStorm();
		}
		
	}
}
