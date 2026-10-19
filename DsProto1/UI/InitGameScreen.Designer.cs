namespace Draftosaurus.UI
{
    partial class InitGameScreen
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
            PvP = new Button();
            PvC = new Button();
            CvC = new Button();
            P2Name = new TextBox();
            P1Name = new TextBox();
            label1 = new Label();
            label2 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            LogoPanel = new Panel();
            label3 = new Label();
            LogoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PvP
            // 
            PvP.Location = new Point(12, 186);
            PvP.Name = "PvP";
            PvP.Size = new Size(297, 29);
            PvP.TabIndex = 0;
            PvP.Text = "Player vs Player";
            PvP.UseVisualStyleBackColor = true;
            PvP.Click += StartGame;
            // 
            // PvC
            // 
            PvC.Location = new Point(12, 221);
            PvC.Name = "PvC";
            PvC.Size = new Size(297, 29);
            PvC.TabIndex = 1;
            PvC.Text = "Player vs CPU";
            PvC.UseVisualStyleBackColor = true;
            PvC.Click += StartGame;
            // 
            // CvC
            // 
            CvC.Enabled = false;
            CvC.Location = new Point(12, 256);
            CvC.Name = "CvC";
            CvC.Size = new Size(297, 29);
            CvC.TabIndex = 2;
            CvC.Text = "CPU vs CPU";
            CvC.UseVisualStyleBackColor = true;
            CvC.Click += StartGame;
            // 
            // P2Name
            // 
            P2Name.Location = new Point(123, 123);
            P2Name.Name = "P2Name";
            P2Name.Size = new Size(186, 27);
            P2Name.TabIndex = 3;
            // 
            // P1Name
            // 
            P1Name.Location = new Point(123, 90);
            P1Name.Name = "P1Name";
            P1Name.Size = new Size(186, 27);
            P1Name.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 5;
            label1.Text = "Player 1 Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 123);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 6;
            label2.Text = "Player 2 Name:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(12, 156);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(129, 24);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Summer Board";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton2.Location = new Point(147, 156);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(118, 24);
            radioButton2.TabIndex = 8;
            radioButton2.Text = "Winter Board";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // LogoPanel
            // 
            LogoPanel.BackColor = Color.White;
            LogoPanel.BorderStyle = BorderStyle.Fixed3D;
            LogoPanel.Controls.Add(label3);
            LogoPanel.Location = new Point(12, 12);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.Size = new Size(297, 72);
            LogoPanel.TabIndex = 9;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("DCC - Ash", 23.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = Color.Chocolate;
            label3.Location = new Point(-2, 10);
            label3.Name = "label3";
            label3.Size = new Size(280, 48);
            label3.TabIndex = 0;
            label3.Text = "Draftosaurus";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InitGameScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 291);
            Controls.Add(LogoPanel);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(P1Name);
            Controls.Add(P2Name);
            Controls.Add(CvC);
            Controls.Add(PvC);
            Controls.Add(PvP);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InitGameScreen";
            Text = "Draftosaurus Setup";
            LogoPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PvP;
        private Button PvC;
        private Button CvC;
        private TextBox P2Name;
        private TextBox P1Name;
        private Label label1;
        private Label label2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Panel LogoPanel;
        private Label label3;
    }
}