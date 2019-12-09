using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management.StudentManagement
{
    public partial class IndexForm : Form
    {
        private LogicLayer Business;
        private Student studentview;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            this.btnAdd.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStudent.DoubleClick += grdStudents_DoubleClick;
            this.btnStatistic.Click += BtnStatistic_Click;
            txtSearch.Text = "Please enter code";
            txtSearch.ForeColor = Color.Gray;
            this.txtSearch.Leave += TxtSearch_Leave;
            this.txtSearch.Enter += TxtSearch_Enter;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var db = new StudentEntities4();
            grdStudent.DataSource = db.Students.Where(x => x.Name.Contains(txtSearch.Text)).ToList();
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Please enter code")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Please enter code";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void BtnStatistic_Click(object sender, EventArgs e)
        {
            new StatisticForm().ShowDialog();
            this.ShowAllStudent();
        }

        void grdStudents_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdStudent.SelectedRows.Count == 1)
            {
                var row = this.grdStudent.SelectedRows[0];
                var studentView = (StudentView)row.DataBoundItem;

                new UpdateForm(studentView.Id).ShowDialog();
            }
            this.ShowAllStudent();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdStudent.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this!!", "Comfirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var @student = (StudentView)this.grdStudent.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteStudent(@student.Id);
                    MessageBox.Show("Delete class successfully!!");
                    this.ShowAllStudent();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            new CreateForm().ShowDialog();
            this.ShowAllStudent();
        }

        private void ShowAllStudent()
        {
           // this.grdStudent.DataSource = this.Business.GetStudents();
            var students = this.Business.GetStudents();
            var studentViews = new StudentView[students.Length];
            for (int i = 0; i < students.Length; i++)
                studentViews[i] = new StudentView(students[i]);
            this.grdStudent.DataSource = studentViews;
        }
        void IndexForm_Load(object sender, EventArgs e)
        {
            this.ShowAllStudent();
        }
    }
}
