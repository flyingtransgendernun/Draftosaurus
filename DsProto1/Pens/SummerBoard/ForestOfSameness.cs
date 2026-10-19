using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens.SummerBoard
{
    
    public class ForestOfSameness : PenWithSlots
    {
        private const int MaxCapacity = 6;
        private DinoSpecies? SoleSpecies;
        public ForestOfSameness() : base(
            "The Forest Of Sameness", 
            "This Pen can only hold dinosaurs of the same species and must" +
            "be filled from left to right with no gaps.\r\n" +
            "At the end of the game, it brings in victory points based on the number of dinosaurs in it.",
            new Point(24, 24),
            [new Rectangle(0, 0, 180, 120)],
            PlacementCondition.Woodlands,
            [new Point(20, 60), new Point(50, 60), new Point(80, 60), new Point(110, 60), new Point(140, 60), new Point(170, 60)],  
            DinoPenSprites.Woodlands
            ) { }

        public override int CalculateVictoryPoints(GameEngine game)
        {
            return DinoCount + CalculateTRexBonus();
        }

        /// <summary>
        /// All dinosaurs within the pen must be the same species
        /// </summary>
        /// <param name="dino"></param>
        /// <returns></returns>
        protected override PlacementAttemptResult DoesDinosaurMeetPlacementRules(Dinosaur dino)
        {
            if (Dinosaurs.Count > MaxCapacity) return new PlacementAttemptResult(false, "The pen is at it's capacity");

            if (SoleSpecies != null && dino.Species != SoleSpecies) return new PlacementAttemptResult(false, "All dinosaurs have to be the same species");

            return PlacementAttemptResult.Success;
        }

        public override void PlaceDinosaur(Player p)
        {
            DinoArgs args = p.DinosaurPlacementArgs;
            SoleSpecies ??= args.Dinosaur.Species;
            base.PlaceDinosaur(p);
        }
    }
}
