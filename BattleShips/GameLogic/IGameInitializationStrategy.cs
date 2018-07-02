using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Models;

namespace BattleShips.GameLogic
{
    public interface IGameInitializationStrategy
    {
        void Initialize(Grid hiddenGrid, Grid visibleGrid, IList<IShip> ships);
    }
}
