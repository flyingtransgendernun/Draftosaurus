using Draftosaurus.Boards;
using Draftosaurus.Pens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    public class Player
    {
        private string _name;
        private DinoArgs? _selectedDinosaurArgs;
        private List<Dinosaur> hand;
        private ZooBoard board; 
        private bool _hasPlacedThisTurn;
        public Player(string name, ZooBoard board)  
        {
            _name = name;
            _hasPlacedThisTurn = false;
            _selectedDinosaurArgs = new DinoArgs(null, null, new Point(0, 0));
            hand = [];
            this.board = board;
        }

        public bool HasPlacedThisTurn
        {
            get { return _hasPlacedThisTurn; }
            set { _hasPlacedThisTurn = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The player's currently selected dinosaur (may be null)
        /// </summary>
        public Dinosaur? SelectedDinosaur
        {
            get { return _selectedDinosaurArgs.Dinosaur; }
            set
            {
                if(value == null || hand.Contains(value))
                {
                    _selectedDinosaurArgs.Dinosaur = value;
                }
                else
                {
                    throw new Exception("Dinosaur does not exist in player's hand");
                }
            }
        }

        public DinoArgs? DinosaurPlacementArgs
        {
            get { return _selectedDinosaurArgs; }
            set { _selectedDinosaurArgs = value; }
        }

        /// <summary>
        /// The player's currently selected pen (may be null)
        /// </summary>
        public DinoPen? SelectedPen
        {
            get { return DinosaurPlacementArgs.Pen; }
            set
            {
                if (value == null || board.Pens.Contains(value))
                {
                    DinosaurPlacementArgs.Pen = value;
                }
                else
                {
                    throw new Exception("Pen does not exist on player's board");
                }
            }
        }

        public List<Dinosaur> Hand
        {
            get { return hand; }
            set { hand = value; }
        }

        /// <summary>
        /// How many dinosaurs the players has placed
        /// </summary>
        public int DinoCount
        {
            get { return Board.Pens.Sum(pen => pen.DinoCount); }
        }

        /// <summary>
        /// The player's board
        /// </summary>
        public ZooBoard Board
        {
            get { return board; }
        }

        public int GetSpeicesCount(DinoSpecies species)
        {
            return Board.Pens.Sum(pen => pen.Dinosaurs.Where(d => d.Species == species).Count());
        }

        /// <summary>
        /// Tries to place the selected dinosaur in the selected pen at the position on the board clicked. 
        /// If the placement fails, will show a Message Box explaining why to the player
        /// </summary>
        public void TryPlaceDino(PlacementDie die)
        {
            if (SelectedPen == null || SelectedDinosaur == null)
            {
                  return;
            }
            //MessageBox.Show(SelectedPen.Name);
            PlacementAttemptResult result = SelectedPen.IsDinoPlacementValid(SelectedDinosaur, this, die);

            if (!result.WasSuccess)
            {
                MessageBox.Show(result.Message, $"{Name}'s Placement Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                SelectedPen.PlaceDinosaur(this);
                //MessageBox.Show($"{Name} has Placed {SelectedDinosaur.Species} at {DinosaurPlacementArgs.Position}");
                HasPlacedThisTurn = true;
            }
        }
    }
}
