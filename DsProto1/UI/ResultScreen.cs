using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Draftosaurus.Pens
{
    public partial class ResultScreen : Form
    {
        private GameEngine _game;
        public ResultScreen(GameEngine game)
        {
            _game = game;
            InitializeComponent();
            SetResults();
        }

        private void SetResults()
        {
            List<Player> players = [.. _game.Players.OrderByDescending(p => p.Board.CalculateVictoryPoints(_game))];
            Player winner;
            ResultsListBox.Items.Clear();
            foreach(Player p in players)
            {
                ResultsListBox.Items.Add(
                    p.Name.PadRight(16) + 
                    $"Score: {p.Board.CalculateVictoryPoints(_game)}".PadRight(24) + 
                    $"Highest Scoring Pen: {p.Board.Pens.OrderByDescending(pen => pen.CalculateVictoryPoints(_game)).First().Name}");
            }
            if(players[0].Board.CalculateVictoryPoints(_game) > players[1].Board.CalculateVictoryPoints(_game))
            {
                winner = players[0];
            }
            // both tied, does player 1 have more trexs
            else
            {
                int p1TC = players[0].GetSpeicesCount(DinoSpecies.TRex);
                int p2TC = players[1].GetSpeicesCount(DinoSpecies.TRex);
                if(p1TC == p2TC)
                {
                    WinningPlayerText.Text = $"Both Players Tie!";
                    return;
                }
                else
                {
                    winner = (p1TC < p2TC) ? players[0] : players[1];
                }
            }
            WinningPlayerText.Text = $"{players.First().Name} Wins!";
        }
        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Open up the init game screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
