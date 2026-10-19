using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens.SummerBoard
{
    internal class SolitaryIsland : SoloPen
    {
        public SolitaryIsland() : base(
            "Solitary Island",
            "At the end of the game, it brings in 7 victory points if the dinosaur in this Pen is the only one of its species in your Zoo. " +
            "Otherwise, it brings in 0 points.",
            new Point(350, 315),
            [new Rectangle(0, 0, 80, 80)],
            PlacementCondition.Grasslands,
            DinoPenSprites.Grasslands
            )
        { }

        public override int CalculateVictoryPoints(GameEngine game)
        {
            if (Dinosaurs.Count == 0) return 0;
            Player? owner = FindPenOwner(game);
            Dinosaur solitaryDino = Dinosaurs[0];

            // if an owner cant be found throw an exception
            if (owner == null) throw new Exception("Owner for dinosaur in solitary pen could not be found");

            foreach(DinoPen pen in owner.Board.Pens)
            {
                // skip solitary island
                if (pen is not SolitaryIsland && pen.Dinosaurs.Any(dino => dino.Species == solitaryDino.Species)) return CalculateTRexBonus();
            }

            return 7 + CalculateTRexBonus();
        }

        public override void PlaceDinosaur(Player p)
        {
            base.PlaceDinosaur(p);
        }
    }
}
