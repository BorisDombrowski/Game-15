using System;
using System.Collections.Generic;
using UnityEngine;
using Game15.Model;
using Game15.View;

namespace Game15.Controller
{
    public class GameController : MonoBehaviour
    {
        private GameModel game;
        public GameView view;

        private void Start()
        {
            game = new GameModel(GameManager.CurrentLevel);
            game.Start(1000 + DateTime.Now.DayOfYear);

            view.Initialize(this);
            view.GenerateField(GameManager.CurrentLevel.LevelImage, game.size, game.cellSize, game.spacing);
        }

        public void OnClick(int x, int y)
        {
            game.PressAt(x, y);
            view.UpdateView();

            if(game.IsSolved())
            {
                FinishGame();
            }
        }

        private void FinishGame()
        {
            view.OnSolved();
        }

        public int GetDigitAt(int x, int y)
        {
            return game.GetDigitAt(x, y);
        }

        public Texture2D GetTextureAt(int x, int y)
        {
            return game.GetTextureAt(x, y);
        }
    }
}
