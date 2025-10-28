﻿using System;
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
    public partial class frmDanhMuc : Form
    {
        public string MaBan;
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        public frmDanhMuc(string maBan)
        {
            InitializeComponent();
            this.MaBan = maBan;
        }
        private void LoadDanhSachNgayLap()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, CheckoutDate FROM Bills WHERE TableID = @MaBan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBan", MaBan);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                lsNgayLap.Items.Clear();
                while (reader.Read())
                {
                    // Hiển thị: "MaHD - NgayLap"
                    string display = $"{reader["ID"]} - {Convert.ToDateTime(reader["CheckoutDate"]).ToString("dd/MM/yyyy HH:mm")}";
                    lsNgayLap.Items.Add(display);
                }
            }
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDanhSachNgayLap();
        }
        private void LoadChiTietHoaDon(string maHD)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT c.Name,a.Quantity,b.Amount,(a.Quantity*b.Amount) AS ThanhTien
                                FROM BillDetail a, Bills b, Food c "+
                                "WHERE a.InvoiceID=b.ID AND a.FoodID=c.ID AND b.ID = @MaHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCTHD.DataSource = dt;

                double tongTien = 0;
                foreach (DataRow row in dt.Rows)
                    tongTien += Convert.ToDouble(row["ThanhTien"]);

                // 🔹 Lấy thông tin giảm giá & thuế từ Bill để tính tổng cuối
                string query2 = "SELECT Discount, Tax FROM Bills WHERE ID = @MaHD";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@MaHD", maHD);
                conn.Open();
                SqlDataReader r = cmd2.ExecuteReader();
                double discount = 0, tax = 0;
                if (r.Read())
                {
                    discount = Convert.ToDouble(r["Discount"]);
                    tax = Convert.ToDouble(r["Tax"]);
                }
                r.Close();

                double afterDiscount = tongTien - (tongTien * discount/100);
                double afterTax = afterDiscount + (afterDiscount * tax/100);
                lblTongTien.Font = new Font("Consolas", 10);
                lblTongTien.Text = $"{"Tổng:".PadRight(15)}{tongTien:N0}đ\n"+
                    $"{"Giảm giá:".PadRight(15)}{discount}%\n" +
                    $"{"Thuế:".PadRight(15)}{tax}%\n" +
                    $"{"Thành tiền:".PadRight(15)}{afterTax:N0}đ";
            }
        }
        private void lsNgayLap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsNgayLap.SelectedItem != null)
            {
                string selected = lsNgayLap.SelectedItem.ToString();
                string maHD = selected.Split('-')[0].Trim(); // lấy phần mã HĐ phía trước dấu '-'
                LoadChiTietHoaDon(maHD);
            }
        }
    }
}
