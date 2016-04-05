using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Provides health to a game object.
    /// </summary>
    public class Health : BaseBehaviour {
        [Tooltip("Slider health.")]
        public Slider healthSlider;
        [Tooltip("Type of unit.")]
        public CenterConfig.unitType type;

        /// <summary>Currently available health.</summary>
        protected float currentHp;
        /// <summary>Available health</summary>
        protected float hp;
        /// <summary>Center of config values..</summary>
        protected CenterConfig config;

        /// <summary>
        /// Name of gameobject coins to enemy, auto get coins for add
        /// </summary>
        public string coinsO;
        /// <summary>
        /// Name of gameobject coins to self, auto get coins for add
        /// </summary>
        public string coinsS;
        /// <summary>
        /// scene load if destroy base
        /// </summary>
        public string scene;

        //[Tooltip("Coins of opponent for add if destroy the unit.")]
        protected Coins coinsOpponent;
        //[Tooltip("Coins of self for add if destroy the unit.")]
        protected Coins coinsSelf;

        protected void Start() {
            this.config = new CenterConfig();
            this.hp = this.config.GetHealt((int)type);
            this.currentHp = this.hp;

            coinsOpponent = GameObject.Find(coinsO).GetComponent<Coins>();
            coinsSelf = GameObject.Find(coinsS).GetComponent<Coins>();

        }

        protected void Update() {
            this.healthSlider.value = (float)this.currentHp / (float)this.hp;
        }

        public void ChangeHealth(float amount) {
            this.currentHp += amount;
            if (this.currentHp >= this.hp) {
                this.currentHp = this.hp;
            }
            if (this.currentHp <= 0) {
                coinsOpponent.ChangeCoins(-this.config.GetValue((int)type));
                coinsSelf.ChangeCoins(-(this.config.GetValue((int)type) / 2));
                if (type != CenterConfig.unitType.Base) {
                    Destroy(this.gameObject);
                }
                else {
					Application.LoadLevel(scene);
					
                    //SceneManager.LoadScene(scene);
                }
            }
        }
    }
}