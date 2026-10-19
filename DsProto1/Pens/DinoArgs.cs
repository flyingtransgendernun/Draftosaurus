using System;
using System.Collections.Generic;
using System.Text;
using Draftosaurus.Engine;

namespace Draftosaurus.Pens
{
    public class DinoArgs(Dinosaur dino, DinoPen pen, Point p) : EventArgs()
    {
        private Dinosaur? _dino = dino;
        private DinoPen? _pen = pen;
        private Point _position = p;
        public Dinosaur? Dinosaur
        {
            get { return _dino; }
            set { _dino = value; }
        }

        public DinoPen? Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }
        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }

    public enum DinoSelectMode
    {
        ToPlace,
        ToDiscard
    }

    public class DinoSelectArgs(DinoSelectMode mode) : EventArgs
    {
        private readonly DinoSelectMode _selectMode = mode;
        public DinoSelectMode SelectMode
        {
            get { return _selectMode; }
        }
    }
}
