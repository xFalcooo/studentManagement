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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace StudentMS_Falcotelo
{
    public partial class frmSecond : Form
    {
        DBStudentMS_FalcoteloEntities db = new DBStudentMS_FalcoteloEntities();

        public tblStudent recordStudent { get; set; }
        public List<tblSubject> recordSubject { get; set; }

        public frmSecond()
        {
            InitializeComponent();
            recordStudent = new tblStudent();
            recordSubject = new List<tblSubject>();
        }

        private void listCourse()
        {
            var listOfCourse = db.tblCourse.ToList();
            cmbcourse.DataSource = listOfCourse;
            cmbcourse.DisplayMember = "course_name";
            cmbcourse.ValueMember = "course_id";
        }
        private void loadStudentSubject()
        {
            dgvShow.Rows.Clear();

            recordSubject.ForEach(o =>
            {
                var index = dgvShow.Rows.Add();
                dgvShow.Rows[index].Cells["dgvTxtSubjectNumber"].Value = o.subject_no;
                dgvShow.Rows[index].Cells["dgvTxtSubjectName"].Value = o.subject_name;
            });
        }
        public void addSubject(tblSubject subject)
        {
            if (recordSubject == null)
                recordSubject = new List<tblSubject>();

            recordSubject.Add(subject);

            var index = dgvShow.Rows.Add();
            dgvShow.Rows[index].Cells["dgvTxtSubjectNumber"].Value = subject.subject_no;
            dgvShow.Rows[index].Cells["dgvTxtSubjectName"].Value = subject.subject_name;
        }

        public void ShowForm2()
        {
            // Show Form when called
            this.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }

        private void frmSecond_Load(object sender, EventArgs e)
        {
            dgvShow.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShow.AllowUserToAddRows = false;

            listCourse();

            txtfirst.Text = recordStudent?.first_name;
            txtmid.Text = recordStudent?.middle_name;
            txtlast.Text = recordStudent?.last_name;
            dtpbday.Value = (DateTime)(recordStudent?.birth_date ?? DateTime.Today);
            cmbcourse.SelectedValue = recordStudent?.course_id ?? 1;

            loadStudentSubject();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmThird thirdForm = new frmThird();
            thirdForm.SetForm2(this);
            this.Hide();
            thirdForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (db = new DBStudentMS_FalcoteloEntities()) // Replace with your actual DbContext class
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (recordStudent == null || recordStudent.student_no == 0)
                        {
                            //Save New Record
                            var addedStudent = db.tblStudent.Add(new tblStudent()
                            {
                                first_name = txtfirst.Text,
                                middle_name = txtmid.Text,
                                last_name = txtlast.Text,
                                birth_date = dtpbday.Value,
                                course_id = (int?)(cmbcourse.SelectedValue ?? null),
                            });

                            recordSubject.ForEach(o =>
                            {
                                db.tblAssignedSubject.Add(new tblAssignedSubject()
                                {
                                    student_no = addedStudent.student_no,
                                    subject_no = o.subject_no
                                });
                            });
                        }
                        else
                        {
                            //Update Existing Record
                            var updateStudent = db.tblStudent.Where(o => o.student_no == recordStudent.student_no).FirstOrDefault();
                            updateStudent.first_name = txtfirst.Text;
                            updateStudent.middle_name = txtmid.Text;
                            updateStudent.last_name = txtlast.Text;
                            updateStudent.birth_date = dtpbday.Value;
                            updateStudent.course_id = (int?)(cmbcourse.SelectedValue ?? null);

                            var listOfAssignedSubjectNo = recordSubject.Select(o => (int?)o.subject_no).ToList();

                            var deletedAssignedSubject = db.tblAssignedSubject
                                .Where(x => !listOfAssignedSubjectNo.Contains(x.subject_no) && x.student_no == recordStudent.student_no).ToList();
                            db.tblAssignedSubject.RemoveRange(deletedAssignedSubject);

                            var addedAssignedSubject = recordSubject
                                .Where(x => !db.tblAssignedSubject.Any(y => y.subject_no == x.subject_no && y.student_no == recordStudent.student_no)).ToList();

                            addedAssignedSubject.ForEach(o =>
                            {
                                db.tblAssignedSubject.Add(new tblAssignedSubject()
                                {
                                    student_no = recordStudent.student_no,
                                    subject_no = o.subject_no
                                });
                            });
                        }
                        
                        //db.SaveChanges();

                        db.SaveChanges();

                        transaction.Commit();

                        MessageBox.Show("Student Record added/updated successfully.");

                        frmMain main = new frmMain();
                        this.Hide();
                        main.Show();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error occurred.");
                    }
                }
            }
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvShow.Columns["dgvBtnDelete"].Index && e.RowIndex >= 0)
            {
                int selectedrowindex = dgvShow.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvShow.Rows[selectedrowindex];
                int deleteSubjectNo = Convert.ToInt32(selectedRow.Cells[0].Value);

                var deletedSubject = recordSubject.Find(o => o.subject_no == deleteSubjectNo);
                recordSubject.Remove(deletedSubject);
                dgvShow.Rows.RemoveAt(selectedrowindex);
            }
        }
    }
}
