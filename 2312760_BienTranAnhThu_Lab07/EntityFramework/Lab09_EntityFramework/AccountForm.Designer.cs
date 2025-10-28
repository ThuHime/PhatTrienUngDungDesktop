namespace Lab09_EntityFramework
{
    partial class AccountForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchUserName = new System.Windows.Forms.TextBox();
            this.txtSearchRole = new System.Windows.Forms.TextBox();
            this.lvwAccount = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.contextMenuAccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDeleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập tên tài khoản cần tìm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập tên vai trò cần tìm:";
            // 
            // txtSearchUserName
            // 
            this.txtSearchUserName.Location = new System.Drawing.Point(283, 15);
            this.txtSearchUserName.Name = "txtSearchUserName";
            this.txtSearchUserName.Size = new System.Drawing.Size(200, 20);
            this.txtSearchUserName.TabIndex = 1;
            // 
            // txtSearchRole
            // 
            this.txtSearchRole.Location = new System.Drawing.Point(283, 46);
            this.txtSearchRole.Name = "txtSearchRole";
            this.txtSearchRole.Size = new System.Drawing.Size(200, 20);
            this.txtSearchRole.TabIndex = 2;
            // 
            // lvwAccount
            // 
            this.lvwAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwAccount.FullRowSelect = true;
            this.lvwAccount.GridLines = true;
            this.lvwAccount.HideSelection = false;
            this.lvwAccount.Location = new System.Drawing.Point(21, 124);
            this.lvwAccount.Name = "lvwAccount";
            this.lvwAccount.Size = new System.Drawing.Size(656, 267);
            this.lvwAccount.TabIndex = 2;
            this.lvwAccount.UseCompatibleStateImageBehavior = false;
            this.lvwAccount.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên tài khoản";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên đầy đủ";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Email";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số điện thoại";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mật khẩu";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ngày tạo";
            this.columnHeader6.Width = 100;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(40, 88);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.Location = new System.Drawing.Point(142, 88);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(106, 30);
            this.btnAddAccount.TabIndex = 3;
            this.btnAddAccount.Text = "Thêm tài khoản";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAccount.Location = new System.Drawing.Point(268, 88);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(128, 30);
            this.btnUpdateAccount.TabIndex = 3;
            this.btnUpdateAccount.Text = "Cập nhật tài khoản";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.Location = new System.Drawing.Point(412, 88);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(104, 30);
            this.btnResetPassword.TabIndex = 3;
            this.btnResetPassword.Text = "Reset mật khẩu";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(532, 88);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(127, 30);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "Thay đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // contextMenuAccount
            // 
            this.contextMenuAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeleteAccount,
            this.tsmViewRoles});
            this.contextMenuAccount.Name = "contextMenuAccount";
            this.contextMenuAccount.Size = new System.Drawing.Size(192, 48);
            // 
            // tsmDeleteAccount
            // 
            this.tsmDeleteAccount.Name = "tsmDeleteAccount";
            this.tsmDeleteAccount.Size = new System.Drawing.Size(191, 22);
            this.tsmDeleteAccount.Text = "Xóa tài khoản";
            this.tsmDeleteAccount.Click += new System.EventHandler(this.tsmDeleteAccount_Click);
            // 
            // tsmViewRoles
            // 
            this.tsmViewRoles.Name = "tsmViewRoles";
            this.tsmViewRoles.Size = new System.Drawing.Size(191, 22);
            this.tsmViewRoles.Text = "Xem danh sách vai trò";
            this.tsmViewRoles.Click += new System.EventHandler(this.tsmViewRoles_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 408);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnUpdateAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lvwAccount);
            this.Controls.Add(this.txtSearchRole);
            this.Controls.Add(this.txtSearchUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AccountForm";
            this.Text = "Quản lý tài khoản";
            this.contextMenuAccount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchUserName;
        private System.Windows.Forms.TextBox txtSearchRole;
        private System.Windows.Forms.ListView lvwAccount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.ContextMenuStrip contextMenuAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmViewRoles;
    }
}