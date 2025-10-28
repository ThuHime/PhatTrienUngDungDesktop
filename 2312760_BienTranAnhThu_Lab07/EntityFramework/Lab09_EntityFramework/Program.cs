using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab09_Entity_Framework.Models;

namespace Lab09_EntityFramework
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
            //Application.Run(new AccountDetailsForm());
            //Application.Run(new AccountForm());
            //Application.Run(new AccountManagementForm());
            AccountModel loggedInAccount = null;
            using (var context = new RestaurantContext())
            {
                //Hiển thị form đăng nhập

                using (var loginForm = new LoginForm(context))
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        loggedInAccount = loginForm.LoggedInAccount;
                    }
                }

                // Nếu không đăng nhập, thoát chương trình
                if (loggedInAccount == null)
                {
                    return;
                }
                Application.Run(new MainForm(context, loggedInAccount));
            }
            //Application.Run(new BillDetailsForm());
            //Application.Run(new BillsForm());
            //Application.Run(new FoodForm());
            //Application.Run(new Form1());
            //Application.Run(new MenuForm());
            //Application.Run(new RoleForm());
            //Application.Run(new TableForm());
        }
    }
}
