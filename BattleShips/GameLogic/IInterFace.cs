using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models;

namespace BattleShips.GameLogic
{
    public interface IInterface
    {
        string GetUserInput();

        UserCommand GetCommandFromInput();

        Position GetShotPositionFromInput();

        void ExitGame();
    }
}
