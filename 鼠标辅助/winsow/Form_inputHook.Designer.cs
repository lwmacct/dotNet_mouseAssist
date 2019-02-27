namespace app {
	partial class Form_inputHook {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && ( components != null )) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label_MousePosition = new System.Windows.Forms.Label();
			this.button_stopkeyboard = new System.Windows.Forms.Button();
			this.resultinfo = new System.Windows.Forms.TextBox();
			this.button__stop = new System.Windows.Forms.Button();
			this.button_start = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label_MousePosition
			// 
			this.label_MousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label_MousePosition.AutoSize = true;
			this.label_MousePosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_MousePosition.Location = new System.Drawing.Point(543, 34);
			this.label_MousePosition.Name = "label_MousePosition";
			this.label_MousePosition.Size = new System.Drawing.Size(127, 14);
			this.label_MousePosition.TabIndex = 9;
			this.label_MousePosition.Text = "移动鼠标以便查看效果";
			// 
			// button_stopkeyboard
			// 
			this.button_stopkeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_stopkeyboard.Location = new System.Drawing.Point(433, 25);
			this.button_stopkeyboard.Name = "button_stopkeyboard";
			this.button_stopkeyboard.Size = new System.Drawing.Size(75, 23);
			this.button_stopkeyboard.TabIndex = 8;
			this.button_stopkeyboard.Text = "屏蔽键盘";
			this.button_stopkeyboard.UseVisualStyleBackColor = true;
			this.button_stopkeyboard.Click += new System.EventHandler(this.Button_Click);
			// 
			// resultinfo
			// 
			this.resultinfo.Location = new System.Drawing.Point(68, 63);
			this.resultinfo.Multiline = true;
			this.resultinfo.Name = "resultinfo";
			this.resultinfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.resultinfo.Size = new System.Drawing.Size(664, 362);
			this.resultinfo.TabIndex = 7;
			this.resultinfo.Text = "监控键盘和鼠标的操作记录：";
			// 
			// button__stop
			// 
			this.button__stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button__stop.Location = new System.Drawing.Point(342, 25);
			this.button__stop.Name = "button__stop";
			this.button__stop.Size = new System.Drawing.Size(75, 23);
			this.button__stop.TabIndex = 6;
			this.button__stop.Text = "恢复正常";
			this.button__stop.UseVisualStyleBackColor = true;
			this.button__stop.Click += new System.EventHandler(this.Button_Click);
			// 
			// button_start
			// 
			this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_start.Location = new System.Drawing.Point(249, 25);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(75, 23);
			this.button_start.TabIndex = 5;
			this.button_start.Text = "开始监控";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.Button_Click);
			// 
			// Form_inputHook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label_MousePosition);
			this.Controls.Add(this.button_stopkeyboard);
			this.Controls.Add(this.resultinfo);
			this.Controls.Add(this.button__stop);
			this.Controls.Add(this.button_start);
			this.Name = "Form_inputHook";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form_inputHook";
			this.Load += new System.EventHandler(this.Form_inputHook_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_MousePosition;
		private System.Windows.Forms.Button button_stopkeyboard;
		private System.Windows.Forms.TextBox resultinfo;
		private System.Windows.Forms.Button button__stop;
		private System.Windows.Forms.Button button_start;
	}
}