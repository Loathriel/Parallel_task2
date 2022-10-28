namespace Parallel2
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
            this.magic = new System.Windows.Forms.Button();
            this.n1_y = new System.Windows.Forms.NumericUpDown();
            this.n2_x = new System.Windows.Forms.NumericUpDown();
            this.results = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.n1_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2_x)).BeginInit();
            this.SuspendLayout();
            // 
            // magic
            // 
            this.magic.Location = new System.Drawing.Point(169, 182);
            this.magic.Name = "magic";
            this.magic.Size = new System.Drawing.Size(75, 23);
            this.magic.TabIndex = 0;
            this.magic.Text = "Simulate";
            this.magic.UseVisualStyleBackColor = true;
            this.magic.Click += new System.EventHandler(this.magic_Click);
            // 
            // n1_y
            // 
            this.n1_y.Location = new System.Drawing.Point(76, 58);
            this.n1_y.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.n1_y.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.n1_y.Name = "n1_y";
            this.n1_y.Size = new System.Drawing.Size(56, 23);
            this.n1_y.TabIndex = 1;
            this.n1_y.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // n2_x
            // 
            this.n2_x.Location = new System.Drawing.Point(76, 103);
            this.n2_x.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.n2_x.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.n2_x.Name = "n2_x";
            this.n2_x.Size = new System.Drawing.Size(56, 23);
            this.n2_x.TabIndex = 2;
            this.n2_x.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(307, 42);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.ReadOnly = true;
            this.results.Size = new System.Drawing.Size(100, 100);
            this.results.TabIndex = 3;
            this.results.Text = "Sequential time:\r\n0 ms\r\n\r\nParallel time: \r\n0 ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 286);
            this.Controls.Add(this.results);
            this.Controls.Add(this.n2_x);
            this.Controls.Add(this.n1_y);
            this.Controls.Add(this.magic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.n1_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2_x)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button magic;
        private NumericUpDown n1_y;
        private NumericUpDown n2_x;
        private TextBox results;
    }
}