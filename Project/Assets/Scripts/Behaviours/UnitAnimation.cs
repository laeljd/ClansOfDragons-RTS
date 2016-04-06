using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Play animation if move or idle
    /// </summary>
    public class UnitAnimation : MonoBehaviour {
        [Tooltip("Animation for start when move.")]
        public Animation unitAnim;
        [Tooltip("Detectoror of object to look position.")]
        public Detector detector;
        [Tooltip("Agent to chek if stay moving.")]
        public NavMeshAgent unit;

        protected void Awake() {
            StartCoroutine(PlayAnimation());
        }

        protected IEnumerator PlayAnimation() {
            while (true) {
                if (unit.velocity.sqrMagnitude > 0 && detector.objectCollider == null) {
                    unitAnim.Play("Move");
                }
                else {
                    unitAnim.Play("Idle");
                }
                yield return new WaitForEndOfFrame();
            }
        }

       

    }
}