namespace Draftosaurus
{
    partial class DieDisplay
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
            DieIcon = new PictureBox();
            DieDescription = new TextBox();
            CurrentConditionName = new Label();
            LastRolledPlayerName = new Label();
            ((System.ComponentModel.ISupportInitialize)DieIcon).BeginInit();
            SuspendLayout();
            // 
            // DieIcon
            // 
            DieIcon.BackgroundImageLayout = ImageLayout.Stretch;
            DieIcon.BorderStyle = BorderStyle.Fixed3D;
            DieIcon.Location = new Point(3, 3);
            DieIcon.Name = "DieIcon";
            DieIcon.Size = new Size(108, 103);
            DieIcon.TabIndex = 0;
            DieIcon.TabStop = false;
            // 
            // DieDescription
            // 
            DieDescription.Location = new Point(117, 3);
            DieDescription.Multiline = true;
            DieDescription.Name = "DieDescription";
            DieDescription.ReadOnly = true;
            DieDescription.Size = new Size(160, 103);
            DieDescription.TabIndex = 1;
            // 
            // CurrentConditionName
            // 
            CurrentConditionName.BackColor = SystemColors.ControlLightLight;
            CurrentConditionName.BorderStyle = BorderStyle.Fixed3D;
            CurrentConditionName.Location = new Point(4, 116);
            CurrentConditionName.Name = "CurrentConditionName";
            CurrentConditionName.Size = new Size(274, 28);
            CurrentConditionName.TabIndex = 2;
            CurrentConditionName.Text = "label1";
            // 
            // LastRolledPlayerName
            // 
            LastRolledPlayerName.BackColor = SystemColors.ControlLightLight;
            LastRolledPlayerName.BorderStyle = BorderStyle.Fixed3D;
            LastRolledPlayerName.Location = new Point(4, 144);
            LastRolledPlayerName.Name = "LastRolledPlayerName";
            LastRolledPlayerName.Size = new Size(274, 28);
            LastRolledPlayerName.TabIndex = 3;
            LastRolledPlayerName.Text = "label1";
            // 
            // DieDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LastRolledPlayerName);
            Controls.Add(CurrentConditionName);
            Controls.Add(DieDescription);
            Controls.Add(DieIcon);
            Name = "DieDisplay";
            Size = new Size(281, 179);
            ((System.ComponentModel.ISupportInitialize)DieIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox DieIcon;
        private TextBox DieDescription;
        private Label CurrentConditionName;
        private Label LastRolledPlayerName;
    }
}
