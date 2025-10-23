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
    public partial class frmFood : Form
    {
        private DataTable foodTable;
        public frmFood()
        {
            InitializeComponent();
        }
        private void LoadCategory()
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn=new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID,Name FROM Category";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "ID";
        }
        private void frmFood_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex == -1) return;
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Food WHERE FoodCategoryID=@categoryid";
            cmd.Parameters.Add("@categoryid",SqlDbType.Int);
            if(cboCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView=cboCategory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryid"].Value = rowView["ID"];
            }
            else
            {
                cmd.Parameters["@categoryid"].Value = cboCategory.SelectedValue;
            }    
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foodTable=new DataTable();
            conn.Open();
            adapter.Fill(foodTable);
            conn.Close();
            conn.Dispose();
            dgvFoodList.DataSource = foodTable;
            lblQuantity.Text=foodTable.Rows.Count.ToString();
            lblCatName.Text=cboCategory.Text;
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-0AS400S\\SQLEXPRESS;database=Restaurant Management;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT @numSaleFood=sum(Quantity) FROM BillDetail WHERE FoodID=@foodid";
            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView=selectedRow.DataBoundItem as DataRowView;
                cmd.Parameters.Add("@foodId", SqlDbType.Int);
                cmd.Parameters["@foodId"].Value = rowView["ID"]; 

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
                cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là: " + result + " " + rowView["Unit"]);
                conn.Close();
            } 
            cmd.Dispose();
            conn.Dispose();
        }

        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            frmFoodInfo foodForm=new frmFoodInfo();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.Show(this);
        }

        private void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index=cboCategory.SelectedIndex;
            cboCategory.SelectedIndex = -1;
            cboCategory.SelectedIndex = index;
        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            if(dgvFoodList.SelectedRows.Count>0)
            {
                DataGridViewRow selectedRow=dgvFoodList.SelectedRows[0];
                DataRowView rowView=selectedRow.DataBoundItem as DataRowView;
                frmFoodInfo foodForm=new frmFoodInfo();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }    
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;

            string filterExpression = "Name like '%" + txtSearchByName.Text + "%'";
            string sortExpression = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            DataView foodView = new DataView(foodTable,
                filterExpression, sortExpression, rowStateFilter);

            dgvFoodList.DataSource = foodView;
        }
    }
}
