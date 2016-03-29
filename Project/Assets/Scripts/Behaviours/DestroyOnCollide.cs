using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Destroys the game object on collision.
    /// 
    /// It's recommended to use layers to prevent unwanted collisions.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class DestroyOnCollide : BaseBehaviour {

        protected void OnTriggerEnter(Collider other) {
            if (this.GetComponent<Power>().tag != other.gameObject.tag && this.gameObject.tag != other.gameObject.tag) {
                Destroy(this.gameObject);
            }
        }

        protected void OnCollisionEnter(Collision collision) {
            if (this.GetComponent<Power>().tag != collision.gameObject.tag && this.gameObject.tag != collision.gameObject.tag) {
                Destroy(this.gameObject);
            }
        }
    }
}