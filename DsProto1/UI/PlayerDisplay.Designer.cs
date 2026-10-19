namespace Draftosaurus
{
    partial class PlayerDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GamePanel = new Panel();
            PlayerName = new Label();
            BoardDisplay = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)BoardDisplay).BeginInit();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GamePanel.BackColor = SystemColors.ControlLightLight;
            GamePanel.BorderStyle = BorderStyle.Fixed3D;
            GamePanel.Location = new Point(6, 485);
            GamePanel.Name = "GamePanel";
            GamePanel.Size = new Size(507, 193);
            GamePanel.TabIndex = 2;
            // 
            // PlayerName
            // 
            PlayerName.BackColor = SystemColors.ControlLightLight;
            PlayerName.BorderStyle = BorderStyle.Fixed3D;
            PlayerName.Location = new Point(6, 447);
            PlayerName.Margin = new Padding(3);
            PlayerName.Name = "PlayerName";
            PlayerName.Size = new Size(500, 32);
            PlayerName.TabIndex = 4;
            PlayerName.Text = "PlayerNameLabel";
            PlayerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BoardDisplay
            // 
            BoardDisplay.BackColor = SystemColors.ControlLightLight;
            BoardDisplay.BorderStyle = BorderStyle.Fixed3D;
            BoardDisplay.Location = new Point(6, 0);
            BoardDisplay.Name = "BoardDisplay";
            BoardDisplay.Size = new Size(500, 441);
            BoardDisplay.TabIndex = 5;
            BoardDisplay.TabStop = false;
            BoardDisplay.Click += BoardDisplay_Click;
            BoardDisplay.Paint += BoardDisplay_Paint;
            // 
            // PlayerDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BoardDisplay);
            Controls.Add(PlayerName);
            Controls.Add(GamePanel);
            Name = "PlayerDisplay";
            Size = new Size(516, 710);
            ((System.ComponentModel.ISupportInitialize)BoardDisplay).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public Panel GamePanel;
        private Label PlayerName;
        private PictureBox BoardDisplay;
    }
}
