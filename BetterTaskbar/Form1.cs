using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Json.Net;
using Microsoft.Win32;

namespace BetterTaskbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            //Detect Applications From Windows Registry
            string[] applicationsDetected = new string[300];
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                int count = 0;
                foreach(string subkey_name in key.GetSubKeyNames())
                {
                    using(RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {

                        if(subkey.GetValue("InstallLocation") != null)
                        {
                            applicationsDetected[count] = (subkey.GetValue("DisplayName").ToString() + ":" + subkey.GetValue("InstallLocation").ToString());
                            //Console.WriteLine("Element Added");
                            count++;
                        }

                    }
                }
            }

            InitializeComponent();

            //Setting Up Windows Form Attributes
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;

            //Removing Header/Titlebar
            this.ControlBox = false;
            this.Text = String.Empty;

            //Making it non-resizable
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;

            //Getting Width of All Screens
            int appWidth = 0;
            foreach (Screen s in Screen.AllScreens)
            {
                appWidth = appWidth + s.WorkingArea.Width;
            }

            //Debug
            Console.WriteLine(appWidth);
            Console.WriteLine(Screen.AllScreens.Length);

            //Determine Maximum Number of Icons
            int numberOfIcons = 0;
            int MAX_ICON_COUNT = Screen.AllScreens.Length * 152 * (int)(appWidth / 1920) - 1;

            //Getting Taskbar
            ToolStrip taskBarFlowLayout = this.taskbarIcons;


            //Screen Sizing and Positioning Logic for Elements



            //Event Handler Delcaration
            //Options Button Handler
            EventHandler optionsButton_Click = (object sender, EventArgs e) =>
            {
                Console.WriteLine("Options Menu");
            };

            //Add Button Handler
            EventHandler addShortcutEventHandler = (sender, args) =>
            {
                if (numberOfIcons <= MAX_ICON_COUNT)
                {

                }
                else
                {
                    MessageBox.Show("Max Number of Icons Reached");
                    return;
                }

                //Create New Window to see items
                Form addNewShortcutWindow = new Form();
                addNewShortcutWindow.AutoSize = false;
                addNewShortcutWindow.Size = new Size(500, 500);


                ListBox applicationList = new ListBox();
                applicationList.Width = 500;
                applicationList.Height = 400;
                applicationList.SelectionMode = SelectionMode.One;
                applicationList.BeginUpdate();
                Console.WriteLine(applicationsDetected.Length);
                for (int i = 0; i < applicationsDetected.Length && applicationsDetected[i] != null; i++)
                {

                    applicationList.Items.Add(applicationsDetected[i].ToString().Substring(0, applicationsDetected[i].ToString().IndexOf(':')));
                    Console.WriteLine("Item Added");
                }
                applicationList.EndUpdate();
                applicationList.Hide();
                applicationList.Show();
                addNewShortcutWindow.Controls.Add(applicationList);

                Label lbl = new Label();
                lbl.Location = new Point(10, 400);
                lbl.Width = 500;
                lbl.Text = "Can't Find What You're Looking For? Find Your Application Manually";

                addNewShortcutWindow.Controls.Add(lbl);

                Button findAppManually = new Button();
                findAppManually.Text = "Find .exe";
                findAppManually.Location = new Point(10, 430);

                addNewShortcutWindow.Controls.Add(findAppManually);

                addNewShortcutWindow.Show();

                ToolStripButton temp;
                temp = new ToolStripButton();
                temp.Tag = "C:\\Program Files\\Mozilla Firefox\\firefox.exe"; //Text is the name of application to open
                //need to figure out text visibility
                temp.Click += button_Clicked;
                //temp.MinimumSize = new Size(0, 0);
                //temp.MaximumSize = new Size(50, 50);
                temp.AutoSize = false;
                temp.Height = 100;
                temp.Width = 100;
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(temp.Tag.ToString());

                //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon("firefox.exe"); //need to find the path for each application to load
                Image img = icon.ToBitmap(); // Image.FromFile("C:\\Repositories\\BetterTaskbar\\BetterTaskbar\\BetterTaskbar\\test.png");
                temp.Image = img;

                taskBarFlowLayout.Items.Add(temp);
                numberOfIcons++;

            };

            //Close Button
            Button closeButton = this.exitButton;
            closeButton.Location = new Point(appWidth - 49, closeButton.Location.Y);

            //Options Button
            Button options = (Button)this.optionsButton;
            options.Location = new Point(appWidth - 75, options.Location.Y);
            options.Click += optionsButton_Click;

            //Add Button
            Button addShortcut = this.addShortcutButton;
            addShortcut.Click += addShortcutEventHandler;
            addShortcut.Location = new Point(appWidth - 75,addShortcut.Location.Y);

            StartPosition = FormStartPosition.Manual;
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = appWidth;
            int h = 100; //will need to adjust sizing later;
            this.Location = new Point(0, (screen.Height - h) +37);
            this.Size = new Size(w+20, h);

            //Getting and accessing the flowPanel
            taskBarFlowLayout.AutoSize = false;
            taskBarFlowLayout.MaximumSize = new Size((appWidth-81), 60);
            taskBarFlowLayout.Height = 60;
            taskBarFlowLayout.Width = appWidth - 81;
            taskBarFlowLayout.LayoutStyle = ToolStripLayoutStyle.Flow;
            taskBarFlowLayout.ImageScalingSize = new Size(20, 20 );
            taskBarFlowLayout.AllowItemReorder = true;


            //Debug Population of Taskbar
            for (int i=0; i < MAX_ICON_COUNT; i++)
            {
                ToolStripButton temp;
                temp = new ToolStripButton();
                temp.Tag = "C:\\Program Files\\Mozilla Firefox\\firefox.exe"; //Text is the name of application to open
                temp.Click += button_Clicked;
                temp.Height = 25;
                temp.Width = 25;
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(temp.Tag.ToString());
                Image img = icon.ToBitmap(); // Image.FromFile("C:\\Repositories\\BetterTaskbar\\BetterTaskbar\\BetterTaskbar\\test.png");
                temp.Image = img;
                taskBarFlowLayout.Items.Add(temp);
                numberOfIcons++;
              }

            var fb = this.ClientRectangle;

            EventHandler tickHandler = (sender, args) =>
            {
                var mp = Cursor.Position;
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
            ToolStripButton t = (ToolStripButton)sender;
            Process p = new Process();
            p.StartInfo.FileName = t.Tag.ToString();
            p.Start();
            return;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
