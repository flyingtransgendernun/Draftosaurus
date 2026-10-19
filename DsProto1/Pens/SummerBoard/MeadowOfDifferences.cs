using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens.SummerBoard
{
    public class MeadowOfDifferences : PenWithSlots
    {
        private const int MaxCapacity = 6;
        public MeadowOfDifferences() : base(
            "The Meadow Of Differences",
            "This Pen can only hold dinosaurs of different species and must be filled from left to right with no gaps.\n" +
            "At the end of the game, it brings in victory points based on the number of dinosaurs in it.",
            new Point(300, 180),
            [new Rectangle(0, 0, 140, 80)],
            PlacementCondition.Grasslands,
            [new Point(25, 40), new Point(45, 40), new Point(65, 40), new Point(85, 40), new Point(105, 40), new Point(125, 40)],
            DinoPenSprites.Grasslands
            )
        { }

        public override int CalculateVictoryPoints(GameEngine game)
        {
            return DinoCount + CalculateTRexBonus();
        }

        /// <summary>
        /// All dinosaurs have to be different species
        /// </summary>
        /// <param name="dino"></param>
        /// <returns></returns>
        protected override PlacementAttemptResult DoesDinosaurMeetPlacementRules(Dinosaur dino)
        {
            if (DinoCount > MaxCapacity) return new PlacementAttemptResult(false, "The pen is at it's capacity");

            if (Dinosaurs.Any(d => d.Species == dino.Species)) return new PlacementAttemptResult(false, "Theres already a dinosaur of this species in the pen");

            return PlacementAttemptResult.Success;
        }
    }
}
