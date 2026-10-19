using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens
{
    public class DinoPenPalette
    {
        private Color _ground, _fence;

        public Color Ground
        {
            get { return _ground; }
        }

        public Color Fence
        {
            get { return _fence; }
        }

        private DinoPenPalette(Color ground, Color fence)
        {
            _ground = ground;
            _fence = fence;
        }

        public static DinoPenPalette Woodlands = new(Color.Beige, Color.BurlyWood);
        public static DinoPenPalette Grasslands = new(Color.Gold, Color.Purple);

    }
}
