using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Common;
using BattleShips.GameLogic;
using BattleShips.Models;

namespace BattleShips.Console
{
    public class ConsoleRenderer:IRenderer
    {
        private const int GridRowStartingPosition = 2;
        private const int GridColStartingPosition = 0;

        private StringBuilder consoleView;

        public ConsoleRenderer()
        {
            this.consoleView = new StringBuilder();
        }

        public void RenderGrid(Grid grid)
        {
            System.Console.SetCursorPosition(GridColStartingPosition, GridRowStartingPosition);

            this.consoleView.Clear().Append(' ');

            for (int i = 1; i <= GlobalConstants.GridColsCount; i++)
            {
                string stringToAppend = i < 9 ? i.ToString() : i.ToString().Substring(i.ToString().Length - 1);
                this.consoleView.Append(stringToAppend);
            }

            this.consoleView.AppendLine();

            for (int row = 0; row < grid.TotalRows; row++)
            {
                this.consoleView.Append((char)(GlobalConstants.MinRowValueOnGridAsciiCode + row));

                for (int col = 0; col < grid.TotalCols; col++)
                {
                    this.consoleView.Append(grid.GetCellByRowAndCol(row, col));
                }

                this.consoleView.Append(Environment.NewLine);
            }

            System.Console.WriteLine(this.consoleView.ToString());
            this.SetCursorAtInputPosition();
        }

        
        public void UpdateGrid(Grid grid, Position position)
        {
            System.Console.SetCursorPosition(position.Col + GridColStartingPosition + 1, position.Row + GridRowStartingPosition + 1);
            System.Console.Write(grid.GetCellByRowAndCol(position.Row, position.Col));
            this.SetCursorAtInputPosition();
        }

        public void RenderMessage(string message, bool setCursor = true)
        {
            this.ClearRow(GridRowStartingPosition + GlobalConstants.GridRowsCount + 2);
            System.Console.SetCursorPosition(0, GridRowStartingPosition + GlobalConstants.GridRowsCount + 2);
            System.Console.WriteLine(message);
            if (setCursor)
            {
                this.SetCursorAtInputPosition();
            }
        }

        public void RenderStatusMessage(string message)
        {
            this.ClearRow(0);
            System.Console.SetCursorPosition(0, 0);
            System.Console.WriteLine("<< {0} >>", message);
            this.SetCursorAtInputPosition();
        }

        public void RenderErrorMessage(string message)
        {
            this.ClearRow(GridRowStartingPosition + GlobalConstants.GridRowsCount + 4);
            System.Console.SetCursorPosition(0, GridRowStartingPosition + GlobalConstants.GridRowsCount + 4);
            System.Console.WriteLine(message);
            this.SetCursorAtInputPosition();
        }

        public void Clear()
        {
            System.Console.Clear();
        }

        public void ClearError()
        {
            this.ClearRow(GridRowStartingPosition + GlobalConstants.GridRowsCount + 4);
            this.ClearRow(GridRowStartingPosition + GlobalConstants.GridRowsCount + 5);
        }

        private void ClearRow(int row)
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.SetCursorPosition(0, row);
            System.Console.Write(new string(' ', System.Console.WindowWidth));

        }

        private void SetCursorAtInputPosition()
        {
            this.ClearRow(GridRowStartingPosition + GlobalConstants.GridRowsCount  + 3 );
            System.Console.SetCursorPosition(0, GridRowStartingPosition + GlobalConstants.GridRowsCount + 3);
        }
    }
}
