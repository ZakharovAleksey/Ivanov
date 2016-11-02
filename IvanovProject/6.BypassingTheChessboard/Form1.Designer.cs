namespace _6.BypassingTheChessboard
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
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.textBoxChessBoardSize = new System.Windows.Forms.TextBox();
            this.lblChessBoard = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingArea
            // 
            this.drawingArea.Location = new System.Drawing.Point(29, 43);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(256, 256);
            this.drawingArea.TabIndex = 0;
            this.drawingArea.TabStop = false;
            // 
            // textBoxChessBoardSize
            // 
            this.textBoxChessBoardSize.Location = new System.Drawing.Point(382, 70);
            this.textBoxChessBoardSize.Name = "textBoxChessBoardSize";
            this.textBoxChessBoardSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxChessBoardSize.TabIndex = 1;
            // 
            // lblChessBoard
            // 
            this.lblChessBoard.AutoSize = true;
            this.lblChessBoard.Location = new System.Drawing.Point(379, 43);
            this.lblChessBoard.Name = "lblChessBoard";
            this.lblChessBoard.Size = new System.Drawing.Size(117, 13);
            this.lblChessBoard.TabIndex = 2;
            this.lblChessBoard.Text = "Input ChessBoard Size:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(383, 126);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 48);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 356);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblChessBoard);
            this.Controls.Add(this.textBoxChessBoardSize);
            this.Controls.Add(this.drawingArea);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.TextBox textBoxChessBoardSize;
        private System.Windows.Forms.Label lblChessBoard;
        private System.Windows.Forms.Button btnStart;
    }
}

