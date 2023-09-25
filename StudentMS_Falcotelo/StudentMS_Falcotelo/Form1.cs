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
using System.Data.Entity;

namespace StudentMS_Falcotelo
{
    public partial class frmMain : Form
    {
        DBStudentMS_FalcoteloEntities db = new DBStudentMS_FalcoteloEntities();

        public frmMain()
        {
            InitializeComponent();
        }

        private void studentRecord()
        {
            dgvShow.DataSource = null;
            dgvShow.Columns.Clear();
            var recordsList = db.vwStudentRecord.ToList();
            dgvShow.DataSource = recordsList;

            addButton();
        }
        private void addButton()
        {
            DataGridViewButtonColumn buttonDelColumn = new DataGridViewButtonColumn();
            buttonDelColumn.Name = "btnDEL";
            buttonDelColumn.HeaderText = "Delete";
            buttonDelColumn.Text = "DELETE";
            buttonDelColumn.UseColumnTextForButtonValue = true;
            buttonDelColumn.FlatStyle = FlatStyle.Popup;
            dgvShow.Columns.Add(buttonDelColumn);

            DataGridViewButtonColumn buttonUpdColumn = new DataGridViewButtonColumn();
            buttonUpdColumn.Name = "btnUPD";
            buttonUpdColumn.HeaderText = "Update";
            buttonUpdColumn.Text = "UPDATE";
            buttonUpdColumn.UseColumnTextForButtonValue = true;
            buttonUpdColumn.FlatStyle = FlatStyle.Popup;
            dgvShow.Columns.Add(buttonUpdColumn);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvShow.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShow.AllowUserToAddRows = false;
            studentRecord();
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (db = new DBStudentMS_FalcoteloEntities())
            {
                int selectedrowindex = dgvShow.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvShow.Rows[selectedrowindex];
                int studentNo = Convert.ToInt32(selectedRow.Cells[0].Value);

                // Step 1: Query the record to delete
                var selectedStudent = db.tblStudent.Where(o => o.student_no == studentNo).FirstOrDefault(); // Replace YourTable and Id with your table and primary key
                var selectedAssignedSubject = db.tblAssignedSubject.Where(o => o.student_no == studentNo).ToList(); // Replace YourTable and Id with your table and primary key

                var listOfSubjectNo = selectedAssignedSubject.Select(x => x.subject_no ?? 0).ToList();
                var selectedSubject = db.tblSubject.Where(o => listOfSubjectNo.Contains(o.subject_no)).ToList();
                if (selectedStudent != null)
                {
                    if (e.ColumnIndex == dgvShow.Columns["btnUPD"].Index && e.RowIndex >= 0)
                    {
                        frmSecond second = new frmSecond();
                        second.recordStudent = selectedStudent;
                        second.recordSubject.AddRange(selectedSubject);
                        this.Hide();
                        second.Show();
                    }

                    if (e.ColumnIndex == dgvShow.Columns["btnDEL"].Index && e.RowIndex >= 0)
                    {
                        // Step 2: Remove the record from the DbContext
                        db.tblStudent.Remove(selectedStudent);
                        db.tblAssignedSubject.RemoveRange(selectedAssignedSubject);

                        MessageBox.Show("Student Record deleted successfully.");
                    }

                    // Step 3: Call SaveChanges to commit the deletion to the database
                    db.SaveChanges();
                    studentRecord();
                }
                else
                {
                    Console.WriteLine("Record not found.");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSecond second = new frmSecond();
            this.Hide();
            second.Show();
        }

        private void dgvShow_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 4)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All
                    & ~(DataGridViewPaintParts.ContentForeground));
                var r = e.CellBounds;
                r.Inflate(-4, -4);
                e.Graphics.FillRectangle(Brushes.Red, r);
                e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
            }
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All
                    & ~(DataGridViewPaintParts.ContentForeground));
                var r = e.CellBounds;
                r.Inflate(-4, -4);
                e.Graphics.FillRectangle(Brushes.Blue, r);
                e.Paint(e.CellBounds, DataGridViewPaintParts.ContentForeground);
                e.Handled = true;
            }
        }
    }
}
