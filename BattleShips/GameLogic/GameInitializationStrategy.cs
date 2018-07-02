using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Common;
using BattleShips.Models;

namespace BattleShips.GameLogic
{
    public class GameInitializationStrategy:IGameInitializationStrategy
    {
        private static Random random;

        private readonly Dictionary<Type, int> shipsForPlacement;
        private ShipFactory shipFactory;

        static GameInitializationStrategy()
        {
            random = new Random();
        }

        public GameInitializationStrategy()
        {
            this.shipsForPlacement = new Dictionary<Type, int>
            {
                { typeof(Battleship), GlobalConstants.InitialBattleshipsCount },
                { typeof(Destroyer), GlobalConstants.InitialDestroyerCount }
            };

            this.shipFactory = new ShipFactory();
        }

        public void Initialize(Grid hiddenGrid, Grid visibleGrid, IList<IShip> ships)
        {
            this.FillInitialGrid(visibleGrid, GlobalConstants.NoShotSymbol);
            this.FillInitialGrid(hiddenGrid, GlobalConstants.BlankSymbol);
            this.AddShipsToGrid(hiddenGrid, ships);
        }

        private void FillInitialGrid(Grid grid, char symbol)
        {
            for (int row = 0; row < grid.TotalRows; row++)
            {
                for (int col = 0; col < grid.TotalCols; col++)
                {
                    grid.SetCellByRowAndCol(row, col, symbol);
                }
            }
        }

        private void AddShipsToGrid(Grid grid, IList<IShip> ships)
        {
            foreach (var shipForPlacement in this.shipsForPlacement)
            {
                for (int i = 0; i < shipForPlacement.Value; i++)
                {
                    ShipDirection direction = this.GetRandomShipDirection();
                    IShip ship = this.shipFactory.Get(shipForPlacement.Key.Name, direction);
                    Position topLeft = this.GetRandomShipPosition(ship.Size, direction);

                    while (this.ShipsOverlap(ship, grid))
                    {
                        ship.TopLeftPosition = this.GetRandomShipPosition(ship.Size, direction);
                    }

                    this.AddShipToList(ship, ships);
                    grid.PlaceShip(ship);
                }
            }
        }

        private void AddShipToList(IShip ship, IList<IShip> ships)
        {
            ships.Add(ship);
        }

        private bool ShipsOverlap(IShip ship, Grid grid)
        {
            int shipRow = ship.TopLeftPosition.Row;
            int shipCol = ship.TopLeftPosition.Col;

            for (int i = 0; i < ship.Size; i++)
            {
                if (grid.GetCellByRowAndCol(shipRow, shipCol) == ship.Image)
                {
                    return true;
                }

                if (ship.Direction == ShipDirection.Vertical)
                {
                    shipRow++;
                }
                else
                {
                    shipCol++;
                }
            }

            return false;
        }

        private ShipDirection GetRandomShipDirection()
        {
            return random.Next(0, 2) == 0 ? ShipDirection.Vertical : ShipDirection.Horizontal;
        }

        private Position GetRandomShipPosition(int shipSize, ShipDirection direction)
        {
            int row;
            int col;

            if (direction == ShipDirection.Horizontal)
            {
                row = random.Next(0, GlobalConstants.GridRowsCount);
                col = random.Next(0, GlobalConstants.GridColsCount - shipSize);
            }
            else
            {
                row = random.Next(0, GlobalConstants.GridRowsCount - shipSize);
                col = random.Next(0, GlobalConstants.GridColsCount);
            }

            return new Position(row, col);
        }
    }
}
