using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game15.Model
{
    struct Coordinates
    {
        public int x;
        public int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool OnMap(int size)
        {
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;
        }

        public static IEnumerable<Coordinates> YieldCoordinates(int size)
        {
            for(int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    yield return new Coordinates(x, y);
                }
            }
        }

        public static Coordinates GetLastCellCoordinates(int size)
        {
            return new Coordinates(size - 1, size - 1);
        }

        public Coordinates Add(int sx, int sy)
        {
            return new Coordinates(x + sx, y + sy);
        }
    }
}
