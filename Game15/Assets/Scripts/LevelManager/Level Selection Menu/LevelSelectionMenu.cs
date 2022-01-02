using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    [SerializeField] private LevelSelectionButton ButtonPrefab;
    [SerializeField] private Transform Layout;

    private void Awake()
    {
        GameManager.Initialized += OnGameManagerInitialized;
    }

    private void OnGameManagerInitialized(List<LevelData> levels)
    {
        for(int lvl = 0; lvl < levels.Count; lvl++)
        {
            var bt = Instantiate(ButtonPrefab, Layout);
            bt.Initialize(lvl, levels[lvl].DescriptiveName);
        }
    }

    private void OnDestroy()
    {
        GameManager.Initialized -= OnGameManagerInitialized;
    }
}
