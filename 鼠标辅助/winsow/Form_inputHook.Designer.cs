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
			this.textBox_resultinfo = new System.Windows.Forms.TextBox();
			this.button_stop = new System.Windows.Forms.Button();
			this.button_start = new System.Windows.Forms.Button();
			this.button_truncate = new System.Windows.Forms.Button();
			this.lable_state_Shift = new System.Windows.Forms.Label();
			this.lable_state_Ctrl = new System.Windows.Forms.Label();
			this.lable_state_Alt = new System.Windows.Forms.Label();
			this.button_unitTest = new System.Windows.Forms.Button();
			this.textBox_windowInfo = new System.Windows.Forms.TextBox();
			this.button_setTopTier = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label_MousePosition
			// 
			this.label_MousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label_MousePosition.AutoSize = true;
			this.label_MousePosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_MousePosition.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_MousePosition.Location = new System.Drawing.Point(502, 56);
			this.label_MousePosition.Name = "label_MousePosition";
			this.label_MousePosition.Size = new System.Drawing.Size(172, 23);
			this.label_MousePosition.TabIndex = 9;
			this.label_MousePosition.Text = "移动鼠标以便查看效果";
			this.label_MousePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button_stopkeyboard
			// 
			this.button_stopkeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_stopkeyboard.Location = new System.Drawing.Point(207, 21);
			this.button_stopkeyboard.Name = "button_stopkeyboard";
			this.button_stopkeyboard.Size = new System.Drawing.Size(75, 23);
			this.button_stopkeyboard.TabIndex = 8;
			this.button_stopkeyboard.Text = "屏蔽键盘";
			this.button_stopkeyboard.UseVisualStyleBackColor = true;
			this.button_stopkeyboard.Click += new System.EventHandler(this.Button_Click);
			// 
			// textBox_resultinfo
			// 
			this.textBox_resultinfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox_resultinfo.Location = new System.Drawing.Point(19, 93);
			this.textBox_resultinfo.Margin = new System.Windows.Forms.Padding(10);
			this.textBox_resultinfo.MaxLength = 65536;
			this.textBox_resultinfo.Multiline = true;
			this.textBox_resultinfo.Name = "textBox_resultinfo";
			this.textBox_resultinfo.ReadOnly = true;
			this.textBox_resultinfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox_resultinfo.Size = new System.Drawing.Size(690, 340);
			this.textBox_resultinfo.TabIndex = 7;
			this.textBox_resultinfo.WordWrap = false;
			// 
			// button_stop
			// 
			this.button_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_stop.Location = new System.Drawing.Point(126, 21);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(75, 23);
			this.button_stop.TabIndex = 6;
			this.button_stop.Text = "恢复正常";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.Button_Click);
			// 
			// button_start
			// 
			this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_start.Location = new System.Drawing.Point(45, 21);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(75, 23);
			this.button_start.TabIndex = 5;
			this.button_start.Text = "开始监控";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.Button_Click);
			// 
			// button_truncate
			// 
			this.button_truncate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_truncate.Location = new System.Drawing.Point(288, 21);
			this.button_truncate.Name = "button_truncate";
			this.button_truncate.Size = new System.Drawing.Size(75, 23);
			this.button_truncate.TabIndex = 10;
			this.button_truncate.Text = "清空日志";
			this.button_truncate.UseVisualStyleBackColor = true;
			this.button_truncate.Click += new System.EventHandler(this.Button_Click);
			// 
			// lable_state_Shift
			// 
			this.lable_state_Shift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lable_state_Shift.AutoSize = true;
			this.lable_state_Shift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lable_state_Shift.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lable_state_Shift.Location = new System.Drawing.Point(207, 56);
			this.lable_state_Shift.Name = "lable_state_Shift";
			this.lable_state_Shift.Size = new System.Drawing.Size(98, 23);
			this.lable_state_Shift.TabIndex = 11;
			this.lable_state_Shift.Text = "shift 键状态";
			// 
			// lable_state_Ctrl
			// 
			this.lable_state_Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lable_state_Ctrl.AutoSize = true;
			this.lable_state_Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lable_state_Ctrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lable_state_Ctrl.Location = new System.Drawing.Point(45, 56);
			this.lable_state_Ctrl.Name = "lable_state_Ctrl";
			this.lable_state_Ctrl.Size = new System.Drawing.Size(89, 23);
			this.lable_state_Ctrl.TabIndex = 12;
			this.lable_state_Ctrl.Text = "ctrl 键状态";
			// 
			// lable_state_Alt
			// 
			this.lable_state_Alt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lable_state_Alt.AutoSize = true;
			this.lable_state_Alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lable_state_Alt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lable_state_Alt.Location = new System.Drawing.Point(366, 56);
			this.lable_state_Alt.Name = "lable_state_Alt";
			this.lable_state_Alt.Size = new System.Drawing.Size(84, 23);
			this.lable_state_Alt.TabIndex = 13;
			this.lable_state_Alt.Text = "alt 键状态";
			// 
			// button_unitTest
			// 
			this.button_unitTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_unitTest.Location = new System.Drawing.Point(537, 21);
			this.button_unitTest.Name = "button_unitTest";
			this.button_unitTest.Size = new System.Drawing.Size(75, 23);
			this.button_unitTest.TabIndex = 14;
			this.button_unitTest.Text = "代码测试";
			this.button_unitTest.UseVisualStyleBackColor = true;
			this.button_unitTest.Click += new System.EventHandler(this.Button_Click);
			// 
			// textBox_windowInfo
			// 
			this.textBox_windowInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox_windowInfo.Location = new System.Drawing.Point(19, 453);
			this.textBox_windowInfo.Margin = new System.Windows.Forms.Padding(10);
			this.textBox_windowInfo.MaxLength = 65536;
			this.textBox_windowInfo.Multiline = true;
			this.textBox_windowInfo.Name = "textBox_windowInfo";
			this.textBox_windowInfo.ReadOnly = true;
			this.textBox_windowInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox_windowInfo.Size = new System.Drawing.Size(690, 359);
			this.textBox_windowInfo.TabIndex = 15;
			this.textBox_windowInfo.WordWrap = false;
			// 
			// button_setTopTier
			// 
			this.button_setTopTier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_setTopTier.Location = new System.Drawing.Point(369, 21);
			this.button_setTopTier.Name = "button_setTopTier";
			this.button_setTopTier.Size = new System.Drawing.Size(75, 23);
			this.button_setTopTier.TabIndex = 16;
			this.button_setTopTier.Text = "窗口置顶";
			this.button_setTopTier.UseVisualStyleBackColor = true;
			this.button_setTopTier.Click += new System.EventHandler(this.Button_Click);
			// 
			// Form_inputHook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 865);
			this.Controls.Add(this.button_setTopTier);
			this.Controls.Add(this.textBox_windowInfo);
			this.Controls.Add(this.button_unitTest);
			this.Controls.Add(this.lable_state_Alt);
			this.Controls.Add(this.lable_state_Ctrl);
			this.Controls.Add(this.lable_state_Shift);
			this.Controls.Add(this.button_truncate);
			this.Controls.Add(this.label_MousePosition);
			this.Controls.Add(this.button_stopkeyboard);
			this.Controls.Add(this.textBox_resultinfo);
			this.Controls.Add(this.button_stop);
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
		private System.Windows.Forms.TextBox textBox_resultinfo;
		private System.Windows.Forms.Button button_stop;
		private System.Windows.Forms.Button button_start;
		private System.Windows.Forms.Button button_truncate;
		private System.Windows.Forms.Label lable_state_Shift;
		private System.Windows.Forms.Label lable_state_Ctrl;
		private System.Windows.Forms.Label lable_state_Alt;
		private System.Windows.Forms.Button button_unitTest;
		private System.Windows.Forms.TextBox textBox_windowInfo;
		private System.Windows.Forms.Button button_setTopTier;
	}
}