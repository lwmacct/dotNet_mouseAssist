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
using Lwm.Controls;
using System.Threading;
using System.Text.RegularExpressions;
using Lwm.Json;
using System.IO;

namespace App {
	/// <summary>
	/// 在这里控制视图显示窗口
	/// </summary>
	public partial class Keyboard_Mouse_Assist {
		#region 导入 DLL

		/// <summary>
		/// 窗口置顶 SwitchToThisWindow( this.Handle, true );
		/// </summary>
		/// <param name="hWnd">窗口句柄</param>
		/// <param name="fAltTab"></param>
		/// <returns></returns>
		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

		#endregion  导入 DLL

		#region 私有变量

		/// <summary>
		/// 新窗口宽度
		/// </summary>
		private int new_window_width = 380;

		/// <summary>
		/// 弹出的窗口
		/// </summary>
		private New_Window new_Window = null;

		/// <summary>
		/// 窗口的列表
		/// </summary>
		private Controls_FlpList flpList = null;

		/// <summary>
		/// 放开 alt 后要执行的热键
		/// </summary>
		private Software_Hotkey.HotKey_Execute up_Alt_Execute_HotKey = null;

		/// <summary>
		/// 软件的快捷键列表,用于设置放开由滚轮触发的组合键操作
		/// </summary>
		private List<Software_Hotkey.HotKey_Execute> vHe_Lisy = null;

		/// <summary>
		/// 模拟过程对象
		/// </summary>
		private Software_Hotkey.HotKey_Execute.Course course = new Software_Hotkey.HotKey_Execute.Course();

		/// <summary>
		/// 热键管理对象
		/// </summary>
		public Software_Hotkey.Manage vShm = new Software_Hotkey.Manage();



		/// <summary>
		/// 本类的构造函数
		/// </summary>
		public Keyboard_Mouse_Assist() {
			vShm.Load_Config();//载入配置
		}

		#endregion 私有变量

		#region 私有方法

		/// <summary>
		/// 初始化软件软件热键列表,这个方法留着做使用示例吧
		/// </summary>
		private void Init_Software_Hotkey_List() {
			Software_Hotkey.Setting setting = new Software_Hotkey.Setting {
				title_regexMatch = @".*?(Microsoft Visual Studio)",
				title_MatchValue = "Microsoft Visual Studio",
				title_MatchGroup = 1,
				class_regexMatch = @"^(HwndWrapper)\[DefaultDomain",
				class_MatchValue = "HwndWrapper",
				class_MatchGroup = 1,
				softwareName = "Visual Studio"
			};
			Software_Hotkey vSh = new Software_Hotkey( setting );

			vSh.next.HotKey[0].Add( Keys.LShiftKey );
			vSh.next.HotKey[0].Add( Keys.F5 );

			vSh.last.HotKey[0].Add( Keys.F5 );

			Software_Hotkey.HotKey_Execute vHe1 = new Software_Hotkey.HotKey_Execute();
			Software_Hotkey.HotKey_Execute vHe2 = new Software_Hotkey.HotKey_Execute();
			vHe1.HotKey[0].Add( Keys.F5 );
			vHe1.comment = "开始";

			vHe2.HotKey[0].Add( Keys.LShiftKey );
			vHe2.HotKey[0].Add( Keys.F5 );
			vHe2.comment = "停止";

			vSh.key_List.Add( vHe1 );
			vSh.key_List.Add( vHe2 );
			//JSON.stringify()

			vShm.Software_Hotkey_List.Add( vSh );
			vShm.Save_Config();
		}

		/// <summary>
		/// 鼠标辅助按键处理
		/// </summary>
		/// <param name="v_ih"></param>
		/// <param name="action"></param>
		private void Mouse_Auxiliary_button(InputHook v_ih, InputHook.Action action) {

			if (v_ih.keyStateAll[Keys.LControlKey] == true &&
				v_ih.keyStateAll[Keys.LShiftKey] == true &&
				v_ih.keyStateAll[Keys.LMenu] == true &&
				course.be_execute == false) {

				course.handle = v_ih.window_Info_Mouse.IntPtr;//设置鼠标所在窗口句柄
				course.titleName = v_ih.window_Info_Foreground.title.ToString();
				course.className = v_ih.window_Info_Foreground.className.ToString();

				//减号
				if (v_ih.keyStateAll[Keys.Subtract]) {
					course.be_execute = true;//标记为正在处理
					set_be_dispose_mouse();//500毫秒后设置 be_dispose_mouse 为false

					up_Alt_Execute_HotKey = vShm.Get_Last( course.titleName, course.className );
				}

				//加号
				if (v_ih.keyStateAll[Keys.Add]) {
					course.be_execute = true;//标记为正在处理
					set_be_dispose_mouse();//500毫秒后设置 be_dispose_mouse 为false

					up_Alt_Execute_HotKey = vShm.Get_Next( course.titleName, course.className );
				}
				////开启一个线程,512毫秒后设置为false
				void set_be_dispose_mouse() {
					new Thread( new ThreadStart( () => {
						System.Threading.Thread.Sleep( 512 );
						course.be_execute = false;//标记为正在处理
					} ) ).Start();
				}
			}
		}

