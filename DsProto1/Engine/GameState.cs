using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    public enum GameState
    {
        WaitingToStart,
        RoundStart,
        SelectDinoToPlace,
        SelectDinoToDiscard,
        SelectPenToPlaceIn,
        GameEnd,
        TurnStart,
        EndTurn,
    }
}
