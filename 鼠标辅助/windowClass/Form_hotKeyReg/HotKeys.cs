using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;



public class HotKeys {

	#region 组合键 常量定义
	public const byte keys_Alt = 1;    // 鼠标左键
	public const byte keys_Control = 2;    // 鼠标右键
	public const byte keys_Shift = 4;     // CANCEL 键
	public const byte keys_Win = 8;    // 鼠标中键
	#endregion

	#region bVk参数 按键常量定义
	public const byte key_Win = 91;    // win键  (键码91)
	public const byte key_LButton = 0x1;    // 鼠标左键
	public const byte key_RButton = 0x2;    // 鼠标右键
	public const byte key_Cancel = 0x3;     // CANCEL 键
	public const byte key_MButton = 0x4;    // 鼠标中键
	public const byte key_Back = 0x8;       // BACKSPACE 键
	public const byte key_Tab = 0x9;        // TAB 键
	public const byte key_Clear = 0xC;      // CLEAR 键
	public const byte key_Return = 0xD;     // ENTER 键
	public const byte key_Shift = 0x10;     // SHIFT 键
	public const byte key_Control = 0x11;   // CTRL 键
	public const byte key_Alt = 18;         // Alt 键  (键码18)
	public const byte key_Menu = 0x12;      // MENU 键
	public const byte key_Pause = 0x13;     // PAUSE 键
	public const byte key_Capital = 0x14;   // CAPS LOCK 键
	public const byte key_Escape = 0x1B;    // ESC 键
	public const byte key_Space = 0x20;     // SPACEBAR 键
	public const byte key_PageUp = 0x21;    // PAGE UP 键
	public const byte key_End = 0x23;       // End 键
	public const byte key_Home = 0x24;      // HOME 键
	public const byte key_Left = 0x25;      // LEFT ARROW 键
	public const byte key_Up = 0x26;        // UP ARROW 键
	public const byte key_Right = 0x27;     // RIGHT ARROW 键
	public const byte key_Down = 0x28;      // DOWN ARROW 键
	public const byte key_Select = 0x29;    // Select 键
	public const byte key_Print = 0x2A;     // PRINT SCREEN 键
	public const byte key_Execute = 0x2B;   // EXECUTE 键
	public const byte key_Snapshot = 0x2C;  // SNAPSHOT 键
	public const byte key_Delete = 0x2E;    // Delete 键
	public const byte key_Help = 0x2F;      // HELP 键
	public const byte key_Numlock = 0x90;   // NUM LOCK 键

	//常用键 字母键A到Z
	public const byte key_A = 65;
	public const byte key_B = 66;
	public const byte key_C = 67;
	public const byte key_D = 68;
	public const byte key_E = 69;
	public const byte key_F = 70;
	public const byte key_G = 71;
	public const byte key_H = 72;
	public const byte key_I = 73;
	public const byte key_J = 74;
	public const byte key_K = 75;
	public const byte key_L = 76;
	public const byte key_M = 77;
	public const byte key_N = 78;
	public const byte key_O = 79;
	public const byte key_P = 80;
	public const byte key_Q = 81;
	public const byte key_R = 82;
	public const byte key_S = 83;
	public const byte key_T = 84;
	public const byte key_U = 85;
	public const byte key_V = 86;
	public const byte key_W = 87;
	public const byte key_X = 88;
	public const byte key_Y = 89;
	public const byte key_Z = 90;

	//数字键盘0到9
	public const byte key_0 = 48;    // 0 键
	public const byte key_1 = 49;    // 1 键
	public const byte key_2 = 50;    // 2 键
	public const byte key_3 = 51;    // 3 键
	public const byte key_4 = 52;    // 4 键
	public const byte key_5 = 53;    // 5 键
	public const byte key_6 = 54;    // 6 键
	public const byte key_7 = 55;    // 7 键
	public const byte key_8 = 56;    // 8 键
	public const byte key_9 = 57;    // 9 键


