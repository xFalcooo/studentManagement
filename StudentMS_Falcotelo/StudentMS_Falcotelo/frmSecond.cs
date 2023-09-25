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
    public partial class frmSecond : Form
    {
        string connectionString = "Data Source=BENEDICK\\SQLEXPRESS;Initial Catalog=DBStudentMS_Falcotelo;Integrated Security=True";

        public string value { get; set; }
        public frmSecond()
        {
            InitializeComponent();
          
        }
        private void addClicked()
        {
            
        }
        private void addButtons()
        {
            DataGridViewButtonColumn buttonDelColumn = new DataGridViewButtonColumn();
            buttonDelColumn.Name = "btnDEL";
            buttonDelColumn.HeaderText = "Action";
            buttonDelColumn.Text = "Delete";
            buttonDelColumn.UseColumnTextForButtonValue = true;
            dgvShow.Columns.Add(buttonDelColumn);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmThird third = new frmThird();
            this.Hide();
            third.Show();
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
            MessageBox.Show(value);
            try
            {
                DataGridViewButtonColumn buttonDelColumn = new DataGridViewButtonColumn();
                buttonDelColumn.Name = "btnDEL";
                buttonDelColumn.HeaderText = "Action";
                buttonDelColumn.Text = "Delete";
                buttonDelColumn.UseColumnTextForButtonValue = true;

                var index = this.dgvShow.Rows.Add();
                this.dgvShow.Rows[index].Cells[0].Value = value;
                
            }
            catch
            {

            }
            //addButtons();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dtpbday.Text);
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmdAddToStudent = new SqlCommand("insert into tblStudent (first_name, middle_name, last_name, birth_date) values ('"+txtfirst.Text+"','"+txtmid.Text+"','"+txtlast.Text+"','"+dtpbday.Value.Date.ToString("yyyyMMdd") + "')", con);
            cmdAddToStudent.ExecuteNonQuery();
            SqlCommand cmdAddToSubject = new SqlCommand("insert into tblSubject (subject_name) values ('" + value + "')");
            cmdAddToSubject.ExecuteNonQuery();
            SqlCommand cmdAddToCourse = new SqlCommand("insert into tblSubject (subject_name) values ('" + value + "')");
            cmdAddToCourse.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Saved");
        }
    }
}
