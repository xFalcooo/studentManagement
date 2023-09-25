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
    public partial class frmThird : Form
    {
        string connectionString = "Data Source=BENEDICK\\SQLEXPRESS;Initial Catalog=DBStudentMS_Falcotelo;Integrated Security=True";

        public frmThird()
        {
            InitializeComponent();
            subjectList();
            addButtons();
        }
        private void subjectList()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmdSubject = new SqlCommand("select subject_name as [Subject Name] from tblSubject", con);
            cmdSubject.ExecuteNonQuery();
            SqlDataAdapter adSubject = new SqlDataAdapter(cmdSubject);
            DataTable dtSubject = new DataTable();
            adSubject.Fill(dtSubject);
            dgvShow.DataSource = dtSubject;
        }
        private void addButtons()
        {
            DataGridViewButtonColumn buttonSelColumn = new DataGridViewButtonColumn();
            buttonSelColumn.Name = "btnSEL";
            buttonSelColumn.HeaderText = "Action";
            buttonSelColumn.Text = "Select";
            buttonSelColumn.UseColumnTextForButtonValue = true;
            dgvShow.Columns.Add(buttonSelColumn);
        }

        private void frmThird_Load(object sender, EventArgs e)
        {
            dgvShow.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvShow.AllowUserToAddRows = false;
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvShow.Columns["btnSEL"].Index && e.RowIndex >= 0)
            {
                int selectedrowindex = dgvShow.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvShow.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells[1].Value);
       
                frmSecond second = new frmSecond();
                second.value = cellValue;
                this.Hide();
                second.Show();
            }
        }
    }
}
