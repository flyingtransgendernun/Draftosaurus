using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    public class DinoSpecies
    {
        private readonly string _name;
        private readonly Color _colour;
        private readonly Image _sprite;

        public string Name
        {
            get { return _name; }
        }

        public Color Colour
        {
            get { return _colour; }
        }

        public Image Sprite
        {
            get { return _sprite; }
        }

        public static int AmountOfSpecies
        {
            get { return All.Length; }
        }

        private DinoSpecies(string name, Color colour)
        {
            _name = name;
            _colour = colour;
            _sprite = DinosaurSprites.placeholder;
        }
        private DinoSpecies(string name, Color colour, Image sprite)
        {
            _name = name;
            _colour = colour;
            _sprite = sprite;
        }

        public readonly static DinoSpecies TRex = new("Tyrannosaurus Rex", Color.Red, DinosaurSprites.Red);
        public readonly static DinoSpecies Spinosaurus = new("Spinosaurus", Color.Orange, DinosaurSprites.Orange);
        public readonly static DinoSpecies Triceratops = new("Triceratops", Color.Yellow, DinosaurSprites.Yellow);
        public readonly static DinoSpecies Parasaurolophus = new("Parasaurolophus", Color.Green, DinosaurSprites.Green);
        public readonly static DinoSpecies Stegosaurus = new("Stegosaurus", Color.Blue, DinosaurSprites.Blue);
        public readonly static DinoSpecies Brontosaurus = new("Brontosaurus", Color.Purple, DinosaurSprites.Purple);
        public readonly static DinoSpecies[] All = [TRex, Spinosaurus, Triceratops, Parasaurolophus, Stegosaurus, Brontosaurus];
    }
}
