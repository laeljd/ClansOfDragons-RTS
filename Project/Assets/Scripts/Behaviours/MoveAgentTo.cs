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
        [Tooltip("Type of unit.")]
        public CenterConfig.unitType type;
        /// <summary>Unit to move self</summary>
        protected NavMeshAgent unit;
        /// <summary>Speed of moviment</summary>
        protected float speed;
        /// <summary>Center of config values.</summary>
        public CenterConfig speedConfig;
        /// <summary>
        /// name of opponent base to auto get to attack
        /// </summary>
        public string nameBase;

        protected override void Awake() {
            base.Awake();
            if(this.detector == null) {
                this.detector = gameObject.GetComponent<Detector>();
            }
            if (this.targetPosition == null) {
                this.targetPosition = this.transform;
            }
            this.unit = gameObject.GetComponent<NavMeshAgent>();
            this.speedConfig = new CenterConfig();
            this.speed = this.speedConfig.GetSpeed((int)type);
            this.unit.speed = this.speed;

            targetPosition = GameObject.Find(nameBase).transform;
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