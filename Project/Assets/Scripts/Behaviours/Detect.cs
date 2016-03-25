using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
    /// <summary>
    /// Detects an opponent.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class Detect : MonoBehaviour {
        [Tooltip("Tag used to detect enemies.")]
        public string[] opponentTag = { "Enemy" };
        /// <summary>Reference to the opponent being attacked.</summary>
        public Collider opponentCollider;
        /// <summary>Reference to the opponent Transform.</summary>
        public Transform opponentTransform;

        /// <summary>Current opponent being targeted.</summary>
        protected Collider opponent {
            get { return this.opponentCollider; }
            set {
                if (value == null) {
                    if (this.opponentCollider == null) return;
                    this.opponentCollider = null;
                    this.opponentTransform = null;
                }
                else {
                    this.opponentCollider = value;
                    this.opponentTransform = this.opponentCollider.GetComponent<Transform>();
                }
            }
        }

        protected void OnTriggerStay(Collider other) {
            //If the current opponent is destroyed, checks whether
            //any other colliders staying on the trigger are
            //enemies that can be targeted.
            foreach (string tag in this.opponentTag) {
                if (this.opponent == null && other.CompareTag(tag)) {
                    this.opponent = other;
                }
            }
        }

        protected void OnTriggerEnter(Collider other) {
            foreach (string tag in this.opponentTag) {
                if (this.opponentCollider != null || !other.CompareTag(tag)) {
                    return;
                }
            }
            this.opponent = other;
        }

        protected void OnTriggerExit(Collider other) {
            if (this.opponentCollider == other) {
                this.opponent = null;
            }
        }
    }
}
