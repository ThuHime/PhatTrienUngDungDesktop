namespace Lab_Advanced_Command
{
    partial class frmActivityLog
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
            this.lstDates = new System.Windows.Forms.ListBox();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.lblTotalBills = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // lstDates
            // 
            this.lstDates.FormattingEnabled = true;
            this.lstDates.Location = new System.Drawing.Point(12, 12);
            this.lstDates.Name = "lstDates";
            this.lstDates.Size = new System.Drawing.Size(182, 95);
            this.lstDates.TabIndex = 0;
            this.lstDates.SelectedIndexChanged += new System.EventHandler(this.lstDates_SelectedIndexChanged);
            // 
            // dgvBills
            // 
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(200, 12);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.Size = new System.Drawing.Size(588, 150);
            this.dgvBills.TabIndex = 1;
            // 
            // lblTotalBills
            // 
            this.lblTotalBills.AutoSize = true;
            this.lblTotalBills.Location = new System.Drawing.Point(207, 179);
            this.lblTotalBills.Name = "lblTotalBills";
            this.lblTotalBills.Size = new System.Drawing.Size(10, 13);
            this.lblTotalBills.TabIndex = 3;
            this.lblTotalBills.Text = ".";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(207, 209);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(10, 13);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = ".";
            // 
            // frmActivityLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 203);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalBills);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.lstDates);
            this.Name = "frmActivityLog";
            this.Text = "ActivityLogForm";
            this.Load += new System.EventHandler(this.frmActivityLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDates;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Label lblTotalBills;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}