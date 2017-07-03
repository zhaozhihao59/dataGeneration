namespace dataGeneration
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_linked = new System.Windows.Forms.Button();
            this.cbb_huihuaList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_tableList = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gb_date = new System.Windows.Forms.GroupBox();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_number = new System.Windows.Forms.GroupBox();
            this.rb_rd = new System.Windows.Forms.RadioButton();
            this.rb_zzz = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_max = new System.Windows.Forms.TextBox();
            this.tb_seed = new System.Windows.Forms.TextBox();
            this.tb_zzzNum = new System.Windows.Forms.TextBox();
            this.tb_min = new System.Windows.Forms.TextBox();
            this.gb_str = new System.Windows.Forms.GroupBox();
            this.cbb_str = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_generation = new System.Windows.Forms.Button();
            this.tb_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tm_scheduler = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb_date.SuspendLayout();
            this.gb_number.SuspendLayout();
            this.gb_str.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(458, 35);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 23);
            this.btn_setting.TabIndex = 5;
            this.btn_setting.Text = "设置";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_linked
            // 
            this.btn_linked.Location = new System.Drawing.Point(348, 35);
            this.btn_linked.Name = "btn_linked";
            this.btn_linked.Size = new System.Drawing.Size(75, 23);
            this.btn_linked.TabIndex = 6;
            this.btn_linked.Text = "连接";
            this.btn_linked.UseVisualStyleBackColor = true;
            this.btn_linked.Click += new System.EventHandler(this.btn_linked_Click);
            // 
            // cbb_huihuaList
            // 
            this.cbb_huihuaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_huihuaList.FormattingEnabled = true;
            this.cbb_huihuaList.Items.AddRange(new object[] {
            "--请选择会话--"});
            this.cbb_huihuaList.Location = new System.Drawing.Point(146, 34);
            this.cbb_huihuaList.Name = "cbb_huihuaList";
            this.cbb_huihuaList.Size = new System.Drawing.Size(167, 20);
            this.cbb_huihuaList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(51, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择会话";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_tableList);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 727);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表信息";
            // 
            // tv_tableList
            // 
            this.tv_tableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_tableList.Font = new System.Drawing.Font("隶书", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_tableList.Location = new System.Drawing.Point(3, 17);
            this.tv_tableList.Name = "tv_tableList";
            this.tv_tableList.Size = new System.Drawing.Size(515, 707);
            this.tv_tableList.TabIndex = 0;
            this.tv_tableList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_tableList_AfterCheck);
            this.tv_tableList.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_tableList_BeforeSelect);
            this.tv_tableList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_tableList_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gb_date);
            this.groupBox2.Controls.Add(this.gb_number);
            this.groupBox2.Controls.Add(this.gb_str);
            this.groupBox2.Location = new System.Drawing.Point(539, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 727);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "类型设置";
            // 
            // gb_date
            // 
            this.gb_date.Controls.Add(this.dtp_end);
            this.gb_date.Controls.Add(this.label7);
            this.gb_date.Controls.Add(this.dtp_start);
            this.gb_date.Controls.Add(this.label6);
            this.gb_date.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_date.Location = new System.Drawing.Point(3, 473);
            this.gb_date.Name = "gb_date";
            this.gb_date.Size = new System.Drawing.Size(717, 251);
            this.gb_date.TabIndex = 2;
            this.gb_date.TabStop = false;
            this.gb_date.Text = "日期类型";
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(128, 92);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(200, 21);
            this.dtp_end.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(42, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "结束日期:";
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(128, 42);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(200, 21);
            this.dtp_start.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(42, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "开始日期:";
            // 
            // gb_number
            // 
            this.gb_number.Controls.Add(this.rb_rd);
            this.gb_number.Controls.Add(this.rb_zzz);
            this.gb_number.Controls.Add(this.label5);
            this.gb_number.Controls.Add(this.label4);
            this.gb_number.Controls.Add(this.tb_max);
            this.gb_number.Controls.Add(this.tb_seed);
            this.gb_number.Controls.Add(this.tb_zzzNum);
            this.gb_number.Controls.Add(this.tb_min);
            this.gb_number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_number.Location = new System.Drawing.Point(3, 214);
            this.gb_number.Name = "gb_number";
            this.gb_number.Size = new System.Drawing.Size(717, 510);
            this.gb_number.TabIndex = 1;
            this.gb_number.TabStop = false;
            this.gb_number.Text = "数字类型";
            // 
            // rb_rd
            // 
            this.rb_rd.AutoSize = true;
            this.rb_rd.Checked = true;
            this.rb_rd.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_rd.Location = new System.Drawing.Point(407, 77);
            this.rb_rd.Name = "rb_rd";
            this.rb_rd.Size = new System.Drawing.Size(90, 20);
            this.rb_rd.TabIndex = 14;
            this.rb_rd.TabStop = true;
            this.rb_rd.Text = "随机种子";
            this.rb_rd.UseVisualStyleBackColor = true;
            this.rb_rd.CheckedChanged += new System.EventHandler(this.rb_rd_CheckedChanged);
            // 
            // rb_zzz
            // 
            this.rb_zzz.AutoSize = true;
            this.rb_zzz.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_zzz.Location = new System.Drawing.Point(407, 34);
            this.rb_zzz.Name = "rb_zzz";
            this.rb_zzz.Size = new System.Drawing.Size(74, 20);
            this.rb_zzz.TabIndex = 14;
            this.rb_zzz.TabStop = true;
            this.rb_zzz.Text = "自增长";
            this.rb_zzz.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(41, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "最大值:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(41, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "最小值:";
            // 
            // tb_max
            // 
            this.tb_max.Location = new System.Drawing.Point(111, 74);
            this.tb_max.Name = "tb_max";
            this.tb_max.Size = new System.Drawing.Size(100, 21);
            this.tb_max.TabIndex = 12;
            this.tb_max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_min_KeyPress);
            // 
            // tb_seed
            // 
            this.tb_seed.Location = new System.Drawing.Point(508, 74);
            this.tb_seed.Name = "tb_seed";
            this.tb_seed.Size = new System.Drawing.Size(100, 21);
            this.tb_seed.TabIndex = 12;
            this.tb_seed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_min_KeyPress);
            // 
            // tb_zzzNum
            // 
            this.tb_zzzNum.Location = new System.Drawing.Point(508, 36);
            this.tb_zzzNum.Name = "tb_zzzNum";
            this.tb_zzzNum.Size = new System.Drawing.Size(100, 21);
            this.tb_zzzNum.TabIndex = 12;
            this.tb_zzzNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_min_KeyPress);
            // 
            // tb_min
            // 
            this.tb_min.Location = new System.Drawing.Point(111, 31);
            this.tb_min.Name = "tb_min";
            this.tb_min.Size = new System.Drawing.Size(100, 21);
            this.tb_min.TabIndex = 12;
            this.tb_min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_min_KeyPress);
            // 
            // gb_str
            // 
            this.gb_str.Controls.Add(this.cbb_str);
            this.gb_str.Controls.Add(this.label3);
            this.gb_str.Cursor = System.Windows.Forms.Cursors.Default;
            this.gb_str.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_str.Location = new System.Drawing.Point(3, 17);
            this.gb_str.Name = "gb_str";
            this.gb_str.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gb_str.Size = new System.Drawing.Size(717, 197);
            this.gb_str.TabIndex = 0;
            this.gb_str.TabStop = false;
            this.gb_str.Text = "字符串类型";
            // 
            // cbb_str
            // 
            this.cbb_str.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_str.FormattingEnabled = true;
            this.cbb_str.Items.AddRange(new object[] {
            "random"});
            this.cbb_str.Location = new System.Drawing.Point(111, 30);
            this.cbb_str.Name = "cbb_str";
            this.cbb_str.Size = new System.Drawing.Size(584, 20);
            this.cbb_str.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "生成规则:";
            // 
            // btn_generation
            // 
            this.btn_generation.Location = new System.Drawing.Point(1145, 27);
            this.btn_generation.Name = "btn_generation";
            this.btn_generation.Size = new System.Drawing.Size(117, 31);
            this.btn_generation.TabIndex = 5;
            this.btn_generation.Text = "生成";
            this.btn_generation.UseVisualStyleBackColor = true;
            this.btn_generation.Click += new System.EventHandler(this.btn_generation_Click);
            // 
            // tb_number
            // 
            this.tb_number.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_number.Location = new System.Drawing.Point(960, 30);
            this.tb_number.Name = "tb_number";
            this.tb_number.Size = new System.Drawing.Size(158, 26);
            this.tb_number.TabIndex = 9;
            this.tb_number.Text = "10000";
            this.tb_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_min_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(765, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "需要生成的条目数:";
            // 
            // tm_scheduler
            // 
            this.tm_scheduler.Enabled = true;
            this.tm_scheduler.Interval = 60000;
            this.tm_scheduler.Tick += new System.EventHandler(this.tm_scheduler_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 813);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_number);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_generation);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.btn_linked);
            this.Controls.Add(this.cbb_huihuaList);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "mainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gb_date.ResumeLayout(false);
            this.gb_date.PerformLayout();
            this.gb_number.ResumeLayout(false);
            this.gb_number.PerformLayout();
            this.gb_str.ResumeLayout(false);
            this.gb_str.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_linked;
        internal System.Windows.Forms.ComboBox cbb_huihuaList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_tableList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gb_number;
        private System.Windows.Forms.GroupBox gb_str;
        private System.Windows.Forms.Button btn_generation;
        private System.Windows.Forms.TextBox tb_number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_date;
        private System.Windows.Forms.RadioButton rb_rd;
        private System.Windows.Forms.RadioButton rb_zzz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_max;
        private System.Windows.Forms.TextBox tb_seed;
        private System.Windows.Forms.TextBox tb_zzzNum;
        private System.Windows.Forms.TextBox tb_min;
        private System.Windows.Forms.ComboBox cbb_str;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer tm_scheduler;
    }
}

