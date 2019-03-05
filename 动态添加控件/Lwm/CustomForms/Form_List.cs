using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwm.Window;

namespace Lwm.CustomForms {
	public partial class Form_List : Form {
		public Form_List() {
			InitializeComponent();
		}

		private void button4_Click(object sender, EventArgs e) {
			//button1.Focus();
			//control.Focus();
		}
		private Button button_测试按钮;
		private Panel panel_模板;
		private TableLayoutPanel tableLayoutPanel_成员;
		private Label label_按键;
		private Label label_注释;
		private FlowLayoutPanel flowLayoutPanel_列表;
		private TableLayoutPanel tableLayoutPanel1;
		private Label label1;
		private Label label2;
		private TableLayoutPanel tableLayoutPanel2;
		private Label label3;
		private Label label4;
		private TableLayoutPanel tableLayoutPanel3;
		private Label label5;
		private Label label6;
		private FlowLayoutPanel flowLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel6;
		private Label label9;
		private Label label10;
		private TableLayoutPanel tableLayoutPanel7;
		private Label label11;
		private Label label12;
		private FlowLayoutPanel flowLayoutPanel2;
		private FlowLayoutPanel flowLayoutPanel3;
		private TableLayoutPanel tableLayoutPanel5;
		private Label label7;
		private Label label8;
		private TableLayoutPanel tableLayoutPanel8;
		private Label label13;
		private Label label14;
		private TableLayoutPanel tableLayoutPanel9;
		private Label label15;
		private Label label16;
		private Panel panel1;






		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <attr name="disposing">true if managed resources should be disposed; otherwise, false.</attr>
		protected override void Dispose(bool disposing) {
			if (disposing && ( components != null )) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_测试按钮 = new System.Windows.Forms.Button();
			this.panel_模板 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tableLayoutPanel_成员 = new System.Windows.Forms.TableLayoutPanel();
			this.label_按键 = new System.Windows.Forms.Label();
			this.label_注释 = new System.Windows.Forms.Label();
			this.flowLayoutPanel_列表 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel4.SuspendLayout();
			this.panel_模板.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			this.tableLayoutPanel_成员.SuspendLayout();
			this.flowLayoutPanel_列表.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 23.15436F ) );
			this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 43.1208F ) );
			this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 33.33333F ) );
			this.tableLayoutPanel4.Controls.Add( this.textBox2, 0, 0 );
			this.tableLayoutPanel4.Controls.Add( this.button1, 2, 0 );
			this.tableLayoutPanel4.Controls.Add( this.textBox1, 1, 0 );
			this.tableLayoutPanel4.Location = new System.Drawing.Point( 21, 912 );
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 35F ) );
			this.tableLayoutPanel4.Size = new System.Drawing.Size( 598, 37 );
			this.tableLayoutPanel4.TabIndex = 24;
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox2.Font = new System.Drawing.Font( "微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
			this.textBox2.Location = new System.Drawing.Point( 2, 2 );
			this.textBox2.Margin = new System.Windows.Forms.Padding( 0 );
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size( 137, 32 );
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "快捷键";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox2.WordWrap = false;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point( 398, 2 );
			this.button1.Margin = new System.Windows.Forms.Padding( 0 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 198, 33 );
			this.button1.TabIndex = 3;
			this.button1.Text = "添加快捷键";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font( "微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
			this.textBox1.Location = new System.Drawing.Point( 141, 2 );
			this.textBox1.Margin = new System.Windows.Forms.Padding( 0 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 255, 32 );
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "注释内容";
			this.textBox1.WordWrap = false;
			// 
			// button_测试按钮
			// 
			this.button_测试按钮.Location = new System.Drawing.Point( 21, 711 );
			this.button_测试按钮.Name = "button_测试按钮";
			this.button_测试按钮.Size = new System.Drawing.Size( 127, 38 );
			this.button_测试按钮.TabIndex = 26;
			this.button_测试按钮.Text = "button2";
			this.button_测试按钮.UseVisualStyleBackColor = true;
			this.button_测试按钮.Click += new System.EventHandler( this.button2_Click );
			// 
			// panel_模板
			// 
			this.panel_模板.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_模板.Controls.Add( this.tableLayoutPanel9 );
			this.panel_模板.Controls.Add( this.tableLayoutPanel_成员 );
			this.panel_模板.Controls.Add( this.flowLayoutPanel_列表 );
			this.panel_模板.Location = new System.Drawing.Point( 21, 12 );
			this.panel_模板.Name = "panel_模板";
			this.panel_模板.Size = new System.Drawing.Size( 625, 583 );
			this.panel_模板.TabIndex = 28;
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.tableLayoutPanel9.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel9.ColumnCount = 2;
			this.tableLayoutPanel9.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel9.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel9.Controls.Add( this.label15, 0, 0 );
			this.tableLayoutPanel9.Controls.Add( this.label16, 1, 0 );
			this.tableLayoutPanel9.Location = new System.Drawing.Point( 9, 453 );
			this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel9.Size = new System.Drawing.Size( 598, 42 );
			this.tableLayoutPanel9.TabIndex = 28;
			// 
			// label15
			// 
			this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label15.Location = new System.Drawing.Point( 5, 2 );
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size( 141, 38 );
			this.label15.TabIndex = 2;
			this.label15.Text = "Ctrl+Shift+A";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label16
			// 
			this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label16.Location = new System.Drawing.Point( 154, 2 );
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size( 439, 38 );
			this.label16.TabIndex = 1;
			this.label16.Text = "label4";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel_成员
			// 
			this.tableLayoutPanel_成员.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanel_成员.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel_成员.ColumnCount = 2;
			this.tableLayoutPanel_成员.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel_成员.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel_成员.Controls.Add( this.label_按键, 0, 0 );
			this.tableLayoutPanel_成员.Controls.Add( this.label_注释, 1, 0 );
			this.tableLayoutPanel_成员.Location = new System.Drawing.Point( 9, 505 );
			this.tableLayoutPanel_成员.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel_成员.Name = "tableLayoutPanel_成员";
			this.tableLayoutPanel_成员.RowCount = 1;
			this.tableLayoutPanel_成员.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel_成员.Size = new System.Drawing.Size( 598, 42 );
			this.tableLayoutPanel_成员.TabIndex = 27;
			// 
			// label_按键
			// 
			this.label_按键.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label_按键.Location = new System.Drawing.Point( 5, 2 );
			this.label_按键.Name = "label_按键";
			this.label_按键.Size = new System.Drawing.Size( 141, 38 );
			this.label_按键.TabIndex = 2;
			this.label_按键.Text = "Ctrl+Shift+A";
			this.label_按键.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_注释
			// 
			this.label_注释.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label_注释.Location = new System.Drawing.Point( 154, 2 );
			this.label_注释.Name = "label_注释";
			this.label_注释.Size = new System.Drawing.Size( 439, 38 );
			this.label_注释.TabIndex = 1;
			this.label_注释.Text = "label4";
			this.label_注释.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel_列表
			// 
			this.flowLayoutPanel_列表.AutoSize = true;
			this.flowLayoutPanel_列表.Controls.Add( this.tableLayoutPanel1 );
			this.flowLayoutPanel_列表.Controls.Add( this.tableLayoutPanel2 );
			this.flowLayoutPanel_列表.Controls.Add( this.tableLayoutPanel3 );
			this.flowLayoutPanel_列表.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel_列表.Location = new System.Drawing.Point( 9, 9 );
			this.flowLayoutPanel_列表.Margin = new System.Windows.Forms.Padding( 0 );
			this.flowLayoutPanel_列表.Name = "flowLayoutPanel_列表";
			this.flowLayoutPanel_列表.Size = new System.Drawing.Size( 602, 376 );
			this.flowLayoutPanel_列表.TabIndex = 26;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel1.Controls.Add( this.label1, 0, 0 );
			this.tableLayoutPanel1.Controls.Add( this.label2, 1, 0 );
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 598, 42 );
			this.tableLayoutPanel1.TabIndex = 28;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point( 5, 2 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 141, 38 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Ctrl+Shift+A";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point( 154, 2 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 439, 38 );
			this.label2.TabIndex = 1;
			this.label2.Text = "label4";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel2.Controls.Add( this.label3, 0, 0 );
			this.tableLayoutPanel2.Controls.Add( this.label4, 1, 0 );
			this.tableLayoutPanel2.Location = new System.Drawing.Point( 0, 42 );
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel2.Size = new System.Drawing.Size( 598, 42 );
			this.tableLayoutPanel2.TabIndex = 29;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point( 5, 2 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 141, 38 );
			this.label3.TabIndex = 2;
			this.label3.Text = "Ctrl+Shift+A";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point( 154, 2 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 439, 38 );
			this.label4.TabIndex = 1;
			this.label4.Text = "label4";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel3.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel3.Controls.Add( this.label5, 0, 0 );
			this.tableLayoutPanel3.Controls.Add( this.label6, 1, 0 );
			this.tableLayoutPanel3.Location = new System.Drawing.Point( 0, 84 );
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel3.Size = new System.Drawing.Size( 598, 42 );
			this.tableLayoutPanel3.TabIndex = 30;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point( 5, 2 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 141, 38 );
			this.label5.TabIndex = 2;
			this.label5.Text = "Ctrl+Shift+A";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.Location = new System.Drawing.Point( 154, 2 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 439, 38 );
			this.label6.TabIndex = 1;
			this.label6.Text = "label4";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add( this.tableLayoutPanel6 );
			this.flowLayoutPanel1.Controls.Add( this.tableLayoutPanel7 );
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point( 681, 12 );
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding( 0 );
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size( 536, 175 );
			this.flowLayoutPanel1.TabIndex = 27;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel6.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel6.Controls.Add( this.label9, 0, 0 );
			this.tableLayoutPanel6.Controls.Add( this.label10, 1, 0 );
			this.tableLayoutPanel6.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel6.Size = new System.Drawing.Size( 478, 42 );
			this.tableLayoutPanel6.TabIndex = 29;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point( 5, 2 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 111, 38 );
			this.label9.TabIndex = 2;
			this.label9.Text = "Ctrl+Shift+A";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label10.Location = new System.Drawing.Point( 124, 2 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 349, 38 );
			this.label10.TabIndex = 1;
			this.label10.Text = "label10";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel7.ColumnCount = 2;
			this.tableLayoutPanel7.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel7.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel7.Controls.Add( this.label11, 0, 0 );
			this.tableLayoutPanel7.Controls.Add( this.label12, 1, 0 );
			this.tableLayoutPanel7.Location = new System.Drawing.Point( 0, 42 );
			this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel7.Size = new System.Drawing.Size( 478, 42 );
			this.tableLayoutPanel7.TabIndex = 30;
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label11.Location = new System.Drawing.Point( 5, 2 );
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size( 111, 38 );
			this.label11.TabIndex = 2;
			this.label11.Text = "Ctrl+Shift+A";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label12.Location = new System.Drawing.Point( 124, 2 );
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size( 349, 38 );
			this.label12.TabIndex = 1;
			this.label12.Text = "label4";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add( this.flowLayoutPanel3 );
			this.flowLayoutPanel2.Controls.Add( this.panel1 );
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point( 672, 348 );
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size( 604, 501 );
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.Controls.Add( this.tableLayoutPanel5 );
			this.flowLayoutPanel3.Controls.Add( this.tableLayoutPanel8 );
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel3.Location = new System.Drawing.Point( 0, 0 );
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding( 0 );
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size( 478, 84 );
			this.flowLayoutPanel3.TabIndex = 28;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel5.ColumnCount = 2;
			this.tableLayoutPanel5.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel5.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel5.Controls.Add( this.label7, 0, 0 );
			this.tableLayoutPanel5.Controls.Add( this.label8, 1, 0 );
			this.tableLayoutPanel5.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel5.Size = new System.Drawing.Size( 478, 42 );
			this.tableLayoutPanel5.TabIndex = 29;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Location = new System.Drawing.Point( 5, 2 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 111, 38 );
			this.label7.TabIndex = 2;
			this.label7.Text = "Ctrl+Shift+A";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Location = new System.Drawing.Point( 124, 2 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 349, 38 );
			this.label8.TabIndex = 1;
			this.label8.Text = "label8";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel8.ColumnCount = 2;
			this.tableLayoutPanel8.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 24.92669F ) );
			this.tableLayoutPanel8.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 75.07331F ) );
			this.tableLayoutPanel8.Controls.Add( this.label13, 0, 0 );
			this.tableLayoutPanel8.Controls.Add( this.label14, 1, 0 );
			this.tableLayoutPanel8.Location = new System.Drawing.Point( 0, 42 );
			this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding( 0 );
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel8.Size = new System.Drawing.Size( 478, 42 );
			this.tableLayoutPanel8.TabIndex = 30;
			// 
			// label13
			// 
			this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label13.Location = new System.Drawing.Point( 5, 2 );
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size( 111, 38 );
			this.label13.TabIndex = 2;
			this.label13.Text = "Ctrl+Shift+A";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label14.Location = new System.Drawing.Point( 124, 2 );
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size( 349, 38 );
			this.label14.TabIndex = 1;
			this.label14.Text = "label4";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point( 3, 87 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 589, 298 );
			this.panel1.TabIndex = 29;
			// 
			// Form_List
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 10F, 21F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 1316, 1002 );
			this.Controls.Add( this.flowLayoutPanel2 );
			this.Controls.Add( this.flowLayoutPanel1 );
			this.Controls.Add( this.panel_模板 );
			this.Controls.Add( this.button_测试按钮 );
			this.Controls.Add( this.tableLayoutPanel4 );
			this.Font = new System.Drawing.Font( "微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ) );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding( 5 );
			this.Name = "Form_List";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form_Test";
			this.Load += new System.EventHandler( this.Form_List_Load );
			this.tableLayoutPanel4.ResumeLayout( false );
			this.tableLayoutPanel4.PerformLayout();
			this.panel_模板.ResumeLayout( false );
			this.panel_模板.PerformLayout();
			this.tableLayoutPanel9.ResumeLayout( false );
			this.tableLayoutPanel_成员.ResumeLayout( false );
			this.flowLayoutPanel_列表.ResumeLayout( false );
			this.tableLayoutPanel1.ResumeLayout( false );
			this.tableLayoutPanel2.ResumeLayout( false );
			this.tableLayoutPanel3.ResumeLayout( false );
			this.flowLayoutPanel1.ResumeLayout( false );
			this.tableLayoutPanel6.ResumeLayout( false );
			this.tableLayoutPanel7.ResumeLayout( false );
			this.flowLayoutPanel2.ResumeLayout( false );
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout( false );
			this.tableLayoutPanel5.ResumeLayout( false );
			this.tableLayoutPanel8.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

			

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;

		private void Form_List_Load(object sender, EventArgs e) {

		}

		private Flp_List list;
		private void button2_Click(object sender, EventArgs e) {


			int width = 450;
			New_Window newWindow = new New_Window( new New_Window.Attr_C() { width = width } );

			//创建一个列表
			list = new Flp_List( new Flp_List.Attr_C() { width = width } );
			for (int i = 0; i < 10; i++) {
				list.Add_Record( "按键" + i, "注释" + i );
			}

			newWindow.Controls.Add( list.Flp_list );
			newWindow.Show();
			list.Select_UpDown_Item( true );
		}


	}

	/// <summary>
	/// 基于 FlowLayoutPanel 的列表
	/// </summary>
	public class Flp_List {
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
		public void Add_Record(string value1, string value2, float value1_Percent = 33.33F, float value2_Percent = 66.666F) {
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
				public int width = 600;

				/// <summary>
				/// 高度 默认42
				/// </summary>
				public int height = 42;

				/// <summary>
				/// 值一占用的百分比
				/// </summary>
				public float value1_Percent = 24F;

				/// <summary>
				/// 值二占用的百分比
				/// </summary>
				public float value2_Percent = 76F;
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

		public Flp_List(Attr_C attr) {
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
