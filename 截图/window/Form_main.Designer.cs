namespace App {
	partial class Form_main {
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.button_screenshot = new System.Windows.Forms.Button();
			this.pictureBox_src = new System.Windows.Forms.PictureBox();
			this.pictureBox_cut = new System.Windows.Forms.PictureBox();
			this.panel_inputCoord = new System.Windows.Forms.Panel();
			this.textBox_height = new System.Windows.Forms.TextBox();
			this.textBox_x = new System.Windows.Forms.TextBox();
			this.textBox_width = new System.Windows.Forms.TextBox();
			this.label_hint_y = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label_hint_x = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_y = new System.Windows.Forms.TextBox();
			this.button_unitTest = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_src)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_cut)).BeginInit();
			this.panel_inputCoord.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_screenshot
			// 
			this.button_screenshot.Location = new System.Drawing.Point(499, 298);
			this.button_screenshot.Name = "button_screenshot";
			this.button_screenshot.Size = new System.Drawing.Size(124, 47);
			this.button_screenshot.TabIndex = 4;
			this.button_screenshot.Text = "截取坐标图";
			this.button_screenshot.UseVisualStyleBackColor = true;
			this.button_screenshot.Click += new System.EventHandler(this.Button_Click);
			// 
			// pictureBox_src
			// 
			this.pictureBox_src.Location = new System.Drawing.Point(12, 12);
			this.pictureBox_src.Name = "pictureBox_src";
			this.pictureBox_src.Size = new System.Drawing.Size(481, 215);
			this.pictureBox_src.TabIndex = 5;
			this.pictureBox_src.TabStop = false;
			// 
			// pictureBox_cut
			// 
			this.pictureBox_cut.Location = new System.Drawing.Point(499, 12);
			this.pictureBox_cut.Name = "pictureBox_cut";
			this.pictureBox_cut.Size = new System.Drawing.Size(289, 215);
			this.pictureBox_cut.TabIndex = 6;
			this.pictureBox_cut.TabStop = false;
			// 
			// panel_inputCoord
			// 
			this.panel_inputCoord.Controls.Add(this.textBox_height);
			this.panel_inputCoord.Controls.Add(this.textBox_x);
			this.panel_inputCoord.Controls.Add(this.textBox_width);
			this.panel_inputCoord.Controls.Add(this.label_hint_y);
			this.panel_inputCoord.Controls.Add(this.label1);
			this.panel_inputCoord.Controls.Add(this.label_hint_x);
			this.panel_inputCoord.Controls.Add(this.label2);
			this.panel_inputCoord.Controls.Add(this.textBox_y);
			this.panel_inputCoord.Location = new System.Drawing.Point(499, 233);
			this.panel_inputCoord.Name = "panel_inputCoord";
			this.panel_inputCoord.Padding = new System.Windows.Forms.Padding(3);
			this.panel_inputCoord.Size = new System.Drawing.Size(289, 59);
			this.panel_inputCoord.TabIndex = 7;
			// 
			// textBox_height
			// 
			this.textBox_height.Location = new System.Drawing.Point(209, 27);
			this.textBox_height.Name = "textBox_height";
			this.textBox_height.Size = new System.Drawing.Size(68, 21);
			this.textBox_height.TabIndex = 15;
			// 
			// textBox_x
			// 
			this.textBox_x.Location = new System.Drawing.Point(87, 6);
			this.textBox_x.Name = "textBox_x";
			this.textBox_x.Size = new System.Drawing.Size(68, 21);
			this.textBox_x.TabIndex = 11;
			// 
			// textBox_width
			// 
			this.textBox_width.Location = new System.Drawing.Point(209, 6);
			this.textBox_width.Name = "textBox_width";
			this.textBox_width.Size = new System.Drawing.Size(68, 21);
			this.textBox_width.TabIndex = 14;
			// 
			// label_hint_y
			// 
			this.label_hint_y.AutoSize = true;
			this.label_hint_y.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_hint_y.Location = new System.Drawing.Point(7, 27);
			this.label_hint_y.Name = "label_hint_y";
			this.label_hint_y.Size = new System.Drawing.Size(74, 21);
			this.label_hint_y.TabIndex = 8;
			this.label_hint_y.Text = "垂直坐标";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(161, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 21);
			this.label1.TabIndex = 13;
			this.label1.Text = "高度";
			// 
			// label_hint_x
			// 
			this.label_hint_x.AutoSize = true;
			this.label_hint_x.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_hint_x.Location = new System.Drawing.Point(7, 6);
			this.label_hint_x.Name = "label_hint_x";
			this.label_hint_x.Size = new System.Drawing.Size(74, 21);
			this.label_hint_x.TabIndex = 9;
			this.label_hint_x.Text = "水平坐标";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(161, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 21);
			this.label2.TabIndex = 12;
			this.label2.Text = "宽度";
			// 
			// textBox_y
			// 
			this.textBox_y.Location = new System.Drawing.Point(87, 27);
			this.textBox_y.Name = "textBox_y";
			this.textBox_y.Size = new System.Drawing.Size(68, 21);
			this.textBox_y.TabIndex = 10;
			// 
			// button_unitTest
			// 
			this.button_unitTest.Location = new System.Drawing.Point(664, 298);
			this.button_unitTest.Name = "button_unitTest";
			this.button_unitTest.Size = new System.Drawing.Size(124, 47);
			this.button_unitTest.TabIndex = 8;
			this.button_unitTest.Text = "单元测试";
			this.button_unitTest.UseVisualStyleBackColor = true;
			this.button_unitTest.Click += new System.EventHandler(this.Button_Click);
			// 
			// Form_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 496);
			this.Controls.Add(this.button_unitTest);
			this.Controls.Add(this.panel_inputCoord);
			this.Controls.Add(this.pictureBox_cut);
			this.Controls.Add(this.pictureBox_src);
			this.Controls.Add(this.button_screenshot);
			this.Name = "Form_main";
			this.Text = "程序入口";
			this.Load += new System.EventHandler(this.Form_main_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_src)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_cut)).EndInit();
			this.panel_inputCoord.ResumeLayout(false);
			this.panel_inputCoord.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button_screenshot;
		private System.Windows.Forms.PictureBox pictureBox_src;
		private System.Windows.Forms.PictureBox pictureBox_cut;
		private System.Windows.Forms.Panel panel_inputCoord;
		private System.Windows.Forms.TextBox textBox_height;
		private System.Windows.Forms.TextBox textBox_x;
		private System.Windows.Forms.TextBox textBox_width;
		private System.Windows.Forms.Label label_hint_y;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label_hint_x;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_y;
		private System.Windows.Forms.Button button_unitTest;
	}
}

