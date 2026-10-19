using Draftosaurus.Pens;
using Draftosaurus.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Draftosaurus.Engine
{
    public class GameEngine
    {
        private int _currentDieRollerIdx;
        private GameState _state;
        private List<Player> _players;
        private DinoBag _bag;
        private PlacementDie _die;
        private int _roundCounter;
        private GamePresenter _presenter;

        /// <summary>
        /// The object responsible for displaying the current game to form
        /// </summary>
        public GamePresenter Presenter
        {
            get { return _presenter; }
            set { _presenter = value; }
        }

        /// <summary>
        /// The game's current state. Triggers an event when changed
        /// </summary>
        public GameState State
        {
            get { return _state; }
            set
            {
                GameState old = _state;
                _state = value;
                StateChange?.Invoke(this, new StateChangeEventArgs(old, _state));
                
            }
        }

        /// <summary>
        /// The game's players
        /// </summary>
        public ReadOnlyCollection<Player> Players
        {
            get { return new ReadOnlyCollection<Player>(_players); }
        }

        /// <summary>
        /// Have all players selected a dinosaur?
        /// </summary>
        private bool AllPlayersSelectedDinosaurs
        {
            get { return Players.All(p => p.SelectedDinosaur != null); }
        }
        
        /// <summary>
        /// Rolled to get a random placement condition each turn that all but the player who rolled it have to follow
        /// </summary>
        public PlacementDie Die
        {
            get { return _die; }
        }

        /// <summary>
        /// A stack containing all the dinosaurs used in the game
        /// </summary>
        public DinoBag Bag
        {
            get { return _bag; }
        }

        /// <summary>
        /// Initialises a new game engine
        /// </summary>
        /// <param name="players">The players playing the game</param>
        public GameEngine(List<Player> players)
        {
            _players = players;
            _state = GameState.WaitingToStart;
            _die = new PlacementDie();
            _bag = new DinoBag();
            _roundCounter = 1;
            _currentDieRollerIdx = 0;
            StateChange += OnStateChange;
        }

        /// <summary>
        /// Handles when the state is changed
        /// </summary>
        private event EventHandler? StateChange;
        private delegate void StateChangeHandler(object? sender, StateChangeEventArgs e);

        /// <summary>
        /// Arguments for when the state is changed
        /// </summary>
        /// <param name="previous">The state before changing</param>
        /// <param name="next">The state after changing</param>
        private class StateChangeEventArgs(GameState previous, GameState next) : EventArgs()
        {
            private GameState _prev = previous;
            private GameState _next = next;
            public GameState PreviousState
            {
                get { return _prev; }
            }

            public GameState NewState
            {
                get { return _next; }
            }
        }

        /// <summary>
        /// Calls different game functions when the state is changed depending on what the new state is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStateChange(object? sender, EventArgs e)
        {
            if (e is not StateChangeEventArgs sc) return;
            
            switch (sc.NewState)
            {
                case GameState.RoundStart:
                    RoundStart();
                    break;
                case GameState.TurnStart:
                    TurnStart();
                    break;
                case GameState.SelectDinoToPlace:
                    InitDinoSelection();
                    break;
                case GameState.SelectPenToPlaceIn:
                    InitPenSelection();
                    break;
                case GameState.SelectDinoToDiscard:
                    InitDinoSelection();
                    break;
                case GameState.EndTurn:
                    EndTurn();
                    break;

            }
            //MessageBox.Show($"Going from {sc.PreviousState} to {sc.NewState}");
        }

        /// <summary>
        /// If all players have selected dinosaurs, it will change the game's state to the pen selection phase
        /// </summary>
        public void OnDinoSelected(DinoSelectMode dinoSelectMode)
        {
            // if all have not selected a dinosaur, return
            if (!AllPlayersSelectedDinosaurs) return;

            switch (dinoSelectMode)
            {
                case DinoSelectMode.ToPlace:
                    State = GameState.SelectPenToPlaceIn;
                    break;
                case DinoSelectMode.ToDiscard:
                    foreach(Player p in Players)
                    {
                        if (p.SelectedDinosaur == null) throw new Exception("Dinosaur wasn't properly selected");
                        p.Hand.Remove(p.SelectedDinosaur);
                        p.SelectedDinosaur = null;
                    }
                    State = GameState.EndTurn;
                    break;
                default:
                    throw new Exception("Trying to select dinosaur in an invalid state");
            }
            
        }

        /// <summary>
        /// Tries to place a player's dinosaur, and will go to the next phase if all have placed
        /// </summary>
        /// <param name="sender">The player who placed the dinosaur</param>
        public void OnPenConfirmed(Player sender)
        {
            sender.TryPlaceDino(Die);

            IEnumerable<Player> unplacedPlayers = Players.Where(p => !p.HasPlacedThisTurn);

            if (!unplacedPlayers.Any())
            {
                //MessageBox.Show("All have placed");
                State = GameState.SelectDinoToDiscard;
            }
        }

        public void InitDinoSelection()
        {
            foreach (Player p in _players)
            {
                p.HasPlacedThisTurn = false;
                // determine move for CPU players
                if (p is CPU c)
                {
                    c.DetermineDinosaur();
                    Presenter.Players[c].SetPanelToText("Waiting...");
                }
                // set non CPU player's selections to null
                else
                {
                    p.SelectedDinosaur = null;
                    Presenter.Players[p].ShowHandPanel();
                }
            }
        }

        public void InitPenSelection()
        {
            foreach (Player p in _players)
            {
                // determine move for CPU players
                if (p is CPU c)
                {
                    c.DeterminePenToPlaceIn(Die);
                    c.TryPlaceDino(Die);
                    Presenter.Players[c].SetPanelToText("Waiting...");
                }
                // set non CPU player's selections to null
                else
                {
                    p.SelectedPen = null;
                    Presenter.Players[p].ShowPenPanel();
                }
            }
        }

        /// <summary>
        /// At the end of the turn, swap hands
        /// </summary>
        public void EndTurn()
        {
            if (_players[0].Hand.Count > 1)
            {
                // trade hands.
                SwapPlayerHands();
                State = GameState.TurnStart;
            }
            else if (Bag.Count < 12)
            {
                EndGame();
            }
            else
            {
                foreach(Player p in Players)
                {
                    Presenter.OutputForm.ScoreKeeperListbox.Items.Add
                        ($"Round {_roundCounter}: {p.Name} has {p.Board.CalculateVictoryPoints(this)} points");
                }
                _roundCounter++;
                RoundStart();
            }

        }

        public void SwapPlayerHands()
        {
            // cant do the swap if there are more than 2 players
            if(_players.Count != 2)
            {
                return;
            }
            /*MessageBox.Show("Before swap");
            foreach (Player p in _players)
            {
                MessageBox.Show($"{p.Name}: {String.Join(',', p.Hand.Select(d => d.Species.Name))}");
            }*/
            List<Dinosaur> hand1 = _players[0].Hand;
            _players[0].Hand = _players[1].Hand;
            _players[1].Hand = hand1;
            /*MessageBox.Show("After swap");
            foreach(Player p in _players)
            {
                MessageBox  .Show($"{p.Name}: {String.Join(',', p.Hand.Select(d => d.Species.Name))}");
            }*/
            
        }
        /// <summary>
        /// Roll the placement die and set the game to dinosaur selection phase
        /// </summary>
        public void TurnStart()
        {
            Die.Roll(Players[_currentDieRollerIdx]);
            // increment value to the next player tp roll
            _currentDieRollerIdx = (_currentDieRollerIdx + 1) % Players.Count;
            State = GameState.SelectDinoToPlace;
        }

        /// <summary>
        /// On start of the round, distribute dinosaurs to all players and start a turn.
        /// </summary>
        public void RoundStart()
        {
            //MessageBox.Show($"Round {_roundCounter}");
            Presenter.OutputForm.RoundLabel.Text = $"Round {_roundCounter}";
            Bag.Distribute(_players, 6);
            State = GameState.TurnStart;
        }

        public void EndGame()
        {
            Presenter.TriggerResultScreen();
        }
    }
}
