namespace Draftosaurus.Pens
{
    partial class ResultScreen
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
            LogoPanel = new Panel();
            WinningPlayerText = new Label();
            ResultsListBox = new ListBox();
            NewGameButton = new Button();
            Close = new Button();
            LogoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LogoPanel
            // 
            LogoPanel.BackColor = Color.White;
            LogoPanel.BorderStyle = BorderStyle.Fixed3D;
            LogoPanel.Controls.Add(WinningPlayerText);
            LogoPanel.Location = new Point(12, 12);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.Size = new Size(489, 72);
            LogoPanel.TabIndex = 3;
            // 
            // WinningPlayerText
            // 
            WinningPlayerText.BackColor = Color.Transparent;
            WinningPlayerText.Font = new Font("DCC - Ash", 23.9999981F, FontStyle.Bold, GraphicsUnit.Point, 238);
            WinningPlayerText.ForeColor = Color.Chocolate;
            WinningPlayerText.Location = new Point(3, 11);
            WinningPlayerText.Name = "WinningPlayerText";
            WinningPlayerText.Size = new Size(479, 48);
            WinningPlayerText.TabIndex = 0;
            WinningPlayerText.Text = "Draftosaurus";
            WinningPlayerText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ResultsListBox
            // 
            ResultsListBox.FormattingEnabled = true;
            ResultsListBox.Location = new Point(12, 90);
            ResultsListBox.Name = "ResultsListBox";
            ResultsListBox.Size = new Size(489, 84);
            ResultsListBox.TabIndex = 4;
            // 
            // NewGameButton
            // 
            NewGameButton.Location = new Point(12, 180);
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new Size(215, 29);
            NewGameButton.TabIndex = 5;
            NewGameButton.Text = "New Game";
            NewGameButton.UseVisualStyleBackColor = true;
            NewGameButton.Click += NewGameButton_Click;
            // 
            // Close
            // 
            Close.Location = new Point(286, 180);
            Close.Name = "Close";
            Close.Size = new Size(215, 29);
            Close.TabIndex = 6;
            Close.Text = "Close";
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // ResultScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 214);
            Controls.Add(Close);
            Controls.Add(NewGameButton);
            Controls.Add(ResultsListBox);
            Controls.Add(LogoPanel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResultScreen";
            Text = "Draftosaurus Results";
            LogoPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel LogoPanel;
        private Label WinningPlayerText;
        private ListBox ResultsListBox;
        private Button NewGameButton;
        private Button Close;
    }
}