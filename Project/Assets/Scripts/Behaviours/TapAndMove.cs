using UnityEngine;

namespace FATEC.CubeWars.Behaviours {
	/// <summary>
	/// Moves a NavMeshAgent when tapping on the scenario.
	/// </summary>
	public class TapAndMove : BaseBehaviour {
		[Tooltip("Agent to be moved.")]
		public NavMeshAgent agent;
		[Tooltip("Ground tag.")]
		public string groundTag = "Ground";
		[Tooltip("Raycast distance.")]
		public float distance = 1000.0f;
		[Tooltip("Reference to the camera.")]
		public new Camera camera;

		protected void Update() {
			if (Input.GetMouseButtonDown(0)) {
				var ray = this.camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, this.distance)) {
					if (hit.collider.CompareTag(this.groundTag)) {
						this.agent.SetDestination(hit.point);
					}
				}
			}
		}
	}
}