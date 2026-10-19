using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Draftosaurus.Engine;
using Draftosaurus.Pens;

namespace Draftosaurus
{
    public partial class PlayerDisplay : UserControl
    {
        private GameEngine? _game;
        private Player? _player;

        /// <summary>
        /// Used to trigger the game engine when a dinosaur is selected on the GUI
        /// </summary>
        public event EventHandler? DinosaurSelected;
        public delegate void DinoSelectedEventHandler(object? sender, EventArgs e);

        /// <summary>
        /// Used to trigger the game engine when a pen is selected on the GUI
        /// </summary>
        public event EventHandler? PenSelected;
        public delegate void PenSelectedEventHandler(object? sender, EventArgs e);

        public PlayerDisplay()
        {
            InitializeComponent();
            DinosaurSelected += OnDinoSelected;
            PenSelected += OnPenSelected;
        }

        /// <summary>
        /// The player being displayed
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Player? Player
        {
            get { return _player; }
            set
            {
                _player = value;
                if (value != null)
                {
                    PlayerName.Text = value.Name;
                }
            }
        }
        /// <summary>
        /// The game engine
        /// </summary>

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public GameEngine? Game
        {
            get { return _game; }
            set { _game = value; }
        }

        /// <summary>
        /// Draws the board to the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (sender is PictureBox pic) pic.BackColor = Color.ForestGreen;
            if (Player == null)
            {
                return;
            }
            Player.Board.Draw(e.Graphics);
        }

        /// <summary>
        /// Selects a pen based on where the user clicked on the board display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardDisplay_Click(object sender, EventArgs e)
        {
            if (Game == null || Player == null) return;

            if (Game.State == GameState.SelectPenToPlaceIn && e is MouseEventArgs mouseEvent)
            {
                DinoPen? found = Player.Board.FindPen(mouseEvent.Location);
                if (found == null)
                {
                    return;
                }
                //MessageBox.Show($"{found.Name} ({Player.Name})");
                Player.SelectedPen = found;
                Player.DinosaurPlacementArgs.Position = mouseEvent.Location;
                ShowPenInformationToGamePanel(found);
                //MessageBox.Show(Player.DinosaurPlacementArgs.ToString());
            }
        }

        /// <summary>
        /// Disables the game panel until all players have selected a dinosaur and triggers the game engine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDinoSelected(object? sender, EventArgs e)
        {
            if (e is not DinoSelectArgs dsa) return;
            if (Player.SelectedDinosaur == null)
            {
                MessageBox.Show($"{Player.Name}, please select a dinosaur.");
                return;
            }
            if (sender is Control c) c.Enabled = false; 
            Game.OnDinoSelected(dsa.SelectMode);
        }

        /// <summary>
        /// Disables the game panel until all players have placed a dinosaur and triggers the game engine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPenSelected(object? sender, EventArgs e)
        {
            UnselectAllPanelControls();
            if (
                Player.DinosaurPlacementArgs != null &&
                Player.SelectedDinosaur != null && 
                Player.SelectedPen != null)
            {
                Game.OnPenConfirmed(Player);
                if (sender is Control c && Player.HasPlacedThisTurn) c.Enabled = false;
                //PlayerName.Text = $"{Player.Name}'s score: {Player.Board.CalculateVictoryPoints(Game)}";
            }
            else
            {
                SetPanelToText("Select a Pen");
            }
        }

