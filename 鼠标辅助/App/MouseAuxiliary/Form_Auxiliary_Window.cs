using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwm.inputAssist;
using Lwm.Window;
using Lwm.CustomControls;
using System.Threading;
using System.Text.RegularExpressions;

namespace App {
	/// <summary>
	/// 在这里控制视图显示窗口
	/// </summary>
	public partial class Form_Auxiliary_Window {
		private New_Window new_Window = null;//弹出的窗口
		private Controls_FlpList flpList = null;//窗口的列表



		/// <summary>
		/// 是否正在处理鼠标辅助键,用于去除重复
		/// </summary>
		private Boolean be_dispose_mouse = false;

		public Form_Auxiliary_Window() {
			Init_Software_Hotkey_List();
		}

		/// <summary>
		/// 热键管理对象
		/// </summary>
		Software_Hotkey.Manage vShm = new Software_Hotkey.Manage();

		/// <summary>
		/// 初始化软件软件热键列表
		/// </summary>
		private void Init_Software_Hotkey_List() {

			Software_Hotkey.Config config = new Software_Hotkey.Config( @".*?(Microsoft Visual Studio)", 1, "Microsoft Visual Studio", @"^(HwndWrapper)\[DefaultDomain", 1, "HwndWrapper" );
			Software_Hotkey vSh = new Software_Hotkey( config );

			vSh.next.Add_Key( Keys.LShiftKey ).Add_Key( Keys.F5 );
			vSh.last.Add_Key( Keys.F5 );


			vShm.Add_Software_Hotkey_List( vSh );//添加到管理类
		}


		/// <summary>
		/// 放开 alt 后要执行的热键
		/// </summary>
		public Software_Hotkey.HotKey_Execute up_Alt_Execute_HotKey = null;

		/// <summary>
		/// 键盘信息处理
		/// </summary>
		public void Auxiliary_Window_Handler(InputHook vIH, InputHook.Action action) {
			Mouse_Auxiliary_button( vIH, action );
			//如果按键是弹起操作,并且弹起的是 左 Alt 键
			if (action == InputHook.Action.KeyUp && vIH.keyboard_Input_Record[0].KeyCode == Keys.LMenu) {

				if (up_Alt_Execute_HotKey != null) {

					up_Alt_Execute_HotKey.Execute();
				}
				//Key_List s=new Key_List();
				if (new_Window != null) {
					//new_Window.Dispose(); //释放资源 
					new_Window.Close();//关闭窗口
					new_Window = null;
				}
			}
		}


		/// <summary>
		/// 鼠标辅助按键
		/// </summary>
		/// <param name="vIH"></param>
		/// <param name="action"></param>
		private void Mouse_Auxiliary_button(InputHook vIH, InputHook.Action action) {

			if (vIH.keyStateAll[Keys.LControlKey] == true &&
				vIH.keyStateAll[Keys.LShiftKey] == true &&
				vIH.keyStateAll[Keys.LMenu] == true &&
				be_dispose_mouse == false) {


				string titleName = vIH.window_Info_Foreground.title.ToString();
				string className = vIH.window_Info_Foreground.className.ToString();

				//减号
				if (vIH.keyStateAll[Keys.Subtract]) {
					be_dispose_mouse = true;//标记为正在处理
					set_be_dispose_mouse();//500毫秒后设置 be_dispose_mouse 为false

					up_Alt_Execute_HotKey = vShm.Trigger_Last( titleName, className );
				}

				//加号
				if (vIH.keyStateAll[Keys.Add]) {
					be_dispose_mouse = true;//标记为正在处理
					set_be_dispose_mouse();//500毫秒后设置 be_dispose_mouse 为false

					up_Alt_Execute_HotKey = vShm.Trigger_Next( titleName, className );

				}
				////开启一个线程,500毫秒后设置为false
				void set_be_dispose_mouse() {
					new Thread( new ThreadStart( () => {
						System.Threading.Thread.Sleep( 500 );
						be_dispose_mouse = false;

					} ) ).Start();
				}
			}
		}
		/// <summary>
		/// 鼠标信息处理
		/// </summary>
		public void Auxiliary_Window_Handler(InputHook vIH, MouseEventArgs mea) {
			int width = 320;

			if (vIH.keyStateAll[Keys.LMenu] == true && mea.Delta != 0) {
				Console.WriteLine( vIH.window_Info_Foreground.ToString() );
				//如果窗口已被销毁
				if (new_Window == null) {
					new_Window = new New_Window( new New_Window.Attr_C() { width = width } );

					new_Window.SuspendLayout();
					new_Window.Opacity = 0.65;
					flpList = new Controls_FlpList( new Controls_FlpList.Attr_C() { width = width } );
					new_Window.Controls.Add( flpList.Flp_list );
					for (int i = 0; i < 5; i++) {
						flpList.Add_Record( "按键" + i, "注释" + i );
					}

					//flpList.Select_UpDown_Item( false );

					new_Window.ResumeLayout( false );
					new_Window.PerformLayout();

					new_Window.ControlBox = false;//不显示控制按钮
					new_Window.ShowInTaskbar = false;//不显示在任务栏
													 //设置显示位置
					new_Window.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
					new_Window.Location = (Point)new Size(
						mea.Location.X - 10,
						mea.Location.Y - 10
					);

					new_Window.Text = vIH.window_Info_Foreground.title.ToString();//设置窗口标题
					new_Window.Show();//显示窗口
					SwitchToThisWindow( new_Window.Handle, true );//窗口置顶
				}

				if (mea.Delta < 0) {
					Console.WriteLine( "下一条" );
					flpList.Select_UpDown_Item( true );//选择下一条
				} else {
					Console.WriteLine( "上一条" );
					flpList.Select_UpDown_Item( false );//选择上一条
				}
			}
		}

		/// <summary>
		/// 窗口置顶 SwitchToThisWindow( this.Handle, true );
		/// </summary>
		/// <param name="hWnd">窗口句柄</param>
		/// <param name="fAltTab"></param>
		/// <returns></returns>
		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);


	}
}
