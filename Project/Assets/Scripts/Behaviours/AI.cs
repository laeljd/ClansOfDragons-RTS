using UnityEngine;
using System.Collections;
namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Represents the Artificial Intelegence of Enemy
    /// </summary>
    public class AI : MonoBehaviour {
        [Tooltip("Coins")]
        public Coins coins;
        [Tooltip("Prefab unit light")]
        public GameObject unitLight;
        [Tooltip("Prefab unit medium")]
        public GameObject unitMedium;
        [Tooltip("Prefab unit heavy")]
        public GameObject unitHeavy;
        [Tooltip("Position to instantiate.")]
        public new Transform transform;
        [Tooltip("Detector used to check danger in base.")]
        public Detector detector;
        /// <summary>Center of config values.</summary>
        public CenterConfig unitConfig;

        private int nLight;
        private int nMedium;
        private int nHeavy;

        protected void Awake() {
            this.unitConfig = new CenterConfig();
        }
        // Update is called once per frame
        void Update() {
            if (nLight <= nMedium + 2) {
                if (coins.coins >= 50) {
                    if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitLight))) {
                        nLight++;
                        GameObject.Instantiate(this.unitLight, this.transform.position, Quaternion.identity);
                    }
                }
            }
            else if (nLight <= nMedium + 1) {
                if (coins.coins >= 100) {
                    if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitMedium))) {
                        nMedium++;
                        GameObject.Instantiate(this.unitMedium, this.transform.position, Quaternion.identity);
                    }
                }
            }
            else {
                if (coins.coins >= 150) {
                    if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitHeavy))) {
                        nHeavy++;
                        GameObject.Instantiate(this.unitHeavy, this.transform.position, Quaternion.identity);
                    }
                }
            }

            if (detector.objectCollider != null) {
                if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitMedium))) {
                    GameObject.Instantiate(this.unitMedium, this.transform.position, Quaternion.identity);
                }
                else {
                    if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitLight))) {
                        GameObject.Instantiate(this.unitLight, this.transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}