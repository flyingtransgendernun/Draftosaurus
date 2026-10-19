using Draftosaurus.Boards;
using Draftosaurus.Pens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    /// <summary>
    /// A player that has additional methods for automatically selecting moves
    /// </summary>
    public class CPU(string name, ZooBoard board) : Player(name, board)
    {

        /// <summary>
        /// Selects a Dinosaur automatically (currently just random but might come up with an algorithim later)
        /// </summary>
        public void DetermineDinosaur()
        {
            Random rand = new();
            if(Hand.Count < 1)
            {
                throw new Exception("Hand is empty and round hasn't ended");
            }
            this.SelectedDinosaur = Hand.ElementAt(rand.Next(Hand.Count));
        }

        /// <summary>
        /// Selects a random (valid) pen to place in
        /// </summary>
        /// <param name="die">The placement die (to ensure the move also follows the roll)</param>
        /// <exception cref="Exception">No pen could be found</exception>
        public void DeterminePenToPlaceIn(PlacementDie die)
        {
            if(SelectedDinosaur == null)
            {
                throw new Exception("Trying to place dinosaur without having selected one");
            }

            foreach(DinoPen pen in board.Pens.Shuffle())
            {
                PlacementAttemptResult result = pen.IsDinoPlacementValid(this.SelectedDinosaur, this, die);
                if (result.WasSuccess)
                {
                    SelectedPen = pen;
                    // set position argument to random spot within the pen
                    Random r = new();
                    int bounary = 15;
                    Point placePos = new(
                        r.Next(pen.PositionOnBoard.X + bounary, pen.PositionOnBoard.X + pen.Width - bounary * 2),
                        r.Next(pen.PositionOnBoard.Y + bounary, pen.PositionOnBoard.Y + pen.Height - bounary * 2)
                        );
                    DinosaurPlacementArgs.Position = placePos;
                    //MessageBox.Show($"placing in {pen.Name}, {pen.PositionOnBoard}. placing at {placePos}");
                    return;
                }
            }

            // There should always be at least one pen on the board that doesn't have a placement rules (the river) so something has gone horrible wrong
            throw new Exception("Valid pen could not be found to place in");
        }
    }
}
