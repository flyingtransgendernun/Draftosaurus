using Draftosaurus.Boards;
using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Draftosaurus.Pens
{
    /// <summary>
    /// A pen with a fixed number of slots. The slots determine both how many dinosaurs can be in the pen, as well as where on the pen they will be drawn
    /// </summary>
    public abstract class PenWithSlots : DinoPen
    {
        private Dictionary<Point, bool> _slots;
        public PenWithSlots(string name, string description, Point position, Rectangle[] clickableRegions, PlacementCondition terrainType, Point[] slotPositions)
            : base(name, description, position, clickableRegions, terrainType)
        {
            _slots = [];
            foreach(Point p in slotPositions)
            {
                _slots.Add(p, false);
            }
        }

        public PenWithSlots(string name, string description, Point position, Rectangle[] clickableRegions, PlacementCondition terrainType, Point[] slotPositions, Image icon)
            : base(name, description, position, clickableRegions, terrainType, icon)
        {
            _slots = [];
            foreach (Point p in slotPositions)
            {
                _slots.Add(p, false);
            }
        }

        protected Dictionary<Point, bool> Slots
        {
            get { return _slots; }
        }

        /// <summary>
        /// Finds the
        /// </summary>
        /// <returns></returns>
        protected Point? FindNextFreeSlot()
        {
            IEnumerable<KeyValuePair<Point, bool>> emptySlotPositions = Slots.Where(slot => !slot.Value);
            if(emptySlotPositions.Any())
            {
                return emptySlotPositions.First().Key;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Places the dinosaur into the next free slot. If there are no free slots nothing will happen
        /// </summary>
        /// <param name="p"></param>
        public override void PlaceDinosaur(Player p)
        {
            Point? nextSlot = FindNextFreeSlot();
            if (nextSlot == null) return;
            else p.DinosaurPlacementArgs.Position = (Point)nextSlot;
            base.PlaceDinosaur(p);
            Slots[(Point)nextSlot] = true;
        }
        public override void DrawDinosaurs(Graphics paper)
        {
            foreach (Dinosaur d in Dinosaurs)
            {
                paper.DrawImage(d.Species.Sprite, d.Position.X - SpriteSize / 2 + PositionOnBoard.X, d.Position.Y + PositionOnBoard.Y - SpriteSize / 2, SpriteSize, SpriteSize);
            }
        }
    }
}
