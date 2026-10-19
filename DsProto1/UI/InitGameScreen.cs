using Draftosaurus.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Draftosaurus.UI
{
    public partial class InitGameScreen : Form
    {
        public InitGameScreen()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, EventArgs e)
        {
            GameEngine g;
            string p1name = (String.IsNullOrWhiteSpace(P1Name.Text)) ? "Player 1" : P1Name.Text;
            string p2name = (String.IsNullOrWhiteSpace(P2Name.Text)) ? "Player 2" : P2Name.Text;
            if (sender == PvP)
            {
               g = GameFactory.CreateTwoPlayerGame(p1name, p2name, GameType.PvP, BoardType.Summer);
            }
            else if(sender == PvC)
            {
               g = GameFactory.CreateTwoPlayerGame(p1name, p2name + " (CPU)", GameType.PvC, BoardType.Summer);
            }
            else if(sender == CvC)
            {
                g = GameFactory.CreateTwoPlayerGame(p1name + " (CPU)", p2name + " (CPU)", GameType.CvC, BoardType.Summer);
            }
            else
            {
                MessageBox.Show("Invalid sender");
                return;
            }
            MainGameScreen mainGameScreen = new(g);
            mainGameScreen.ShowDialog();
        }
    }
}
