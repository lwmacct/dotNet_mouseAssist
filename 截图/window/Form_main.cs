using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwm.ScreenShot;
using Lwm.Md5;
using System.Diagnostics;

namespace App {
	/// <summary>
	/// 2019-3-1 09:44:51
	/// </summary>
	public partial class Form_main : Form {
		public Form_main() {
			InitializeComponent();
			//启动窗口
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.CenterScreen;
			//图像控件
			pictureBox_src.BorderStyle = BorderStyle.FixedSingle;
			pictureBox_cut.BorderStyle = BorderStyle.FixedSingle;
			//控件容器
			panel_inputCoord.BorderStyle = BorderStyle.FixedSingle;
			//坐标输入框内容
			textBox_x.Text = "2414";
			textBox_y.Text = "1411";
			textBox_width.Text = "20";
			textBox_height.Text = "20";

		}

		private void Form_main_Load(object sender, EventArgs e) {

		}

		/// <summary>
		/// 窗口指定区域截图
		/// </summary>
		public void Window_specified_area_screenshot() {
			ScreenCapture SC = new ScreenCapture();

			Image image = SC.CaptureScreen(
				int.Parse( textBox_x.Text ),
				int.Parse( textBox_y.Text ),
				int.Parse( textBox_width.Text ),
				int.Parse( textBox_height.Text )
			);
			Get_Md5 gm = new Get_Md5();
			this.pictureBox_cut.Image = image;
			//07b48a26a5f2a8880e3c7de8352eedfc 英文
			//0aae315c797b865c53fd40393540afea 中文
			Console.WriteLine( gm.Get_imageMd5( image ) );
		}

		private void Button_Click(object sender, EventArgs e) {
			Button obj = (Button)sender;
			switch (obj.Name) {
				case "button_screenshot":
					Window_specified_area_screenshot();
					break;
				case "button_unitTest":
					new UnitTest();
					break;
			}
		}
		private class UnitTest {
			public void StackTrace_I() {
				StackTrace st = new StackTrace( new StackFrame( true ) );
				StackFrame sf = st.GetFrame( 0 );
				//文件位置
				Console.WriteLine( "AT:{0}文件-{1}方法-{2}行-{3}", sf.GetFileName(), sf.GetMethod().Name, sf.GetFileLineNumber(), sf.GetFileColumnNumber() );
			}
			public void UnitTes() {
				StackTrace_I();
			}

		}


	}
}