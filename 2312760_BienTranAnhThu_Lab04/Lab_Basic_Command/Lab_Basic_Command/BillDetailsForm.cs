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
    public partial class frmBillDetails : Form
    {
        public int BillID { get; set; }
        public frmBillDetails()
        {
            InitializeComponent();
        }
        public frmBillDetails(int billID)
        {
            InitializeComponent();
            BillID = billID; // gán billID được truyền từ form khác
        }

        private void frmBillDetails_Load(object sender, EventArgs e)
        {
            if(BillID>0)
                LoadBillDetails(BillID);
        }
        private void LoadBillDetails(int billID)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT a.ID,a.InvoiceID,a.FoodID,b.Name,a.Quantity,b.Price,(a.Quantity*b.Price) AS Total FROM BillDetail a,Food b WHERE a.FoodID=b.ID AND a.InvoiceID=@BillID";
            SqlDataAdapter da=new SqlDataAdapter(query,sqlConnection);
            da.SelectCommand.Parameters.AddWithValue("@BillID", billID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBillDetails.AutoGenerateColumns = false;
            dgvBillDetails.DataSource = dt;
        }
    }
}
