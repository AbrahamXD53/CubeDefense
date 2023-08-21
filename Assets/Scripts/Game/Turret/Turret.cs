using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Turret MonoBehaviour that request projectile creation to ProjectileManager 
    /// </summary>
    public class Turret : MonoBehaviour
    {
        protected const float ScanRate = 0.15f;
        protected const float RotationSpeed = 20;

        public Transform turretAxis;
        public GameObject rangeObject;

        public float Range
        {
            get => description.levels[level].range;
        }

        private TurretTile tile;
        private Transform target;
        private int level;

        private TurretDescription description;

        private ProjectileManager projectileManager;
        private float elapsedScanner;
        private float elapsedFireRate;
        private Collider[] colliders;

        #region UnityCallbacks

        void FixedUpdate()
        {
            Aim();
        }
        void Update()
        {
            SearchNewTarget();
            Fire();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
        #endregion

        public void SetUp(TurretTile tTile, TurretDescription description, ProjectileManager manager)
        {
            projectileManager = manager;
            this.description = description;

            tile = tTile;
            level = 0;

            rangeObject.transform.localScale = 2f * Range * Vector3.one;
        }

        protected virtual void Fire()
        {
            if (!target)
                return;

            elapsedFireRate -= Time.deltaTime;

            if (elapsedFireRate > 0)
                return;

            elapsedFireRate = description.levels[level].fireRate;

            Projectile pro = projectileManager.Instantiate(description.projectileType, transform.position, transform.rotation);
            pro.SetTarget(target);
        }

        protected void SearchNewTarget()
        {
            if (target)
                return;

            elapsedScanner += Time.deltaTime;

            if (elapsedScanner < ScanRate)
                return;

            elapsedScanner = 0;

            colliders = Physics.OverlapSphere(transform.position, Range, description.layerMask);
            foreach (var col in colliders)
            {
                if(Vector3.Distance(transform.position, col.transform.position) < Range)
                {
                    target = col.transform;
                    return;
                }
            }
        }

        protected void Aim()
        {
            if (!target)
                return;

            Vector3 dir = target.position - transform.position;
            turretAxis.LookAtY(dir, Time.deltaTime * RotationSpeed);

            if (dir.magnitude > Range)
            {
                target = null;
                elapsedScanner = ScanRate;
            }
        }


    }
}
