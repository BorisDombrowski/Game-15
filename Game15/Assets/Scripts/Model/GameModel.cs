using System;
using UnityEngine;

namespace Game15.Model
{
    public class GameModel
    {        
        private Texture2D[] slicedTextures;
        private LevelData levelData;

        public int size { get; private set; }
        public float spacing => levelData.CellSpacing;
        public float cellSize => levelData.CellSize;
        private Map map;
        private Coordinates space;

        public int moves { get; private set; }

        public GameModel(LevelData data)
        {
            size = data.CellCountInRow;
            levelData = data;

            var slicer = new ImageSlicer();
            slicedTextures = slicer.SliceImage(data.LevelImage, size, (int)data.CellSize, (int)data.CellSpacing);

            map = new Map(size);
        }

        public void Start(int seed = 0)
        {
            int digit = 0;
            foreach(var c in Coordinates.YieldCoordinates(size))
            {
                map.Set(c, ++digit);
            }
            space = Coordinates.GetLastCellCoordinates(size);

            if(seed > 0)
            {
                Shuffle(seed);
            }

            moves = 0;
        }

        private void Shuffle(int seed)
        {
            var rnd = new System.Random(seed);
            for(int j = 0; j < seed; j++)
            {
                PressAt(rnd.Next(size), rnd.Next(size));
            }
        }

        //PRESS AT CONCRETE POSITION
        public int PressAt(int x, int y)
        {
            return PressAt(new Coordinates(x, y));
        }

        private int PressAt(Coordinates coordinates)
        {
            if (space.Equals(coordinates))
            {
                return 0;
            }
            
            if(coordinates.x != space.x && coordinates.y != space.y)
            {
                return 0;
            }

            while(coordinates.x != space.x)
            {
                Shift(Math.Sign(coordinates.x - space.x), 0);
            }

            while(coordinates.y != space.y)
            {
                Shift(0, Math.Sign(coordinates.y - space.y));
            }

            var steps = Math.Abs(coordinates.x - space.x) + Math.Abs(coordinates.y - space.y);
            moves += steps;
            return steps;
        }

        private void Shift(int sx, int sy)
        {
            var next = space.Add(sx, sy);
            map.Copy(next, space);
            space = next;
        }

        //GET DIGIT AT CONCRETE POSITION
        public int GetDigitAt(int x, int y)
        {
            return GetDigitAt(new Coordinates(x, y));
        }

        private int GetDigitAt(Coordinates coordinates)
        {
            if(space.Equals(coordinates))
            {
                return 0;
            }
            return map.Get(coordinates);
        }

        //GET TEXTURE AT CONCRETE POSITION        
        public Texture2D GetTextureAt(int x, int y)
        {
            var coordinates = new Coordinates(x, y);

            if (coordinates.OnMap(size))
            {
                var number = GetDigitAt(coordinates) - 1;

                if (number < 0 || number > slicedTextures.Length - 1) return null;
                return slicedTextures[number];
            }
            return null;
        }

        //CHECK IS GAME SOLVED
        public bool IsSolved()
        {
            if(!space.Equals(Coordinates.GetLastCellCoordinates(size)))
            {
                return false;
            }

            int digit = 0;
            foreach(var c in Coordinates.YieldCoordinates(size))
            {
                if(map.Get(c) != ++digit)
                {
                    return space.Equals(c);
                }
            }
            return true;
        }
    }
}
