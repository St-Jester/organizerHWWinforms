using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Form2 : Form
    {

        public string currentdate;
        public string taskinfo, taskTitle;

        public Form2()
        {
            InitializeComponent();
        }

        private void AddTaskbutton1_Click(object sender, EventArgs e)
        {
            taskinfo = textBox2.Text;
            taskTitle = textBox2.Text;
            DialogResult = DialogResult.OK;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 1;
            currentdate = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }


    }
}
