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
        /// <summary>Time for auto give coins.</summary>
        public int coinsTime = 15;

        /// <summary>Count for create a unit.</summary>
        private int nLight;
        private int nMedium;

        protected void Awake() {
            this.unitConfig = new CenterConfig();
            StartCoroutine(AutoGiveCoins());
        }



        void Update() {
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
            else {
                if (nLight <= 2) {
                    if (coins.coins >= 50) {
                        if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitLight))) {
                            nLight++;
                            GameObject.Instantiate(this.unitLight, this.transform.position, Quaternion.identity);
                        }
                    }
                }
                else if (nMedium <= 2) {
                    if (coins.coins >= 100) {
                        nLight = 0;
                        if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitMedium))) {
                            nMedium++;
                            GameObject.Instantiate(this.unitMedium, this.transform.position, Quaternion.identity);
                        }
                    }
                }
                else {
                    if (coins.coins >= 150) {
                        nMedium = 0;
                        if (coins.ChangeCoins(unitConfig.GetValue((int)CenterConfig.unitType.UnitHeavy))) {
                            GameObject.Instantiate(this.unitHeavy, this.transform.position, Quaternion.identity);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Give cois to the enemy time
        /// </summary>
        protected IEnumerator AutoGiveCoins() {
            while (true) {
                yield return new WaitForSeconds(this.coinsTime);
                this.coins.ChangeCoins(-50);
            }
        }
    }
}