        /// <summary>
        /// Sets the back colour of all controls to be the default colour
        /// </summary>
        public void UnselectAllPanelControls()
        {
            foreach (Control c in GamePanel.Controls)
            {
                c.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Displays the player's hand to the game panel
        /// </summary>
        public void ShowHandPanel()
        {
            if (Player == null || Game == null) return;
            this.Enabled = true;
            int size = 64;
            int margin = size / 4;
            Size buttonSize = new(size, size);
            GamePanel.Controls.Clear();
            for(int i = 0; i < Player.Hand.Count; i++)
            {
                Point position = new(margin * 2 / 3 + (margin / 2 * (i + 1) + i * size), margin * 3);
                Button dinoButton = new()
                {
                    Name = i.ToString(),
                    Size = buttonSize,
                    BackgroundImage = Player.Hand[i].Species.Sprite,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Location = position,
                };
                dinoButton.Click += (object? sender, EventArgs e) =>
                {
                    if (sender == null || sender is not Button b || !Int32.TryParse(b.Name, out int dinoId)) return;
                    Player.SelectedDinosaur = Player.Hand[dinoId];
                    UnselectAllPanelControls();
                    b.BackColor = Color.Blue;
                };
                GamePanel.Controls.Add(dinoButton);
            }
            Button confirm = CreateConfirmButton();
            confirm.Click += (s, e) =>
            {
                switch (Game.State)
                {
                    case GameState.SelectDinoToPlace:
                        DinosaurSelected?.Invoke(this, new DinoSelectArgs(DinoSelectMode.ToPlace));
                        break;
                    case GameState.SelectDinoToDiscard:
                        DinosaurSelected?.Invoke(this, new DinoSelectArgs(DinoSelectMode.ToDiscard));
                        break;
                    default:
                        throw new Exception($"Dino hand not loaded in valid state {Game.State}");
                }
            };
            GamePanel.Controls.Add(confirm);
            
        }

        

        /// <summary>
        /// Creates a basic confirmation button shared between panel states
        /// </summary>
        /// <returns></returns>
        private Button CreateConfirmButton()
        {
            return new()
            {
                Text = "Confirm",
                AutoSize = true,
                Location = new Point(GamePanel.Width - 86, GamePanel.Height - 40),
                Enabled = (Player is not CPU)
            };
        }

        private Button CreateConfirmPenButton()
        {
            Button confirm = CreateConfirmButton();
            confirm.Click += (object? sender, EventArgs e) =>
            {
                PenSelected?.Invoke(this, EventArgs.Empty);
            };
            return confirm;
        }

        public void SetPanelToText(string text)
        {
            GamePanel.Controls.Clear();
            Label l = new()
            {
                Text = text
            };
            l.Location = new Point((GamePanel.Width - l.Width) / 2, (GamePanel.Height - l.Height) / 2);
            GamePanel.Controls.Add(l);
        }

        /// <summary>
        /// Puts a message telling the player to select a pen on their game panel
        /// </summary>
        public void ShowPenPanel()
        {
            this.Enabled = true;
            //MessageBox.Show("Showing pen panel");
            if (Player == null || Game == null) return;

            GamePanel.Controls.Clear();
            if (Player.SelectedPen == null)
            {
                SetPanelToText("Select a Pen");
            }
        }

        public void ShowPenInformationToGamePanel(DinoPen pen)
        {
            if (Player == null || Game == null) return;

            GamePanel.Controls.Clear();
            int margin = 16;
            int iconSize = 96;
            PictureBox icon = new()
            {
                Location = new Point(margin, (margin * 3) / 2),
                Size = new Size(iconSize, iconSize),
                BackgroundImage = pen.Icon,
                BackgroundImageLayout = ImageLayout.Stretch,
                BorderStyle = BorderStyle.Fixed3D
            };

            Label nameLabel = new()
            {
                Text = pen.Name,
                Font = new Font(FontFamily.GenericSansSerif, 14),
                Location = new Point(icon.Right + margin, margin),
                AutoSize = true
            };

            TextBox textBox = new()
            {
                Multiline = true,
                ReadOnly = true,
                Location = new Point(icon.Right + margin, nameLabel.Bottom + margin),
                Size = new Size(GamePanel.Width - margin * 2 - icon.Right, icon.Height - nameLabel.Height - margin / 2),
                Text = pen.Description,
                ScrollBars = ScrollBars.Vertical
            };

            Button confirm = CreateConfirmPenButton();

            Color penDinosBg = Color.Gray;

            PictureBox penDinos = new()
            {
                Location = new Point(icon.Left, confirm.Top),
                Size = new Size(confirm.Left - icon.Left, confirm.Height + 8),
                BackColor = penDinosBg,
                BorderStyle = BorderStyle.Fixed3D
            };

            penDinos.Paint += (s, e) =>
            {
                int dinoIconSize = 16;
                Graphics paper = e.Graphics;
                if (s is Control c) c.BackColor = penDinosBg;
                for (int i = 0; i < pen.DinoCount; i++)
                {
                    Dinosaur d = pen.Dinosaurs[i];
                    paper.DrawImage(d.Species.Sprite, i * dinoIconSize + margin / 2, 4, dinoIconSize, dinoIconSize);
                }
            };

            GamePanel.Controls.AddRange(icon, nameLabel, textBox, confirm, penDinos);
        }
    }
}
