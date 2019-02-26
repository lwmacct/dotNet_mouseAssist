using System;
using System.Windows.Forms;

namespace app {
	public partial class HotkeyReg : Form {
		public HotkeyReg() {
			InitializeComponent();
		}
		#region 控件方法
		private void HotkeyReg_Load(object sender, EventArgs e) {
			//Btn_hotkeyReg_Click( null, EventArgs.Empty );
			btn_hotkeyReg.PerformClick();//模拟点击  //this.WindowState = FormWindowState.Maximized;

		}

		private void Btn_hotkeyReg_Click(object sender, EventArgs e) {
			Func_hotKeys_reg();
		}

		private void Btn_hotKeyUnload_Click(object sender, EventArgs e) {
			Func_hotKeys_unload();
		}
		private void HotkeyReg_FormClosing(object sender, FormClosingEventArgs e) {
			bool is_close = true;//是否阻止窗口关闭
			switch (e.CloseReason) {
				case CloseReason.ApplicationExitCall:
					Console.WriteLine( "应用程序exit退出" );
					is_close = false;
					break;
				case CloseReason.FormOwnerClosing:
					Console.WriteLine( "窗体的所有者退出，导致子窗体关闭" );
					break;
				case CloseReason.MdiFormClosing:
					Console.WriteLine( "Mdi父窗体关闭，导致子窗体关闭" );
					break;
				case CloseReason.TaskManagerClosing:
					Console.WriteLine( "任务管理器关闭窗体" );
					break;
				case CloseReason.UserClosing:
					Console.WriteLine( "用户通过UI关闭窗体" );
					break;
				case CloseReason.WindowsShutDown:
					Console.WriteLine( "关机导致应用程序关闭" );
					break;
				case CloseReason.None:
					Console.WriteLine( "未知原因导致窗体窗体" );
					break;
				default:
					Console.WriteLine( "未知原因导致窗体窗体" );
					break;

			}
			if (is_close) {
				e.Cancel = true;//阻止窗口关闭 
			}
			WindowState = FormWindowState.Minimized;//最小化
		}
		#endregion 控件方法

		#region 注册切换桌面切换组组合键,以及实现
		private HotKeys h = new HotKeys();
		#region 注册和卸载热键

		/// <summary>
		/// 注册热键
		/// </summary>
		private void Func_hotKeys_reg() {
			//注册Ctrl + Shift + Alt + Left 快捷键
			//注册Ctrl + Shift + Alt + Right 快捷键
			bool is_leftDesktop = false;//默认为失败
			bool is_rightDesktop = false;//默认为失败
			is_leftDesktop = h.Regist( Handle, HotKeys.keys_Control + HotKeys.keys_Shift, Keys.Subtract, Func_left_callBack );
			is_rightDesktop = h.Regist( Handle, HotKeys.keys_Control + HotKeys.keys_Shift, Keys.Add, Func_right_callBack );
			if (is_leftDesktop && is_rightDesktop) {
				Console.WriteLine( "注册热键成功" );
			} else {
				Console.WriteLine( "注册热键失败" );
			}
		}
		/// <summary>
		/// 卸载热键
		/// </summary>
		private void Func_hotKeys_unload() {
			bool is_leftDesktop = false;//默认为失败
			bool is_rightDesktop = false;//默认为失败
			is_leftDesktop = h.UnRegist( Handle, Func_left_callBack );//卸载
			is_rightDesktop = h.UnRegist( Handle, Func_right_callBack );
			if (is_leftDesktop && is_rightDesktop) {
				Console.WriteLine( "注册热键成功" );
			} else {
				Console.WriteLine( "注册热键失败" );
			}
		}
		#endregion 注册和卸载热键

		#region 热键回调
		private void Func_left_callBack() {
			//MessageBox.Show( "Ctrl + Shift + Alt + Left 快捷键" );
			h.Keybd_event( HotKeys.key_Win, 0, 0, 0 );//模拟按下win键
			h.Keybd_event( HotKeys.key_Control, 0, 0, 0 );//模拟按下Alt键
			h.Keybd_event( HotKeys.key_Left, 0, 0, 0 );//模拟按下Alt键
													   //松开按钮不能少
			h.Keybd_event( HotKeys.key_Win, 0, 2, 0 );
			h.Keybd_event( HotKeys.key_Control, 0, 2, 0 );
			h.Keybd_event( HotKeys.key_Left, 0, 2, 0 );
		}
		private void Func_right_callBack() {
			//MessageBox.Show( "Ctrl + Shift + Alt + Right 快捷键" );

			h.Keybd_event( HotKeys.key_Win, 0, 0, 0 );//模拟按下win键
			h.Keybd_event( HotKeys.key_Control, 0, 0, 0 );//模拟按下Alt键
			h.Keybd_event( HotKeys.key_Right, 0, 0, 0 );//模拟按下Alt键
														//松开按钮不能少
			h.Keybd_event( HotKeys.key_Win, 0, 2, 0 );
			h.Keybd_event( HotKeys.key_Control, 0, 2, 0 );
			h.Keybd_event( HotKeys.key_Right, 0, 2, 0 );
		}


		#endregion 热键回调

		#region override
		protected override void WndProc(ref Message m) {
			//窗口消息处理函数
			h.ProcessHotKey( m );
			base.WndProc( ref m );
		}

		#endregion override

		#endregion 注册切换桌面切换组组合键,以及实现
	}
}
