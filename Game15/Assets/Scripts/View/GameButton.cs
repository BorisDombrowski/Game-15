using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game15.View
{
    [RequireComponent(typeof(RawImage))]
    public class GameButton : MonoBehaviour
    {
        public int x;
        public int y;
        public Text DigitText;
        private GameView gameView;
        public bool interactible = true;

        public void Initialize(int x, int y, GameView gameView)
        {
            this.x = x;
            this.y = y;
            this.gameView = gameView;
        }

        public void OnClick()
        {
            if (interactible)
            {
                gameView.OnClick(x, y);
            }
        }

        public void SetButtonView(int digit, Texture2D texture)
        {
            DigitText.text = digit.ToString();
            var ri = GetComponent<RawImage>();
            ri.texture = texture;

            if(digit > 0)
            {
                ri.color = Color.white;
                DigitText.color = Color.yellow;
            }
            else
            {
                ri.color = Color.clear;
                DigitText.color = Color.clear;
            }
        }

        public void ShowDigit(bool show)
        {
            DigitText.gameObject.SetActive(show);
        }
    }
}
