using Draftosaurus.Engine;
using Draftosaurus.Pens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Draftosaurus.UI
{
    public class GamePresenter(GameEngine engine, MainGameScreen outputForm)
    {
        private GameEngine _game = engine;
        private MainGameScreen _outputForm = outputForm;
        private Dictionary<Player, PlayerDisplay> _players;

        public GameEngine Game
        {
            get { return _game; }
            set { _game = value; }
        }

        public MainGameScreen OutputForm
        {
            get { return _outputForm; }
        }

        public Dictionary<Player, PlayerDisplay> Players{
            get { return _players; }
        }

        /// <summary>
        /// Initialises the UI. Needs to be called on Form load.
        /// </summary>
        public void InitialiseControls()
        {
            _players = new Dictionary<Player, PlayerDisplay>()
            {
                { Game.Players[0], OutputForm.Player1Display },
                { Game.Players[1], OutputForm.Player2Display },
            };
            foreach (KeyValuePair<Player, PlayerDisplay> p in Players)
            {
                p.Value.Player = p.Key;
                p.Value.Game = Game;
            }
            Game.Die.Display = OutputForm.DieDisplayer;
            OutputForm.DieDisplayer.Die = Game.Die;
            OutputForm.BagDisplay.Bag = Game.Bag;
        }

        public void Update()
        {
            foreach (KeyValuePair<Player, PlayerDisplay> p in Players)
            {
                p.Value.Refresh();
            }
            OutputForm.BagDisplay.Refresh();
        }

        public void TriggerResultScreen()
        {
            ResultScreen rs = new(Game);
            rs.ShowDialog();
            OutputForm.Close();
        }
    }
}
