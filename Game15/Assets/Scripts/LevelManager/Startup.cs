using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private List<LevelData> levels = new List<LevelData>();

    private void Start()
    {
        GameManager.Initialize(levels);
    }
}
