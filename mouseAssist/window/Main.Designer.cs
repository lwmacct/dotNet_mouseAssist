namespace app {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Main ) );
			this.notifyIcon_tray = new System.Windows.Forms.NotifyIcon( this.components );
			this.contextMenuStrip_tray = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip_tray.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon_tray
			// 
			this.notifyIcon_tray.ContextMenuStrip = this.contextMenuStrip_tray;
			this.notifyIcon_tray.Icon = ( (System.Drawing.Icon)( resources.GetObject( "notifyIcon_tray.Icon" ) ) );
			this.notifyIcon_tray.Text = "鼠标辅助";
			this.notifyIcon_tray.Visible = true;
			// 
			// contextMenuStrip_tray
			// 
			this.contextMenuStrip_tray.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
			this.退出ToolStripMenuItem} );
			this.contextMenuStrip_tray.Name = "contextMenuStrip1";
			this.contextMenuStrip_tray.Size = new System.Drawing.Size( 107, 28 );
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size( 106, 24 );
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler( this.退出ToolStripMenuItem_Click );
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 800, 450 );
			this.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "控制台";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.contextMenuStrip_tray.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon_tray;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_tray;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
	}
}

