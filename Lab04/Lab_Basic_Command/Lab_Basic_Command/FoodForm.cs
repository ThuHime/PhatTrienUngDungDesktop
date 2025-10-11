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
using Microsoft.SqlServer.Server;

namespace Lab_Basic_Command
{
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
            
        }
        public void LoadFood(int categoryID)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT Name FROM Category where ID=" + categoryID;
            sqlConnection.Open();
            object result = sqlCommand.ExecuteScalar();
            string catName = result?.ToString() ?? "Không xác định";
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;
            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID=" + categoryID;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            //Tự động sinh Insert/Update/Delete
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable("Food");
            da.Fill(dt);
            dgvFood.DataSource = dt;
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable("Food");
                da.Update(dt);
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: "+ex.Message);
            } 
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFood.CurrentRow != null)
            {
                //Xóa trên datagridview
                dgvFood.Rows.RemoveAt(dgvFood.CurrentRow.Index);
                DataTable dt = new DataTable("Food");
                SqlDataAdapter da = new SqlDataAdapter();
                da.Update(dt);
                MessageBox.Show("Xóa món ăn thành công");
            }
            else
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
        }
    }
}
