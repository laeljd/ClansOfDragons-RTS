using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Attack the position informed and stop if metting an opponent unit
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveAgentTo : BaseBehaviour {
        [Tooltip("Detector object stop moving.")]
        public Detector detector;
        [Tooltip("Position of target to move.")]
        public Transform targetPosition;
        [Tooltip("Center of config values.")]
        public CenterConfig speedConfig;
        [Tooltip("Type of unit.")]
        public CenterConfig.unitType type;
        /// <summary>Unit to move self</summary>
        protected NavMeshAgent unit;
        /// <summary>Speed of moviment</summary>
        protected float speed;

        protected override void Awake() {
            base.Awake();
            if(this.detector == null) {
                this.detector = gameObject.GetComponent<Detector>();
            }
            if (this.targetPosition == null) {
                this.targetPosition = this.transform;
            }
            this.unit = gameObject.GetComponent<NavMeshAgent>();
            if (this.speedConfig == null) {
                this.speedConfig = GameObject.FindGameObjectWithTag("CenterConfig").GetComponent<CenterConfig>();
            }
            this.speed = this.speedConfig.GetSpeed((int)type);
            this.unit.speed = this.speed;
        }

        protected void Update() {
            if (this.detector.objectCollider == null) {
                this.unit.SetDestination(this.targetPosition.position);
            }
            else {
                this.unit.ResetPath();
            }
        }
    }
}