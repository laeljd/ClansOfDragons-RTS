using UnityEngine;
using UnityEngine.UI;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Provides health to a game object.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	public class Health : BaseBehaviour {
		[Tooltip("Available health.")]
		public int hp = 5;
		[Tooltip("Slider health.")]
		public Slider healthSlider;
		[Tooltip("Tag used to check for collisions.")]
		public string collisionTag = "Projectile";

		/// <summary>Currently available health.</summary>
		protected int currentHp;

		protected void Start() {
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
				Destroy(this.gameObject);
			}
		}
	}
}