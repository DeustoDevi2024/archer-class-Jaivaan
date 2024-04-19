using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Archer.UI
{

    public class StartScreen : MonoBehaviour
    {

        [SerializeField]
        private Button startButton;

        private void Awake()
        {
            startButton.onClick.AddListener(OnStartClick);
        }

        private void OnStartClick()
        {
            AppLogic.Instance.LoadGame();
        }
    }

}