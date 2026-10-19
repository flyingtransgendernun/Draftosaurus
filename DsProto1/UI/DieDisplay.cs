using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Draftosaurus
{
    public partial class DieDisplay : UserControl
    {
        private PlacementDie? _die;
        public DieDisplay()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PlacementDie? Die
        {
            get
            {
                return _die;
            }
            set
            {
                _die = value;
                UpdateFromDie();
            }
        }

        public void UpdateFromDie()
        {
            if (_die == null) return;
            PlacementCondition cc = _die.CurrentCondition;
            DieIcon.BackColor = Color.White;

            DieIcon.BackgroundImage = cc.Icon;
            DieDescription.Text = cc.Description;
            CurrentConditionName.Text = cc.Name;
            if(_die.LastRolled != null) LastRolledPlayerName.Text = $"Last rolled by {_die.LastRolled.Name}";
        }
    }
}
