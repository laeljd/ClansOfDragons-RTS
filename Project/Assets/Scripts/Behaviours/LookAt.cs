using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
    /// <summary>
    /// Aim on enemy.
    /// </summary>
    [RequireComponent(typeof(Detect))]
    public class LookAt : MonoBehaviour {
        [Tooltip("Detector of opponent.")]
        public Detect opponenttDetector;

        protected void Awake() {
            this.opponenttDetector = gameObject.GetComponent<Detect>();
        }

        protected void Update() {
            if (this.opponenttDetector.opponentTransform != null) {
                this.transform.LookAt(this.opponenttDetector.opponentTransform);
                this.transform.root.LookAt(this.opponenttDetector.opponentTransform);
            }
        }

    }
}