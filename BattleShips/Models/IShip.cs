using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public interface IShip
    {
        int Size { get; }

        ShipDirection Direction { get; }

        char Image { get; }

        Position TopLeftPosition { get; set; }

        bool IsSunk { get; set; }

        int HitsCount { get; set; }

    }
}
