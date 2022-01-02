using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesNavigation : MonoBehaviour
{
    public void StartNextLevel()
    {
        GameManager.StartNextLevel();
    }

    public void RestartLevel()
    {
        GameManager.RestartLevel();
    }

    public void ReturnToMenu()
    {
        GameManager.ReturnToMenu();
    }
}
