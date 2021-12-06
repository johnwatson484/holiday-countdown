using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HolidayCountdown
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            int x = Screen.PrimaryScreen.WorkingArea.Left + 20;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - 20;
            this.Location = new Point(x, y);

            txtHoliday.CustomFormat = "dd/MM/yyyy HH:mm";

            txtName.Text = Properties.Settings.Default.Name;
            txtHoliday.Text = Properties.Settings.Default.HolidayDate;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string Holiday = txtHoliday.Text.ToString();

            if (Name != "" && Holiday != "")
            {
                Properties.Settings.Default.Name = Name.Trim();
                Properties.Settings.Default.HolidayDate = Holiday.Trim();

                Properties.Settings.Default.Save();

                Application.Restart();
            }
        }
    }
}
