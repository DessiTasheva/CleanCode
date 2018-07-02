using System;
using BattleShips.Common;


namespace BattleShips.Models
{
    public class ShipFactory
    {
        public IShip Get(string shipType, ShipDirection direction)
        {
            switch (shipType)
            {
                case "Battleship":
                    return new Battleship(direction);
                case "Destroyer":
                    return new Destroyer(direction);
                default:
                    throw new InvalidOperationException(GlobalConstants.InvalidShipMsg);
            }
        }
    }
}
