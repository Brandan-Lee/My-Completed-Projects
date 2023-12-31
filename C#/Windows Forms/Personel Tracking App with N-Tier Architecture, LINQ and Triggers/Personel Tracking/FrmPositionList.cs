﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL.DTO;

namespace Personel_Tracking
{
    public partial class FrmPositionList : Form
    {
        public FrmPositionList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!UserStatic.isAdmin)
                MessageBox.Show("You are not an admin");
            else
                ChangeToPositionForm();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!UserStatic.isAdmin)
                MessageBox.Show("You are not an admin");
            else
            {
                if (detail.ID == 0)
                    MessageBox.Show("Please select a position from the table");
                else
                {
                    FrmPosition frm = new FrmPosition();

                    frm.isUpdate = true;
                    frm.detail = detail;

                    this.Hide();
                    frm.ShowDialog();
                    this.Visible = true;
                    FillGrid();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ChangeToPositionForm()
        {
            FrmPosition frm = new FrmPosition();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();
        }

        void FillGrid()
        {
            positionList = PositionBLL.GetPositions();
            dataGridView1.DataSource = positionList;
        }

        List<PositionDTO> positionList = new List<PositionDTO>();
        PositionDTO detail = new PositionDTO();
        private void FrmPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridView1.Columns[0].HeaderText = "Department Name";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Postition Name";
            dataGridView1.Columns[4].Visible = false;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.PositionName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.DepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.OldDepartmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UserStatic.isAdmin)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this position", "Warning!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    PositionBLL.DeletePosition(detail.ID);
                    MessageBox.Show("Position was deleted");
                    FillGrid();
                }
            }
            else
                MessageBox.Show("You are not an admin");
        }
    }
}
