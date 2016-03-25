using UnityEngine;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Moves a NavMeshAgent when tapping on the scenario.
	/// </summary>
	public class MouseAction : BaseBehaviour {
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

        /// <summary> Unity selected to move </summary>
        public NavMeshAgent unity;

		protected void Update() {
			if (Input.GetMouseButtonDown(0)) {
				var ray = this.camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, this.distance)) {
					if (hit.collider.CompareTag(this.groundTag)) {
                        if (this.unity != null) { 
                            this.unity.SetDestination(hit.point);
                        }
                    }
                    if (hit.collider.CompareTag(this.unityTag)) {
                        this.unity = hit.collider.GetComponent<NavMeshAgent>();
                    }
                    //if (hit.collider.CompareTag(this.enemyTag)) {
                    //
                    //if (hit.collider.CompareTag(this.baseTag)) {
                    //
                }
			}
		}
	}
}