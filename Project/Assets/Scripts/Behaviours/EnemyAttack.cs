using UnityEngine;
using System.Collections;

namespace FATEC.CubeWars.Behaviours {
    /// <summary>
    /// Attack the base of player
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAttack : BaseBehaviour {
        [Tooltip("Detector of opponent.")]
        public Detect opponentDetector;
        [Tooltip("Position of base to attack.")]
        public Transform basePlayer;
        /// <summary> Unity to move </summary>
        public NavMeshAgent unity;

        protected override void Awake() {
            base.Awake();
            this.opponentDetector = gameObject.GetComponentInChildren<Detect>();
            this.unity = gameObject.GetComponent<NavMeshAgent>();

        }
        protected void Update() {

            if (this.opponentDetector.opponentCollider == null) {
                this.unity.SetDestination(this.basePlayer.position);
            }
            else {
                this.unity.ResetPath();

            }
        }

    }
}