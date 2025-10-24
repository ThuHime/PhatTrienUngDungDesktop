namespace _2312760_BienTranAnhThu_KTGK
{
    partial class frmKhachHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaSo = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.mtbSDT = new System.Windows.Forms.MaskedTextBox();
            this.btnMacDinh = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdSDT = new System.Windows.Forms.RadioButton();
            this.rdTen = new System.Windows.Forms.RadioButton();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvKhachHang = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Địa chỉ giao hàng:";
            // 
            // txtMaSo
            // 
            this.txtMaSo.Location = new System.Drawing.Point(114, 11);
            this.txtMaSo.Name = "txtMaSo";
            this.txtMaSo.ReadOnly = true;
            this.txtMaSo.Size = new System.Drawing.Size(180, 20);
            this.txtMaSo.TabIndex = 1;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(114, 47);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(180, 20);
            this.txtTen.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(352, 47);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(293, 58);
            this.txtDiaChi.TabIndex = 1;
            // 
            // mtbSDT
            // 
            this.mtbSDT.Location = new System.Drawing.Point(114, 85);
            this.mtbSDT.Mask = "0000000000";
            this.mtbSDT.Name = "mtbSDT";
            this.mtbSDT.Size = new System.Drawing.Size(180, 20);
            this.mtbSDT.TabIndex = 2;
            // 
            // btnMacDinh
            // 
            this.btnMacDinh.Location = new System.Drawing.Point(238, 125);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(75, 23);
            this.btnMacDinh.TabIndex = 3;
            this.btnMacDinh.Text = "Mặc định";
            this.btnMacDinh.UseVisualStyleBackColor = true;
            this.btnMacDinh.Click += new System.EventHandler(this.btnMacDinh_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(352, 125);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdSDT);
            this.groupBox1.Controls.Add(this.rdTen);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Location = new System.Drawing.Point(271, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // rdSDT
            // 
            this.rdSDT.AutoSize = true;
            this.rdSDT.Location = new System.Drawing.Point(103, 19);
            this.rdSDT.Name = "rdSDT";
            this.rdSDT.Size = new System.Drawing.Size(75, 17);
            this.rdSDT.TabIndex = 0;
            this.rdSDT.Text = "Theo SDT";
            this.rdSDT.UseVisualStyleBackColor = true;
            // 
            // rdTen
            // 
            this.rdTen.AutoSize = true;
            this.rdTen.Checked = true;
            this.rdTen.Location = new System.Drawing.Point(24, 19);
            this.rdTen.Name = "rdTen";
            this.rdTen.Size = new System.Drawing.Size(68, 17);
            this.rdTen.TabIndex = 0;
            this.rdTen.TabStop = true;
            this.rdTen.Text = "Theo tên";
            this.rdTen.UseVisualStyleBackColor = true;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(188, 16);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(180, 20);
            this.txtTim.TabIndex = 1;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Danh sách khách hàng";
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Location = new System.Drawing.Point(564, 415);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(75, 23);
            this.btnXuatFile.TabIndex = 3;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã KH";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên khách hàng";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số ĐT";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Địa chỉ giao hàng";
            this.columnHeader4.Width = 200;
            // 
            // lvKhachHang
            // 
            this.lvKhachHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvKhachHang.FullRowSelect = true;
            this.lvKhachHang.GridLines = true;
            this.lvKhachHang.HideSelection = false;
            this.lvKhachHang.Location = new System.Drawing.Point(25, 249);
            this.lvKhachHang.Name = "lvKhachHang";
            this.lvKhachHang.Size = new System.Drawing.Size(620, 152);
            this.lvKhachHang.TabIndex = 5;
            this.lvKhachHang.UseCompatibleStateImageBehavior = false;
            this.lvKhachHang.View = System.Windows.Forms.View.Details;
            this.lvKhachHang.SelectedIndexChanged += new System.EventHandler(this.lvKhachHang_SelectedIndexChanged);
            this.lvKhachHang.DoubleClick += new System.EventHandler(this.lvKhachHang_DoubleClick);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 443);
            this.Controls.Add(this.lvKhachHang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnMacDinh);
            this.Controls.Add(this.mtbSDT);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMaSo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmKhachHang";
            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.MaskedTextBox mtbSDT;
        private System.Windows.Forms.Button btnMacDinh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdSDT;
        private System.Windows.Forms.RadioButton rdTen;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvKhachHang;
    }
}

