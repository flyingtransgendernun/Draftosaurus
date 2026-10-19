using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens.SummerBoard
{
    internal class PrairieOfLove : DinoPen
    {
        public PrairieOfLove() : base(
            "The Prairie Of Love",
            "This Pen can hold all the different dinosaur species.\n" +
            "At the end of the game, it brings in 5 victory points for each same-species dinosaur couple in it. " +
            "(A couple is made up of 2 dinosaurs of the same species. Having more than one couple from the same species is allowed.)",
            new Point(80, 300),
            [new Rectangle(0, 0, 100, 120)],
            PlacementCondition.Grasslands,
            DinoPenSprites.Grasslands
            )
        { }

        /// <summary>
        /// Count how many dinosaurs there are of that species, take the quotient when divided by 2 and times by 5
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public override int CalculateVictoryPoints(GameEngine game)
        {
            return DinoSpecies.All.Sum(species => Dinosaurs.Where(d => d.Species == species).Count() / 2) * 5 + CalculateTRexBonus();
        }

        /// <summary>
        /// There is no placement rule for the praire of love, so it always returns success
        /// </summary>
        /// <param name="dino"></param>
        /// <returns></returns>
        protected override PlacementAttemptResult DoesDinosaurMeetPlacementRules(Dinosaur dino)
        {
            return PlacementAttemptResult.Success;        
        }
    }
}
