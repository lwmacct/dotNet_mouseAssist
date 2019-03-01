using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;

namespace Lwm.inputAssist {
	/// <summary>
	/// 辅助 PhpStorm 编码时的输入
	/// </summary>
	public class Assist_PhpStorm {
		public Assist_PhpStorm(InputHook hKS) {
			//Console.WriteLine(DateTime.Now.ToString());
			this.hKS = hKS;
			if (!this.Is_phpstorm()) return;//判断前台窗口是否为phpstorm 如果不是就什么也不干了
			this.Get_editFileType();//获取文件类型
			switch (this.editFileType) {
				case "PHP":
					InputProcess_php();//执行php输入辅助
					break;
			}
		}

		/// <summary>
		/// 正在编辑的文件类型
		/// </summary>
		private string editFileType;

		/// <summary>
		/// 按键信息
		/// </summary>
		private readonly InputHook hKS;

		/// <summary>
		/// php文件输入处理
		/// </summary>
		public void InputProcess_php() {
			Boolean has_triggered = false;
			AnalogInput AI = new AnalogInput();
			//[,][.]
			if (hKS.inputRecord[0] == Keys.OemPeriod && hKS.inputRecord[1] == Keys.Oemcomma) {//如果上一次按下的是逗号
				has_triggered = true;
				hKS.is_simulated = true;
				AI.Delete( 2 );
				AI.Input( "$v->" );

			}
			//[.][,]
			if (hKS.inputRecord[0] == Keys.Oemcomma && hKS.inputRecord[1] == Keys.OemPeriod) {
				has_triggered = true;
				hKS.is_simulated = true;
				AI.Delete( 2 );
				AI.Input( "$this->" );
			}
			//[v][=]
			if (hKS.inputRecord[0] == Keys.Oemplus && hKS.inputRecord[1] == Keys.V) {
				has_triggered = true;
				hKS.is_simulated = true;
				AI.Delete( 2 );
				AI.Input( "$v = new class( get_defined_vars() ) { };" );
				AI.Move( AnalogInput.Direction.Left, 2 );
				AI.Input( "\n" );
				AI.Input( "public function __construct(&$arg) { }" );
				AI.Move( AnalogInput.Direction.Left, 2 );
				AI.Input( "\n" );
				AI.Input( "$this->arg = &$arg;" );
				AI.Move( AnalogInput.Direction.Up, 1 );
				AI.HeadTail( AnalogInput.Direction.Home );
				AI.Input( "\n" );
				AI.Move( AnalogInput.Direction.Up, 1 );
				AI.Input( "public $arg;//param\n" );
				AI.Input( "" );
				AI.Input( "public $tEach,$tI,$tKey,$tValue;//Temp variable" );
			}
			//[Alt][Alt]
			if (hKS.inputRecord[0] == Keys.LMenu && hKS.inputRecord[1] == Keys.LMenu) {
				has_triggered = true;
				hKS.is_simulated = true;
				AI.Input( "console_log(  );" );
				AI.Move( AnalogInput.Direction.Left, 2 );
			}

			if (has_triggered) { //如果辅助输入已被触发就重置本次输入为ESC,避免下一个键被当做检测键
				hKS.inputRecord[0] = Keys.Escape;
			}
			hKS.is_simulated = false;//还原为未在模拟输入
		}

		/// <summary>
		/// 判断前台窗口是否为phpstorm
		/// </summary>
		/// <returns></returns>
		public Boolean Is_phpstorm() {
			Boolean default_return = false;
			string str = hKS.window_Info_Foreground.title.ToString();
			if (str.Length >= 8) {
				str = str.Substring( str.Length - 8 );
				if (str == "PhpStorm") {
					default_return = true;
				}
			}

			//Console.WriteLine( hKS.window_Info_Foreground.title.ToString() );
			return default_return;
		}

		/// <summary>
		/// 获取并设置正在编辑的文件类型
		/// </summary>
		public void Get_editFileType() {
			//remove-repetition2 [Y:\myFile\GitHub\webProject\remove-repetition2] - ...\src\unitTest\test.php [remove-repetition2] - PhpStorm
			string title = hKS.window_Info_Foreground.title.ToString();
			string[] titleSplit = title.Split( new char[] { '\\' } );
			Regex reg = new Regex( "(.*?)\\.(.*?)\\s\\[" ); //(.*?)\.(.*?)\s\[
			Match match = reg.Match( titleSplit[titleSplit.Length - 1] );
			this.editFileType = match.Groups[2].Value.ToUpper();
		}
	}
}
