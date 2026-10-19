using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens
{
    /// <summary>
    /// Special zone that dinosaurs can be placed in regardless of the dice rule
    /// </summary>
    public class River : DinoPen
    {
        private const int SectionWidth = 60;
        public River() :
            base(
                "The River",
                "A place where dinosaurs can be placed without restriction",
                new Point(220, 0), 
                [
                    new Rectangle(0, 0, SectionWidth, 250), 
                    new Rectangle(-SectionWidth / 4, 200, SectionWidth, 200), 
                    new Rectangle(SectionWidth / 4 - 20, 380, SectionWidth * 2, 100),
                    new Rectangle(-30, 420, 120, 50),
                ], 
                PlacementCondition.None, DinoPenSprites.River) 
        { }

        /// <summary>
        /// The river has no placement rule
        /// </summary>
        /// <param name="dino"></param>
        /// <returns></returns>
        protected override PlacementAttemptResult DoesDinosaurMeetPlacementRules(Dinosaur dino)
        {
            return PlacementAttemptResult.Success;
        }

        public override void Draw(Graphics paper)
        {
            TextureBrush brush = new(DinoPenSprites.River);
            foreach(Rectangle r in this.clickableRegions.Select(r => GetRegionRelativeToPosition(r)))
            {
                paper.FillRectangle(brush, r);
            }
            DrawDinosaurs(paper);
        }

        /// <summary>
        /// 1 point for every dinosaur in the pen
        /// </summary>
        /// <param name="game">Current game state</param>
        /// <returns></returns>
        public override int CalculateVictoryPoints(GameEngine game)
        {
            return (Dinosaurs.Count * Dinosaur.PointValue) + CalculateTRexBonus();
        }
    }
}
