﻿namespace app {
    partial class Hk_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.resultinfo = new System.Windows.Forms.TextBox();
            this.stopkeyboard = new System.Windows.Forms.Button();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Location = new System.Drawing.Point(202, 63);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "开始监控";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stop.Location = new System.Drawing.Point(295, 63);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 1;
            this.stop.Text = "恢复正常";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // resultinfo
            // 
            this.resultinfo.Location = new System.Drawing.Point(202, 92);
            this.resultinfo.Multiline = true;
            this.resultinfo.Name = "resultinfo";
            this.resultinfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultinfo.Size = new System.Drawing.Size(259, 291);
            this.resultinfo.TabIndex = 2;
            this.resultinfo.Text = "监控键盘和鼠标的操作记录：";
            // 
            // stopkeyboard
            // 
            this.stopkeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopkeyboard.Location = new System.Drawing.Point(386, 63);
            this.stopkeyboard.Name = "stopkeyboard";
            this.stopkeyboard.Size = new System.Drawing.Size(75, 23);
            this.stopkeyboard.TabIndex = 3;
            this.stopkeyboard.Text = "屏蔽键盘";
            this.stopkeyboard.UseVisualStyleBackColor = true;
            this.stopkeyboard.Click += new System.EventHandler(this.stopkeyboard_Click);
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMousePosition.Location = new System.Drawing.Point(202, 392);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(43, 14);
            this.labelMousePosition.TabIndex = 4;
            this.labelMousePosition.Text = "label1";
            // 
            // Hk_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 458);
            this.Controls.Add(this.labelMousePosition);
            this.Controls.Add(this.stopkeyboard);
            this.Controls.Add(this.resultinfo);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Name = "Hk_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hk_Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Hk_Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox resultinfo;
        private System.Windows.Forms.Button stopkeyboard;
        private System.Windows.Forms.Label labelMousePosition;

    }
}