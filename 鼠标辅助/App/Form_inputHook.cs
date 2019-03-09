using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardHook;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Lwm.inputAssist;
using System.Threading;
using Lwm.Forms;
using Lwm.Win32API;


namespace App {

	partial class Form_inputHook : Form {

		/// <summary>
		/// 输入钩子
		/// </summary>
		private InputHook vHks = new InputHook();

		/// <summary>
		/// 键盘鼠标辅助
		/// </summary>
		private Keyboard_Mouse_Assist v_kma;

		/// <summary>
		/// 按钮集中处理对象
		/// </summary>
		private Button_Function v_bf;

		/// <summary>
		/// 事件集中处理对象
		/// </summary>
		private Controls_Eval v_ce;

		/// <summary>
		/// 热键列表
		/// </summary>
		private ListView_Mouse_Hotkey v_lmh;

		/// <summary>
		/// 初始化控件
		/// </summary>
		private Init_Conrols v_ic;

		/// <summary>
		/// 组合键,在添加热键到列表的时候用到,在输入热键时,热键会保存到这个变量
		/// </summary>
		private List<Keys>[] v_hotKey = new List<Keys>[2] { new List<Keys>(), new List<Keys>() };


		public Form_inputHook() {
			InitializeComponent();
			v_kma = new Keyboard_Mouse_Assist();
			v_lmh = new ListView_Mouse_Hotkey();
			v_bf = new Button_Function( this );
			v_ce = new Controls_Eval( this );//事件要在最后初始化,因为要给 v_lmh 配置事件
			v_ic = new Init_Conrols( this );
			Init_software_list();


			//init 窗口
			//this.ShowInTaskbar = false;
			//this.WindowState = FormWindowState.Minimized;
			//v_kma.Show();
			// vHks

			vHks.Event_Keys += new InputHook.D_KeysEvent( CallBack_KeyboardEvent );
			vHks.Event_Mouse += new InputHook.D_MouseEvent( CallBack_MouseEvent );
			//辅助窗口列表

			//this.vId.OnKeyPress += new KeyPressEventHandler( hook_MainKeyPress );//这个接口有点问题,控制台提示程序错误,但不停止运行
		}

		/// <summary>
		/// 主要处理一些懒得用手去配置的属性和需要代码布局的控件
		/// </summary>
		private class Init_Conrols {
			private readonly Form_inputHook win;

			public Init_Conrols(Form_inputHook form_inputHook) {
				this.win = form_inputHook;
			}
		}

		/// <summary>
		/// 控件事件
		/// </summary>
		private class Controls_Eval {
			private readonly Form_inputHook win;

			/// <summary>
			/// 获取当前选中的软件配置
			/// </summary>
			/// <returns></returns>
			private Software_Hotkey Get_Selection_Software() {
				int index = win.comboBox_software_list.SelectedIndex;
				Software_Hotkey ret = win.v_kma.vShm.Software_Hotkey_List[index];
				return ret;
			}

