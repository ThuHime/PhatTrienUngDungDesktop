using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace RestaurantManagementProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmFood());
            //Application.Run(new frmAccount());
            //Application.Run(new frmBillDetails());
            //Application.Run(new frmBills());
            //Application.Run(new frmCategory());
            //Application.Run(new frmPhanQuyen());
            //Application.Run(new frmRole());
            //Application.Run(new frmRoleAccount());
            //Application.Run(new frmTable());
            //Application.Run(new frmLogin());
            //Application.Run(new MainForm());
            //Application.Run(new OrderForm());
            //Application.Run(new ReportForm());
            //Application.Run(new TableManagerForm());
            Account loggedInUser = null;

            using (var loginForm = new frmLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    loggedInUser = loginForm.LoggedInAccount;
                }
                else
                {
                    return; // Thoát nếu không đăng nhập
                }
            }

            if (loggedInUser == null)
            {
                MessageBox.Show("Lỗi: Không thể xác định tài khoản người dùng.");
                return; // Đảm bảo ứng dụng không tiếp tục với tài khoản null
            }

            var mainForm = new MainForm(loggedInUser); // Đảm bảo loggedInUser không phải null
            Application.Run(mainForm);
        }
    }
}
