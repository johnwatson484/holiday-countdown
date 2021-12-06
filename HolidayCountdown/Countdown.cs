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
    public partial class Countdown : Form
    {     
        
        public DateTime Holiday()
        {
            var HolidayDate = DateTime.Parse(Properties.Settings.Default.HolidayDate);

            return HolidayDate; 
        }

        public string UserName()
        {
            var Name = Properties.Settings.Default.Name;

            return Name.ToString();
        }           

        public Countdown()
        {
            InitializeComponent();

            int x = Screen.PrimaryScreen.WorkingArea.Left + 20;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height - 20;
            this.Location = new Point(x, y);          
                 
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Start();

            string Name = UserName();

            if (Name != null)
            {
                lbMain.Text = (Name + "'s Holiday Countdown");
            }
            else
            {
                lbMain.Text = ("Holiday Countdown");
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
           DateTime HolidayDate = Holiday() ;

           if (HolidayDate != null)
           {
               TimeSpan Time = HolidayDate - DateTime.Now;

               int Days = Time.Days;
               int Hours = Time.Hours;
               int Minutes = Time.Minutes;
               int Seconds = Time.Minutes;

               if (Time < TimeSpan.Zero)
               {
                   lbDays.Text = "00";
                   lbHours.Text = "00";
                   lbMinutes.Text = "00";
                   lbSeconds.Text = "00";
               }
               else
               {
                   lbDays.Text = Time.Days.ToString();
                   lbHours.Text = Time.Hours.ToString();
                   lbMinutes.Text = Time.Minutes.ToString();
                   lbSeconds.Text = Time.Seconds.ToString();
               }
           }
           else
           {
               lbDays.Text = "00";
               lbHours.Text = "00";
               lbMinutes.Text = "00";
               lbSeconds.Text = "00";
           }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settings = new Settings();
            settings.ShowDialog();
            
        }

    }
}
