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
    public partial class frmOrderDetails : Form
    {
        private int InvoiceID;
        public frmOrderDetails()
        {
            InitializeComponent();
        }
        public frmOrderDetails(int invoiceID)
        {
            InitializeComponent();
            InvoiceID = invoiceID;
        }
        private void LoadBillDetails()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetBillDetailsByInvoiceID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDetails.DataSource = dt;
            conn.Close();
        }
        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
        }
    }
}
