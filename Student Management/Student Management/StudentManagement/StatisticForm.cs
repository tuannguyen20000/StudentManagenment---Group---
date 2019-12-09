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
    public partial class StatisticForm : Form
    {
        private LogicLayer Business;
        public StatisticForm()
        {
            this.Business = new LogicLayer();
            InitializeComponent();
            this.Load += StatisticForm_Load;
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            this.ShowAllFacullty();
        }
        private void ShowAllFacullty()
        {
            var faculty = this.Business.getFaculty();
            var facultyviews = new FacultyView[faculty.Length];
            for(int i = 0; i < facultyviews.Length; i++)
            {
                facultyviews[i] = new FacultyView(faculty[i]);
            }
            grdStatistic.DataSource = facultyviews;
        }

    }
}
