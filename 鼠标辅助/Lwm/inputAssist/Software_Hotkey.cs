using Lwm.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Lwm.inputAssist {
	/// <summary>
	/// 软件热键类
	/// </summary>
	[DataContract]
	public class Software_Hotkey {

		#region 子类

		/// <summary>
		/// 构造函数时的配置类
		/// </summary>
		[DataContract]
		public class Setting {
			/// <summary>
			/// 软件名称
			/// </summary>
			[DataMember( IsRequired = true )]
			public string softwareName="";

			/// <summary>
			/// 窗口标题 正则表达式
			/// </summary>
			[DataMember( IsRequired = true )]
			public string title_regexMatch="";

			/// <summary>
			/// 匹配到的分组
			/// </summary>
			[DataMember( IsRequired = true )]
			public int title_MatchGroup=0;

			/// <summary>
			/// 匹配到的值
			/// </summary>
			[DataMember( IsRequired = true )]
			public string title_MatchValue="";

			/// <summary>
			/// 窗口类名 正则表达式,不需要验证类名无需填写
			/// </summary>
			[DataMember( IsRequired = true )]
			public string class_regexMatch="";

			/// <summary>
			/// 窗口类名 匹配到的分组
			/// </summary>
			[DataMember( IsRequired = true )]
			public int class_MatchGroup=0;

			/// <summary>
			/// 窗口类名 匹配到的值
			/// </summary>
			[DataMember( IsRequired = true )]
			public string class_MatchValue="";

		}

		/// <summary>
		/// 提供用于管理当前类的子类
		/// </summary>
		public class Manage {

			/// <summary>
			/// 热键列表
			/// </summary>
			public List<Software_Hotkey> Software_Hotkey_List = new List<Software_Hotkey>();

			
			/// <summary>
			/// 加载配置
			/// </summary>
			/// <param name="filePath"></param>
			public void Load_Config(string filePath = @"Config\Software_Config_List.json") {
				String content = File.ReadAllText( filePath );
				Software_Hotkey_List = JSON.parse<List<Software_Hotkey>>( content );
			}

			/// <summary>
			/// 保存配置
			/// </summary>
			/// <param name="filePath"></param>
			public void Save_Config(string filePath = @"Config\Software_Config_List.json") {
				String content = JSON.stringify( Software_Hotkey_List );
				File.WriteAllText( @"Config\Software_Config_List.json", content );
			}

			/// <summary>
			/// 通知软件热键列表管理器,按下了 Alt + 鼠标辅助按键 Next,匹配成功则返回需要执行的热键
			/// </summary>
			/// <param name="window_titleName">窗口标题</param>
			/// <param name="window_className">窗口类名</param>
			/// <returns></returns>
			public HotKey_Execute Get_Next(string window_titleName, string window_className) {
				HotKey_Execute ret = null;
				for (var i = 0; i < Software_Hotkey_List.Count; i++) {
					if (Software_Hotkey_List[i].Perform_Matching( window_titleName, window_className )) {
						ret = Software_Hotkey_List[i].next;

					}
				}
				return ret;
			}

			/// <summary>
			/// 通知软件热键列表管理器,按下了 Alt + 鼠标辅助按键 Last,匹配成功则返回需要执行的热键
			/// </summary>
			/// <param name="window_titleName">窗口标题</param>
			/// <param name="window_className">窗口类名</param>
			/// <returns></returns>
			public HotKey_Execute Get_Last(string window_titleName, string window_className) {
				HotKey_Execute ret = null;
				for (var i = 0; i < Software_Hotkey_List.Count; i++) {
					if (Software_Hotkey_List[i].Perform_Matching( window_titleName, window_className )) {
						ret = Software_Hotkey_List[i].last;
					}

				}
				return ret;
			}


			/// <summary>
			/// 取得软件 快捷键列表 key_List(相当于右键菜单列表)
			/// </summary>
			/// <param name="window_titleName">窗口标题</param>
			/// <param name="window_className">窗口类名</param>
			/// <returns></returns>
			public List<HotKey_Execute> Get_Key_List(string window_titleName, string window_className) {

				List<HotKey_Execute> ret = new List<HotKey_Execute>();
				for (var i = 0; i < Software_Hotkey_List.Count; i++) {
					if (Software_Hotkey_List[i].Perform_Matching( window_titleName, window_className )) {
						ret = Software_Hotkey_List[i].key_List;
					}
				}
				return ret;
			}
		}

		/// <summary>
		/// 热键执行类
		/// </summary>
		[DataContract]
		public class HotKey_Execute {
			/// <summary>
			/// 模拟键盘的方法
			/// </summary>
			/// <param name="bVk" >按键的虚拟键值</param>
			/// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
			/// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
			/// <param name= "dwExtraInfo">一般设置为0</param>
			[System.Runtime.InteropServices.DllImport( "user32.dll" )]
			public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

			/// <summary>
			///组合键数据
			/// </summary>
			[DataMember( IsRequired = true )]
			public List<Keys> HotKey = new List<Keys>();

			/// <summary>
			/// 注释
			/// </summary>
			[DataMember( IsRequired = true )]
			public string comment = "";

			/// <summary>
			/// 组合键的文本表示
			/// </summary>
			public string Key_Text {
				get { return Create_Key_Text(); }
			}

			/// <summary>
			/// 开始执行热键
			/// </summary>
			/// <param name="is_simulated">用于标记为已模拟完成</param>
			public void Execute(Boolean[] is_simulated) {

				//我们需要开一个新线程来执行,避免执行下面这句的时候 Alt 按键还是按着的
				new Thread( new ThreadStart( () => {
					//System.Threading.Thread.Sleep( 0 );

					//如果是右键菜单触发就需要先取出 软件 Alt 状态
					if (is_simulated[1] == false) {
						//解除应用的 Alt 按下状态
						keybd_event( (byte)Keys.LMenu, 0, 0, 0 );
						keybd_event( (byte)Keys.LMenu, 0, 2, 0 );
					}

					Execute_Dowm();//按下
					Execute_Up();//弹起

					is_simulated[0] = false;//设置为未在模拟状态

				} ) ).Start();

			}

			/// <summary>
			/// 执行按下 按顺序按下
			/// </summary>
			public void Execute_Dowm() {
				for (var i = 0; i < this.HotKey.Count; i++) {
					keybd_event( (byte)HotKey[i], 0, 0, 0 );
				}
			}

			/// <summary>
			/// 执行弹起 弹起的时候返过来弹起
			/// </summary>
			public void Execute_Up() {
				for (var i = this.HotKey.Count - 1; i >= 0; i--) {
					keybd_event( (byte)HotKey[i], 0, 2, 0 );
				}
			}

			/// <summary>
			/// 设置快捷键按键(keys)
			///	例如 Ctrl + Alt + A 就要添加三次
			///
			/// 按添加顺序执行热键  在这里可以体验一把链式调用
			/// </summary>
			/// <param name="key">按键 keys </param>
			/// <returns></returns>
			public HotKey_Execute Add_Key(Keys key) {
				this.HotKey.Add( key );
				return this;
			}

			/// <summary>
			/// 清除热键
			/// </summary>
			public void ClearKey() {
				HotKey.Clear();
			}

			/// <summary>
			/// 创建组合键的文本表示
			/// </summary>
			/// <returns></returns>
			private string Create_Key_Text() {
				List<string> str = new List<string>();
				for (var i = 0; i < HotKey.Count; i++) {
					str.Add( To_Normal_key( HotKey[i] ) );
				}

				return string.Join( " + ", str.ToArray() );
			}
			/// <summary>
			/// 将 LshiftKey 之类的文本转为 Shift
			/// </summary>
			/// <param name="str"></param>
			private string To_Normal_key(Keys key) {
				string str = key.ToString();
				switch (key) {
					case Keys.LShiftKey:
					case Keys.RShiftKey:
						str = "Shift";
						break;
					case Keys.LControlKey:
					case Keys.RControlKey:
						str = "Ctrl";
						break;
					case Keys.LMenu:
					case Keys.RMenu:
						str = "Alt";
						break;

				}
				return str;
			}


		}

		#endregion

		/// <summary>
		/// 构造函数时的配置
		/// </summary>
		[DataMember( IsRequired = true )]
		public Setting setting;

		/// <summary>
		/// 滚轮快捷键列表
		/// </summary>
		[DataMember( IsRequired = true )]
		public List<HotKey_Execute> key_List = new List<HotKey_Execute>();


		/// <summary>
		/// 鼠标辅助键 上一个 
		/// </summary>
		[DataMember( IsRequired = true )]
		public HotKey_Execute last = new HotKey_Execute();

		/// <summary>
		/// 鼠标辅助键 下一个 
		/// </summary>
		[DataMember( IsRequired = true )]
		public HotKey_Execute next = new HotKey_Execute();

		/// <summary>
		/// 添加列表快捷键
		/// </summary>
		/// <param name="hotkey">热键组合</param>
		public void Add_Key_List(HotKey_Execute hotkey) {
			key_List.Add( hotkey );
		}

		/// <summary>
		/// 执行匹配
		/// </summary>
		/// <returns></returns>
		public Boolean Perform_Matching(string window_title, string window_class) {
			Match mat_title = Regex.Match( window_title, setting.title_regexMatch );//标题正则
			Match mat_class;//类名正则
			Boolean title_bool = false;//标题是否匹配成功
			Boolean class_bool = false;//类名是否匹配成功
			Boolean ret_bool = false;//最终匹配结果

			//匹配标题
			if (mat_title.Groups.Count >= setting.title_MatchGroup) {
				if (mat_title.Groups[setting.title_MatchGroup].Value == setting.title_MatchValue) {
					title_bool = true;
				}
			}

			//如果要求类名匹配
			if (setting.class_regexMatch != null) {
				mat_class = Regex.Match( window_class, setting.class_regexMatch );
				//匹配标题
				if (mat_class.Groups.Count >= setting.class_MatchGroup) {
					if (mat_class.Groups[setting.class_MatchGroup].Value == setting.class_MatchValue) {
						class_bool = true;
					}
				}

			} else { //否则默认为真
				class_bool = true;
			}
			//计算最终返回
			if (class_bool && title_bool) {
				ret_bool = true;
			}
			return ret_bool;
		}

		public Software_Hotkey(Setting setting) {
			this.setting = setting;
		}
	}
}
