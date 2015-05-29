namespace HookKeyV2
{
    partial class KeyV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartAndStop = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.oriKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tarKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFlip = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.txtChangeTar = new System.Windows.Forms.TextBox();
            this.txtChangeOri = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAddTar = new System.Windows.Forms.TextBox();
            this.txtAddOri = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartAndStop
            // 
            this.btnStartAndStop.Location = new System.Drawing.Point(26, 6);
            this.btnStartAndStop.Name = "btnStartAndStop";
            this.btnStartAndStop.Size = new System.Drawing.Size(78, 27);
            this.btnStartAndStop.TabIndex = 0;
            this.btnStartAndStop.Text = "开始";
            this.btnStartAndStop.UseVisualStyleBackColor = true;
            this.btnStartAndStop.Click += new System.EventHandler(this.btnStartAndStop_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "Version:2.00     Made by HZ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.oriKey,
            this.tarKey});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(7, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(237, 197);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // oriKey
            // 
            this.oriKey.Text = "原按键";
            this.oriKey.Width = 116;
            // 
            // tarKey
            // 
            this.tarKey.Text = "目标按键";
            this.tarKey.Width = 116;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlFlip);
            this.panel1.Controls.Add(this.btnStartAndStop);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 49);
            this.panel1.TabIndex = 19;
            // 
            // pnlFlip
            // 
            this.pnlFlip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFlip.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.pnlFlip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFlip.Location = new System.Drawing.Point(0, 39);
            this.pnlFlip.Name = "pnlFlip";
            this.pnlFlip.Size = new System.Drawing.Size(404, 10);
            this.pnlFlip.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 243);
            this.panel2.TabIndex = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Location = new System.Drawing.Point(271, 186);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(126, 48);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "删除当前按键";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(26, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 25);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChange);
            this.groupBox3.Controls.Add(this.txtChangeTar);
            this.groupBox3.Controls.Add(this.txtChangeOri);
            this.groupBox3.Location = new System.Drawing.Point(271, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(126, 78);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "修改当前按键";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(84, 20);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(32, 50);
            this.btnChange.TabIndex = 5;
            this.btnChange.TabStop = false;
            this.btnChange.Text = "修改";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtChangeTar
            // 
            this.txtChangeTar.Location = new System.Drawing.Point(12, 47);
            this.txtChangeTar.Name = "txtChangeTar";
            this.txtChangeTar.Size = new System.Drawing.Size(67, 21);
            this.txtChangeTar.TabIndex = 4;
            this.txtChangeTar.TabStop = false;
            // 
            // txtChangeOri
            // 
            this.txtChangeOri.Location = new System.Drawing.Point(12, 20);
            this.txtChangeOri.Name = "txtChangeOri";
            this.txtChangeOri.Size = new System.Drawing.Size(67, 21);
            this.txtChangeOri.TabIndex = 3;
            this.txtChangeOri.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtAddTar);
            this.groupBox2.Controls.Add(this.txtAddOri);
            this.groupBox2.Location = new System.Drawing.Point(271, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 78);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加新按键";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(84, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 50);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAddTar
            // 
            this.txtAddTar.Location = new System.Drawing.Point(12, 47);
            this.txtAddTar.Name = "txtAddTar";
            this.txtAddTar.Size = new System.Drawing.Size(67, 21);
            this.txtAddTar.TabIndex = 1;
            this.txtAddTar.TabStop = false;
            // 
            // txtAddOri
            // 
            this.txtAddOri.Location = new System.Drawing.Point(12, 20);
            this.txtAddOri.Name = "txtAddOri";
            this.txtAddOri.Size = new System.Drawing.Size(67, 21);
            this.txtAddOri.TabIndex = 0;
            this.txtAddOri.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 224);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已设置按键";
            // 
            // KeyV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 292);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyV2";
            this.Text = "KeyV2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartAndStop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader oriKey;
        private System.Windows.Forms.ColumnHeader tarKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlFlip;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAddTar;
        private System.Windows.Forms.TextBox txtAddOri;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.TextBox txtChangeTar;
        private System.Windows.Forms.TextBox txtChangeOri;
    }
}