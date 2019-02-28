using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using app;
using System.Threading;

namespace inputAssist {
	class Assist_PhpStorm {
		public Assist_PhpStorm(HotKeyState hKS) {
			//Console.WriteLine(DateTime.Now.ToString());
			this.hKS = hKS;
			if (!this.Is_phpstorm()) return;//判断前台窗口是否为phpstorm 如果不是就什么也不干了
			this.Get_editFileType();
			switch (this.editFileType) {
				case "PHP":
					InputProcess_php();
					break;
			}
		}

		/// <summary>
		/// php文件输入处理
		/// </summary>
		public void InputProcess_php() {
			AnalogInput AI = new AnalogInput();
			//[,][.]
			if (hKS.inputRecord[0] == Keys.OemPeriod && hKS.inputRecord[1] == Keys.Oemcomma) {//如果上一次按下的是逗号
				AI.Delete( 2 );
				AI.Input( "$v->" );
			} else
			//[/][.]
			if (hKS.inputRecord[0] == Keys.OemPeriod && hKS.inputRecord[1] == Keys.OemQuestion) {
				AI.Delete( 2 );
				AI.Input( "$this->" );
			}
			//[v][=]
			if (hKS.inputRecord[0] == Keys.Oemplus && hKS.inputRecord[1] == Keys.V) {//如果上一次按下的是逗号
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

			//KeyDown	{ KeyValue = 8, KeyCode = Back, Modifiers = None, SuppressKeyPress = False }
			//Console.WriteLine( hKS.inputRecord[1] );
		}

		/// <summary>
		/// 文件类型
		/// </summary>
		private enum FileType {
			php, html, js
		}
		/// <summary>
		/// 正在编辑的文件类型
		/// </summary>
		private string editFileType;
		/// <summary>
		/// 按键信息
		/// </summary>
		private readonly HotKeyState hKS;


		/// <summary>
		/// 判断前台窗口是否为phpstorm
		/// </summary>
		/// <returns></returns>
		public Boolean Is_phpstorm() {
			Boolean default_return = false;
			string str = hKS.foregroundWindowInfo.title.ToString();
			str = str.Substring( str.Length - 8 );
			if (str == "PhpStorm") {
				default_return = true;
			}
			//Console.WriteLine( hKS.foregroundWindowInfo.title.ToString() );
			return default_return;
		}
		/// <summary>
		/// 获取并设置正在编辑的文件类型
		/// </summary>
		public void Get_editFileType() {
			//remove-repetition2 [Y:\myFile\GitHub\webProject\remove-repetition2] - ...\src\unitTest\test.php [remove-repetition2] - PhpStorm
			string title = hKS.foregroundWindowInfo.title.ToString();
			string[] titleSplit = title.Split( new char[] { '\\' } );
			Regex reg = new Regex( "(.*?)\\.(.*?)\\s\\[" ); //(.*?)\.(.*?)\s\[
			Match match = reg.Match( titleSplit[titleSplit.Length - 1] );
			this.editFileType = match.Groups[2].Value.ToUpper();
		}
	}
}
