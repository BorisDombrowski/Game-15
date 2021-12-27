using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game15.Model
{
    struct Map
    {
        private int size;
        private int[,] map;

        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        public void Set(Coordinates coordinates, int value)
        {
            if(coordinates.OnMap(size))
            {
                map[coordinates.x, coordinates.y] = value;
            }
        }

        public int Get(Coordinates coordinates)
        {
            if(coordinates.OnMap(size))
            {
                return map[coordinates.x, coordinates.y];
            }
            return 0;
        }

        public void Copy(Coordinates from, Coordinates to)
        {
            Set(to, Get(from));
        }
    }
}
