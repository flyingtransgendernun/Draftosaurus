using Draftosaurus.Boards;
using Draftosaurus.Engine;
using Draftosaurus.Pens.SummerBoard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Draftosaurus.Pens
{
    public abstract class DinoPen
    {
        protected const int SpriteSize = 48;
        private string _name;
        private string _description;
        private List<Dinosaur> _dinosaurs;
        private PlacementCondition _terrainType;
        private Point _position; // the top-left position
        protected Rectangle[] clickableRegions; // relative to the top-left
        private Image _icon;

        private DinoPenPalette _palette;

        /// <summary>
        /// The name of the pen
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// A description of the pen and it's placement rule
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// Dinosaurs in the pen
        /// </summary>
        public List<Dinosaur> Dinosaurs
        {
            get { return _dinosaurs; }
        }

        /// <summary>
        /// The position of the pen's top-left on the board
        /// </summary>
        public Point PositionOnBoard
        {
            get { return _position; }
            set { _position = value; }
        }

        public int DinoCount
        {
            get { return Dinosaurs.Count; }
        }

        public Image Icon
        {
            get { return _icon; }
        }

        protected DinoPenPalette Palette
        {
            get { return _palette; }
        }

        public PlacementCondition TerrainType
        {
            get { return _terrainType; }
        }

        public DinoPen(string name, string description, Point position, Rectangle[] clickableRegions, PlacementCondition terrainType)
        {
            _name = name;
            _description = description;
            _dinosaurs = [];
            _position = position;
            this.clickableRegions = clickableRegions;
            _terrainType = terrainType;
            _palette = (this._terrainType == PlacementCondition.Grasslands) ? DinoPenPalette.Grasslands : DinoPenPalette.Woodlands;
            _icon = DinoPenSprites.Placeholder;
        }

        public DinoPen(string name, string description, Point position, Rectangle[] clickableRegions, PlacementCondition terrainType, Image icon)
        {
            _name = name;
            _description = description;
            _dinosaurs = [];
            _position = position;
            this.clickableRegions = clickableRegions;
            _terrainType = terrainType;
            _palette = (this._terrainType == PlacementCondition.Grasslands) ? DinoPenPalette.Grasslands : DinoPenPalette.Woodlands;
            _icon = icon;
        }

        public int Width
        {
            get { return clickableRegions[0].Width; }
        }

        public int Height
        {
            get { return clickableRegions[0].Height; }
        }

        /// <summary>
        /// Determines whether the pen is on the Restroom or Foodcourt side of the zoo 
        /// </summary>
        /// <param name="zoo">The zoo the pen is in</param>
        /// <returns>Whether it's on the Restroom or Foodcourt side of the zoo (or none if it is the river)</returns>
        public PlacementCondition DetermineSideOfBoard()
        {
            // if it's the river return none
            if (this is River)
            {
                return PlacementCondition.None;
            }
            int middle = ZooBoard.Width / 2;
            if (PositionOnBoard.X > middle)
            {
                return PlacementCondition.FoodCourtSide;
            }
            else
            {
                return PlacementCondition.RestroomSide;
            }

        }

        /// <summary>
        /// Determines whether this pen was clicked
        /// </summary>
        /// <param name="mousePos">The position the mouse clicked on the form</param>
        /// <param name="zoo">The zoo the pen is in</param>
        /// <returns>Whether the pen was clicked or not</returns>
        public bool WasClicked(Point mousePos)
        {
            Point penPositionOnScreen = PositionOnBoard;

            foreach (Rectangle region in clickableRegions)
            {
                if (GetRegionRelativeToPosition(region).Contains(mousePos)) return true;
            }
            return false;
        }

        protected Rectangle GetRegionRelativeToPosition(Rectangle r)
        {
            return new Rectangle(r.X + PositionOnBoard.X, r.Y + PositionOnBoard.Y, r.Width, r.Height);
        }

        /// <summary>
        /// A pen that contains at least 1 t-rex gets an extra point
        /// </summary>
        /// <returns></returns>
        public int CalculateTRexBonus()
        {
            return (Dinosaurs.Any(d => d.Species == DinoSpecies.TRex)) ? 1 : 0;
        }

        /// <summary>
        /// Tests whether placing a dino would meet it's placement rules
        /// </summary>
        /// <param name="dino">The dinosaur to the add</param>
        /// <param name="die">The game's placement die</param>
        /// <returns>The result of the placement attempt</returns>
        protected abstract PlacementAttemptResult DoesDinosaurMeetPlacementRules(Dinosaur dino);
        
        public PlacementAttemptResult IsDinoPlacementValid(Dinosaur dino, Player player, PlacementDie die)
        {
            if (player != die.LastRolled && !DieRuleIsMet(die)) return PlacementAttemptResult.DieRuleNotMet;
            else return DoesDinosaurMeetPlacementRules(dino);
        }
        
        /// <summary>
        /// Draws the board
        /// </summary>
        /// <param name="paper">The graphics object to draw it onto</param>
        public virtual void Draw(Graphics paper)
        {
            Rectangle region = GetRegionRelativeToPosition(clickableRegions[0]);
            paper.FillRectangle(new SolidBrush(Palette.Ground), region);
            paper.DrawRectangle(new Pen(Palette.Fence, 8), region);
            DrawDinosaurs(paper);
        }

        protected bool DieRuleIsMet(PlacementDie die)
        {
            return this is River || die.CurrentCondition.DoesPenMeetRule(this);
        }

        /// <summary>
        /// Calculates how many victory points the pen is worth based on the pen's rule
        /// </summary>
        /// <param name="game">The current game (required for certain calculation rules)</param>
        /// <returns>The pen's victory points</returns>
        public abstract int CalculateVictoryPoints(GameEngine game);

        
        public virtual void PlaceDinosaur(Player p)
        {
            DinoArgs args = p.DinosaurPlacementArgs;
            Dinosaur d = args.Dinosaur;
            if (d == null) return;
            if (!p.Hand.Contains(d)) 
                throw new Exception($"Dino {d.Species.Name} does not exist in {p.Name}'s hand");
            d.Position = args.Position;
            Dinosaurs.Add(d);
            p.Hand.Remove(d);
        }

        protected Player? FindPenOwner(GameEngine game)
        {
            foreach (Player p in game.Players)
            {
                foreach (DinoPen pen in p.Board.Pens)
                {
                    if (pen == this) return p;
                }
            }
            return null;
        }
        public virtual void DrawDinosaurs(Graphics paper)
        {
            foreach (Dinosaur d in Dinosaurs)
            {
                paper.DrawImage(d.Species.Sprite, d.Position.X - SpriteSize / 2, d.Position.Y - SpriteSize / 2, SpriteSize, SpriteSize);
            }
        }

    }
}
