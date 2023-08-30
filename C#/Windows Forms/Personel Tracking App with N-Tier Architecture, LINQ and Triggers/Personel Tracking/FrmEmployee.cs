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
using DAL.DTO;
using System.IO;

namespace Personel_Tracking
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        EmployeeDTO dto = new EmployeeDTO();
        public EmployeeDetailDTO detail = new EmployeeDetailDTO();
        public bool isUpdate = false;
        string imagePath = "";
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            dto = EmployeeBLL.GetEmployees();

            //fill comboboxes
            cmbDepartment.DataSource = dto.Departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            cmbPosition.DataSource = dto.Positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = -1;
            comboFull = true;

            if (isUpdate)
            {
                txtUserNo.Text = detail.UserNo.ToString();
                txtPassword.Text = detail.Password;
                chAdmin.Checked = Convert.ToBoolean(detail.IsAdmin);
                txtName.Text = detail.Name;
                txtSurname.Text = detail.Surname;
                txtSalary.Text = detail.Salary.ToString();
                cmbDepartment.SelectedValue = Convert.ToInt32(detail.DepartmentID);
                cmbPosition.SelectedValue = Convert.ToInt32(detail.PositionID);
                dpBirthday.Value = Convert.ToDateTime(detail.Birthday);
                txtAdress.Text = detail.Adress;
                imagePath = Application.StartupPath + "\\images\\" + detail.ImagePath;
                txtImagePath.Text = imagePath;
                pictureBox1.ImageLocation = imagePath;

                if (!UserStatic.isAdmin)
                {
                    chAdmin.Enabled = false;
                    txtSalary.Enabled = false;
                    cmbDepartment.Enabled = false;
                    cmbPosition.Enabled = false;
                    txtUserNo.Enabled = false;
                }
            }
        }

        bool comboFull = false;
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList(); 
            }
        }

        string fileName = "";
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                txtImagePath.Text = openFileDialog1.FileName;
                string unigue = Guid.NewGuid().ToString();
                fileName += unigue + openFileDialog1.SafeFileName;
            }
        }

        public int count = 1;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User No is empty");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Password is empty");
            else if (txtName.Text.Trim() == "")
                MessageBox.Show("Name is empty");
            else if (txtSurname.Text.Trim() == "")
                MessageBox.Show("Surname is empty");
            else if (txtSalary.Text.Trim() == "")
                MessageBox.Show("Salary is empty");
            else if (cmbDepartment.SelectedIndex == -1)
                MessageBox.Show("Select a department");
            else if (cmbPosition.SelectedIndex == -1)
                MessageBox.Show("Select a position");
            else
            {
                if (!isUpdate)
                {
                    if (!EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text)))
                        MessageBox.Show("This user no is used by another employee, please change");
                    else
                    {
                        EMPLOYEE employee = new EMPLOYEE();
                        employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                        employee.Password = txtPassword.Text;
                        employee.Name = txtName.Text;
                        employee.Surname = txtSurname.Text;
                        employee.Salary = Convert.ToInt32(txtSalary.Text);
                        employee.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                        employee.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);
                        employee.Adress = txtAdress.Text;
                        employee.Birthday = dpBirthday.Value;
                        employee.ImagePath = fileName;
                        employee.IsAdmin = chAdmin.Checked;

                        EmployeeBLL.AddEmployee(employee);
                        File.Copy(txtImagePath.Text, @"images\\" + fileName);
                        MessageBox.Show("Employee was added");

                        txtUserNo.Clear();
                        txtPassword.Clear();
                        chAdmin.Checked = false;
                        txtName.Clear();
                        txtSurname.Clear();
                        txtSalary.Clear();
                        txtAdress.Clear();
                        txtImagePath.Clear();
                        pictureBox1.Image = null;
                        cmbDepartment.SelectedIndex = -1;
                        cmbPosition.DataSource = dto.Positions;
                        cmbPosition.SelectedIndex = -1;
                        comboFull = true;
                        dpBirthday.Value = DateTime.Today;
                        employee = new EMPLOYEE();
                        this.Close();
                    }
                }
                else if (isUpdate)
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        EMPLOYEE employee = new EMPLOYEE();

                        if (txtImagePath.Text != imagePath)
                        {
                            if (File.Exists(@"images\\" + detail.ImagePath))
                                File.Delete(@"images\\" + detail.ImagePath);

                            File.Copy(txtImagePath.Text, @"images\\" + fileName);

                            employee.ImagePath = fileName;
                        }
                        else
                            employee.ImagePath = detail.ImagePath;

                        employee.ID = detail.EmployeeID;
                        employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                        employee.Name = txtName.Text;
                        employee.Surname = txtSurname.Text;
                        employee.IsAdmin = chAdmin.Checked;
                        employee.Password = txtPassword.Text;
                        employee.Adress = txtAdress.Text;
                        employee.Birthday = dpBirthday.Value;
                        employee.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                        employee.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);
                        employee.Salary = Convert.ToInt32(txtSalary.Text);

                        EmployeeBLL.UpdateEmployee(employee);
                        MessageBox.Show("Employee was updated");
                        this.Close();
                    }
                }
            }
        }

        bool isUnique = false;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User No is empty");
            else
            {
                isUnique = EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text));

                if (!isUnique)
                    MessageBox.Show("This user no is used by another employee, please change");
                else
                    MessageBox.Show("This user no is usable");
            }
        }
    }
}
