using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
    /// <summary>
    /// Aim on enemy.
    /// </summary>
    [RequireComponent(typeof(Detect))]
    public class LookAt : BaseBehaviour {
        [Tooltip("Detector of opponent.")]
        public Detect opponentDetector;

        protected override void Awake() {
            base.Awake();
            this.opponentDetector = gameObject.GetComponent<Detect>();
        }

        protected void Update() {
            if (this.opponentDetector.opponentTransform != null) {
                this.transform.LookAt(this.opponentDetector.opponentTransform);
                this.transform.root.LookAt(this.opponentDetector.opponentTransform);
            }
        }

    }
}