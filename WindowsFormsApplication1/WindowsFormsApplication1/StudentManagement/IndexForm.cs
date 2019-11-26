using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.StudentManagement
{
    public partial class IndexForm : Form
    {
        private LogicLayer Business;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStudents.DoubleClick += grdStudents_DoubleClick;
        }

        void grdStudents_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdStudents.SelectedRows.Count == 1)
            {
                var row = this.grdStudents.SelectedRows[0];
                var studentView = (StudentView)row.DataBoundItem;

                new UpdateForm(studentView.id).ShowDialog();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            new CreateForm().ShowDialog();
            this.ShowAllStudents();
        }

        private void ShowAllStudents()
        {
            this.grdStudents.DataSource = this.Business.GetStudents();
            var students = this.Business.GetStudents();
            var studentsviews = new StudentView[students.Length];
            for (int i = 0; i < students.Length; i++)
                studentsviews[i] = new StudentView(students[i]);
            this.grdStudents.DataSource = studentsviews;
        }
        void IndexForm_Load(object sender, EventArgs e)
        {
            this.ShowAllStudents();
        }
    }
}
