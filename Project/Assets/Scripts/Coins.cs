using UnityEngine;
using UnityEngine.UI;

namespace FATEC.ClansOfDragons {
    /// <summary>
    /// Coins of Players
    /// </summary>
    public class Coins : MonoBehaviour{
        [Tooltip("Amount initial of coins")]
        public int coins = 200;
        [Tooltip("Text for update in screen")]
        public Text text;

        protected void Update() {
            if (this.text != null) {
                this.text.text = "$: "+(this.coins).ToString();
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