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
    public partial class frmRoleList : Form
    {
        private string accountName;
        public frmRoleList()
        {
            InitializeComponent();
        }
        public frmRoleList(string acc)
        {
            InitializeComponent();
            accountName = acc;
        }
        private void LoadRoles()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetRolesByAccount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountName", accountName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRoles.DataSource = dt;

            dgvRoles.Columns["Assigned"].HeaderText = "✓";
            dgvRoles.Columns["Assigned"].ReadOnly = false;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string roleName = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên vai trò mới:", "Thêm vai trò", "");
            if (!string.IsNullOrEmpty(roleName))
            {
                string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("InsertRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", roleName);
                cmd.Parameters.AddWithValue("@Path", DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Đã thêm vai trò mới!");
                LoadRoles();
            }    
        }

        private void frmRoleList_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmdDel = new SqlCommand("DELETE FROM RoleAccount WHERE AccountName = @AccountName", conn);
            cmdDel.Parameters.AddWithValue("@AccountName", accountName);
            cmdDel.ExecuteNonQuery();

            foreach (DataGridViewRow row in dgvRoles.Rows)
            {
                bool assigned = Convert.ToBoolean(row.Cells["Assigned"].Value);
                if (assigned)
                {
                    int roleID = Convert.ToInt32(row.Cells["ID"].Value);
                    SqlCommand cmdIns = new SqlCommand("INSERT INTO RoleAccount (RoleID, AccountName, Actived) VALUES (@RoleID, @AccountName, 1)", conn);
                    cmdIns.Parameters.AddWithValue("@RoleID", roleID);
                    cmdIns.Parameters.AddWithValue("@AccountName", accountName);
                    cmdIns.ExecuteNonQuery();
                }
            }
            conn.Close();

            MessageBox.Show("Cập nhật vai trò thành công!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
