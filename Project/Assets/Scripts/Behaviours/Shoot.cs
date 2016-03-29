using UnityEngine;
using System.Collections;

namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Shoot on enemy.
    /// </summary>
    public class Shoot : BaseBehaviour {
        [Tooltip("Object to instantiate.")]
        public GameObject projectilePrefab;
        [Tooltip("Detectoror of object to attack.")]
        public Detector detector;
        [Tooltip("Tag to identify origin of power.")]
        public string tagProjectile;
        [Tooltip("Center of config values.")]
        public CenterConfig fireRateConfig;
        [Tooltip("Type of unit.")]
        public CenterConfig.unitType type;
        /// <summary>Fire local position.</summary>
        protected Vector3 firePosition;
        /// <summary>Reference to the weapon coroutine.</summary>
        protected Coroutine weapon;
        /// <summary>Fire rate delay (seconds).</summary>
        protected float fireRate;
        /// <summary>Power of projectile.</summary>
        protected float power;

        protected override void Awake() {
            base.Awake();
            if (this.detector == null) {
                this.detector = gameObject.GetComponent<Detector>();
            }
            if (this.fireRateConfig == null) {
                this.fireRateConfig = GameObject.FindGameObjectWithTag("CenterConfig").GetComponent<CenterConfig>();
            }
            this.fireRate = this.fireRateConfig.GetFireRate((int)type);
            this.power = this.fireRateConfig.GetPower((int)type);
        }

        protected void Update() {
            if (this.detector.objectCollider == null) {
                if (this.weapon != null) {
                    this.StopCoroutine(this.weapon);
                    this.weapon = null;
                }
            }
            else {
                if (this.weapon == null) {
                    this.weapon = this.StartCoroutine(this.Fire());
                }
            }
        }


        /// <summary>
        /// Fires projectiles in given fire rate delay.
        /// </summary>
        protected IEnumerator Fire() {
            while (true) {
                if (this.detector.objectTransform == null) {
                    break;
                }

                var projectile = Instantiate(this.projectilePrefab);
                projectile.GetComponent<Transform>().position = this.transform.TransformPoint(this.firePosition);
                projectile.GetComponent<MoveProjectile>().targetPosition = this.detector.objectTransform.position;
                var power = projectile.GetComponent<Power>();
                power.tag = this.tagProjectile;
                power.damage = this.power;
                yield return new WaitForSeconds(this.fireRate);
            }
        }
    }
}
