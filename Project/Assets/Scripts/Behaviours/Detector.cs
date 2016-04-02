using UnityEngine;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Detect an object to only one cause.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class Detector : MonoBehaviour {
        [Tooltip("Info of Detector")]
        [Multiline]
        public string info;
        [Tooltip("Tags used to detect objects, to only one cause")]
        public string[] detectTag = { "Untagged" };
        //[HideInInspector]
        /// <summary>Reference to the objectDetected.</summary>
        public Collider objectCollider;
        [HideInInspector]
        /// <summary>Reference to the objectDetected Transform.</summary>
        public Transform objectTransform;

        /// <summary>Current objectDetected being targeted.</summary>
        protected Collider objectDetected {
            get { return this.objectCollider; }
            set {
                if (value == null) {
                    if (this.objectCollider == null) return;
                    this.objectCollider = null;
                    this.objectTransform = null;
                }
                else {
                    this.objectCollider = value;
                    this.objectTransform = this.objectCollider.GetComponent<Transform>();
                }
            }
        }
 
        protected void OnTriggerStay(Collider other) {
            //If the current objectDetected is destroyed, checks whether
            //any other colliders staying on the trigger are
            foreach (string tag in this.detectTag) {
                if (this.objectDetected == null && other.CompareTag(tag)) {
                    this.objectDetected = other;
                }
            }
        }

        protected void OnTriggerEnter(Collider other) {
            foreach (string tag in this.detectTag) {
                if (this.objectCollider != null || !other.CompareTag(tag)) {
                    return;
                }
            }
            this.objectDetected = other;
        }

        protected void OnTriggerExit(Collider other) {
            if (this.objectCollider == other) {
                this.objectDetected = null;
            }
        }
    }
}
