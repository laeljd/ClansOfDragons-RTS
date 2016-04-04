using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Decrese or increase health to a game object.
    /// </summary>
    public class HealthManager : MonoBehaviour {
        [Tooltip("Health of object.")]
        public Health health;
        [Tooltip("Detector used to check for collisions to decrease health.")]
        public Detector damageDetector;
        [Tooltip("Detector used to check for collisions to increase health.")]
        public Detector restoreDetector;
        [Tooltip("Type of unit.")]
        public CenterConfig.unitType type;
        /// <summary>Rate to rstore health (secondes).</summary>
        protected float restoreRate;
        /// <summary>Coroutine to start and stop restore.</summary>
        protected Coroutine restore;
        /// <summary>Center of config values.</summary>
        protected CenterConfig restoreRateConfig;

        protected void Awake() {
            this.restoreRateConfig = new CenterConfig();
            this.restoreRate = this.restoreRateConfig.GetRestoreRate((int)type);
        }

        protected void Update() {
            if (this.damageDetector != null) {
                if (this.damageDetector.objectCollider != null) {
                    var power = this.damageDetector.objectCollider.gameObject.GetComponent<Power>();
                    if (power != null) {
                        if (power.tag != this.gameObject.tag) {
                            this.health.ChangeHealth(-power.damage);
                            Destroy(this.damageDetector.objectCollider.gameObject);
                        }
                    }
                }
            }
            if (this.restoreDetector != null) {
                if (this.restoreDetector.objectCollider != null) {
                    if (restore == null) {
                        var power = this.restoreDetector.objectCollider.GetComponent<Power>();
                        if (power != null) {
                            this.restore = StartCoroutine(RestoreHealth(power.restore));
                        }
                    }
                }
                else {
                    if (this.restore != null) {
                        StopCoroutine(this.restore);
                        this.restore = null;
                    }
                }
            }
        }

        /// <summary>
        /// Change the current game object health.
        /// </summary>
        protected IEnumerator RestoreHealth(float amount) {
            while (true) {
                this.health.ChangeHealth(amount);
                yield return new WaitForSeconds(this.restoreRate);
            }
        }
    }
}