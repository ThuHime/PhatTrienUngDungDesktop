namespace Lab09_EntityFramework
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdminManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewBillDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewTables = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFoods = new System.Windows.Forms.ComboBox();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnCheckoutTable = new System.Windows.Forms.Button();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.btnAddFoodToBill = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdminManagement,
            this.menuViewAccount});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdminManagement
            // 
            this.menuAdminManagement.Name = "menuAdminManagement";
            this.menuAdminManagement.Size = new System.Drawing.Size(112, 20);
            this.menuAdminManagement.Text = "Quản lý tài khoản";
            this.menuAdminManagement.Click += new System.EventHandler(this.menuAdminManagement_Click);
            // 
            // menuViewAccount
            // 
            this.menuViewAccount.Name = "menuViewAccount";
            this.menuViewAccount.Size = new System.Drawing.Size(147, 20);
            this.menuViewAccount.Text = "Xem thông tin tài khoản";
            this.menuViewAccount.Click += new System.EventHandler(this.menuViewAccount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewBillDetails);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 333);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết hóa đơn";
            // 
            // listViewBillDetails
            // 
            this.listViewBillDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewBillDetails.FullRowSelect = true;
            this.listViewBillDetails.GridLines = true;
            this.listViewBillDetails.HideSelection = false;
            this.listViewBillDetails.Location = new System.Drawing.Point(6, 19);
            this.listViewBillDetails.Name = "listViewBillDetails";
            this.listViewBillDetails.Size = new System.Drawing.Size(262, 308);
            this.listViewBillDetails.TabIndex = 2;
            this.listViewBillDetails.UseCompatibleStateImageBehavior = false;
            this.listViewBillDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 100;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewTables);
            this.groupBox2.Location = new System.Drawing.Point(297, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 277);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách bàn";
            // 
            // listViewTables
            // 
            this.listViewTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewTables.FullRowSelect = true;
            this.listViewTables.GridLines = true;
            this.listViewTables.HideSelection = false;
            this.listViewTables.Location = new System.Drawing.Point(6, 19);
            this.listViewTables.Name = "listViewTables";
            this.listViewTables.Size = new System.Drawing.Size(336, 250);
            this.listViewTables.TabIndex = 0;
            this.listViewTables.UseCompatibleStateImageBehavior = false;
            this.listViewTables.View = System.Windows.Forms.View.Details;
            this.listViewTables.Click += new System.EventHandler(this.listViewTables_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên bàn";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Trạng thái";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số lượng";
            this.columnHeader6.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn món ăn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhập số lượng:";
            // 
            // comboBoxFoods
            // 
            this.comboBoxFoods.FormattingEnabled = true;
            this.comboBoxFoods.Location = new System.Drawing.Point(418, 309);
            this.comboBoxFoods.Name = "comboBoxFoods";
            this.comboBoxFoods.Size = new System.Drawing.Size(192, 21);
            this.comboBoxFoods.TabIndex = 4;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(418, 335);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(191, 20);
            this.numericUpDownQuantity.TabIndex = 5;
            // 
            // btnCheckoutTable
            // 
            this.btnCheckoutTable.Location = new System.Drawing.Point(46, 376);
            this.btnCheckoutTable.Name = "btnCheckoutTable";
            this.btnCheckoutTable.Size = new System.Drawing.Size(90, 26);
            this.btnCheckoutTable.TabIndex = 6;
            this.btnCheckoutTable.Text = "Thanh toán";
            this.btnCheckoutTable.UseVisualStyleBackColor = true;
            this.btnCheckoutTable.Click += new System.EventHandler(this.btnCheckoutTable_Click);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Location = new System.Drawing.Point(155, 376);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(90, 26);
            this.btnPrintBill.TabIndex = 6;
            this.btnPrintBill.Text = "In hóa đơn";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // btnAddFoodToBill
            // 
            this.btnAddFoodToBill.Location = new System.Drawing.Point(451, 361);
            this.btnAddFoodToBill.Name = "btnAddFoodToBill";
            this.btnAddFoodToBill.Size = new System.Drawing.Size(90, 26);
            this.btnAddFoodToBill.TabIndex = 6;
            this.btnAddFoodToBill.Text = "Thêm món ăn";
            this.btnAddFoodToBill.UseVisualStyleBackColor = true;
            this.btnAddFoodToBill.Click += new System.EventHandler(this.btnAddFoodToBill_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 416);
            this.Controls.Add(this.btnAddFoodToBill);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.btnCheckoutTable);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.comboBoxFoods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Quản lý nhà hàng";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdminManagement;
        private System.Windows.Forms.ToolStripMenuItem menuViewAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewBillDetails;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewTables;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFoods;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button btnCheckoutTable;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Button btnAddFoodToBill;
    }
}