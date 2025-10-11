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

namespace Lab_Basic_Command
{
    public partial class frmBills : Form
    {
        public frmBills()
        {
            InitializeComponent();
        }
        public int BillID {  get; set; }
        private void btnLoadBill_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT ID,Name,TableID,Amount,Discount,Tax,Status,CheckoutDate,Account,(Amount - Discount + Tax) AS FinalAmount " +
                "FROM Bills " +
                "WHERE CheckoutDate>=@FromDate AND CheckoutDate<=@ToDate";
            SqlDataAdapter da=new SqlDataAdapter(query, sqlConnection);
            da.SelectCommand.Parameters.AddWithValue("@FromDate",dtpFromDate.Value.Date);
            da.SelectCommand.Parameters.AddWithValue("@ToDate",dtpToDate.Value.Date.AddDays(1).AddSeconds(-1));
            DataTable dt=new DataTable();
            da.Fill(dt);
            dgvBills.AutoGenerateColumns = false;
            dgvBills.DataSource = dt;
            //Tính tổng
            decimal total = 0, discount = 0, final = 0;
            foreach(DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["Amount"]);
                discount += Convert.ToDecimal(row["Discount"]);
                final += Convert.ToDecimal(row["FinalAmount"]);
            } 
            txtTotal.Text = total.ToString("N0");
            txtDiscount.Text = discount.ToString("N0");
            txtFinalAmount.Text = final.ToString("N0");
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                int billID = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["ID"].Value);
                frmBillDetails frm=new frmBillDetails();
                frm.BillID = billID;
                frm.ShowDialog();
            }    
        }
    }
}
