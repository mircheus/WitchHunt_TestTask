using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace Game.Reader.Games.ShootingGame
{
    public class WinMenu : MonoBehaviour
    {
        private const float HalfTransparent = 0.5f;

        [SerializeField] private Image background;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private float _fadeSpeed;

        public void ShowWinMenu()
        {
            background.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            StartCoroutine(FadeInText());
            StartCoroutine(FadeInBackground());
        }

        private IEnumerator FadeInText()
        {
            while(scoreText.color.a < 1)
            {
                scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, scoreText.color.a + _fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator FadeInBackground()
        {
            while (background.color.a < HalfTransparent)
            {
                background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a + _fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

