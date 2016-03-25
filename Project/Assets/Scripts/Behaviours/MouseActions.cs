using UnityEngine;

namespace FATEC.CubeWars.Behaviours {
    /// <summary>
    /// Moves a NavMeshAgent when tapping on the scenario.
    /// </summary>
    public class MouseActions : BaseBehaviour {
        [Tooltip("Ground tag.")]
        public string groundTag = "Ground";
        [Tooltip("Unity tag.")]
        public string unityTag = "Unity";
        [Tooltip("Enemy tag.")]
        public string enemyTag = "Enemy";
        [Tooltip("Base tag.")]
        public string baseTag = "Base";
        [Tooltip("Raycast distance.")]
        public float distance = 1000.0f;
        [Tooltip("Reference to the camera.")]
        public new Camera camera;
        [Tooltip("Base menu to enable/disabe")]
        public GameObject BaseMenu;
        /// <summary> Unity selected to move </summary>
        protected NavMeshAgent unity;

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
                            if (this.unity != null) {
                                this.unity.SetDestination(hit.point);
                            }
                        }
                    }
                    if (hit.collider.CompareTag(this.unityTag)) {
                        if (!BaseMenu.activeSelf) {
                            this.unity = hit.collider.GetComponent<NavMeshAgent>();
                        }
                    }
                    //if (hit.collider.CompareTag(this.enemyTag)) {
                    //}
                    if (hit.collider.CompareTag(this.baseTag)) {
                        Debug.Log("base");
                        if (BaseMenu.activeSelf) {
                            BaseMenu.SetActive(false);
                        }
                        else {
                            BaseMenu.SetActive(true);
                        }
                        Debug.Log(BaseMenu.activeSelf);
                    }
                }
            }
        }
    }
}