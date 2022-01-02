using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game15.Controller;

namespace Game15.View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup GameLayout;
        [SerializeField] private GameButton ButtonPrefab;
        private List<GameButton> createdButtons = new List<GameButton>();

        [SerializeField] private RawImage Background;
        [SerializeField] private Toggle ShowDigitsToggle;
        [SerializeField] private GameObject StartNextLevelButton;


        private GameController controller;

        public void Initialize(GameController controller)
        {
            this.controller = controller;

            if(!GameManager.HasNextLevel())
            {
                StartNextLevelButton.SetActive(false);
            }
        }

        public void GenerateField(Texture2D bgSprite,int fieldSize, float cellSize, float spacing)
        {
            Background.texture = bgSprite;

            for (int y = 0; y < fieldSize; y++)
            {
                for(int x = 0; x < fieldSize; x++)
                {
                    var bt = Instantiate(ButtonPrefab, GameLayout.transform);
                    bt.Initialize(x, y, this);
                    createdButtons.Add(bt);
                }
            }

            GameLayout.spacing = new Vector2(spacing, spacing);
            GameLayout.cellSize = new Vector2(cellSize, cellSize);

            ShowDigits(false);
            UpdateView();
        }

        public void OnClick(int x, int y)
        {
            controller.OnClick(x, y);
        }

        public void UpdateView()
        {
            foreach(var bt in createdButtons)
            {
                bt.SetButtonView(controller.GetDigitAt(bt.x, bt.y), controller.GetTextureAt(bt.x, bt.y));
            }
        }

        public void OnSolved()
        {
            StartCoroutine(Win());
        }

        private IEnumerator Win()
        {
            ShowDigitsToggle.interactable = false;
            ShowDigits(false);
            foreach (var bt in createdButtons)
            {
                bt.interactible = false;
            }

            GetComponent<Animator>().Play("LevelWin");

            yield return new WaitForSeconds(1.5f);

            foreach(var bt in createdButtons)
            {
                Destroy(bt.gameObject);
            }
        }

        public void OnShowDigitsValueChanged()
        {
            ShowDigits(ShowDigitsToggle.isOn);
        }

        private void ShowDigits(bool show)
        {
            foreach (var bt in createdButtons)
            {
                bt.ShowDigit(show);
            }
        }
    }
}
