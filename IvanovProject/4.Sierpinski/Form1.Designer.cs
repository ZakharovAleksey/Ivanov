namespace _4.Sierpinski
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
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxDepth = new System.Windows.Forms.TextBox();
            this.labelExecution = new System.Windows.Forms.Label();
            this.chBoxRecursive = new System.Windows.Forms.CheckBox();
            this.chBoxIterative = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingArea
            // 
            this.drawingArea.Location = new System.Drawing.Point(28, 28);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(391, 365);
            this.drawingArea.TabIndex = 1;
            this.drawingArea.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(440, 94);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(183, 52);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(440, 339);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(183, 54);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input depth:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(566, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(440, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 54);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save execution time";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Input maximum depth:";
            // 
            // tbMaxDepth
            // 
            this.tbMaxDepth.Location = new System.Drawing.Point(566, 181);
            this.tbMaxDepth.Name = "tbMaxDepth";
            this.tbMaxDepth.Size = new System.Drawing.Size(57, 20);
            this.tbMaxDepth.TabIndex = 8;
            this.tbMaxDepth.Text = "0";
            // 
            // labelExecution
            // 
            this.labelExecution.AutoSize = true;
            this.labelExecution.Location = new System.Drawing.Point(464, 292);
            this.labelExecution.Name = "labelExecution";
            this.labelExecution.Size = new System.Drawing.Size(117, 13);
            this.labelExecution.TabIndex = 9;
            this.labelExecution.Text = "Execution is not started";
            // 
            // chBoxRecursive
            // 
            this.chBoxRecursive.AutoSize = true;
            this.chBoxRecursive.Location = new System.Drawing.Point(453, 62);
            this.chBoxRecursive.Name = "chBoxRecursive";
            this.chBoxRecursive.Size = new System.Drawing.Size(74, 17);
            this.chBoxRecursive.TabIndex = 10;
            this.chBoxRecursive.Text = "Recursive";
            this.chBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // chBoxIterative
            // 
            this.chBoxIterative.AutoSize = true;
            this.chBoxIterative.Location = new System.Drawing.Point(533, 62);
            this.chBoxIterative.Name = "chBoxIterative";
            this.chBoxIterative.Size = new System.Drawing.Size(64, 17);
            this.chBoxIterative.TabIndex = 11;
            this.chBoxIterative.Text = "Iterative";
            this.chBoxIterative.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 436);
            this.Controls.Add(this.chBoxIterative);
            this.Controls.Add(this.chBoxRecursive);
            this.Controls.Add(this.labelExecution);
            this.Controls.Add(this.tbMaxDepth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.drawingArea);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaxDepth;
        private System.Windows.Forms.Label labelExecution;
        private System.Windows.Forms.CheckBox chBoxRecursive;
        private System.Windows.Forms.CheckBox chBoxIterative;
    }
}

