using Draftosaurus.Pens;
using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Draftosaurus.Boards
{
    public abstract class ZooBoard(List<DinoPen> pens)
    {
        public const int Width = 500;
        private readonly List<DinoPen> _pens = pens;

        public List<DinoPen> Pens
        {
            get { return _pens; }
        }

        public void Draw(Graphics paper)
        {
            foreach(DinoPen p in Pens)
            {
                p.Draw(paper);
            }
        }

        public DinoPen? FindPen(Point position)
        {
            foreach(DinoPen p in Pens)
            {
                if (p.WasClicked(position))
                {
                    return p;
                }
            }
            return null;
        }

        public int CalculateVictoryPoints(GameEngine game)
        {
            if (game == null) return 0;
            return Pens.Sum(p => p.CalculateVictoryPoints(game));
        }
    }
}
