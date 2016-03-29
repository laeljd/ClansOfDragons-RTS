using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    public class MoveCamera : BaseBehaviour {
        [Tooltip("Camera Speed")]
        public float speed = 15;

        protected void Update() {
            var axisX = Input.GetAxis("Horizontal") * this.speed * Time.deltaTime;
            var axisZ = Input.GetAxis("Vertical") * this.speed * Time.deltaTime;

            if (axisX != 0) {
                this.transform.Translate(axisX, 0, axisX, Space.World);
            }
            if (axisZ != 0) {
                this.transform.Translate(-axisZ, 0, axisZ, Space.World);
            }
        }
    }
}
