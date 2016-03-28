using UnityEngine;
using UnityEngine.UI;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Provides health to a game object.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	public class Health : BaseBehaviour {
        
        public enum UnityType {
            UnityLight, UnityMedium, UnityHeavy, Base
        }

        [Tooltip("Config values.")]
        public UnityConfig config;
        [Tooltip("Type of unity.")]
        /// <summary>Type of unity</summary>
        public UnityType type;

        /// <summary>Available health</summary>
        protected float hp;
		[Tooltip("Slider health.")]
		public Slider healthSlider;
		[Tooltip("Tag used to check for collisions.")]
		public string collisionTag = "Projectile";

		/// <summary>Currently available health.</summary>
		protected float currentHp;

		protected void Start() {
            this. hp = config.GetHealt((int)type);
            this.currentHp = this.hp;
		}

		protected void OnTriggerEnter(Collider other) {
			if (other.CompareTag(this.collisionTag)) {
				this.ReceiveDamage();
			}
		}

		protected void OnCollisionEnter(Collision collision) {
			if (collision.collider.CompareTag(this.collisionTag)) {
				this.ReceiveDamage();
			}
		}

		protected void Update() {
			this.healthSlider.value = 
				(float)this.currentHp / (float)this.hp;
		}

		/// <summary>
		/// Makes the current game object receives damage.
		/// </summary>
		protected void ReceiveDamage() {
			this.currentHp -= 1;

			if (this.currentHp == 0) {
                if (this.CompareTag("Base")){
                    gameObject.SetActive(false);
                }
                else {
                    Destroy(this.gameObject);
                }
			}
		}
	}
}