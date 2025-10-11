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
    public partial class frmRole : Form
    {
        private string accountName;
        public frmRole()
        {
            InitializeComponent();
        }
        public frmRole(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
        }
        private void LoadRoles(string accountName)
        {
            string connectString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string query = "SELECT a.ID,b.AccountName,a.RoleName,a.Path,b.Actived,a.Notes"
                    + " FROM Role a,RoleAccount b"
                    + " WHERE a.ID=b.RoleID AND b.AccountName=@acc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@acc", accountName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRole.DataSource = dt;
            }
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            LoadRoles(accountName);
        }
    }
}
