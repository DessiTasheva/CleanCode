using System;
using BattleShips.Console;
using BattleShips.GameLogic;

namespace BattleShips
{
    class Program
    {
        public static void Main()
        {
            IInterface userInterface = new ConsoleInterface();
            IRenderer renderer = new ConsoleRenderer();
            IGameInitializationStrategy gameInitializationStrategy = new GameInitializationStrategy();
            Engine gameEngine = new Engine(renderer, userInterface, gameInitializationStrategy);

            gameEngine.Run();
        }
    }
}