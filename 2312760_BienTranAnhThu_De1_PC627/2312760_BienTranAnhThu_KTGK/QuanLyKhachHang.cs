using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _2312760_BienTranAnhThu_KTGK
{
    public delegate int SoSanh(object kh1, object kh2);
    public class QuanLyKhachHang
    {
        public List<KhachHang> dsKhachHnag;
        public QuanLyKhachHang()
        {
            dsKhachHnag = new List<KhachHang>();
        }
        public KhachHang this[int index]
        {
            get { return dsKhachHnag[index]; }
            set { dsKhachHnag[index] = value; }
        }
        public void Them(KhachHang kh)
        {
            dsKhachHnag.Add(kh);
        }
        public void Xoa(object obj,SoSanh ss)
        {
            int i = this.dsKhachHnag.Count - 1;
            for(;i >= 0; i--) 
                this.dsKhachHnag.RemoveAt(i);
        }
        public KhachHang Tim(object obj,SoSanh ss)
        {
            KhachHang khressult = null;
            foreach(KhachHang kh in dsKhachHnag)
                if(ss(obj,kh)==0)
                {
                    khressult = kh;
                    break;
                }    
            return khressult;
        }
        public bool Sua(object obj,SoSanh ss,KhachHang khsua)
        {
            int count = this.dsKhachHnag.Count - 1;
            bool kq = false;
            for(int i=0;i<count;i++)
                if (ss(obj, this[i])==0)
                {
                    this[i] = khsua;
                    kq = true;
                    break;
                }
            return kq;
        }
        //ĐocFile
        public void DocTuFile(string filename)
        {
            string t;
            string[] s;
            KhachHang kh;
            using(StreamReader sr=new StreamReader(new FileStream(filename, FileMode.Open)))
            {
                while ((t = sr.ReadLine()) != null)
                {
                    s = t.Split('|');
                    kh=new KhachHang();
                    kh.MaKH = s[0];
                    kh.Ten = s[1];
                    kh.SDT = s[2];
                    kh.DiaChi = s[3];
                    Them(kh);
                }       
            }     
        }
        //XuatFileJSON
        public void XuatFileJSON()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json=JsonConvert.SerializeObject(dsKhachHnag,Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
    }
}
