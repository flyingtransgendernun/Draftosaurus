using Draftosaurus.Boards;
using Draftosaurus.Engine;
using Draftosaurus.UI;

namespace Draftosaurus
{
    public partial class MainGameScreen : Form
    {
        private GameEngine _game;
        private GamePresenter _presenter;
        public MainGameScreen(GameEngine game)
        {
            _game = game;
            _game.Presenter = new(game, this);
            _presenter = _game.Presenter;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _presenter.InitialiseControls();
            _game.State = GameState.RoundStart;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            _presenter.Update();
        }
    }
}
