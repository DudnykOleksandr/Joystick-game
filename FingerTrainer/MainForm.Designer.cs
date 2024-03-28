using FingerTrainer;

namespace FingerTrainer
{
    partial class MainForm
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
            panel1 = new CustomPanel();
            panel2 = new CustomPanel();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            level = new NumericUpDown();
            label1 = new Label();
            checkBox1 = new CheckBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)level).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 400);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(409, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 400);
            panel2.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(4, 468);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(805, 96);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(4, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 36);
            button1.TabIndex = 2;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(731, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 36);
            button2.TabIndex = 2;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // level
            // 
            level.Location = new Point(148, 18);
            level.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            level.Name = "level";
            level.Size = new Size(72, 27);
            level.TabIndex = 3;
            level.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 20);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 4;
            label1.Text = "Level";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(238, 21);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(153, 24);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Auto increase level";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(388, 22);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 6;
            label2.Text = "Info";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 572);
            Controls.Add(label2);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(level);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "Finger Trainer";
            ((System.ComponentModel.ISupportInitialize)level).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomPanel panel1;
        private CustomPanel panel2;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private NumericUpDown level;
        private Label label1;
        private CheckBox checkBox1;
        private Label label2;
    }
}
