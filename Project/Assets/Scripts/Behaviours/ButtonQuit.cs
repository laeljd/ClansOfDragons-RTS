using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Quit Game
    /// </summary>
    public class ButtonQuit : MonoBehaviour {
        public void Quit() {
            Application.Quit();
        }
    }
}
