namespace App {
	partial class Form_hotKeyReg {
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
			this.panel_btnAll = new System.Windows.Forms.Panel();
			this.btn_hotKeyUnload = new System.Windows.Forms.Button();
			this.btn_hotkeyReg = new System.Windows.Forms.Button();
			this.panel_btnAll.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_btnAll
			// 
			this.panel_btnAll.Controls.Add(this.btn_hotKeyUnload);
			this.panel_btnAll.Controls.Add(this.btn_hotkeyReg);
			this.panel_btnAll.Location = new System.Drawing.Point(176, 218);
			this.panel_btnAll.Name = "panel_btnAll";
			this.panel_btnAll.Size = new System.Drawing.Size(314, 159);
			this.panel_btnAll.TabIndex = 0;
			// 
			// btn_hotKeyUnload
			// 
			this.btn_hotKeyUnload.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_hotKeyUnload.Location = new System.Drawing.Point(165, 96);
			this.btn_hotKeyUnload.Name = "btn_hotKeyUnload";
			this.btn_hotKeyUnload.Size = new System.Drawing.Size(92, 48);
			this.btn_hotKeyUnload.TabIndex = 1;
			this.btn_hotKeyUnload.Text = "热键卸载";
			this.btn_hotKeyUnload.UseVisualStyleBackColor = true;
			this.btn_hotKeyUnload.Click += new System.EventHandler(this.Btn_hotKeyUnload_Click);
			// 
			// btn_hotkeyReg
			// 
			this.btn_hotkeyReg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_hotkeyReg.Location = new System.Drawing.Point(54, 96);
			this.btn_hotkeyReg.Name = "btn_hotkeyReg";
			this.btn_hotkeyReg.Size = new System.Drawing.Size(92, 48);
			this.btn_hotkeyReg.TabIndex = 0;
			this.btn_hotkeyReg.Text = "热键注册";
			this.btn_hotkeyReg.UseVisualStyleBackColor = true;
			this.btn_hotkeyReg.Click += new System.EventHandler(this.Btn_hotkeyReg_Click);
			// 
			// Form_hotKeyReg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(660, 450);
			this.Controls.Add(this.panel_btnAll);
			this.ImeMode = System.Windows.Forms.ImeMode.On;
			this.MaximizeBox = false;
			this.Name = "Form_hotKeyReg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "热键注册";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotkeyReg_FormClosing);
			this.Load += new System.EventHandler(this.HotkeyReg_Load);
			this.panel_btnAll.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel_btnAll;
		private System.Windows.Forms.Button btn_hotKeyUnload;
		private System.Windows.Forms.Button btn_hotkeyReg;
	}
}