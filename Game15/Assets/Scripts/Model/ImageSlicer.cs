using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game15.Model
{
    class ImageSlicer
    {
        public Texture2D[] SliceImage(Texture2D input_tex, int cell_count, int cell_size, int spacing)
        {
            List<Texture2D> res = new List<Texture2D>();

            var down = 0;
            var up = cell_size;            

            for(int row = 0; row < cell_count; row++) 
            {
                var left = 0;
                var right = cell_size;

                for (int col = 0; col < cell_count; col++)
                {
                    var tex = new Texture2D(cell_size, cell_size);
                    tex.filterMode = FilterMode.Point;

                    for(int y = down, i = 0; y < up; y++, i++) //filling new texture
                    {
                        for(int x = left, j = 0; x < right; x++, j++)
                        {
                            tex.SetPixel(j, i, input_tex.GetPixel(x, y));
                        }
                    }

                    tex.Apply();
                    res.Add(tex);

                    left = right + spacing;
                    right = left + cell_size;
                }

                down = up + spacing;
                up = down + cell_size;
            }

            return ReverseByBlocks(res, cell_count);
        }

        private Texture2D[] ReverseByBlocks(List<Texture2D> list, int cell_count)
        {
            List<List<Texture2D>> rows = new List<List<Texture2D>>();
            for (int i = 0; i < cell_count; i++)
            {
                rows.Add(list.GetRange(i * cell_count, cell_count));
            }

            rows.Reverse();

            var res = new List<Texture2D>();
            foreach(var r in rows)
            {
                res.AddRange(r);
            }

            return res.ToArray();
        }
    }
}
