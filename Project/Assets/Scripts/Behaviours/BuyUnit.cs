using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Player Buy Unit ic click a button
    /// </summary>
    public class BuyUnit : MonoBehaviour {
        [Tooltip("Coins of player to discont.")]
        public Coins coins;
        [Tooltip("Prefab unit to instantiate.")]
        public GameObject prefab;
        [Tooltip("Position to instantiate.")]
        public new Transform transform;
        [Tooltip("Base menu to enable/disable")]
        public GameObject BaseMenu;
        [Tooltip("Amount of the units")]
        public UnitCount unitAmount;
        /// <summary>Center of config values.</summary>
        protected CenterConfig unitValueConfig;

        protected void Awake() {
            this.unitValueConfig = new CenterConfig();
        }

        ///<param name="type">Type of unit, 0 UnitLight, 1 UnitMedium, 2 UnitHeavy, 3 Base</param>
        public void Buy(int type) {
            if (this.unitAmount.currentUnits < this.unitAmount.unitAmountMax) {
                if (coins.ChangeCoins(unitValueConfig.GetValue(type))) {
                    GameObject.Instantiate(this.prefab, this.transform.position, Quaternion.identity);
                    BaseMenu.SetActive(false);
                }
            }
        }
    }
}