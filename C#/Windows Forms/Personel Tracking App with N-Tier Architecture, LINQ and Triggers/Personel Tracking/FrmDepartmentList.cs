using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace Personel_Tracking
{
    public partial class FrmDepartmentList : Form
    {
        public FrmDepartmentList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UserStatic.isAdmin)
                ChangeToDepartmentForm();
            else
                MessageBox.Show("You are not an admin");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UserStatic.isAdmin)
            {
                if (detail.ID == 0)
                    MessageBox.Show("Please select a department from the table");
                else
                {
                    FrmDepartment frm = new FrmDepartment();

                    frm.isUpdate = true;
                    frm.detail = detail;

                    this.Hide();
                    frm.ShowDialog();
                    this.Visible = true;

                    list = DepartmentBLL.GetDepartments();
                    dataGridView1.DataSource = list;
                }
            }
            else
                MessageBox.Show("You are not an admin");
        }

        void ChangeToDepartmentForm()
        {
            FrmDepartment frm = new FrmDepartment();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;

            list = DepartmentBLL.GetDepartments();
            dataGridView1.DataSource = list;
        }

        List<DEPARTMENT> list = new List<DEPARTMENT>();
        public DEPARTMENT detail = new DEPARTMENT();
        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {
            list = DepartmentBLL.GetDepartments();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Department Name";
        }


        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.DepartmentName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UserStatic.isAdmin)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this department", "Warning!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    DepartmentBLL.DeleteDepartment(detail.ID);
                    MessageBox.Show("Department was deleted");
                    list = DepartmentBLL.GetDepartments();
                    dataGridView1.DataSource = list;
                }
            }
            else
                MessageBox.Show("You are not an admin");
        }
    }
}
