using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Lwm.inputAssist {
	/// <summary>
	/// 软件热键类
	/// </summary>
	public class Software_Hotkey {

		#region 子类

		/// <summary>
		/// 构造函数时的配置类
		/// </summary>
		public class Config {
			/// <summary>
			/// 正则表达式
			/// </summary>
			public string title_regexMatch;

			/// <summary>
			/// 匹配到的分组
			/// </summary>
			public int title_MatchGroup;

			/// <summary>
			/// 匹配到的值
			/// </summary>
			public string title_MatchValue;

			/// <summary>
			/// 正则表达式
			/// </summary>
			public string class_regexMatch;

			/// <summary>
			/// 匹配到的分组
			/// </summary>
			public int class_MatchGroup;

			/// <summary>
			/// 匹配到的值
			/// </summary>
			public string class_MatchValue;

			public Config(string title_regexMatch, int title_MatchGroup, string title_MatchValue, string class_regexMatch = null, int class_MatchGroup = 0, string class_MatchValue = null) {
				this.title_MatchGroup = title_MatchGroup;
				this.title_regexMatch = title_regexMatch;
				this.title_MatchValue = title_MatchValue;
				this.class_MatchGroup = class_MatchGroup;
				this.class_regexMatch = class_regexMatch;
				this.class_MatchValue = class_MatchValue;

			}
		}

		/// <summary>
		/// 提供用于管理当前类的子类
		/// </summary>
		public class Manage {
			private List<Software_Hotkey> Software_Hotkey_List = new List<Software_Hotkey>();

			/// <summary>
			/// 添加一个软件的鼠标热键辅助
			/// </summary>
			/// <param name="vSh"></param>
			public void Add_Software_Hotkey_List(Software_Hotkey vSh) {
				Software_Hotkey_List.Add( vSh );
			}

			/// <summary>
			/// 通知软件热键列表管理器,按下了 Alt + 鼠标辅助按键 Next,匹配成功则返回需要执行的热键
			/// </summary>
			/// <param name="window_titleName">窗口标题</param>
			/// <param name="window_className">窗口类名</param>
			/// <returns></returns>
			public HotKey_Execute Trigger_Next(string window_titleName, string window_className) {
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
			public HotKey_Execute Trigger_Last(string window_titleName, string window_className) {
				HotKey_Execute ret = null;
				for (var i = 0; i < Software_Hotkey_List.Count; i++) {
					if (Software_Hotkey_List[i].Perform_Matching( window_titleName, window_className )) {
						ret = Software_Hotkey_List[i].last;
					}

				}
				return ret;
			}
		}

		/// <summary>
		/// 热键执行类
		/// </summary>
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


			private readonly List<Keys> HotKey = new List<Keys>();

			/// <summary>
			/// 开始执行热键
			/// </summary>
			public void Execute() {

				//我们需要开一个新线程来执行,避免执行下面这句的时候 ctrl 按键还是按着的
				new Thread( new ThreadStart( () => {
					//System.Threading.Thread.Sleep( 1 );
					Dowm_Or_Up( 0 );//按下
					Dowm_Or_Up( 2 );//弹起
				} ) ).Start();

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
			/// 注释
			/// </summary>
			public string comment = "";

			/// <summary>
			/// 组合键的文本表示
			/// </summary>
			public string Key_Text {
				get { return Create_Key_Text(); }
			}

			/// <summary>
			/// 创建组合键的文本表示
			/// </summary>
			/// <returns></returns>
			private string Create_Key_Text() {
				StringBuilder str = new StringBuilder();
				for (var i = 0; i < HotKey.Count; i++) {
					str.Append( " + " + HotKey[i].ToString() );
				}
				return str.ToString();
			}

			/// <summary>
			/// 执行 按下或弹起
			/// </summary>
			/// <param name="dwFlags"></param>
			private void Dowm_Or_Up(int dwFlags) {
				for (var i = 0; i < this.HotKey.Count; i++) {
					keybd_event( (byte)HotKey[i], 0, dwFlags, 0 );
				}
			}

		}

		#endregion

		/// <summary>
		/// 构造函数时的配置
		/// </summary>
		private Config config;

		/// <summary>
		/// 滚轮快捷键列表
		/// </summary>
		private List<HotKey_Execute> key_List = new List<HotKey_Execute>();


		/// <summary>
		/// 鼠标辅助键 上一个 
		/// </summary>
		public HotKey_Execute last = new HotKey_Execute();

		/// <summary>
		/// 鼠标辅助键 下一个 
		/// </summary>
		public HotKey_Execute next = new HotKey_Execute();

		/// <summary>
		/// 添加列表快捷键
		/// </summary>
		/// <param name="hotkey">热键组合</param>
		public void Add_Menu_Key(HotKey_Execute hotkey) {
			key_List.Add( hotkey );
		}

		/// <summary>
		/// 执行匹配
		/// </summary>
		/// <returns></returns>
		public Boolean Perform_Matching(string window_title, string window_class) {
			Match mat_title = Regex.Match( window_title, config.title_regexMatch );//标题正则
			Match mat_class;//类名正则
			Boolean title_bool = false;//标题是否匹配成功
			Boolean class_bool = false;//类名是否匹配成功
			Boolean ret_bool = false;//最终匹配结果

			//匹配标题
			if (mat_title.Groups.Count >= config.title_MatchGroup) {
				if (mat_title.Groups[config.title_MatchGroup].Value == config.title_MatchValue) {
					title_bool = true;
				}
			}

			//如果要求类名匹配
			if (config.class_regexMatch != null) {
				mat_class = Regex.Match( window_class, config.class_regexMatch );
				//匹配标题
				if (mat_class.Groups.Count >= config.class_MatchGroup) {
					if (mat_class.Groups[config.class_MatchGroup].Value == config.class_MatchValue) {
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
			Console.WriteLine( ret_bool );
			return ret_bool;
		}

		public Software_Hotkey(Config config) {
			this.config = config;
		}
	}
}
