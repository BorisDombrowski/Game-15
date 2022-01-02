using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    private int LevelID;
    [SerializeField] private Text LevelNameText;

    public void Initialize(int lvl_id, string lvl_name)
    {
        LevelID = lvl_id;
        LevelNameText.text = lvl_name;
    }

    public void OnClick()
    {
        GameManager.StartLevel(LevelID);
    }
}
