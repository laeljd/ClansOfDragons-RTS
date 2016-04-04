﻿using UnityEngine;
using UnityEngine.UI;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Coins of Players
    /// </summary>
    public class Coins : MonoBehaviour{
        [Tooltip("Amount initial of coins")]
        public int coins = 200;
        [Tooltip("Text for update in screen")]
        public Text text;

        protected void Update() {
            if (text != null) {
                text.text = (coins).ToString();
            }
        }

        public bool ChangeCoins(int amount) {
            //only buy if have coins
            if(this.coins >= amount) {
                this.coins -= amount;
                return true;
            }else{
                return false;
            }
        }
    }
}