using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
	/// <summary>
	/// Moves the current game object to a given target position.
	/// </summary>
	public class MoveProjectile : BaseBehaviour {
		[Tooltip("Postion to move to.")]
		public Vector3 targetPosition;
		[Tooltip("Movement speed.")]
		public float speed = 2.0f;

		/// <summary>Direction of the movement.</summary>
		protected Vector3 direction;

		protected void Update() {
			if (this.direction == Vector3.zero) {
				this.direction = 
					(this.targetPosition - this.transform.position).normalized;
			}

			this.transform.Translate(
				this.direction * this.speed * Time.deltaTime, Space.World);
		}
	}
}