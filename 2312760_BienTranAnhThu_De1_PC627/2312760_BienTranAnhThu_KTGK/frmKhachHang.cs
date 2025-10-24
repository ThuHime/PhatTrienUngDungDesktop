using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312760_BienTranAnhThu_KTGK
{
    public partial class frmKhachHang : Form
    {
        public QuanLyKhachHang qlkh;
        public string TenKH {  get; set; }
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void ThemKH(KhachHang kh)
        {
            ListViewItem lvitem=new ListViewItem(kh.MaKH);
            lvitem.SubItems.Add(kh.Ten);
            lvitem.SubItems.Add(kh.SDT);
            lvitem.SubItems.Add(kh.DiaChi);
            lvKhachHang.Items.Add(lvitem);
        }
        public void LoadListView()
        {
            lvKhachHang.Items.Clear();
            foreach (KhachHang kh in qlkh.dsKhachHnag)
                ThemKH(kh);
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            qlkh=new QuanLyKhachHang();
            qlkh.DocTuFile("DanhSachKH.txt");
            LoadListView();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.txtMaSo.Text = "";
            this.txtTen.Text = "";
            this.mtbSDT.Text = "";
            this.txtDiaChi.Text = "";
        }
        public KhachHang GetKH()
        {
            KhachHang kh = new KhachHang();
            kh.MaKH=this.txtMaSo.Text;
            kh.Ten=this.txtTen.Text;
            kh.SDT = this.mtbSDT.Text;
            kh.DiaChi = this.txtDiaChi.Text;
            return kh;
        }
        public KhachHang GetKHLV(ListViewItem lvitem)
        {
            KhachHang kh=new KhachHang();
            kh.MaKH = lvitem.SubItems[0].Text;
            kh.Ten = lvitem.SubItems[1].Text;
            kh.SDT = lvitem.SubItems[2].Text;
            kh.DiaChi = lvitem.SubItems[3].Text;
            return kh;
        }
        public void ThietLapThongTin(KhachHang kh)
        {
            this.txtMaSo.Text = kh.MaKH;
            this.txtTen.Text = kh.Ten;
            this.mtbSDT.Text=kh.SDT;
            this.txtDiaChi.Text=kh.DiaChi;
        }

        private void lvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count=this.lvKhachHang.SelectedItems.Count;
            if(count > 0)
            {
                ListViewItem lvitem = lvKhachHang.SelectedItems[0];
                KhachHang kh = GetKHLV(lvitem);
                ThietLapThongTin(kh);
            } 
                
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var ms = this.txtMaSo.Text;
            var ten=this.txtTen.Text;
            var sdt = this.mtbSDT.Text;
            var dc = this.txtDiaChi.Text;
            if(ms!="")
            {
                ListViewItem lvitem = lvKhachHang.SelectedItems[0];
                lvitem.SubItems[1].Text = ten;
                lvitem.SubItems[2].Text = sdt;
                lvitem.SubItems[3].Text = dc;
            }    
            else
            {
                int count = lvKhachHang.Items.Count + 1;
                ms = "KH" + count.ToString("000");
                ListViewItem lvitem=new ListViewItem(ms);
                lvitem.SubItems.Add(ten);
                lvitem.SubItems.Add(sdt);
                lvitem.SubItems.Add(dc);
                lvKhachHang.Items.Add(lvitem);
            }    
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string key = this.txtTim.Text;
            List<KhachHang> result;
            if(rdTen.Checked)
                result=qlkh.dsKhachHnag.Where(kh=>kh.Ten.IndexOf(key,StringComparison.CurrentCultureIgnoreCase)>=0).ToList();
            else
                result=qlkh.dsKhachHnag.Where(kh=>kh.SDT.Contains(key)).ToList();
            lvKhachHang.Items.Clear();
            foreach (KhachHang kh in result)
                ThemKH(kh);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            qlkh.XuatFileJSON();
        }

        private void lvKhachHang_DoubleClick(object sender, EventArgs e)
        {
            int count = this.lvKhachHang.SelectedItems.Count;
            if(count>0)
            {
                TenKH = lvKhachHang.SelectedItems[0].Text;
                this.Close();
                //MessageBox.Show(TenKH);
            }    
        }
    }
}
