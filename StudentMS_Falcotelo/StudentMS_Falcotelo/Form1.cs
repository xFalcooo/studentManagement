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

namespace StudentMS_Falcotelo
{
    public partial class frmMain : Form
    {
        public string connectionString = "Data Source=BENEDICK\\SQLEXPRESS;Initial Catalog=DBStudentMS_Falcotelo;Integrated Security=True";

        public frmMain()
        {
            InitializeComponent();
            refresher();
            addButton();
        }
        private void refresher()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmdShow = new SqlCommand("select student_no AS [No.], concat(first_name, ' ', last_name) as [Student Name], course_name as Course, subject_name as Subject from tblStudent, tblCourse, tblSubject", con);
            cmdShow.ExecuteNonQuery();
            SqlDataAdapter daShow = new SqlDataAdapter(cmdShow);
            DataTable dtShow = new DataTable();
            daShow.Fill(dtShow);
            dgvShow.DataSource = dtShow;
        }
        private void addButton()
        {
            DataGridViewButtonColumn buttonDelColumn = new DataGridViewButtonColumn();
            buttonDelColumn.Name = "btnDEL";
            buttonDelColumn.HeaderText = "Action";
            buttonDelColumn.Text = "DELETE";
            buttonDelColumn.UseColumnTextForButtonValue = true;
            dgvShow.Columns.Add(buttonDelColumn);

            DataGridViewButtonColumn buttonUpdColumn = new DataGridViewButtonColumn();
            buttonUpdColumn.Name = "btnUPD";
            buttonUpdColumn.HeaderText = "Actions";
            buttonUpdColumn.Text = "UPDATE";
            buttonUpdColumn.UseColumnTextForButtonValue = true;
            dgvShow.Columns.Add(buttonUpdColumn);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvShow.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShow.AllowUserToAddRows = false;
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvShow.Columns["btnUPD"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show("cute");
            }

            if (e.ColumnIndex == dgvShow.Columns["btnDEL"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show("luh");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSecond second = new frmSecond();
            this.Hide();
            second.Show();
        }
    }
}
