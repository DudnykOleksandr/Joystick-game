namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new myPanel();
            panel2 = new myPanel();
            menuStrip1 = new MenuStrip();
            startToolStripMenuItem = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            stopToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 400);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(406, 31);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 400);
            panel2.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { startToolStripMenuItem, stopToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(817, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            startToolStripMenuItem.Name = "startToolStripMenuItem";
            startToolStripMenuItem.Size = new Size(52, 24);
            startToolStripMenuItem.Text = "Start";
            startToolStripMenuItem.Click += startToolStripMenuItem_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(4, 446);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(802, 77);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(52, 24);
            stopToolStripMenuItem.Text = "Stop";
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 535);
            Controls.Add(richTextBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private myPanel panel1;
        private myPanel panel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private RichTextBox richTextBox1;
    }
}
