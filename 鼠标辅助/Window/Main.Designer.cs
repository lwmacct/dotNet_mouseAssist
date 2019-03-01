namespace App {
	partial class Main {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.panel_windowAll = new System.Windows.Forms.Panel();
			this.notifyIcon_MainTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip_Maintray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button_inputHook = new System.Windows.Forms.Button();
			this.panel_windowAll.SuspendLayout();
			this.contextMenuStrip_Maintray.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_windowAll
			// 
			this.panel_windowAll.Controls.Add(this.button_inputHook);
			this.panel_windowAll.Location = new System.Drawing.Point(12, 12);
			this.panel_windowAll.Name = "panel_windowAll";
			this.panel_windowAll.Size = new System.Drawing.Size(878, 134);
			this.panel_windowAll.TabIndex = 0;
			// 
			// notifyIcon_MainTray
			// 
			this.notifyIcon_MainTray.ContextMenuStrip = this.contextMenuStrip_Maintray;
			this.notifyIcon_MainTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_MainTray.Icon")));
			this.notifyIcon_MainTray.Text = "软件名称";
			this.notifyIcon_MainTray.Visible = true;
			// 
			// contextMenuStrip_Maintray
			// 
			this.contextMenuStrip_Maintray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
			this.contextMenuStrip_Maintray.Name = "contextMenuStrip_Maintray";
			this.contextMenuStrip_Maintray.Size = new System.Drawing.Size(181, 50);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// button_inputHook
			// 
			this.button_inputHook.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button_inputHook.Location = new System.Drawing.Point(3, 0);
			this.button_inputHook.Name = "button_inputHook";
			this.button_inputHook.Size = new System.Drawing.Size(121, 47);
			this.button_inputHook.TabIndex = 0;
			this.button_inputHook.Text = "button1";
			this.button_inputHook.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(902, 574);
			this.Controls.Add(this.panel_windowAll);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "程序入口";
			this.Load += new System.EventHandler(this.Main_Load);
			this.panel_windowAll.ResumeLayout(false);
			this.contextMenuStrip_Maintray.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel_windowAll;
		private System.Windows.Forms.NotifyIcon notifyIcon_MainTray;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Maintray;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.Button button_inputHook;
	}
}