			/// <summary>
			/// 软件下拉列表被选中时
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			public void ComboBox_software_list_SelectionChangeCommitted(object sender, EventArgs e) {
				ComboBox v_cb = (ComboBox)sender;
				int index = v_cb.SelectedIndex;
				List<Software_Hotkey> v_sh_list = win.v_kma.vShm.Software_Hotkey_List;

				///设置匹配规则
				void set_regular() {

					//窗口标题
					win.textBox_titleName_regular.Text = v_sh_list[index].setting.title_regexMatch;
					win.textBox_title_regular_valve.Text = v_sh_list[index].setting.title_MatchValue;
					win.numericUpDown_title_group.Value = v_sh_list[index].setting.title_MatchGroup;
					//窗口类名
					win.textBox_className_regular.Text = v_sh_list[index].setting.class_regexMatch;
					win.textBox_class_regular_valve.Text = v_sh_list[index].setting.class_MatchValue;
					win.numericUpDown_class_group.Value = v_sh_list[index].setting.class_MatchGroup;

				}


				///设置鼠标辅助键
				void set_mouseKey() {

					string[] list = v_sh_list[index].last.Key_Text.Split( new char[] { ',', ' ' } );
					string[] next = v_sh_list[index].next.Key_Text.Split( new char[] { ',', ' ' } );
					win.textBox_mouse_last1.Text = list[0];
					win.textBox_mouse_last2.Text = list.Length == 3 ? list[2] : "";

					win.textBox_mouse_next1.Text = next[0];
					win.textBox_mouse_next2.Text = next.Length == 3 ? next[2] : "";
				}


				///设置热键列表
				void set_hotKey_List() {
					win.v_lmh.listView.Items.Clear();
					for (var i = 0; i < v_sh_list[index].key_List.Count; i++) {

						add_item( v_sh_list[index].key_List[i].Key_Text, v_sh_list[index].key_List[i].comment );
					}
				}
				///添加类表项
				void add_item(string Key_Text, string comment) {
					ListViewItem vLvi = new ListViewItem();

					ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
					subItem.Text = comment;

					vLvi.Text = Key_Text;
					vLvi.SubItems.Add( subItem );
					win.v_lmh.listView.Items.Add( vLvi );
				}
				///设置软件名
				win.textBox_software_name.Text = v_sh_list[index].setting.softwareName;

				set_regular();//匹配规则
				set_mouseKey();//鼠标辅助键
				set_hotKey_List();//热键列表
				win.tabControl_setting.Enabled = true;//解除禁用
				win.button_delete_software.Text = "删除";//重置删除按钮

			}

			/// <summary>
			/// 删除热键项
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void Click_Delete_HotKey_item(object sender, EventArgs e) {
				//从热键管理对象删除
				int index = win.comboBox_software_list.SelectedIndex;
				///从列表删除
				foreach (ListViewItem item in win.v_lmh.listView.SelectedItems) {
					win.v_kma.vShm.Software_Hotkey_List[index].key_List.RemoveAt( item.Index );
					win.v_lmh.listView.Items.Remove( item );
				}
				win.v_kma.vShm.Save_Config();
			}

			/// <summary>
			/// 捕获输入的热键,热键按  第一次按键 和 第二次按下按键 分配到 win.v_hotKey 变量中
			/// 并修改编辑框里的内容,编辑框内容被修改了就会自动触发内容被修改事件
			/// 修改事件里有保存热键的逻辑
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void Capture_Input_HotKey(object sender, KeyEventArgs e) {
				if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey) return;
				if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.ControlKey) return;
				if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu || e.KeyCode == Keys.Menu) return;
				TextBox textBox = (TextBox)sender;
				//检测按键是第一次按下键还是第二次按下键来进行索引分配
				string _char = textBox.Name.Substring( textBox.Name.Length - 1 );
				int i = _char == "2" ? 1 : 0;
				win.v_hotKey[i].Clear();
				List<string> key = new List<string>();
				if (e.Control) {
					key.Add( "Ctrl" );
					win.v_hotKey[i].Add( Keys.LControlKey );
				}
				if (e.Shift) {
					key.Add( "Shift" );
					win.v_hotKey[i].Add( Keys.LShiftKey );
				}

