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

namespace Lab_Advanced_Command
{
    public partial class frmActivityLog : Form
    {
        private string accountName;
        public frmActivityLog()
        {
            InitializeComponent();
        }
        public frmActivityLog(string acc)
        {
            InitializeComponent();
            accountName = acc;
        }

        private void frmActivityLog_Load(object sender, EventArgs e)
        {
            LoadBillDates();
        }
        private void LoadBillDates()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetBillDatesByAccount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountName", accountName);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lstDates.Items.Add(Convert.ToDateTime(reader["BillDate"]).ToShortDateString());
            }
            conn.Close();
        }

        private void lstDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDates.SelectedItem == null) return;
            DateTime selectedDate = Convert.ToDateTime(lstDates.SelectedItem);
            LoadBillsByDates(selectedDate);
        }
        private void LoadBillsByDates(DateTime date)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetBillsByDateAndAccount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountName", accountName);
            cmd.Parameters.AddWithValue("@BillDate", date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBills.DataSource = dt;

            // Tính tổng
            int totalBills = dt.Rows.Count;
            decimal totalAmount = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalAmount += Convert.ToDecimal(row["Amount"]);
            }

            lblTotalBills.Text = $"Số hóa đơn: {totalBills}";
            lblTotalAmount.Text = $"Tổng tiền: {totalAmount:#,##0}";
        }
    }
}
