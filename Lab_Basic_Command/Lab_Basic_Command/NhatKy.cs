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
    public partial class frmNhatKy : Form
    {
        public string MaBan;
        public frmNhatKy()
        {
            InitializeComponent();
        }
        public frmNhatKy(string maBan)
        {
            InitializeComponent();
            this.MaBan=maBan;
        }
        private void LoadNhatKyMuaHang(string maBan)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT a.ID,a.CheckoutDate,a.Account,a.Discount,a.Tax,SUM(a.Amount * b.Quantity) AS TongTien" +
                    " FROM Bills a, BillDetail b" +
                    " WHERE a.ID=b.InvoiceID AND a.TableID=@MaBan" +
                    " GROUP BY a.ID, a.CheckoutDate, a.Account, a.Discount, a.Tax" +
                    " ORDER BY a.CheckoutDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNhatKy.DataSource = dt;

                // 🔹 Tính tổng cộng
                double tongHoaDon = dt.Rows.Count;
                double tongTien = 0, tongThue = 0, tongGiamGia = 0;

                foreach (DataRow row in dt.Rows)
                {
                    tongTien += Convert.ToDouble(row[5]);
                    tongThue += Convert.ToDouble(row[4]);
                    tongGiamGia += Convert.ToDouble(row[3]);
                }

                lblThongKe.Text = $"Số HĐ: {tongHoaDon} \n Tổng tiền: {tongTien:#,##0}đ \n Tổng thuế: {tongThue}% \n Tổng giảm giá: {tongGiamGia}%";
            }
        }

        private void frmNhatKy_Load(object sender, EventArgs e)
        {
            LoadNhatKyMuaHang(MaBan);
        }
    }
}
