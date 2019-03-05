using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lwm.CustomControls {
	/// <summary>
	/// 基于 FlowLayoutPanel 的列表
	/// </summary>
	public class Controls_FlpList {
		#region 私有变量

		/// <summary>
		/// 记录集合
		/// </summary>
		private List<Record> recordAll = new List<Record>();

		/// <summary>
		/// 生成本对象的初始配置
		/// </summary>
		private Attr_C attr;


		#endregion 私有变量


		/// <summary>
		/// 基于 FlowLayoutPanel 的 列表
		/// </summary>
		public FlowLayoutPanel Flp_list = new FlowLayoutPanel();


		/// <summary>
		/// 上一次选中的索引
		/// </summary>
		private int selected_Index = 0;

		/// <summary>
		/// 设置或者读取当前选中项,如果未选中任何项就 值默认为 0
		/// </summary>
		public int Selected_Index {
			get { return selected_Index; }
			set {
				//如果索引不超出
				if (value < recordAll.Count && recordAll.Count != 0) {
					Console.WriteLine( Selected_Index.Equals( 0 ) );
					recordAll[selected_Index].vContainer.BackColor = System.Drawing.SystemColors.Control;//还原上一次的	
																										 //设置本次记录
					recordAll[value].vContainer.BackColor = System.Drawing.SystemColors.ActiveBorder;//设置新的
					selected_Index = value;
				}

			}
		}

		/// <summary>
		/// 选择上下一条记录,真=下一条,false=上一条
		/// </summary>
		public int Select_UpDown_Item(Boolean add_And_Subtract) {
			if (add_And_Subtract) {
				if (selected_Index + 1 < recordAll.Count) {
					Selected_Index = selected_Index + 1;
				}
			} else {
				if (selected_Index - 1 >= 0) {
					Selected_Index = selected_Index - 1;
				}
			}
			return 0;
		}

		/// <summary>
		///  添加一条记录
		/// </summary>
		/// <param name="value1">值一</param>
		/// <param name="value2">值二</param>
		/// <param name="value1_Percent">值一占用的百分比</param>
		/// <param name="value2_Percent">值二占用的百分比</param>
		public void Add_Record(string value1, string value2, float value1_Percent = 40f, float value2_Percent = 59F) {
			Record.Attr_C vRa = new Record.Attr_C();
			vRa.width = attr.width;
			vRa.height = attr.Record_height;
			vRa.value1_Percent = value1_Percent;
			vRa.value2_Percent = value2_Percent;
			vRa.value1_Text = value1;
			vRa.value2_Text = value2;
			Record record = new Record( vRa );
			Flp_list.Controls.Add( record.vContainer );
			this.recordAll.Add( record );
		}

		#region 子类

		/// <summary>
		/// 配置类
		/// </summary>
		public class Attr_C {
			/// <summary>
			/// 位于父容器水平的坐标 默认0
			/// </summary>
			public int location_X = 0;

			/// <summary>
			/// 位于父容器的垂直坐标 默认0
			/// </summary>
			public int location_Y = 0;

			/// <summary>
			/// 控件宽度 默认512
			/// </summary>
			public int width = 512;

			/// <summary>
			/// 控件高度 默认512
			/// </summary>
			public int height = 512;

			/// <summary>
			/// 控件排序方向 默认 FlowDirection.TopDown 从上到下
			/// </summary>
			public FlowDirection flowDirection = FlowDirection.TopDown;

			/// <summary>
			/// 是否自动自适应控件大小 默认 true
			/// </summary>
			public Boolean autoSize = true;

			/// <summary>
			/// 每条记录的高度
			/// </summary>
			public int Record_height = 42;

			/// <summary>
			/// 指定的位置和控件停靠的方式。默认 Fill
			/// </summary>
			public DockStyle dock = DockStyle.Fill;
		}

		/// <summary>
		/// 生成一条记录控件
		/// </summary>
		private class Record {

			/// <summary>
			/// TableLayoutPanel 容器
			/// </summary>
			public readonly TableLayoutPanel vContainer = new System.Windows.Forms.TableLayoutPanel();

			/// <summary>
			/// 值1
			/// </summary>
			public readonly Label value1 = new System.Windows.Forms.Label();

			/// <summary>
			/// 值2
			/// </summary>
			public readonly Label value2 = new System.Windows.Forms.Label();

			public class Attr_C {

				/// <summary>
				/// 值一
				/// </summary>
				public string value1_Text;

				/// <summary>
				/// 值二
				/// </summary>
				public string value2_Text;

				/// <summary>
				/// 宽度 默认600
				/// </summary> 
				public int width = 220;

				/// <summary>
				/// 高度 默认42
				/// </summary>
				public int height = 42;

				/// <summary>
				/// 值一占用的百分比
				/// </summary>
				public float value1_Percent = 40F;

				/// <summary>
				/// 值二占用的百分比
				/// </summary>
				public float value2_Percent = 60F;
			}

			public Record(Attr_C attr) {

				// label_1
				this.value1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.value1.Name = attr.value1_Text;
				this.value1.Text = attr.value1_Text;
				this.value1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				//label_2
				this.value2.Dock = System.Windows.Forms.DockStyle.Fill;
				this.value2.Name = attr.value2_Text;
				this.value2.Text = attr.value2_Text;
				this.value2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;


				this.vContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
				//储存列的数量,没有实际意义
				this.vContainer.ColumnCount = 2;
				//储存行的数量,没有实际意义
				this.vContainer.RowCount = 1;
				//添加行
				this.vContainer.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
				//添加列
				this.vContainer.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, attr.value1_Percent ) );
				this.vContainer.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, attr.value2_Percent ) );
				//添加组件到列 (列,行)
				this.vContainer.Controls.Add( this.value1, 0, 0 );
				this.vContainer.Controls.Add( this.value2, 1, 0 );
				//控件信息
				this.vContainer.Margin = new System.Windows.Forms.Padding( 0 );
				this.vContainer.Name = "单条记录";

				this.vContainer.Size = new System.Drawing.Size( attr.width, attr.height );//大小

			}
		}

		#endregion

		public Controls_FlpList(Attr_C attr) {
			this.Selected_Index = 0;
			this.attr = attr;
			this.Flp_list.Dock = attr.dock;//指定的位置和控件停靠的方式。
			this.Flp_list.AutoSize = attr.autoSize;//自动适应子元素最大宽度
			this.Flp_list.FlowDirection = attr.flowDirection;//控件排序方向
			this.Flp_list.Location = new System.Drawing.Point( attr.location_X, attr.location_X );
			this.Flp_list.Margin = new System.Windows.Forms.Padding( 0 );
			this.Flp_list.Name = "FlowLayoutPanel 列表";
			this.Flp_list.Size = new System.Drawing.Size( attr.width, attr.height );

		}
	}
}
