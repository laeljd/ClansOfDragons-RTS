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
        [Tooltip("Prefab mark of the selected")]
        public GameObject mark;

        /// <summary>Current mark</summary>
        protected GameObject currentMark;
        /// <summary> Unit selected to move </summary>
        protected NavMeshAgent unit;

        protected void Update() {

            if (Input.GetMouseButtonDown(0)) {
                var ray = this.camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, this.distance)) {
                    if (hit.collider.CompareTag(this.unitTag)) {
                        if (!BaseMenu.activeSelf) {
                            this.unit = hit.collider.GetComponent<NavMeshAgent>();
                        }
                    }
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
            if (Input.GetMouseButtonDown(1)) {
                var ray = this.camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;
                if (Physics.Raycast(ray, out hit2, this.distance)){
                    if (hit2.collider.CompareTag(this.groundTag)) {
                        if (!BaseMenu.activeSelf) {
                            if (this.unit != null) {
                                this.unit.SetDestination(hit2.point);
                            }
                        }
                    }
                }
            }

            if (this.unit != null) {
                if (this.currentMark == null) {
                    this.currentMark = Instantiate(mark);
                }
                else {
                    this.currentMark.transform.SetParent(this.unit.gameObject.transform);
                    this.currentMark.transform.localPosition = new Vector3(0, -this.unit.baseOffset, 0);
                    this.currentMark.transform.localScale = new Vector3(this.unit.radius, this.unit.radius, this.unit.height / 2);
                }
            }
        }
    }
}