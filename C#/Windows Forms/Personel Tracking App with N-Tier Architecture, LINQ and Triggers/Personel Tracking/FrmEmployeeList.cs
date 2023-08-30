using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DTO;
using Microsoft.SqlServer.Server;

namespace Personel_Tracking
{
    public partial class FrmEmployeeList : Form
    {
        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChangeToEmployeeForm();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmEmployee frm = new FrmEmployee();

            frm.isUpdate = true;
            frm.detail = detail;

            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();
            CleanFilters();
        }

        private void ChangeToEmployeeForm()
        {
            FrmEmployee frm = new FrmEmployee();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();
            CleanFilters();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool comboFull = false;
        void FillGrid()
        {
            dto = EmployeeBLL.GetEmployees();
            dataGridView1.DataSource = dto.Employees;

            //fill comboboxes
            comboFull = false;

            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = -1;

            comboFull = true;
        }

        EmployeeDTO dto = new EmployeeDTO();
        EmployeeDetailDTO detail = new EmployeeDetailDTO();
        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            FillGrid();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Surname";
            dataGridView1.Columns[4].HeaderText = "Dapartment";
            dataGridView1.Columns[5].HeaderText = "Position";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            if (UserStatic.isAdmin == true)
                dataGridView1.Columns[8].HeaderText = "Salary";
            else
                dataGridView1.Columns[8].Visible = false;

            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID ==
                Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<EmployeeDetailDTO> list = dto.Employees;

            if (txtUserNo.Text.Trim() != "")
                list = list.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();

            if (txtName.Text.Trim() != "")
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();

            if (txtSurname.Text.Trim() != "")
                list = list.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();

            if (cmbDepartment.SelectedIndex != -1)
                list = list.Where(x => x.DepartmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();

            if (cmbPosition.SelectedIndex != -1)
                list = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();

            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        void CleanFilters()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            comboFull = false;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.DataSource = dto.Positions;
            cmbPosition.SelectedIndex = -1;
            comboFull = true;

            dataGridView1.DataSource = dto.Employees;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Surname = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.DepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            detail.PositionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detail.Salary = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detail.IsAdmin = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detail.Password = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            detail.ImagePath = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            detail.Adress = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            detail.Birthday = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this employee", "Warning!", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                EmployeeBLL.DeleteEmployee(detail.EmployeeID);
                MessageBox.Show("Employee was deleted");
                FillGrid();
                CleanFilters();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.ExcelExport(dataGridView1);
        }
    }
}
