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
            this.loadAllSubjects();
        }
        private void loadAllSubjects()
        {
            var subjects = this.Business.getSubjects();
            var subjectviews = new SubjectView[subjects.Length];
            for(int i = 0; i < subjectviews.Length; i++)
            {
                subjectviews[i] = new SubjectView(subjects[i]);
            }
            dataGridView1.DataSource = subjectviews;
        }
    }
}