		#endregion 私有方法

		#region 公有方法

		/// <summary>
		/// 键盘信息处理
		/// </summary>
		public void Keyboard_Handler(InputHook v_ih, InputHook.Action action) {
			Mouse_Auxiliary_button( v_ih, action );//检测是否按下鼠标辅助键

			//如果按键是弹起操作,并且弹起的是 左 Alt 键, 并且不是正在模拟的状态,就模拟热键 (如果有需要模拟的热键)
			if (action == InputHook.Action.KeyUp && v_ih.keyboard_Input_Record[0].KeyCode == Keys.LMenu && course.be_simulate == false) {
				//如果有快捷键列表窗口弹出,就取选中项为放在Alt要执行的热键
				if (new_Window != null) {
					new_Window.Dispose(); //释放资源 
					new_Window.Close();//关闭窗口
					new_Window = null;//恢复初始值方便下次判断

					//下面是滚轮触发快捷键的关键
					if (vHe_Lisy != null) {
						if (vHe_Lisy.Count != 0) { //如果窗口不是空的
							up_Alt_Execute_HotKey = vHe_Lisy[flpList.Selected_Index];
						}

						vHe_Lisy = null;
						flpList = null;
						new_Window = null;
					}
				}

				//如果有需要执行的组合键
				if (up_Alt_Execute_HotKey != null) {

					course.be_simulate = true;//标记为正在模拟
											  //开始模拟,模拟过程是新线程,把 is_simulated 传过去是方便在新线程中取消正在模拟状态
					up_Alt_Execute_HotKey.Execute( course );
					up_Alt_Execute_HotKey = null;
				}
			}
		}

		/// <summary>
		/// 鼠标信息处理
		/// </summary>
		public void Mouse_Handler(InputHook v_ih, MouseEventArgs mea) {

			//如果鼠标左键等于按下状态并且鼠标滚轮有滚动,并且不再模拟状态
			if (v_ih.keyStateAll[Keys.LMenu] == true && mea.Delta != 0 && course.be_simulate == false) {

				course.handle = v_ih.window_Info_Mouse.IntPtr;//设置鼠标所在窗口句柄

				//如果窗口已被销毁
				if (new_Window == null) {
					new_Window = new New_Window( new New_Window.Attr_C() { width = new_window_width } );

					new_Window.SuspendLayout();
					new_Window.Opacity = 0.65;
					flpList = new Controls_FlpList( new Controls_FlpList.Attr_C() { width = new_window_width } );

					string titleName = v_ih.window_Info_Foreground.title.ToString();
					string className = v_ih.window_Info_Foreground.className.ToString();
					vHe_Lisy = vShm.Get_Key_List( titleName, className );

					for (int i = 0; i < vHe_Lisy.Count; i++) {
						flpList.Add_Record( vHe_Lisy[i].Key_Text, vHe_Lisy[i].comment );
					}
					flpList.Selected_Index = 0;//设置选中第一条
					new_Window.Controls.Add( flpList.Flp_list );//将列表添加到窗口

					new_Window.ResumeLayout( false );//布局相关
					new_Window.PerformLayout();//布局相关

					new_Window.ControlBox = false;//不显示控制按钮
					new_Window.ShowInTaskbar = false;//不显示在任务栏

					new_Window.StartPosition = FormStartPosition.Manual; //让窗体的位置由Location属性决定
																		 //设置显示位置
					new_Window.Location = (Point)new Size(
						mea.Location.X - 10,
						mea.Location.Y - 10
					);

					new_Window.Text = v_ih.window_Info_Foreground.title.ToString();//设置窗口标题
					new_Window.Show();//显示窗口
					SwitchToThisWindow( new_Window.Handle, true );//窗口置顶
				}

				if (mea.Delta < 0) {
					flpList.Select_UpDown_Item( true );//选择下一条
				} else {
					flpList.Select_UpDown_Item( false );//选择上一条
				}
			}
		}

		#endregion 公有方法





	}
}
