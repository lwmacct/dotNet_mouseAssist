using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app {
	public partial class Main : Form {
		private class InitFom {
			private Main parent;
			public void Form() {
				parent.panel_windowAll.BorderStyle = BorderStyle.FixedSingle;
				parent.WindowState = FormWindowState.Minimized;//最小化
				parent.ShowInTaskbar = false;//不显示任务栏
			}
			public InitFom(Main that) {
				this.parent = that;
				Form();
				
			}
		}
		private Form_hotKeyReg FHKR = new Form_hotKeyReg();//new 一个热键注册窗口
		private Form_inputHook FIH = new Form_inputHook();//new 一个输入辅助窗口

		public Main() {
			InitializeComponent();
			new InitFom( this );//初始化当前窗口
			FHKR.Show();//显示 Form_hotKeyReg
			FIH.Show();//显示 Form_inputHook

		}
		private void Main_Load(object sender, EventArgs e) {
			//notifyIcon_MainTray.Icon="";
		}

		#region 交互处理
		/// <summary>
		/// 所有 Button 点击事件 都填这个方法,集中处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Click(object sender, EventArgs e) {
			Button obj = (Button)sender;
			switch (obj.Name) {
				case "退出ToolStripMenuItem"://开始监控
					Application.Exit();
					break;
				default:
					Console.WriteLine( "按钮方法未定义" );
					break;
			}
		}
		private void ToolStripMenuItem_Click(object sender, EventArgs e) {
			ToolStripMenuItem obj = (ToolStripMenuItem)sender;
			switch (obj.Name) {
				case "退出ToolStripMenuItem"://开始监控
					Application.Exit();
					break;
				default:
					Console.WriteLine( "按钮方法未定义" );
					break;
			}
		}
		#endregion 交互处理

	}
}
