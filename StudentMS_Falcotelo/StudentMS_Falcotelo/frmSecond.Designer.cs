
namespace StudentMS_Falcotelo
{
    partial class frmSecond
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.txtfirst = new System.Windows.Forms.TextBox();
            this.txtmid = new System.Windows.Forms.TextBox();
            this.txtlast = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpbday = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbcourse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTxtSubjectNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtSubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBtnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // dgvShow
            // 
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTxtSubjectNumber,
            this.dgvTxtSubjectName,
            this.dgvBtnDelete});
            this.dgvShow.Location = new System.Drawing.Point(12, 265);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.RowHeadersWidth = 51;
            this.dgvShow.RowTemplate.Height = 24;
            this.dgvShow.Size = new System.Drawing.Size(389, 181);
            this.dgvShow.TabIndex = 1;
            this.dgvShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellContentClick);
            // 
            // txtfirst
            // 
            this.txtfirst.Location = new System.Drawing.Point(158, 29);
            this.txtfirst.Name = "txtfirst";
            this.txtfirst.Size = new System.Drawing.Size(243, 24);
            this.txtfirst.TabIndex = 3;
            // 
            // txtmid
            // 
            this.txtmid.Location = new System.Drawing.Point(158, 63);
            this.txtmid.Name = "txtmid";
            this.txtmid.Size = new System.Drawing.Size(243, 24);
            this.txtmid.TabIndex = 4;
            // 
            // txtlast
            // 
            this.txtlast.Location = new System.Drawing.Point(158, 97);
            this.txtlast.Name = "txtlast";
            this.txtlast.Size = new System.Drawing.Size(243, 24);
            this.txtlast.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Middle Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Last Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(300, 221);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 38);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 38);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(195, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 38);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpbday
            // 
            this.dtpbday.Location = new System.Drawing.Point(158, 131);
            this.dtpbday.Name = "dtpbday";
            this.dtpbday.Size = new System.Drawing.Size(241, 24);
            this.dtpbday.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Birth Date";
            // 
            // cmbcourse
            // 
            this.cmbcourse.FormattingEnabled = true;
            this.cmbcourse.Location = new System.Drawing.Point(158, 165);
            this.cmbcourse.Name = "cmbcourse";
            this.cmbcourse.Size = new System.Drawing.Size(241, 25);
            this.cmbcourse.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Course";
            // 
            // dgvTxtSubjectNumber
            // 
            this.dgvTxtSubjectNumber.HeaderText = "Number";
            this.dgvTxtSubjectNumber.Name = "dgvTxtSubjectNumber";
            this.dgvTxtSubjectNumber.Visible = false;
            // 
            // dgvTxtSubjectName
            // 
            this.dgvTxtSubjectName.HeaderText = "Subject Name";
            this.dgvTxtSubjectName.Name = "dgvTxtSubjectName";
            // 
            // dgvBtnDelete
            // 
            this.dgvBtnDelete.HeaderText = "Action";
            this.dgvBtnDelete.Name = "dgvBtnDelete";
            this.dgvBtnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBtnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmSecond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 504);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbcourse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpbday);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtlast);
            this.Controls.Add(this.txtmid);
            this.Controls.Add(this.txtfirst);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSecond";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            this.Load += new System.EventHandler(this.frmSecond_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.TextBox txtfirst;
        private System.Windows.Forms.TextBox txtmid;
        private System.Windows.Forms.TextBox txtlast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpbday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbcourse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtSubjectNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtSubjectName;
        private System.Windows.Forms.DataGridViewButtonColumn dgvBtnDelete;
    }
}