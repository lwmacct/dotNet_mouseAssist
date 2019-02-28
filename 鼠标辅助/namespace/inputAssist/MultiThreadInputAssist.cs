using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace inputAssist {
	class MultiThreadInputAssist {
		/// <summary>
		/// 按键信息
		/// </summary>
		private readonly app.HotKeyState hKS;

		public void Assist_PhpStorm() {
			new Assist_PhpStorm( hKS );//加载 phpstorm 辅助类
		}

		public MultiThreadInputAssist(app.HotKeyState hKS) {
			this.hKS = hKS;
			Thread t1 = new Thread( new ThreadStart( this.Assist_PhpStorm ) );

			t1.Start();

		}
	}
}
