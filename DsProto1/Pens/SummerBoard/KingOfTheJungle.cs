using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens.SummerBoard
{
    internal class KingOfTheJungle : SoloPen
    {
        public KingOfTheJungle() : base(
            "King of The Jungle",
            "At the end of the game, it brings in 7 victory points if your Zoo contains \n" +
            "at least as many dinosaurs of the species contained in this Pen as there are in each of your opponents' Zoos. \n" +
            "If any of your opponents' Zoos have more dinosaurs of this species than yours does, this Pen brings in 0 points.",
            new Point(340, 50),
            [new Rectangle(0, 0, 60, 60)],
            PlacementCondition.Woodlands,
            DinoPenSprites.Woodlands
            )
        {}

        public override int CalculateVictoryPoints(GameEngine game)
        {
            if (DinoCount == 0) return 0;
            Player? owner = FindPenOwner(game) ?? throw new Exception("Owner for king of the jungle could not be found");
            DinoSpecies targetSpecies = Dinosaurs[0].Species;
            Dictionary<Player, int> counts = game.Players.ToDictionary(
                p => p,
                p => p.Board.Pens.Sum(pen => pen.Dinosaurs.Where(d => d.Species == targetSpecies).Count())
            );
            /*foreach(KeyValuePair<Player, int> count in counts)
            {
                MessageBox.Show($"{count.Key.Name}: {count.Value}");
            }*/
            return ((counts.Any(p => p.Key != owner && p.Value > counts[owner])) ? 0 : 7) + CalculateTRexBonus();
        }
    }
}
