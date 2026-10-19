using System;
using System.Collections.Generic;
using System.Text;
using Draftosaurus.Pens;

namespace Draftosaurus.Engine
{
    public class PlacementCondition
    {
        private string _name;
        private string _description;
        private Image _icon;

        public Func<DinoPen, bool> DoesPenMeetRule;

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public Image Icon
        {
            get { return _icon; }
        }

        private PlacementCondition(string name, string description, Func<DinoPen, bool> penEvaluation)
        {
            _name = name;
            _description = description;
            _icon = PlacementConditionSprites.Placeholder;
            DoesPenMeetRule = penEvaluation;
        }

        private PlacementCondition(string name, string description, Func<DinoPen, bool> penEvaluation, Image icon)
        {
            _name = name;
            _description = description;
            _icon = icon;
            DoesPenMeetRule = penEvaluation;
        }

        public readonly static PlacementCondition Woodlands = 
            new("Woodlands", "The dinosaurs must be placed in a Pen in the woodlands section of your Zoo",
                (pen => pen.TerrainType == PlacementCondition.Woodlands), PlacementConditionSprites.Woodlands);
        public readonly static PlacementCondition Grasslands = 
            new("Grasslands", "The dinosaurs must be placed in a Pen in the grasslands section of your Zoo.",
                (pen => pen.TerrainType == PlacementCondition.Grasslands), PlacementConditionSprites.Grasslands);
        public readonly static PlacementCondition FoodCourtSide = 
            new("Food Court Side", "The dinosaurs must be placed on the food court side of your Zoo (to the right of the River).",
                (pen => pen.DetermineSideOfBoard() == PlacementCondition.FoodCourtSide), PlacementConditionSprites.Foodcourt);
        public readonly static PlacementCondition RestroomSide = 
            new("Restroom Side", "The dinosaurs must be placed on the restroom side of your Zoo (to the left of the River).",
                (pen => pen.DetermineSideOfBoard() == PlacementCondition.RestroomSide), PlacementConditionSprites.Restroom);
        public readonly static PlacementCondition EmptyPen = 
            new("Empty Pen", "The dinosaurs must be placed in an empty Pen.",
                (pen => pen.DinoCount == 0), PlacementConditionSprites.EmptyPen);
        public readonly static PlacementCondition WatchForTRex = 
            new("Watch Out For T-Rex", "The dinosaurs must be placed in a Pen that does not contain a T-Rex",
                (pen => !pen.Dinosaurs.Any(d => d.Species == DinoSpecies.TRex)), PlacementConditionSprites.WatchForTRex);
        public readonly static PlacementCondition None = 
            new("None", "No Placement Condition is set",
                (pen => true));
    }
}
