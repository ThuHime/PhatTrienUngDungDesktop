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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void LoadListView()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT ID,Name,Status,Capacity FROM Table01";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dgvTable.DataSource = dt;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); 
                string query = "INSERT INTO Table01 (Name, Status, Capacity) VALUES (@name, @status, @capacity)";
                SqlCommand cmd = new SqlCommand(query, conn); 
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                cmd.Parameters.AddWithValue("@capacity", int.Parse(txtCapacity.Text));
                cmd.ExecuteNonQuery();
            }
            LoadListView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            if (dgvTable.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvTable.SelectedRows[0].Cells[0].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Table01 SET Name=@name, Status=@status, Capacity=@capacity WHERE ID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                cmd.Parameters.AddWithValue("@capacity", int.Parse(txtCapacity.Text));
                cmd.ExecuteNonQuery();
            }
            LoadListView();
        }

        private void dgvTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTable.SelectedRows[0];
                txtName.Text = row.Cells[1].Value.ToString();
                txtStatus.Text = row.Cells[2].Value.ToString();
                txtCapacity.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            if (dgvTable.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvTable.SelectedRows[0].Cells[0].Value);

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Table01 WHERE ID=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadListView();
            }
        }
        private int GetUnpaidBillIDByTableID(int tableID)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID FROM Bills WHERE TableID = @TableID AND Status = 0"; // 0 = chưa thanh toán
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableID", tableID);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                else
                    return -1; // không có bill nào
            }
        }

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bàn!");
                return;
            }

            int tableID = Convert.ToInt32(dgvTable.SelectedRows[0].Cells[0].Value);
            int billID = GetUnpaidBillIDByTableID(tableID);

            if (billID > 0)
            {
                frmBillDetails frm = new frmBillDetails(billID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bàn này chưa có hóa đơn nào!");
            }
        }

        private void XoaBan(string maBan)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            string query = "DELETE FROM Table01 WHERE ID = @MaBan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                        MessageBox.Show("Không tìm thấy bàn để xóa!");
                }
            }
        }
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                string maBan = dgvTable.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa bàn {maBan}?",
                                                      "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Code xóa bàn trong CSDL
                    XoaBan(maBan);
                    MessageBox.Show("Đã xóa bàn thành công!");
                    LoadListView(); 
                }
            }
        }

        private void tsmDanhMuc_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                string maBan = dgvTable.SelectedRows[0].Cells[0].Value.ToString();

                frmDanhMuc frm = new frmDanhMuc(maBan);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để xem danh mục hóa đơn!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmNhatKy_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                string maBan = dgvTable.SelectedRows[0].Cells[0].Value.ToString();

                frmNhatKy frm = new frmNhatKy(maBan);
                frm.ShowDialog();
            }
        }
    }
}
