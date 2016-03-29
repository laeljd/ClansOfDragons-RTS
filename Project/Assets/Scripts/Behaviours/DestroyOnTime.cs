using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Destroys the game object on time.
    /// </summary>
    public class DestroyOnTime : MonoBehaviour {
        [Tooltip("Time for destroy the game object next start")]
        public float time;
        void Start() {
            StartCoroutine(Destroy(this.time));
        }
        protected IEnumerator Destroy(float time) {
            yield return new WaitForSeconds(this.time);
                Destroy(this.gameObject);
        }
    }
}
