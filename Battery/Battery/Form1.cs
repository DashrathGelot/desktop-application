using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Media;

namespace Battery
{
    public partial class Form1 : Form
    {
        Timer timer1;
        SoundPlayer player = new SoundPlayer();
        double l = 100,B;
        public Form1()
        {
            InitializeComponent();
        }    
        private void Start_Click(object sender, EventArgs e)
        {
            String batterystatus;
            PowerStatus pwr = SystemInformation.PowerStatus;
            batterystatus = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
            String batterylife;
            batterylife = SystemInformation.PowerStatus.BatteryLifePercent.ToString();
            B = Convert.ToDouble(batterylife);
            B = B * 100;
            Console.WriteLine(B);
            label1.Text = "Battery level : " + B.ToString() + "%  Battery Status: " + batterystatus;
            if (B == l)
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "C:\\example\\Sample1.wav";
                player.PlayLooping();
                timer1.Enabled = false;
                //player.Play();
            }  
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(Start_Click);
            timer1.Interval = 200;
            timer1.Start();
            
        }
        private void stop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTimer();
        }
    }
}
