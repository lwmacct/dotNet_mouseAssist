namespace App {
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
			this.button_shield_keyboard = new System.Windows.Forms.Button();
			this.textBox_resultinfo = new System.Windows.Forms.TextBox();
			this.button_relieve_keyboard_shield = new System.Windows.Forms.Button();
			this.button_start = new System.Windows.Forms.Button();
			this.button_truncate = new System.Windows.Forms.Button();
			this.lable_state_Shift = new System.Windows.Forms.Label();
			this.lable_state_Ctrl = new System.Windows.Forms.Label();
			this.lable_state_Alt = new System.Windows.Forms.Label();
			this.button_unitTest = new System.Windows.Forms.Button();
			this.textBox_windowInfo = new System.Windows.Forms.TextBox();
			this.button_setTopTier = new System.Windows.Forms.Button();
			this.panel_funcButton = new System.Windows.Forms.Panel();
			this.panel_lables = new System.Windows.Forms.Panel();
			this.textBox_foregroundWindowInfo = new System.Windows.Forms.TextBox();
			this.button_stop = new System.Windows.Forms.Button();
			this.panel_funcButton.SuspendLayout();
			this.panel_lables.SuspendLayout();
			this.SuspendLayout();
			// 
			// label_MousePosition
			// 
			this.label_MousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label_MousePosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_MousePosition.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_MousePosition.Location = new System.Drawing.Point(463, 3);
			this.label_MousePosition.Name = "label_MousePosition";
			this.label_MousePosition.Size = new System.Drawing.Size(219, 33);
			this.label_MousePosition.TabIndex = 9;
			this.label_MousePosition.Text = "移动鼠标以便查看效果";
			this.label_MousePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button_shield_keyboard
			// 
			this.button_shield_keyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_shield_keyboard.Location = new System.Drawing.Point(220, 6);
			this.button_shield_keyboard.Name = "button_shield_keyboard";
			this.button_shield_keyboard.Size = new System.Drawing.Size(75, 37);
			this.button_shield_keyboard.TabIndex = 8;
			this.button_shield_keyboard.Text = "屏蔽键盘";
			this.button_shield_keyboard.UseVisualStyleBackColor = true;
			this.button_shield_keyboard.Click += new System.EventHandler(this.Button_Click);
			// 
			// textBox_resultinfo
			// 
			this.textBox_resultinfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox_resultinfo.Location = new System.Drawing.Point(9, 313);
			this.textBox_resultinfo.Margin = new System.Windows.Forms.Padding(10);
			this.textBox_resultinfo.MaxLength = 65536;
			this.textBox_resultinfo.Multiline = true;
			this.textBox_resultinfo.Name = "textBox_resultinfo";
			this.textBox_resultinfo.ReadOnly = true;
			this.textBox_resultinfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox_resultinfo.Size = new System.Drawing.Size(711, 165);
			this.textBox_resultinfo.TabIndex = 7;
			this.textBox_resultinfo.WordWrap = false;
			// 
			// button_relieve_keyboard_shield
			// 
			this.button_relieve_keyboard_shield.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_relieve_keyboard_shield.Location = new System.Drawing.Point(301, 6);
			this.button_relieve_keyboard_shield.Name = "button_relieve_keyboard_shield";
			this.button_relieve_keyboard_shield.Size = new System.Drawing.Size(75, 37);
			this.button_relieve_keyboard_shield.TabIndex = 6;
			this.button_relieve_keyboard_shield.Text = "恢复正常";
			this.button_relieve_keyboard_shield.UseVisualStyleBackColor = true;
			this.button_relieve_keyboard_shield.Click += new System.EventHandler(this.Button_Click);
			// 
			// button_start
			// 
			this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_start.Location = new System.Drawing.Point(6, 6);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(75, 37);
			this.button_start.TabIndex = 5;
			this.button_start.Text = "安装钩子";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.Button_Click);
			// 
			// button_truncate
			// 
			this.button_truncate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_truncate.Location = new System.Drawing.Point(469, 6);
			this.button_truncate.Name = "button_truncate";
			this.button_truncate.Size = new System.Drawing.Size(75, 37);
			this.button_truncate.TabIndex = 10;
			this.button_truncate.Text = "清空日志";
			this.button_truncate.UseVisualStyleBackColor = true;
			this.button_truncate.Click += new System.EventHandler(this.Button_Click);
			// 
			// lable_state_Shift
			// 
			this.lable_state_Shift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lable_state_Shift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lable_state_Shift.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lable_state_Shift.Location = new System.Drawing.Point(168, 3);
			this.lable_state_Shift.Name = "lable_state_Shift";
			this.lable_state_Shift.Size = new System.Drawing.Size(145, 33);
			this.lable_state_Shift.TabIndex = 11;
			this.lable_state_Shift.Text = "shift 键状态";
			this.lable_state_Shift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lable_state_Ctrl
			// 
			this.lable_state_Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lable_state_Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lable_state_Ctrl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lable_state_Ctrl.Location = new System.Drawing.Point(6, 3);
			this.lable_state_Ctrl.Name = "lable_state_Ctrl";
			this.lable_state_Ctrl.Size = new System.Drawing.Size(136, 33);
			this.lable_state_Ctrl.TabIndex = 12;
			this.lable_state_Ctrl.Text = "ctrl 键状态";
			this.lable_state_Ctrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lable_state_Alt
			// 
			this.lable_state_Alt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lable_state_Alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lable_state_Alt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lable_state_Alt.Location = new System.Drawing.Point(327, 3);
			this.lable_state_Alt.Name = "lable_state_Alt";
			this.lable_state_Alt.Size = new System.Drawing.Size(131, 33);
			this.lable_state_Alt.TabIndex = 13;
			this.lable_state_Alt.Text = "alt 键状态";
			this.lable_state_Alt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button_unitTest
			// 
			this.button_unitTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_unitTest.Location = new System.Drawing.Point(631, 6);
			this.button_unitTest.Name = "button_unitTest";
			this.button_unitTest.Size = new System.Drawing.Size(75, 37);
			this.button_unitTest.TabIndex = 14;
			this.button_unitTest.Text = "代码测试";
			this.button_unitTest.UseVisualStyleBackColor = true;
			this.button_unitTest.Click += new System.EventHandler(this.Button_Click);
			// 
			// textBox_windowInfo
			// 
			this.textBox_windowInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox_windowInfo.Location = new System.Drawing.Point(9, 498);
			this.textBox_windowInfo.Margin = new System.Windows.Forms.Padding(10);
			this.textBox_windowInfo.MaxLength = 65536;
			this.textBox_windowInfo.Multiline = true;
			this.textBox_windowInfo.Name = "textBox_windowInfo";
			this.textBox_windowInfo.ReadOnly = true;
			this.textBox_windowInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox_windowInfo.Size = new System.Drawing.Size(711, 314);
			this.textBox_windowInfo.TabIndex = 15;
			this.textBox_windowInfo.WordWrap = false;
			// 
			// button_setTopTier
			// 
			this.button_setTopTier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_setTopTier.Location = new System.Drawing.Point(550, 6);
			this.button_setTopTier.Name = "button_setTopTier";
			this.button_setTopTier.Size = new System.Drawing.Size(75, 37);
			this.button_setTopTier.TabIndex = 16;
			this.button_setTopTier.Text = "窗口置顶";
			this.button_setTopTier.UseVisualStyleBackColor = true;
			this.button_setTopTier.Click += new System.EventHandler(this.Button_Click);
			// 
			// panel_funcButton
			// 
			this.panel_funcButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_funcButton.Controls.Add(this.button_stop);
			this.panel_funcButton.Controls.Add(this.button_start);
			this.panel_funcButton.Controls.Add(this.button_setTopTier);
			this.panel_funcButton.Controls.Add(this.button_relieve_keyboard_shield);
			this.panel_funcButton.Controls.Add(this.button_shield_keyboard);
			this.panel_funcButton.Controls.Add(this.button_unitTest);
			this.panel_funcButton.Controls.Add(this.button_truncate);
			this.panel_funcButton.Location = new System.Drawing.Point(9, 9);
			this.panel_funcButton.Margin = new System.Windows.Forms.Padding(0);
			this.panel_funcButton.Name = "panel_funcButton";
			this.panel_funcButton.Padding = new System.Windows.Forms.Padding(3);
			this.panel_funcButton.Size = new System.Drawing.Size(714, 95);
			this.panel_funcButton.TabIndex = 17;
			// 
			// panel_lables
			// 
			this.panel_lables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_lables.Controls.Add(this.label_MousePosition);
			this.panel_lables.Controls.Add(this.lable_state_Shift);
			this.panel_lables.Controls.Add(this.lable_state_Ctrl);
			this.panel_lables.Controls.Add(this.lable_state_Alt);
			this.panel_lables.Location = new System.Drawing.Point(9, 107);
			this.panel_lables.Name = "panel_lables";
			this.panel_lables.Padding = new System.Windows.Forms.Padding(3);
			this.panel_lables.Size = new System.Drawing.Size(711, 152);
			this.panel_lables.TabIndex = 18;
			// 
			// textBox_foregroundWindowInfo
			// 
			this.textBox_foregroundWindowInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox_foregroundWindowInfo.Location = new System.Drawing.Point(9, 272);
			this.textBox_foregroundWindowInfo.Margin = new System.Windows.Forms.Padding(10);
			this.textBox_foregroundWindowInfo.MaxLength = 65536;
			this.textBox_foregroundWindowInfo.Name = "textBox_foregroundWindowInfo";
			this.textBox_foregroundWindowInfo.ReadOnly = true;
			this.textBox_foregroundWindowInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox_foregroundWindowInfo.Size = new System.Drawing.Size(714, 21);
			this.textBox_foregroundWindowInfo.TabIndex = 19;
			this.textBox_foregroundWindowInfo.WordWrap = false;
			// 
			// button_stop
			// 
			this.button_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button_stop.Location = new System.Drawing.Point(87, 6);
			this.button_stop.Name = "button_stop";
			this.button_stop.Size = new System.Drawing.Size(75, 37);
			this.button_stop.TabIndex = 17;
			this.button_stop.Text = "卸载钩子";
			this.button_stop.UseVisualStyleBackColor = true;
			this.button_stop.Click += new System.EventHandler(this.Button_Click);
			// 
			// Form_inputHook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 865);
			this.Controls.Add(this.textBox_foregroundWindowInfo);
			this.Controls.Add(this.panel_lables);
			this.Controls.Add(this.panel_funcButton);
			this.Controls.Add(this.textBox_windowInfo);
			this.Controls.Add(this.textBox_resultinfo);
			this.Name = "Form_inputHook";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form_inputHook";
			this.Load += new System.EventHandler(this.Form_inputHook_Load);
			this.panel_funcButton.ResumeLayout(false);
			this.panel_lables.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_shield_keyboard;
		private System.Windows.Forms.TextBox textBox_resultinfo;
		private System.Windows.Forms.Button button_relieve_keyboard_shield;
		private System.Windows.Forms.Button button_start;
		private System.Windows.Forms.Button button_truncate;
		private System.Windows.Forms.Button button_unitTest;
		private System.Windows.Forms.TextBox textBox_windowInfo;
		private System.Windows.Forms.Button button_setTopTier;
		private System.Windows.Forms.Panel panel_funcButton;
		private System.Windows.Forms.Panel panel_lables;
		public System.Windows.Forms.Label label_MousePosition;
		public System.Windows.Forms.Label lable_state_Shift;
		public System.Windows.Forms.Label lable_state_Ctrl;
		public System.Windows.Forms.Label lable_state_Alt;
		private System.Windows.Forms.TextBox textBox_foregroundWindowInfo;
		private System.Windows.Forms.Button button_stop;
	}
}