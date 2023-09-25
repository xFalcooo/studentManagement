using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using StudentMS_Falcotelo.Model;

namespace StudentMS_Falcotelo
{
    public partial class frmThird : Form
    {
        DBStudentMS_FalcoteloEntities db = new DBStudentMS_FalcoteloEntities();

        private frmSecond secondForm;

        public frmThird()
        {
            InitializeComponent();
        }
        // Set Form1 reference
        public void SetForm2(frmSecond form2)
        {
            this.secondForm = form2;
        }

        private void frmThird_Load(object sender, EventArgs e)
        {
            dgvShow.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShow.AllowUserToAddRows = false;

            db.tblSubject.ToList().ForEach(o =>
            {
                var index = dgvShow.Rows.Add();
                dgvShow.Rows[index].Cells["dgvTxtSubjectNumber"].Value = o.subject_no;
                dgvShow.Rows[index].Cells["dgvTxtSubjectName"].Value = o.subject_name;
            });
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvShow.Columns["dgvBtnSelect"].Index && e.RowIndex >= 0)
            {
                int selectedrowindex = dgvShow.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvShow.Rows[selectedrowindex];
                int number = Convert.ToInt32(selectedRow.Cells["dgvTxtSubjectNumber"].Value);
                string name = Convert.ToString(selectedRow.Cells["dgvTxtSubjectName"].Value);
                var selectedSubject = new tblSubject
                {
                    subject_no = number,
                    subject_name = name,
                };

                secondForm.addSubject(selectedSubject);
                this.Hide();
                secondForm.ShowForm2();
            }
        } 
    }
}
