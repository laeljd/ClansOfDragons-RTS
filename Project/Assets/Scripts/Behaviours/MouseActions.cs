using UnityEngine;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Moves a NavMeshAgent when tapping on the scenario.
    /// </summary>
    public class MouseActions : BaseBehaviour {
        [Tooltip("Ground tag.")]
        public string groundTag = "Ground";
        [Tooltip("Unit tag.")]
        public string unitTag = "Unit";
        [Tooltip("Enemy tag.")]
        public string enemyTag = "Enemy";
        [Tooltip("Base player tag.")]
        public string baseTag = "BasePlayer";
        [Tooltip("Raycast distance.")]
        public float distance = 1000.0f;
        [Tooltip("Reference to the camera.")]
        public new Camera camera;
        [Tooltip("Base menu to enable/disabe")]
        public GameObject BaseMenu;
        /// <summary> Unit selected to move </summary>
        protected NavMeshAgent unit;

        protected void Update() {
            var ray1 = this.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit1;


            if (Physics.Raycast(ray1, out hit1, this.distance)) {
                Debug.DrawLine(this.camera.ScreenPointToRay(Input.mousePosition).origin, hit1.point, Color.cyan);
            }

            if (Input.GetMouseButtonDown(0)) {
                var ray = this.camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, this.distance)) {
                    if (hit.collider.CompareTag(this.groundTag)) {
                        if (!BaseMenu.activeSelf) {
                            if (this.unit != null) {
                                this.unit.SetDestination(hit.point);
                            }
                        }
                    }
                    if (hit.collider.CompareTag(this.unitTag)) {
                        if (!BaseMenu.activeSelf) {
                            this.unit = hit.collider.GetComponent<NavMeshAgent>();
                        }
                    }
                    //if (hit.collider.CompareTag(this.enemyTag)) {
                    //}
                    if (hit.collider.CompareTag(this.baseTag)) {
                        if (BaseMenu.activeSelf) {
                            BaseMenu.SetActive(false);
                        }
                        else {
                            BaseMenu.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}