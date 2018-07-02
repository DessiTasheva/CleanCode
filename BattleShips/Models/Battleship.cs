using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Common;

namespace BattleShips.Models
{
    public class Battleship:Ship
    {
        public Battleship(ShipDirection direction)
            : base(GlobalConstants.BattleshipSize, direction, GlobalConstants.DestroyerSymbol)
        {
        }

        public Battleship(ShipDirection direction, Position topLeft)
            : base(GlobalConstants.BattleshipSize, direction, GlobalConstants.BattleshipSymbol, topLeft)
        {
        }
    }
}
