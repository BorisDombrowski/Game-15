using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Game 15/Level Data", fileName = "New Level Data")]
public class LevelData : ScriptableObject
{
    public string DescriptiveName;
    public Texture2D LevelImage;
    [Range(2, 12)] public int CellCountInRow = 4;
    [Range(0, 10)] public float CellSpacing = 4;
    public float CellSize
    {
        get
        {
            if(LevelImage == null)
            {
                return 0;
            }
            else
            {
                return (float)(LevelImage.width - ((CellCountInRow - 1) * CellSpacing)) / (float)CellCountInRow;
            }
        }
    }
}
