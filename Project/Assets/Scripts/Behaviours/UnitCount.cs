using UnityEngine;
using UnityEngine.UI;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Coins of Players
    /// </summary>

    public class UnitCount : MonoBehaviour {
        [Tooltip("Amount max of units")]
        public int unitAmountMax = 10;
        [Tooltip("Text for update in screen")]
        public Text text;
        [Tooltip("Tag of unit")]
        public string unitTag;
        [HideInInspector]
        /// <summary>Current amount of the units</summary>
        public int currentUnits;

        protected void Awake() {
            this.currentUnits = this.unitAmountMax;
        }

        protected void Update() {
            this.currentUnits = GameObject.FindGameObjectsWithTag(this.unitTag).Length;

            if (this.text != null) {
                this.text.text = "Units: " + (this.currentUnits).ToString() + "/" + (this.unitAmountMax).ToString();
            }
        }
    }
}