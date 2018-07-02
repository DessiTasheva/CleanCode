using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Common;

namespace BattleShips.Models
{
    public class Destroyer:Ship
    {
        public Destroyer(ShipDirection direction)
            : base(GlobalConstants.DestroyerSize, direction, GlobalConstants.DestroyerSymbol)
        {
        }

        public Destroyer(ShipDirection direction, Position topLeft)
            : base(GlobalConstants.DestroyerSize, direction, GlobalConstants.DestroyerSymbol, topLeft)
        {
        }
    }
}
