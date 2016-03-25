using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
    /// <summary>
    /// Shoot on enemy.
    /// </summary>
    [RequireComponent(typeof(Detect))]
    public class Shoot : BaseBehaviour {
        public GameObject projectilePrefab;
        [Tooltip("Fire rate delay (seconds).")]
        public float delay = 1.0f;
        [Tooltip("Fire local position.")]
        public Vector3 firePosition;
        [Tooltip("Detector of opponent.")]
        public Detect opponentDetector;
        /// <summary>Reference to the weapon coroutine.</summary>
        protected Coroutine weapon;

        protected override void Awake() {
            base.Awake();
            this.opponentDetector = gameObject.GetComponent<Detect>();
        }

        protected void Update() {
            if (this.opponentDetector.opponentCollider == null) {
                if (this.weapon != null) {
                    this.StopCoroutine(this.weapon);
                    this.weapon = null;
                }
            }
            else {
                if (this.weapon == null) {
                    this.weapon = this.StartCoroutine(this.Fire());
                }
            }
        }


        /// <summary>
        /// Fires projectiles in given fire rate delay.
        /// </summary>
        protected IEnumerator Fire() {
            while (true) {
                if (this.opponentDetector.opponentTransform == null) {
                    break;
                }

                var projectile = Instantiate(this.projectilePrefab);
                projectile.GetComponent<Transform>().position =
                    this.transform.TransformPoint(this.firePosition);
                projectile.GetComponent<MoveProjectile>().targetPosition =
                    this.opponentDetector.opponentTransform.position;

                yield return new WaitForSeconds(this.delay);
            }
        }
    }
}
