namespace Draftosaurus
{
    partial class MainGameScreen
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
            components = new System.ComponentModel.Container();
            Player2Display = new PlayerDisplay();
            Player1Display = new PlayerDisplay();
            animationTimer = new System.Windows.Forms.Timer(components);
            LogoPanel = new Panel();
            label1 = new Label();
            DieDisplayer = new DieDisplay();
            ScoreKeeperListbox = new ListBox();
            BagDisplay = new BagDisplay();
            RoundLabel = new Label();
            LogoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Player2Display
            // 
            Player2Display.Game = null;
            Player2Display.Location = new Point(777, 12);
            Player2Display.Name = "Player2Display";
            Player2Display.Player = null;
            Player2Display.Size = new Size(473, 684);
            Player2Display.TabIndex = 0;
            // 
            // Player1Display
            // 
            Player1Display.Game = null;
            Player1Display.Location = new Point(298, 12);
            Player1Display.Name = "Player1Display";
            Player1Display.Player = null;
            Player1Display.Size = new Size(473, 684);
            Player1Display.TabIndex = 1;
            // 
            // animationTimer
            // 
            animationTimer.Enabled = true;
            animationTimer.Tick += animationTimer_Tick;
            // 
            // LogoPanel
            // 
            LogoPanel.BackColor = Color.White;
            LogoPanel.BorderStyle = BorderStyle.Fixed3D;
            LogoPanel.Controls.Add(label1);
            LogoPanel.Location = new Point(18, 12);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.Size = new Size(280, 72);
            LogoPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("DCC - Ash", 23.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(-2, 10);
            label1.Name = "label1";
            label1.Size = new Size(280, 48);
            label1.TabIndex = 0;
            label1.Text = "Draftosaurus";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DieDisplayer
            // 
            DieDisplayer.Location = new Point(18, 90);
            DieDisplayer.Name = "DieDisplayer";
            DieDisplayer.Size = new Size(286, 178);
            DieDisplayer.TabIndex = 3;
            // 
            // ScoreKeeperListbox
            // 
            ScoreKeeperListbox.FormattingEnabled = true;
            ScoreKeeperListbox.Location = new Point(18, 500);
            ScoreKeeperListbox.Name = "ScoreKeeperListbox";
            ScoreKeeperListbox.Size = new Size(280, 164);
            ScoreKeeperListbox.TabIndex = 4;
            // 
            // BagDisplay
            // 
            BagDisplay.BorderStyle = BorderStyle.Fixed3D;
            BagDisplay.Location = new Point(18, 274);
            BagDisplay.Name = "BagDisplay";
            BagDisplay.Size = new Size(280, 175);
            BagDisplay.TabIndex = 5;
            // 
            // RoundLabel
            // 
            RoundLabel.BackColor = SystemColors.ControlLightLight;
            RoundLabel.BorderStyle = BorderStyle.Fixed3D;
            RoundLabel.Location = new Point(18, 459);
            RoundLabel.Margin = new Padding(3);
            RoundLabel.Name = "RoundLabel";
            RoundLabel.Size = new Size(280, 32);
            RoundLabel.TabIndex = 6;
            RoundLabel.Text = "Round Counter";
            RoundLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainGameScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(RoundLabel);
            Controls.Add(BagDisplay);
            Controls.Add(ScoreKeeperListbox);
            Controls.Add(DieDisplayer);
            Controls.Add(LogoPanel);
            Controls.Add(Player1Display);
            Controls.Add(Player2Display);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainGameScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Draftosaurus";
            Load += Form1_Load;
            LogoPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public Label player1Label;
        public PlayerDisplay Player2Display;
        public PlayerDisplay Player1Display;
        private System.Windows.Forms.Timer animationTimer;
        private Panel LogoPanel;
        private Label label1;
        public DieDisplay DieDisplayer;
        public ListBox ScoreKeeperListbox;
        private ListBox ScoreTracker;
        public BagDisplay BagDisplay;
        public Label RoundLabel;
    }
}
