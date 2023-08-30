namespace Personel_Tracking
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Location = new System.Drawing.Point(12, 12);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(133, 134);
            this.btnEmployee.TabIndex = 0;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnTasks
            // 
            this.btnTasks.BackColor = System.Drawing.Color.Cyan;
            this.btnTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTasks.Location = new System.Drawing.Point(151, 12);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(133, 134);
            this.btnTasks.TabIndex = 1;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = false;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.BackColor = System.Drawing.Color.Lime;
            this.btnSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalary.Location = new System.Drawing.Point(290, 12);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(133, 134);
            this.btnSalary.TabIndex = 2;
            this.btnSalary.Text = "Salary";
            this.btnSalary.UseVisualStyleBackColor = false;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnPermission
            // 
            this.btnPermission.BackColor = System.Drawing.Color.Green;
            this.btnPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermission.Location = new System.Drawing.Point(12, 152);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(133, 134);
            this.btnPermission.TabIndex = 3;
            this.btnPermission.Text = "Permission";
            this.btnPermission.UseVisualStyleBackColor = false;
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // btnPosition
            // 
            this.btnPosition.BackColor = System.Drawing.Color.Fuchsia;
            this.btnPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosition.Location = new System.Drawing.Point(290, 152);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(133, 134);
            this.btnPosition.TabIndex = 5;
            this.btnPosition.Text = "Position";
            this.btnPosition.UseVisualStyleBackColor = false;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepartment.Location = new System.Drawing.Point(151, 152);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(133, 134);
            this.btnDepartment.TabIndex = 4;
            this.btnDepartment.Text = "Department";
            this.btnDepartment.UseVisualStyleBackColor = false;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(210, 292);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 134);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Yellow;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(71, 292);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(133, 134);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 450);
            this.Controls.Add(this.btnPosition);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.btnDepartment);
            this.Controls.Add(this.btnTasks);
            this.Controls.Add(this.btnEmployee);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Tracking";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
    }
}