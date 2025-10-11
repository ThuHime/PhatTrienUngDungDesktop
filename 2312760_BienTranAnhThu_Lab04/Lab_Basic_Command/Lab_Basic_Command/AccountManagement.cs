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
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }
        public void LoadAccount()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT a.AccountName,a.Password,a.FullName,a.Email,a.Tell,a.DateCreated,b.RoleName,c.Actived"
                + " FROM Account a, Role b, RoleAccount c"
                + " WHERE a.AccountName=c.AccountName AND b.ID=c.RoleID";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.DataSource = dt;
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            cboGroup.SelectedIndex = 0;
            LoadAccount();
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string rolename = cboGroup.Text;
            bool isActive=chkActive.Checked;
            string query="SELECT a.AccountName,a.Password,a.FullName,a.Email,a.Tell,a.DateCreated,b.RoleName,c.Actived"
                + " FROM Account a, Role b, RoleAccount c"
                + " WHERE a.AccountName=c.AccountName AND b.ID=c.RoleID AND b.RoleName=@rolename AND c.Actived=@active";
            SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection);
            da.SelectCommand.Parameters.AddWithValue("@rolename", rolename);
            da.SelectCommand.Parameters.AddWithValue("@active", isActive);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAccounts.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlConnection.Open();
            foreach(DataGridViewRow row in dgvAccounts.Rows)
            {
                if (row.IsNewRow) continue;
                string accountname = row.Cells[0].Value?.ToString();
                string pass=row.Cells[1].Value?.ToString();
                string name=row.Cells[2].Value?.ToString();
                string email=row.Cells[3].Value?.ToString();
                string tell=row.Cells[4].Value?.ToString();
                string date=row.Cells[5].Value?.ToString();
                bool active = string.IsNullOrEmpty(row.Cells[6].Value?.ToString()) ? true : Convert.ToBoolean(row.Cells[6].Value);
                row.Cells[6].Value = active;
                string rolename=row.Cells[7].Value?.ToString();
                
                if (string.IsNullOrWhiteSpace(date))
                {
                    date = DateTime.Now.ToString("yyyy-MM-dd");
                    row.Cells[5].Value = date; // hiển thị lại lên DataGridView
                }
              
                string check = "SELECT COUNT(*) FROM Account WHERE AccountName=@accountname";
                SqlCommand checkcmd=new SqlCommand(check,sqlConnection);
                checkcmd.Parameters.AddWithValue("@accountname",accountname);
                int exists=(int)checkcmd.ExecuteScalar();

                if(exists == 0)
                {
                    string query = "INSERT INTO Account(AccountName,Password,FullName,Email,Tell,DateCreated)"
                + " VALUES (@accountname,@pass,@name,@email,@tell,GETDATE())";
                    SqlCommand cmd=new SqlCommand(query,sqlConnection);
                    cmd.Parameters.AddWithValue("@accountname", accountname);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@tell",tell);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.ExecuteNonQuery();

                    string getRoleIdQuery = "SELECT ID FROM Role WHERE RoleName = @rolename";
                    SqlCommand getRoleCmd = new SqlCommand(getRoleIdQuery, sqlConnection);
                    getRoleCmd.Parameters.AddWithValue("@rolename", rolename);
                    object result = getRoleCmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show($"Vai trò '{rolename}' không tồn tại trong bảng Role!");
                        continue;
                    }
                    int roleID=Convert.ToInt32(result);

                    string insertRole = "INSERT INTO RoleAccount(RoleID, AccountName, Actived) VALUES (@roleid, @acc, @active)";
                    SqlCommand cmdRole = new SqlCommand(insertRole, sqlConnection);
                    cmdRole.Parameters.AddWithValue("@roleid", roleID);
                    cmdRole.Parameters.AddWithValue("@acc", accountname);
                    cmdRole.Parameters.AddWithValue("@active", active);
                    cmdRole.ExecuteNonQuery();
                }
            }
            LoadAccount();
            sqlConnection.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                foreach (DataGridViewRow row in dgvAccounts.Rows)
                {
                    if (row.IsNewRow) continue;

                    string accountname = row.Cells[0].Value?.ToString();
                    string pass = row.Cells[1].Value?.ToString();
                    string name = row.Cells[2].Value?.ToString();
                    string email = row.Cells[3].Value?.ToString();
                    string tell = row.Cells[4].Value?.ToString();
                    string date = row.Cells[5].Value?.ToString();

                    bool active = string.IsNullOrEmpty(row.Cells[6].Value?.ToString()) ? true :
                                  Convert.ToBoolean(row.Cells[6].Value);

                    string query = @"UPDATE Account 
                             SET Password=@pass, FullName=@name, Email=@email, Tell=@tell, DateCreated=@date
                             WHERE AccountName=@accountname;

                             UPDATE RoleAccount
                             SET Actived=@actived
                             WHERE AccountName=@accountname;";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@accountname", accountname);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@tell", tell);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@actived", active);

                    cmd.ExecuteNonQuery();
                }
                LoadAccount();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần reset mật khẩu!");
                return;
            }

            string accountname = dgvAccounts.SelectedRows[0].Cells[0].Value.ToString();

            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "UPDATE Account SET Password='123456' WHERE AccountName=@accountname";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@accountname", accountname);
                cmd.ExecuteNonQuery();
                LoadAccount();
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                string accountName = dgvAccounts.SelectedRows[0].Cells[0].Value.ToString();

                string connectString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "UPDATE RoleAccount SET Actived = 0 WHERE AccountName = @acc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@acc", accountName);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadAccount();
            }
        }

        private void tsmView_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
                frmRole f = new frmRole(accountName);
                f.ShowDialog();
            }
        }
    }
}
