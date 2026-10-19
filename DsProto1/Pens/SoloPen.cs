using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Pens
{
    /// <summary>
    /// A pen that can only hold one dinosaur
    /// </summary>
    public abstract class SoloPen : PenWithSlots
    {
        public SoloPen(string name, string description, Point position, Rectangle[] clickableRegions, PlacementCondition terrainType, Image icon) : 
            base(name, description, position, clickableRegions, terrainType,
                [new Point(clickableRegions[0].Width / 2, clickableRegions[0].Height / 2)], icon)
        { }

        /// <summary>
        /// There can only be one dinosaur in the pen
        /// </summary>
        /// <param name="dino"></param>
        /// <returns></returns>
        protected override PlacementAttemptResult DoesDinosaurMeetPlacementRules(Dinosaur dino)
        {
            if (DinoCount > 0) return new PlacementAttemptResult(false, "Only one dinosaur can be in this pen");
            else return PlacementAttemptResult.Success;
        }
    }
}
