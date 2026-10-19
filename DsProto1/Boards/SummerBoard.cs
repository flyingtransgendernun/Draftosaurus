using Draftosaurus.Pens;
using Draftosaurus.Pens.SummerBoard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Boards
{
    public class SummerBoard() : ZooBoard(
        [
        new River(), 
        new ForestOfSameness(), 
        new SolitaryIsland(), 
        new KingOfTheJungle(), 
        new PrairieOfLove(),
        new WoodyTrio(),
        new MeadowOfDifferences()
        ])
    {}
}
