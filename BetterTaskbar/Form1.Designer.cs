namespace BetterTaskbar
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addShortcutButton = new System.Windows.Forms.Button();
            this.taskbarIcons = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(1871, 3);
            this.exitButton.MaximumSize = new System.Drawing.Size(25, 25);
            this.exitButton.MinimumSize = new System.Drawing.Size(25, 25);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(1845, 3);
            this.optionsButton.MaximumSize = new System.Drawing.Size(25, 25);
            this.optionsButton.MinimumSize = new System.Drawing.Size(25, 25);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(25, 25);
            this.optionsButton.TabIndex = 1;
            this.optionsButton.Text = "O";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(1904, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // addShortcutButton
            // 
            this.addShortcutButton.Location = new System.Drawing.Point(1845, 28);
            this.addShortcutButton.MaximumSize = new System.Drawing.Size(25, 25);
            this.addShortcutButton.MinimumSize = new System.Drawing.Size(25, 25);
            this.addShortcutButton.Name = "addShortcutButton";
            this.addShortcutButton.Size = new System.Drawing.Size(25, 25);
            this.addShortcutButton.TabIndex = 4;
            this.addShortcutButton.Text = "+";
            this.addShortcutButton.UseVisualStyleBackColor = true;
            // 
            // taskbarIcons
            // 
            this.taskbarIcons.Location = new System.Drawing.Point(0, 0);
            this.taskbarIcons.MaximumSize = new System.Drawing.Size(1839, 150);
            this.taskbarIcons.MinimumSize = new System.Drawing.Size(1839, 0);
            this.taskbarIcons.Name = "taskbarIcons";
            this.taskbarIcons.Size = new System.Drawing.Size(1839, 25);
            this.taskbarIcons.TabIndex = 5;
            this.taskbarIcons.Text = "toolStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 133);
            this.Controls.Add(this.taskbarIcons);
            this.Controls.Add(this.addShortcutButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.exitButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addShortcutButton;
        private System.Windows.Forms.ToolStrip taskbarIcons;
    }
}

