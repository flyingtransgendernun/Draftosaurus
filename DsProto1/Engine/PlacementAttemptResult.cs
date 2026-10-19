using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    public class PlacementAttemptResult(bool wasSuccess, string message)
    {
        private readonly bool _wasSuccess = wasSuccess;
        private readonly string _message = message;
        public bool WasSuccess
        {
            get { return _wasSuccess; }
        }

        public string Message
        {
            get { return _message; }
        }

        public readonly static PlacementAttemptResult Success = new(true, "Dinosaur can be placed");
        public readonly static PlacementAttemptResult DieRuleNotMet = new(false, "The current die roll was not followed");
    }
}
