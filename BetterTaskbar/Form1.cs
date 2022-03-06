using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            //Getting and accessing the flowPanel
            FlowLayoutPanel taskBarFlowLayout = this.taskBarIcons;
            taskBarFlowLayout.Height = 100;
            //Read from a file here for shortcuts
            Button temp;
            for(int i=0; i < 200; i++)
            {
                temp = new Button();
                temp.Text = i.ToString(); //Text is the name of application to open
                //need to figure out text visibility
                temp.Click += button_Clicked;
                temp.MinimumSize = new Size(0, 0);
                temp.MaximumSize = new Size(50, 50);
                temp.Height = 25;
                temp.Width = 25;
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
                
                //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon("firefox.exe"); //need to find the path for each application to load
                Image img = icon.ToBitmap(); // Image.FromFile("C:\\Repositories\\BetterTaskbar\\BetterTaskbar\\BetterTaskbar\\test.png");
                temp.Image = img;
                
                taskBarFlowLayout.Controls.Add(temp);
            }




            var fb = this.ClientRectangle; // Or form.Bounds

            EventHandler tickHandler = (sender, args) =>
            {
                var mp = Cursor.Position;



                Console.WriteLine("MP: " + mp.ToString() + " FB: " + fb.ToString());
                if ((mp.X < fb.X + fb.Width) 
                && (mp.X > fb.X) 
                && (mp.Y > screen.Height - fb.Height) 
                && (mp.Y < screen.Height))//!(mp.X < fb.X && mp.Y < fb.Y && mp.X > fb.X + fb.Width && mp.Y > fb.Y + fb.Height))
                {
                    /*
                    Console.WriteLine("Should Maximize");
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                    */ //trying just moving the app off screen instead of min/maxing it for reduction of appearence lag
                    //Moving app faster than minimizing and maximizing app
                    this.Location = new Point(0, (screen.Height - h) + 37);

                    // Use GetKeyState from user32.dll to detect if at least 1 key is pressed
                    // (look at internet how to do it exactly)
                    // If yes MessageBox.Show("Clicked outside");
                }
                else
                {
                    //Console.WriteLine("Should Minimize");
                    //this.WindowState = FormWindowState.Minimized;
                    //this.TopMost = false;
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
            //t.Text = "clicked";
            //t.Image = null;

            
            Process p = new Process();
            p.StartInfo.FileName = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
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
