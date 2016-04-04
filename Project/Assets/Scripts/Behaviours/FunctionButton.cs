﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FATEC.ClansOfDragons.Behaviours {

    public class FunctionButton : MonoBehaviour {
        /// <summary>
        /// Function of button on GUI
        /// </summary>
        [Tooltip("Button for buy unit.")]
        public Button button;
        [Tooltip("Type of unit.")]
        public Function function;
        [HideInInspector]
        /// <summary>Function</summary>
        public enum Function {
            ReturnToMenu, Start, Restart, Quit
        }


        protected void Awake() {
            button.onClick.AddListener(delegate { Action(function); });
        }
        // Update is called once per frame
        protected void Action(Function function) {
            if(function == Function.Start) {
                SceneManager.LoadScene("Game");
            }
            if (function == Function.ReturnToMenu) {
                SceneManager.LoadScene("Main");
            }
            if (function == Function.Restart) {
                SceneManager.LoadScene("Game");
            }
            if (function == Function.Quit) {
                Application.Quit();
            }
        }
    }
}