	public const byte key_Numpad0 = 0x60;    //0 键
	public const byte key_Numpad1 = 0x61;    //1 键
	public const byte key_Numpad2 = 0x62;    //2 键
	public const byte key_Numpad3 = 0x63;    //3 键
	public const byte key_Numpad4 = 0x64;    //4 键
	public const byte key_Numpad5 = 0x65;    //5 键
	public const byte key_Numpad6 = 0x66;    //6 键
	public const byte key_Numpad7 = 0x67;    //7 键
	public const byte key_Numpad8 = 0x68;    //8 键
	public const byte key_Numpad9 = 0x69;    //9 键
	public const byte key_Multiply = 0x6A;   // MULTIPLICATIONSIGN(*)键
	public const byte key_Add = 0x6B;        // PLUS SIGN(+) 键
	public const byte key_Separator = 0x6C;  // ENTER 键
	public const byte key_Subtract = 0x6D;   // MINUS SIGN(-) 键
	public const byte key_Decimal = 0x6E;    // DECIMAL POINT(.) 键
	public const byte key_Divide = 0x6F;     // DIVISION SIGN(/) 键


	//F1到F12按键
	public const byte key_F1 = 0x70;   //F1 键
	public const byte key_F2 = 0x71;   //F2 键
	public const byte key_F3 = 0x72;   //F3 键
	public const byte key_F4 = 0x73;   //F4 键
	public const byte key_F5 = 0x74;   //F5 键
	public const byte key_F6 = 0x75;   //F6 键
	public const byte key_F7 = 0x76;   //F7 键
	public const byte key_F8 = 0x77;   //F8 键
	public const byte key_F9 = 0x78;   //F9 键
	public const byte key_F10 = 0x79;  //F10 键
	public const byte key_F11 = 0x7A;  //F11 键
	public const byte key_F12 = 0x7B;  //F12 键

	#endregion

	#region DLL导入

	[DllImport( "user32.dll" )]
	static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);
	[DllImport( "user32.dll" )]
	static extern bool UnregisterHotKey(IntPtr hWnd, int id);
	/// <summary>
	/// 模拟键盘的方法
	/// </summary>
	/// <param name="bVk" >按键的虚拟键值</param>
	/// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
	/// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
	/// <param name= "dwExtraInfo">一般设置为0</param>
	[DllImport( "user32.dll" )]
	public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

	#endregion
	int keyid = 10;     //区分不同的快捷键
	Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();   //每一个key对于一个处理函数
	public delegate void HotKeyCallBackHanlder();

	public void Keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo) {
		keybd_event( bVk, bScan, dwFlags, dwExtraInfo );
	}
	/// <summary>
	/// 注册快捷键
	/// </summary>
	/// <param name="hWnd">窗口句柄</param>
	/// <param name="modifiers">组合键(Ctrl,Shift,Win,Alt),多个组合键可以直接加出结果(Ctrl+Shift)</param>
	/// <param name="vk">按键值[a-z0-9]</param>
	/// <param name="callBack">回调参数</param>
	/// <returns></returns>
	public Boolean Regist(IntPtr hWnd, int modifiers, Keys vk, HotKeyCallBackHanlder callBack) {
		Boolean is_ok = false;
		int id = keyid++;
		if (RegisterHotKey( hWnd, id, modifiers, vk )) is_ok = true;
		keymap[id] = callBack;
		return is_ok;
	}

	/// <summary>
	/// 注销快捷键
	/// </summary>
	/// <param name="hWnd">窗口句柄</param>
	/// <param name="callBack">注册热键时的回调函数</param>
	/// <returns></returns>
	public Boolean UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack) {
		Boolean is_ok = false;
		foreach (KeyValuePair<int, HotKeyCallBackHanlder> var in keymap) {
			if (var.Value == callBack) {
				if (UnregisterHotKey( hWnd, var.Key )) {
					is_ok = true;
					break;
				}
			}
		}
		return is_ok;
	}

	// 快捷键消息处理
	public void ProcessHotKey(Message m) {
		if (m.Msg == 0x312) {
			int id = m.WParam.ToInt32();
			HotKeyCallBackHanlder callback;
			if (keymap.TryGetValue( id, out callback ))
				callback();
		}
	}
}