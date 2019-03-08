using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lwm.Forms {
	public class ListView_Mouse_Hotkey {
		#region 公开变量
		/// <summary>
		/// 列表
		/// </summary>
		public ListView listView;

		/// <summary>
		/// 列头
		/// </summary>
		public ColumnHeader[] columnHeader;

		/// <summary>
		/// (项) item 列表数据
		/// </summary>
		public ListViewItem[] listViewItem;

		/// <summary>
		/// 右键菜单
		/// </summary>
		public ContextMenuStrip contextMenuStrip;

		#endregion 公开变量


		#region 添加新行

		public void Add_New_Row(string combination_key, string comment) {
			if (combination_key == "" || comment == "") return;
			string[] data = new[] { comment };

			ListViewItem vLvi = new ListViewItem();

			ListViewItem.ListViewSubItem[] subItem = new ListViewItem.ListViewSubItem[data.Length];
			for (var i = 0; i < data.Length; i++) {
				subItem[i] = new ListViewItem.ListViewSubItem();
				subItem[i].Text = data[i];
			}
			vLvi.Text = combination_key;
			vLvi.SubItems.AddRange( subItem );
			listView.Items.Add( vLvi );
			//设置滚动条并选中 参考 https://blog.csdn.net/kaiyanghao123/article/details/77943185
			int length = listView.Items.Count - 1;
			listView.SelectedItems.Clear();//清除之前的选中
			listView.Items[length].Selected = true;//选中行
			listView.EnsureVisible( length );//视图滚动到添加的行
		}

		#endregion 添加新行


		#region 初始化方法

		/// <summary>
		/// 右键菜单,用于删除
		/// </summary>
		private ContextMenuStrip Init_ContextMenuStrip() {

			///点击删除时发生的事件
			void Click_Delete(object sender, EventArgs e) {
				foreach (ListViewItem item in listView.SelectedItems) {
					listView.Items.Remove( item );
				}
			}
			
			/// <summary>
			/// 右键菜单打开前(这里可以避免右键时没有选择任何项就弹出菜单的尴尬)
			/// </summary>
			void ContextMenuStrip_Opening(object sender, CancelEventArgs e) {
				//如果没有选中任何项就取消菜单事件
				if (listView.SelectedItems.Count == 0) {
					e.Cancel = true;
				}
			}

			string[] itme = new[] { "删除" };

			ToolStripMenuItem[] v_array_tsmi = new ToolStripMenuItem[itme.Length];
			for (var i = 0; i < v_array_tsmi.Length; i++) {
				v_array_tsmi[i] = new ToolStripMenuItem();
				v_array_tsmi[i].Text = itme[i];
				v_array_tsmi[i].Size = new Size( 100, 64 );

			}
			//v_array_tsmi[0].Click += new System.EventHandler( Click_Delete );//点击删除时发生的事件

			ContextMenuStrip v_cms = new ContextMenuStrip();
			v_cms.Items.AddRange( v_array_tsmi );
			v_cms.Size = new System.Drawing.Size( 181, 74 );
			v_cms.Opening += new System.ComponentModel.CancelEventHandler( ContextMenuStrip_Opening );
			return v_cms;
		}

		/// <summary>
		/// 初始化列表
		/// </summary>
		/// <returns></returns>
		private ListView Init_ListView() {

			listView = new ListView();
			listView.Dock = DockStyle.Fill;//填充父容器
			listView.View = View.Details;//每个项将显示在单独的行与列中排列的各项有关的详细信息。 最左侧列中包含一个小图标和标签，并且后续列包含由应用程序指定的子项。 列会显示一个可以显示的列标题的头。在运行时，用户可以调整每一列。
			listView.GridLines = true;//获取或设置一个值，该值指示：在包含控件中项及其子项的行和列之间是否显示网格线。
			listView.Size = new Size( 100, 100 );//控件大小
			listView.Location = new Point( 0, 0 );//控件位置
			listView.UseCompatibleStateImageBehavior = false;
			listView.FullRowSelect = true;//获取或设置一个值，该值指示单击某项是否选择其所有子项。
			listView.Scrollable = true;//滚动条
			listView.HeaderStyle = ColumnHeaderStyle.Clickable;//表头样式
			listView.HideSelection = false;//获取或设置一个值，该值指示当控件没有焦点时，该控件中选定的项是否保持突出显示。
			listView.MultiSelect = true;//是否可以选择多个项。
										//listView.HotTracking = true;//获取或设置一个值，该值指示当鼠标指针经过某个项或子项的文本时，文本的外观是否变为超链接的形式。
										//listView.Activation = ItemActivation.Standard;//激活某一项时,必须执行的操作是（如：双击项或者单击项）
										//listView.ResumeLayout( false );
			return listView;
		}

		/// <summary>
		/// 初始化列头
		/// </summary>
		/// <returns></returns>
		private ColumnHeader[] Init_ColumnHeader() {
			//准备数据
			string[] columnName = new[]{
				"组合键",
				"注 释"
			};
			int[] width = new[] { 200, 256 };

			columnHeader = new ColumnHeader[columnName.Length];
			for (var i = 0; i < columnHeader.Length; i++) {
				columnHeader[i] = new ColumnHeader();
				columnHeader[i].Width = width[i];
				columnHeader[i].Text = columnName[i];
				columnHeader[i].TextAlign = HorizontalAlignment.Left;
			}


			return columnHeader;
		}

		/// <summary>
		/// 初始化 (项) item 列表数据
		/// </summary>
		/// <returns></returns>
		private ListViewItem[] Init_ListViewItem() {
			ListViewItem[] vLvi = new ListViewItem[10];
			for (int i = 0; i < vLvi.Length; i++) {

				ListViewItem.ListViewSubItem[] item = new ListViewItem.ListViewSubItem[2];
				for (var i1 = 0; i1 < item.Length; i1++) {
					item[i1] = new ListViewItem.ListViewSubItem();
					item[i1].Text = "第" + ( i1 + 1 ) + "列,第" + i + "行";

				}
				vLvi[i] = new ListViewItem();
				vLvi[i].ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标 
				vLvi[i].Text = "subitem" + i;
				vLvi[i].SubItems.AddRange( item );
				vLvi[i].UseItemStyleForSubItems = true;

			}

			return vLvi;
		}

		#endregion 始化方法

		#region 处理流程


		#endregion 处理流程

		/// <summary>
		/// 构造函数
		/// </summary>
		public ListView_Mouse_Hotkey() {

			//初始化
			this.listView = Init_ListView();
			this.columnHeader = Init_ColumnHeader();
			this.listViewItem = Init_ListViewItem();
			this.contextMenuStrip = Init_ContextMenuStrip();

			//添加数据
			listView.Columns.AddRange( this.columnHeader );//添加列
														   //listView.Items.AddRange( listViewItem );//添加项
			listView.ContextMenuStrip = this.contextMenuStrip;//添加右键菜单
		}
	}
}
