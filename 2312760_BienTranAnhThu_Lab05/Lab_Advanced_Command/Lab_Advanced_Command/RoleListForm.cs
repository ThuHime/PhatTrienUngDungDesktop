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
            if (dt.Columns["Assigned"].DataType != typeof(bool))
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["Assigned"] = Convert.ToInt32(row["Assigned"]) == 1;
                }
            }
            dgvRoles.AutoGenerateColumns = true;
            dgvRoles.DataSource = dt;

            if (dgvRoles.Columns["Assigned"] is DataGridViewTextBoxColumn)
            {
                int idx = dgvRoles.Columns["Assigned"].Index;
                dgvRoles.Columns.Remove("Assigned");

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "Assigned";
                chk.HeaderText = "✓";
                chk.DataPropertyName = "Assigned";
                chk.Width = 50;
                chk.ReadOnly = true;
                dgvRoles.Columns.Insert(0, chk);
            }

            // Các cột khác chỉ đọc
            dgvRoles.Columns["ID"].ReadOnly = true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddRole frm = new frmAddRole();
            if (frm.ShowDialog() == DialogResult.OK)
            {
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
            //LoadRoles();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
