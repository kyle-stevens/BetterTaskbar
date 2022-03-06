using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Json.Net;

namespace BetterTaskbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            
            //Screen Sizing and Positioning Logic
            StartPosition = FormStartPosition.Manual;
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = screen.Width;
            int h = 100; //will need to adjust sizing later;
            this.Location = new Point(0, (screen.Height - h) +37);
            this.Size = new Size(w+20, h);
            


            //Removing Header/Titlebar
            this.ControlBox = false;
            this.Text = String.Empty;

            //Making it non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;

            //Getting and accessing the flowPanel
            FlowLayoutPanel taskBarFlowLayout = this.taskBarIcons;
            taskBarFlowLayout.Height = 100;

            //Read from a file here for shortcuts
            using (StreamReader r = new StreamReader("./shortcutList.json"))
            {
                string json = r.ReadToEnd();
                
            }



                Button temp;
            for(int i=0; i < 200; i++)
            {
                temp = new Button();
                temp.Text = "C:\\Program Files\\Mozilla Firefox\\firefox.exe"; //Text is the name of application to open
                //need to figure out text visibility
                temp.Click += button_Clicked;
                temp.MinimumSize = new Size(0, 0);
                temp.MaximumSize = new Size(50, 50);
                temp.Height = 25;
                temp.Width = 25;
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(temp.Text);
                
                //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon("firefox.exe"); //need to find the path for each application to load
                Image img = icon.ToBitmap(); // Image.FromFile("C:\\Repositories\\BetterTaskbar\\BetterTaskbar\\BetterTaskbar\\test.png");
                temp.Image = img;
                
                taskBarFlowLayout.Controls.Add(temp);
            }




            var fb = this.ClientRectangle;

            EventHandler tickHandler = (sender, args) =>
            {
                var mp = Cursor.Position;



                Console.WriteLine("MP: " + mp.ToString() + " FB: " + fb.ToString());
                if ((mp.X < fb.X + fb.Width) 
                && (mp.X > fb.X) 
                && (mp.Y > screen.Height - fb.Height) 
                && (mp.Y < screen.Height))
                {
                    this.Location = new Point(0, (screen.Height - h) + 37);
                }
                else
                {
                    this.Location = new Point(0, (screen.Height - h) + 137);
                }
            };





            Timer t1 = new Timer();
            t1.Interval = 500;
            t1.Tick += tickHandler;
            t1.Start();

        }

        private void funcMouseCaptureChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Mouse left or entered");
            return;
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            Button t = (Button)sender;
            Process p = new Process();
            p.StartInfo.FileName = t.Text;
            p.Start();
            return;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "notepad.exe";
            p.Start();

            //should open a window to select number of screens, size, size of icons/taskbar, color scheme, and etc.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
