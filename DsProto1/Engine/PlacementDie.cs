    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Draftosaurus.Engine
{
    public class PlacementDie
    {
        public readonly static ReadOnlyCollection<PlacementCondition> Sides = new(
            [
                PlacementCondition.Grasslands,
                PlacementCondition.Woodlands,
                PlacementCondition.WatchForTRex,
                PlacementCondition.RestroomSide,
                PlacementCondition.FoodCourtSide,
                PlacementCondition.EmptyPen
            ]
        );
        private Player _lastRolledPlayer;
        private DieDisplay? _display;

        private PlacementCondition _currentCondition;
        public Player LastRolled
        {
            get { return _lastRolledPlayer; }
        }
        public PlacementCondition CurrentCondition
        {
            get { return _currentCondition; }
            private set 
            { 
                _currentCondition = value; 
                if(Display != null)
                {
                    Display.UpdateFromDie();
                }
            }
        }

        public DieDisplay? Display
        {
            get { return _display; }
            set { _display = value; }
        }

        public PlacementDie()
        {
            CurrentCondition = PlacementCondition.None;
        }

        /// <summary>
        /// Sets a new random placement condition and stores the player who rolled it
        /// </summary>
        /// <param name="roller">The player who won't be affected by the condition this turn</param>
        /// <returns>The new placement condition (also internally set)</returns>
        public PlacementCondition Roll(Player roller)
        {
            _lastRolledPlayer = roller;
            Random rand = new();
            PlacementCondition c = Sides.ElementAt(rand.Next(Sides.Count));
            CurrentCondition = c;
            return _currentCondition;
        }
    }
}
