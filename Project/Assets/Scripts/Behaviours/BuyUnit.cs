using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Player Buy Unit ic click a button
    /// </summary>
    public class BuyUnit : MonoBehaviour {
        [Tooltip("Button for buy unit.")]
        public Button button;
        [Tooltip("Coins of player to discont.")]
        public Coins coins;
        [Tooltip("Prefab unit to instantiate.")]
        public GameObject prefab;
        [Tooltip("Position to instantiate.")]
        public new Transform transform;
        [Tooltip("Base menu to enable/disabe")]
        public GameObject BaseMenu;
        [Tooltip("Type of unit for discont the value of coins")]
        public CenterConfig.unitType type;
        /// <summary>Value of unit.</summary>
        protected int unitValue;
        /// <summary>Center of config values.</summary>
        protected CenterConfig unitValueConfig;

        protected void Awake() {
            this.unitValueConfig = new CenterConfig();
            this.unitValue = this.unitValueConfig.GetValue((int)type);
            if (button != null) {
                button.onClick.AddListener(delegate { Buy((int)this.type); });
            }
        }

        public void Buy(int type) {
            if (coins.ChangeCoins(this.unitValue)) {
                GameObject.Instantiate(this.prefab, this.transform.position, Quaternion.identity);
                BaseMenu.SetActive(false);
            }
        }
    }
}