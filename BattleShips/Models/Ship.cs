﻿using System;
using System.Collections.Generic;
using System.Text;
using BattleShips.Common;

namespace BattleShips.Models
{
    public class Ship:IShip
    {
        private int size;

        public Ship(int size, ShipDirection direction, char shipSymbol)
        {
            this.Size = size;
            this.Direction = direction;
            this.Image = shipSymbol;
        }

        public Ship(int size, ShipDirection direction, char shipSymbol, Position topLeft)
            : this(size, direction, shipSymbol)
        {
            this.TopLeftPosition = topLeft;
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.ValidateSize(value);
                this.size = value;
            }
        }

        public ShipDirection Direction { get; set; }

        public char Image { get; set; }

        public Position TopLeftPosition { get; set; }

        public bool IsSunk { get; set; }

        public int HitsCount { get; set; }

        private void ValidateSize(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException(GlobalConstants.ShipNegativeSizeMsg);
            }
        }
    }
}