				if (e.Alt) {
					key.Add( "Alt" );
					win.v_hotKey[i].Add( Keys.LMenu );
				}
				key.Add( e.KeyCode.ToString() );
				win.v_hotKey[i].Add( e.KeyCode );
				textBox.Text = string.Join( "+", key );
			}

			/// <summary>
			/// 修改匹配标题名正则
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_titleName_regular_TextChanged(object sender, EventArgs e) {
				TextBox textbox = (TextBox)sender;
				Get_Selection_Software().setting.title_regexMatch = textbox.Text;
				win.v_kma.vShm.Save_Config();
			}

			/// <summary>
			/// 修改标题正则匹配值
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_title_regular_valve_TextChanged(object sender, EventArgs e) {
				TextBox textbox = (TextBox)sender;
				Get_Selection_Software().setting.title_MatchValue = textbox.Text;
				win.v_kma.vShm.Save_Config();
			}

			/// <summary>
			/// 修改标题匹配分组
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void NumericUpDown_title_group_ValueChanged(object sender, EventArgs e) {
				NumericUpDown v_nup = (NumericUpDown)sender;
				Get_Selection_Software().setting.title_MatchGroup = (int)v_nup.Value;
				win.v_kma.vShm.Save_Config();
			}

			/// <summary>
			/// 修改类名匹配正则
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_className_regular_TextChanged(object sender, EventArgs e) {
				TextBox textbox = (TextBox)sender;
				Get_Selection_Software().setting.class_regexMatch = textbox.Text;
				win.v_kma.vShm.Save_Config();
			}

			/// <summary>
			///  修改类名正则匹配值
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_class_regular_valve_TextChanged(object sender, EventArgs e) {
				TextBox textbox = (TextBox)sender;
				Get_Selection_Software().setting.class_MatchValue = textbox.Text;
				win.v_kma.vShm.Save_Config();
			}

			/// <summary>
			/// 修改类名匹配分组
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void NumericUpDown_class_group_ValueChanged(object sender, EventArgs e) {
				NumericUpDown v_nup = (NumericUpDown)sender;
				Get_Selection_Software().setting.class_MatchGroup = (int)v_nup.Value;
				win.v_kma.vShm.Save_Config();
			}

			/// <summary>
			/// 修改鼠标辅助键 Next
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_mouse_next1_TextChanged(object sender, EventArgs e) {

				int index = 0;

				if (win.v_hotKey[index].Count != 0 && ( (TextBox)sender ).Text != "") {
					Get_Selection_Software().next.HotKey[index] = new List<Keys>( win.v_hotKey[index] );
					win.v_kma.vShm.Save_Config();
					win.v_hotKey[index].Clear();
				}
			}

			/// <summary>
			/// 修改鼠标辅助键 Next
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_mouse_next2_TextChanged(object sender, EventArgs e) {

				int index = 1;
				if (win.v_hotKey[index].Count != 0 && ( (TextBox)sender ).Text != "") {
					Get_Selection_Software().next.HotKey[index] = new List<Keys>( win.v_hotKey[index] );
					win.v_kma.vShm.Save_Config();
					win.v_hotKey[index].Clear();
				}
			}

			/// <summary>
			/// 修改鼠标辅助键 Last
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_mouse_last1_TextChanged(object sender, EventArgs e) {

				int index = 0;
				if (win.v_hotKey[index].Count != 0 && ( (TextBox)sender ).Text != "") {
					Get_Selection_Software().last.HotKey[index] = new List<Keys>( win.v_hotKey[index] );
					win.v_kma.vShm.Save_Config();
					win.v_hotKey[index].Clear();
				}
			}

			/// <summary>
			/// 修改鼠标辅助键 Last
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_mouse_last2_TextChanged(object sender, EventArgs e) {

				int index = 1;
				if (win.v_hotKey[index].Count != 0 && ( (TextBox)sender ).Text != "") {
					Get_Selection_Software().last.HotKey[index] = new List<Keys>( win.v_hotKey[index] );
					win.v_kma.vShm.Save_Config();
					win.v_hotKey[index].Clear();
				}
			}

			/// <summary>
			/// 重命名
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void TextBox_software_name_TextChanged(object sender, EventArgs e) {
				TextBox textbox = (TextBox)sender;
				string softwareName = textbox.Text;
				if (softwareName == "") {
					softwareName = "未命名";
				}
				int index = win.comboBox_software_list.SelectedIndex;
				Software_Hotkey v_sh = win.v_kma.vShm.Software_Hotkey_List[index];
				v_sh.setting.softwareName = softwareName;
				win.comboBox_software_list.Items.RemoveAt( index );
				win.comboBox_software_list.Items.Insert( index, softwareName );
				win.comboBox_software_list.SelectedIndex = index;
				win.v_kma.vShm.Save_Config();//保存配置
			}

			/// <summary>
			/// 构造函数
			/// </summary>
			/// <param name="form_inputHook"></param>
			public Controls_Eval(Form_inputHook form_inputHook) {
				this.win = form_inputHook;

				//软件下拉列表被选中时
				win.comboBox_software_list.SelectionChangeCommitted += new EventHandler( ComboBox_software_list_SelectionChangeCommitted );
				win.textBox_input_hotKey1.KeyUp += new KeyEventHandler( Capture_Input_HotKey );
				win.textBox_input_hotKey2.KeyUp += new KeyEventHandler( Capture_Input_HotKey );
				//点击删除项的时候
				win.v_lmh.contextMenuStrip.Items[0].Click += new EventHandler( Click_Delete_HotKey_item );
				//修改标题匹配规则
				win.textBox_titleName_regular.TextChanged += new EventHandler( TextBox_titleName_regular_TextChanged );
				win.textBox_title_regular_valve.TextChanged += new EventHandler( TextBox_title_regular_valve_TextChanged );
				win.numericUpDown_title_group.ValueChanged += new EventHandler( NumericUpDown_title_group_ValueChanged );
				//修改标题类名规则
				win.textBox_className_regular.TextChanged += new EventHandler( TextBox_className_regular_TextChanged );
				win.textBox_class_regular_valve.TextChanged += new EventHandler( TextBox_class_regular_valve_TextChanged );
				win.numericUpDown_class_group.ValueChanged += new EventHandler( NumericUpDown_class_group_ValueChanged );
				//鼠标辅助键
				win.textBox_mouse_last1.KeyUp += new KeyEventHandler( Capture_Input_HotKey );
				win.textBox_mouse_last2.KeyUp += new KeyEventHandler( Capture_Input_HotKey );
				win.textBox_mouse_last1.TextChanged += new EventHandler( TextBox_mouse_last1_TextChanged );
				win.textBox_mouse_last2.TextChanged += new EventHandler( TextBox_mouse_last2_TextChanged );

				//鼠标辅助键
				win.textBox_mouse_next1.KeyUp += new KeyEventHandler( Capture_Input_HotKey );
				win.textBox_mouse_next2.KeyUp += new KeyEventHandler( Capture_Input_HotKey );
				win.textBox_mouse_next1.TextChanged += new EventHandler( TextBox_mouse_next1_TextChanged );
				win.textBox_mouse_next2.TextChanged += new EventHandler( TextBox_mouse_next2_TextChanged );

				//重命名
				win.textBox_software_name.TextChanged += new EventHandler( TextBox_software_name_TextChanged );
			}

		}

		/// <summary>
		/// 按钮处理
		/// </summary>
		private class Button_Function {
			private readonly Form_inputHook win;
			/// <summary>
			/// 获取当前选中的软件配置
			/// </summary>
			/// <returns></returns>
			private Software_Hotkey Get_Selection_Software() {
				int index = win.comboBox_software_list.SelectedIndex;
				Software_Hotkey ret = win.v_kma.vShm.Software_Hotkey_List[index];
				return ret;
			}

			/// <summary>
			/// 添加软件
			/// </summary>
			public void Add_software(String softwareName) {
				if (softwareName == "") return;
				Software_Hotkey.Setting setting = new Software_Hotkey.Setting() {
					softwareName = softwareName
				};
				Software_Hotkey v_sh = new Software_Hotkey( setting );
				win.v_kma.vShm.Software_Hotkey_List.Add( v_sh );

				win.v_kma.vShm.Save_Config();
				win.comboBox_software_list.Items.Add( softwareName );
			}

			/// <summary>
			/// 添加热键项
			/// </summary>
			public void Add_hotKey_item() {

				string comment = win.textBox_hotKey_comment.Text;
				int index = win.comboBox_software_list.SelectedIndex;
				Software_Hotkey v_sh = win.v_kma.vShm.Software_Hotkey_List[index];
				Software_Hotkey.HotKey_Execute v_shhe = new Software_Hotkey.HotKey_Execute();
				v_shhe.comment = comment;

				for (var i = 0; i < v_shhe.HotKey.Length; i++) {
					v_shhe.HotKey[i] = new List<Keys>( win.v_hotKey[i] );
				}

				v_sh.key_List.Add( v_shhe );
				//假装触发一次事件,让列表刷新
				win.v_ce.ComboBox_software_list_SelectionChangeCommitted( win.comboBox_software_list, EventArgs.Empty );
				win.v_kma.vShm.Save_Config();//保存配置
			}

			/// <summary>
			/// 删除软件
			/// </summary>
			public void Delete_software() {

			}

			/// <summary>
			/// 软件重命名
			/// </summary>
			public void Software_rename() {
				switch (win.button_delete_software.Text) {
					case "删除":
						win.button_delete_software.Text = "确定删除";
						break;
					case "确定删除":
						int index = win.comboBox_software_list.SelectedIndex;
						win.comboBox_software_list.Items.RemoveAt( index );
						win.v_kma.vShm.Software_Hotkey_List.RemoveAt( index );
						win.tabControl_setting.Enabled = false;//先禁用
						break;
				}
			}

			/// <summary>
			/// 清除
			/// </summary>
			/// <param name="target"></param>
			public void Clear_hotKey(string target) {
				switch (target) {
					case "last":
						win.textBox_mouse_last1.Text = "";
						win.textBox_mouse_last2.Text = "";
						Get_Selection_Software().last.ClearKey();
						break;
					case "next":
						win.textBox_mouse_next1.Text = "";
						win.textBox_mouse_next2.Text = "";
						Get_Selection_Software().next.ClearKey();
						break;
					default:
						Console.WriteLine( "参数有误 方法 Clear_hotKey" );
						break;
				}
				win.v_kma.vShm.Save_Config();
			}

			public Button_Function(Form_inputHook _this) {
				this.win = _this;
			}
		}

		private void Init_software_list() {
			int count = v_kma.vShm.Software_Hotkey_List.Count;
			string softwareName;
			for (int i = 0; i < count; i++) {
				softwareName = v_kma.vShm.Software_Hotkey_List[i].setting.softwareName;
				comboBox_software_list.Items.Add( softwareName );
			}
			tabControl_setting.Enabled = false;//先禁用
			panel_hotKey_list.Controls.Add( v_lmh.listView );//添加自定义控件
			if (count != 0) {
			}
		}

		/// <summary>
		/// 窗口加载完毕
		/// </summary>
		private void Form_inputHook_Load(object sender, EventArgs e) {/*点击主窗口*/
			button_start.PerformClick();//模拟点击 开始监控 //Button_Click( null, EventArgs.Empty );
										//comboBox1.SelectedIndex = 1;

		}


		/// <summary>
		/// 所有 Button 点击事件 都填这个方法,集中处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Click(object sender, EventArgs e) {

			Button btn = (Button)sender;
			switch (btn.Name) {
				case "button_start"://开始监控
					vHks.Hooks_Install();
					break;
				case "button_stop"://停止监控
					vHks.Hooks_UnLoad();

					break;
				case "button_addToList"://添加到列表
					v_bf.Add_hotKey_item();
					break;
				case "button_shield_keyboard"://屏蔽键盘
					vHks.Shield_keyboard();
					break;
				case "button_relieve_keyboard_shield"://解除键盘
					vHks.Relieve_keyboard_Shield();
					break;
				case "button_truncate"://清空按钮
					textBox_inpud_recod.Text = "";
					break;
				case "button_unitTest"://单元测试

					UnitTest();
					break;
				case "button_add_software"://添加软件
					v_bf.Add_software( textBox_add_software.Text );
					break;
				case "button_setTopTier"://窗口置顶
					if (btn.Text == "窗口置顶") {
						this.TopMost = true;
						btn.Text = "取消置顶";
					} else {
						this.TopMost = false;
						btn.Text = "窗口置顶";
					}

					break;
				case "button_delete_software"://删除软件
					v_bf.Software_rename();
					break;
				case "button_clear_next":
					v_bf.Clear_hotKey( "next" );
					break;
				case "button_clear_last":
					v_bf.Clear_hotKey( "last" );
					break;
				default:
					Console.WriteLine( "按钮方法未定义" );
					break;
			}
		}
		private int MAKELONG(int int1, int int2) {
			Int32 inta = ( int1 << 16 ) | int2;
			return inta;
		}
		/// <summary>
		/// 单元测试
		/// </summary>
		private void UnitTest() {


		}


		/// <summary>
		/// 键盘事件处理
		/// </summary>
		/// <param name="Sender">可以忽略</param>
		/// <param name="key">按键信息</param>
		public void CallBack_KeyboardEvent(InputHook vIh, InputHook.Action Sender) {
			v_kma.Keyboard_Handler( vIh, Sender );//传递给视图辅助窗口

			KeyEventArgs key = vIh.keyboard_Input_Record[0];
			//如果是按弹起键
			if (Sender == InputHook.Action.KeyUp && vHks.is_simulated == false) {//使用多线程进行输入辅助处理,不影响主线程
				new MultiThread_InputAuxiliary( vHks );//开新线程辅助输入

			}

			System.Threading.Thread.Sleep( 1 );//不停不行

			if (WindowState == FormWindowState.Normal) { //只有窗口是正常状态才调试输出
				Show_HotKeyState();//显示状态键
				if (Sender == InputHook.Action.KeyUp) {
					textBox_foregroundWindowInfo.Text = vHks.window_Info_Foreground.ToString(); //显示前台窗口信息

					//显示鼠标所在窗口信息(按右侧 Alt 显示)
					if (key.KeyCode == Keys.RMenu && Sender == InputHook.Action.KeyUp) {
						SetFrom_textBox_windowInfo( vHks.window_Info_Mouse.ToString() );
						Console.WriteLine( vHks.window_Info_Foreground.title );
						Console.WriteLine( vHks.window_Info_Foreground.className );
					}
				}
				var v = new {
					key.KeyValue,
					key.KeyCode,
					key.Modifiers,
					key.SuppressKeyPress
				};
				textBox_foregroundWindowInfo.Text = vHks.window_Info_Foreground.ToString();

				LogWrite( Sender + "\t" + v );

			}
		}

		/// <summary>
		/// 鼠标事件处理
		/// </summary>
		/// <param name="e">鼠标信息</param>
		public void CallBack_MouseEvent(InputHook vIh, MouseEventArgs e) {
			v_kma.Mouse_Handler( vIh, e );//传递给视图辅助窗口
			vHks.keyStateAll.TryGetValue( Keys.LMenu, out bool is_Press_LAlt );
			//只有窗口是正常状态才调试输出
			if (WindowState == FormWindowState.Normal) {
				label_MousePosition.Text = string.Format( "x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta );
				if (e.Clicks > 0) {
					LogWrite( "MouseButton\t" + e.Button.ToString() );
				}
			}
		}

		/// <summary>
		/// 按键事件写出数据到文本框
		/// </summary>
		/// <param name="txt"></param>
		private void LogWrite(string txt) {
			textBox_inpud_recod.AppendText( Environment.NewLine + txt + "\t" + System.DateTime.Now );
			textBox_inpud_recod.SelectionStart = textBox_inpud_recod.Text.Length;
		}

		/// <summary>
		/// 显示_鼠标所在窗口信息
		/// </summary>
		/// <param name="txt"></param>
		private void SetFrom_textBox_windowInfo(string txt) {
			textBox_mouse_located_window_info.AppendText( txt + Environment.NewLine );
			textBox_mouse_located_window_info.SelectionStart = textBox_mouse_located_window_info.Text.Length;
		}

		/// <summary>
		/// 显示_热键母键状态
		/// </summary>
		private void Show_HotKeyState() {
			lable_state_Alt.Text = "Alt 键状态 " + vHks.keyStateAll[Keys.LMenu];
			lable_state_Ctrl.Text = "Ctrl 键状态 " + vHks.keyStateAll[Keys.LControlKey];
			lable_state_Shift.Text = "Shift 键状态 " + vHks.keyStateAll[Keys.LShiftKey];
		}

	}
}
