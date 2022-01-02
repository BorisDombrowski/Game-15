using System;
using System.Collections.Generic;

public static class GameManager
{   
    private static List<LevelData> Levels;
    public static Action<List<LevelData>> Initialized;
    public static LevelData CurrentLevel { get; private set; }

    public static void Initialize(List<LevelData> levels)
    {
        Levels = levels;
        Initialized?.Invoke(Levels);
    }

    public static void StartLevel(int index)
    {
        CurrentLevel = Levels[index];
        SceneLoader.StartSceneLoading("game");
    }

    public static void StartNextLevel()
    {        
        CurrentLevel = Levels[GetNextIndex()];
        SceneLoader.StartSceneLoading("game");
    }

    public static void ReturnToMenu()
    {
        CurrentLevel = null;
        SceneLoader.StartSceneLoading("main");
    }

    public static void RestartLevel()
    {
        SceneLoader.StartSceneLoading("game");
    }

    public static bool HasNextLevel()
    {
        if (CurrentLevel == null) return false;

        var index = GetNextIndex();
        if (index >= Levels.Count) 
        { 
            return false; 
        }
        else
        {
            return true;
        }
    }

    private static int GetNextIndex()
    {
        if (CurrentLevel == null) return 0;
        return Levels.IndexOf(CurrentLevel) + 1;
    }
}
