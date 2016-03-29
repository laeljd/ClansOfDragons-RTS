using UnityEngine;
using UnityEngine.UI;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Provides health to a game object.
    /// </summary>
    public class Health : BaseBehaviour {
        [Tooltip("Slider health.")]
        public Slider healthSlider;
        [Tooltip("Center of config values.")]
        public CenterConfig HPconfig;
        [Tooltip("Type of unit.")]
        public CenterConfig.unitType type;
        /// <summary>Currently available health.</summary>
        protected float currentHp;
        /// <summary>Available health</summary>
        protected float hp;

        protected void Start() {
            if (this.HPconfig == null) {
                this.HPconfig = GameObject.FindGameObjectWithTag("CenterConfig").GetComponent<CenterConfig>();
            }
            this.hp = this.HPconfig.GetHealt((int)type);
            this.currentHp = this.hp;
        }

        protected void Update() {
            this.healthSlider.value = (float)this.currentHp / (float)this.hp;
        }

        public void ChangeHealth(float amount) {
            this.currentHp += amount;
            if (this.currentHp == 0) {
                Destroy(this.gameObject);
            }
        }
    }
}