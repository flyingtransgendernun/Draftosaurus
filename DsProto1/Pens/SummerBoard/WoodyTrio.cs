using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens.SummerBoard
{
    public class WoodyTrio : PenWithSlots
    {
        private const int MaxCapacity = 3;
        public WoodyTrio() : base(
            "The Woody Trio",
            "This Pen can hold up to three dinosaurs of any species, the same or different. \n" +
            "At the end of the game, it brings in 7 victory points if there are exactly 3 dinosaurs in it regardless of species.\n " +
            "Otherwise, it brings in 0 points.",
            new Point(90, 180),
            [new Rectangle(0, 0, 100, 100)],
            PlacementCondition.Woodlands,
            [new Point(30, 30), new Point(50, 70), new Point(70, 30)],
            DinoPenSprites.Woodlands
            )
        { }
        public override int CalculateVictoryPoints(GameEngine game)
        {
            return ((DinoCount == MaxCapacity) ? 7 : 0) + CalculateTRexBonus();
        }

        /// <summary>
        /// There is a maximum of 3 dinosaurs in this pen
        /// </summary>
        /// <param name="dino"></param>
        /// <returns></returns>
        protected override PlacementAttemptResult DoesDinosaurMeetPlacementRules(Dinosaur dino)
        {
            return (DinoCount >= MaxCapacity) ? new PlacementAttemptResult(false, "The pen is at it's capacity") : PlacementAttemptResult.Success;
        }
    }
}
