using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace inputAssist {
	/// <summary>
	/// 多线程启动输入辅助,不阻塞主线程
	/// </summary>
	class MultiThreadInputAssist {
		/// <summary>
		/// 按键信息
		/// </summary>
		private readonly HotKeyState hKS;

		public void Assist_PhpStorm() {
			System.Threading.Thread.Sleep(1);
			new Assist_PhpStorm( hKS );//加载 phpstorm 辅助类
		}
		public MultiThreadInputAssist(HotKeyState hKS) {
			this.hKS = hKS;
			Thread t1 = new Thread( new ThreadStart( this.Assist_PhpStorm ) );
			t1.Start();

		}
	}
}
