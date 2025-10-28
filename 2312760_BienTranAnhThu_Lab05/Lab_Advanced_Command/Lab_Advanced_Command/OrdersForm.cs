using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_Advanced_Command
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
        }
        private void LoadBills()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetBillsByDate", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value);
            cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBills.DataSource = dt;
            conn.Close();

            // Tính tổng doanh thu
            double total = 0, discount = 0, net = 0, tax = 0;
            foreach (DataRow row in dt.Rows)
            {
                double amount = Convert.ToDouble(row["Amount"]);
                double discountPercent = Convert.ToDouble(row["Discount"]);
                double taxPercent = Convert.ToDouble(row["Tax"]);

                double discountValue = amount * discountPercent / 100;
                double taxValue = amount * taxPercent / 100;
                double netValue = amount - discountValue + taxValue;

                total += amount;
                discount += discountValue;
                tax += taxValue;
                net += netValue;
            }

            txtTotal.Text = total.ToString("N0");
            txtDiscount.Text = discount.ToString("N0");
            txtNetRevenue.Text = net.ToString("N0");
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int invoiceID = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["ID"].Value);
                frmOrderDetails frm = new frmOrderDetails(invoiceID);
                frm.ShowDialog();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadBills();
        }
    }
}
