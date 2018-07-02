using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Common;

namespace BattleShips.Models
{
    public class Grid
    {
        private readonly char[,] grid;

        public Grid(int rows = GlobalConstants.GridRowsCount, int cols = GlobalConstants.GridColsCount)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.grid = new char[rows, cols];
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public void PlaceShip(IShip ship)
        {
            int shipRow = ship.TopLeftPosition.Row;
            int shipCol = ship.TopLeftPosition.Col;

            for (int i = 0; i < ship.Size; i++)
            {
                this.grid[shipRow, shipCol] = ship.Image;

                if (ship.Direction == ShipDirection.Vertical)
                {
                    shipRow++;
                }
                else
                {
                    shipCol++;
                }
            }
        }

        public char GetCellByPosition(Position position)
        {
            return this.grid[position.Row, position.Col];
        }

        public char GetCellByRowAndCol(int row, int col)
        {
            return this.grid[row, col];
        }

        public void SetCellByPosition(Position position, char value)
        {
            this.grid[position.Row, position.Col] = value;
        }

        public void SetCellByRowAndCol(int row, int col, char value)
        {
            this.ValidateRow(row);
            this.ValidateCol(col);

            this.grid[row, col] = value;
        }

        private void ValidateRow(int value)
        {
            Validator.CheckIfInRange(value, 0, GlobalConstants.GridRowsCount, GlobalConstants.InvalidRowMsg);
        }

        private void ValidateCol(int value)
        {
            Validator.CheckIfInRange(value, 0, GlobalConstants.GridColsCount, GlobalConstants.InvalidColMsg);
        }
    }
}
