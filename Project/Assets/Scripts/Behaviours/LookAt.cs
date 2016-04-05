using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Aim on enemy.
    /// </summary>
    public class LookAt : BaseBehaviour {
        [Tooltip("Detectoror of object.")]
        public Detector detector;

        protected override void Awake() {
            base.Awake();
        }

        protected void Update() {
            if (this.detector.objectTransform != null) {
                this.transform.LookAt(this.detector.objectTransform);
                //this.transform.root.LookAt(this.detector.objectTransform);
            }
        }

    }
}