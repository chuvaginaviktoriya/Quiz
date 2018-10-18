namespace CompileDemo
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Code = new System.Windows.Forms.TextBox();
            this.Class = new System.Windows.Forms.TextBox();
            this.Method = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.NumericUpDown();
            this.To = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.From)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To)).BeginInit();
            this.SuspendLayout();
            // 
            // Code
            // 
            this.Code.Location = new System.Drawing.Point(12, 49);
            this.Code.Multiline = true;
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(394, 212);
            this.Code.TabIndex = 0;
            this.Code.Text = resources.GetString("Code.Text");
            // 
            // Class
            // 
            this.Class.Location = new System.Drawing.Point(12, 10);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(100, 20);
            this.Class.TabIndex = 1;
            this.Class.Text = "Foo";
            // 
            // Method
            // 
            this.Method.Location = new System.Drawing.Point(266, 9);
            this.Method.Name = "Method";
            this.Method.Size = new System.Drawing.Size(100, 20);
            this.Method.TabIndex = 2;
            this.Method.Text = "FooM";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(12, 339);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(394, 66);
            this.Result.TabIndex = 3;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(331, 310);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "≤ a <";
            // 
            // From
            // 
            this.From.Location = new System.Drawing.Point(119, 267);
            this.From.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(47, 20);
            this.From.TabIndex = 9;
            // 
            // To
            // 
            this.To.Location = new System.Drawing.Point(209, 267);
            this.To.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(59, 20);
            this.To.TabIndex = 10;
            this.To.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 417);
            this.Controls.Add(this.To);
            this.Controls.Add(this.From);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Method);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.Code);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.From)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.To)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Code;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.TextBox Method;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown From;
        private System.Windows.Forms.NumericUpDown To;
    }
}

