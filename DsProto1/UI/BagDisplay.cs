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
    public partial class BagDisplay : UserControl
    {
        private DinoBag? _bag = null;
        public BagDisplay()
        {
            InitializeComponent();
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DinoBag? Bag
        {
            get { return _bag; }
            set
            {
                _bag = value;
                UpdateFromBag();
            }
        }

        public void UpdateFromBag()
        {
            DinosaurCountListBox.Items.Clear();
            if (Bag == null) return;
            foreach (DinoSpecies species in DinoSpecies.All)
            {
                int count = Bag.Where(dino => dino.Species == species).Count();
                DinosaurCountListBox.Items.Add($"{count}x".PadRight(4) + species.Name);
            }
        }

        private void bagView_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not PictureBox box || Bag == null) return;
            Graphics paper = e.Graphics;
            int margin = 8;
            Rectangle outline = new(margin, margin, box.Width - margin * 2, box.Height - margin * 2);
            int filledStartPoint = (int)((Bag.Count / (float)Bag.Capacity) * outline.Height);
            paper.FillRectangle
                (new SolidBrush(Color.LightBlue), outline.X, outline.Y + outline.Height - filledStartPoint, outline.Width, filledStartPoint
                );
            paper.DrawRectangle
                (new Pen(Color.Blue, 4), outline);
        }
    }
}
