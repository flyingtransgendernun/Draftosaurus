using Draftosaurus.Boards;
using Draftosaurus.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Draftosaurus.Engine
{
    public enum GameType
    {
        PvP,
        PvC,
        CvC
    }

    public enum BoardType
    {
        Summer
    }

    public static class GameFactory
    {
        public static GameEngine CreateTwoPlayerGame(string player1Name, string player2Name, GameType gameType, BoardType boardType)
        {
            List<Player> players = [
                CreatePlayer(player1Name, boardType, (gameType == GameType.CvC)),
                CreatePlayer(player2Name, boardType, (gameType == GameType.PvC || gameType == GameType.CvC))
                ];
            GameEngine engine = new(players);
            return engine;

        }

        private static Player CreatePlayer(string name, BoardType type, bool isCPU)
        {
            ZooBoard board = GetBoard(type);
            if (isCPU)
            {
                return new CPU(name, board);
            }
            else
            {
                return new Player(name, board);
            }
        }

        private static ZooBoard GetBoard(BoardType type)
        {
            return type switch
            {
                // return a summer board by default
                _ => new SummerBoard(),
            };
        }
    }
}
