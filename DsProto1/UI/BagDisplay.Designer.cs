namespace Draftosaurus
{
    partial class BagDisplay
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
            panel1 = new Panel();
            DinosaurCountListBox = new ListBox();
            bagView = new PictureBox();
            DinoBagLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bagView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(DinosaurCountListBox);
            panel1.Controls.Add(bagView);
            panel1.Controls.Add(DinoBagLabel);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 173);
            panel1.TabIndex = 1;
            // 
            // DinosaurCountListBox
            // 
            DinosaurCountListBox.FormattingEnabled = true;
            DinosaurCountListBox.Location = new Point(3, 41);
            DinosaurCountListBox.Name = "DinosaurCountListBox";
            DinosaurCountListBox.Size = new Size(170, 124);
            DinosaurCountListBox.TabIndex = 13;
            // 
            // bagView
            // 
            bagView.Location = new Point(179, 41);
            bagView.Name = "bagView";
            bagView.Size = new Size(89, 124);
            bagView.TabIndex = 11;
            bagView.TabStop = false;
            bagView.Paint += bagView_Paint;
            // 
            // DinoBagLabel
            // 
            DinoBagLabel.BackColor = SystemColors.ControlLightLight;
            DinoBagLabel.BorderStyle = BorderStyle.Fixed3D;
            DinoBagLabel.Location = new Point(3, 3);
            DinoBagLabel.Margin = new Padding(3);
            DinoBagLabel.Name = "DinoBagLabel";
            DinoBagLabel.Size = new Size(265, 32);
            DinoBagLabel.TabIndex = 10;
            DinoBagLabel.Text = "Dino Bag";
            DinoBagLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BagDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "BagDisplay";
            Size = new Size(275, 177);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bagView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label DinoBagLabel;
        private PictureBox bagView;
        private ListBox DinosaurCountListBox;
    }
}
