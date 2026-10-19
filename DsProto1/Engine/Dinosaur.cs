using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    public class Dinosaur(DinoSpecies species)
    {
        public const int PointValue = 1;
        private Point _position = new(0, 0);
        private readonly DinoSpecies _species = species;

        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }   
        public DinoSpecies Species
        {
            get { return _species; }
        }
    }
}
