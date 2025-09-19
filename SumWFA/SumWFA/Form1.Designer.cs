namespace SumWFA
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
            txtNumber1 = new Label();
            textNumber1 = new TextBox();
            txtNumber2 = new Label();
            textNumber2 = new TextBox();
            button1 = new Button();
            lblResult = new Label();
            SuspendLayout();
            // 
            // txtNumber1
            // 
            txtNumber1.AutoSize = true;
            txtNumber1.Location = new Point(229, 104);
            txtNumber1.Name = "txtNumber1";
            txtNumber1.Size = new Size(92, 25);
            txtNumber1.TabIndex = 0;
            txtNumber1.Text = "Number 1";
            //txtNumber1.Click += label1_Click;
            // 
            // textNumber1
            // 
            textNumber1.Location = new Point(376, 104);
            textNumber1.Name = "textNumber1";
            textNumber1.Size = new Size(150, 31);
            textNumber1.TabIndex = 1;
            // 
            // txtNumber2
            // 
            txtNumber2.AutoSize = true;
            txtNumber2.Location = new Point(229, 164);
            txtNumber2.Name = "txtNumber2";
            txtNumber2.Size = new Size(92, 25);
            txtNumber2.TabIndex = 2;
            txtNumber2.Text = "Number 2";
            // 
            // textNumber2
            // 
            textNumber2.Location = new Point(376, 164);
            textNumber2.Name = "textNumber2";
            textNumber2.Size = new Size(150, 31);
            textNumber2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(321, 245);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(229, 309);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(68, 25);
            lblResult.TabIndex = 5;
            lblResult.Text = "Result :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(button1);
            Controls.Add(textNumber2);
            Controls.Add(txtNumber2);
            Controls.Add(textNumber1);
            Controls.Add(txtNumber1);
            Name = "Form1";
            Text = "Form1";
            //Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtNumber1;
        private TextBox textNumber1;
        private Label txtNumber2;
        private TextBox textNumber2;
        private Button button1;
        private Label lblResult;
    }
}
