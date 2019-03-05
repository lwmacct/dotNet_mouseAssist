using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lwm.Window {
	/// <summary>
	/// 空的窗口
	/// </summary>
	public partial class New_Window : Form {
		/// <summary>
		/// 生成窗口所需的配置
		/// </summary>
		/// <returns></returns>
		public class Attr_C {
			/// <summary>
			/// 窗口宽度 默认 512
			/// </summary>
			public int width = 512;

			/// <summary>
			/// 窗口高度 默认 320
			/// </summary>
			public int height = 320;

			/// <summary>
			/// 窗口设计名称 Name
			/// </summary>
			public String Name = "新窗口";

			/// <summary>
			/// 窗口表示文本 Text
			/// </summary>
			public String Text = "新窗口";

			/// <summary>
			/// 显示窗口时初始位置
			/// </summary>
			public FormStartPosition StartPosition = FormStartPosition.CenterScreen;

			/// <summary>
			/// 是否自动自适应控件大小 默认 true
			/// </summary>
			public Boolean autoSize = true;
		}

		public New_Window(Attr_C attr) {
			this.AutoSize = attr.autoSize;
			this.Font = new System.Drawing.Font( "微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
			this.components = new System.ComponentModel.Container();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( attr.width, attr.height );//窗口大小
			this.Name = attr.Name;
			this.Text = attr.Text;
			this.StartPosition = attr.StartPosition;

		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && ( components != null )) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#endregion
	}

}
