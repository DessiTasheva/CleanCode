using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Common;
using BattleShips.GameLogic;
using BattleShips.Models;

namespace BattleShips.Console
{
    public class ConsoleInterface:IInterface
    {
        private string coordinates;

        public string GetUserInput()
        {
            var input = System.Console.ReadLine();
            return input;
        }

        public UserCommand GetCommandFromInput()
        {
            string input = this.GetUserInput().ToUpper();

            switch (input)
            {
                case GlobalConstants.ShowCommand:
                    return UserCommand.Show;
                case GlobalConstants.ExitCommand:
                    return UserCommand.Exit;
                case GlobalConstants.NewGameCommand:
                    return UserCommand.New;
                case GlobalConstants.AgreeCommand:
                    return UserCommand.Agree;
                default:
                    if (this.AreValidCoordinates(input))
                    {
                        this.coordinates = input;
                        return UserCommand.Shoot;
                    }

                    return UserCommand.Invalid;
            }
        }

        public Position GetShotPositionFromInput()
        {
            return Position.GetFromBattleshipBoard(this.coordinates[0], this.coordinates.Substring(1));
        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }

        private bool AreValidCoordinates(string coordinates)
        {
            int col;
            if (coordinates.Length < 2 || coordinates.Length > 3 || !char.IsLetter(coordinates[0])
                || coordinates[0] < GlobalConstants.MinRowValueOnGrid || coordinates[0] > GlobalConstants.MaxRowValueOnGrid
                || !int.TryParse(coordinates.Substring(1), out col))
            {
                return false;
            }

            return true;
        }
    }
}


