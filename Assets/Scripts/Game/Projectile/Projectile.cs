using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Projectile Mono, with pool, remember, Don't call Destroy on this object
    /// </summary>
    public class Projectile : APoolObject<Projectile>
    {
        [SerializeField] MeshRenderer meshRenderer;
        private Transform target;
        private Enemy enemy;

        public ProjectileStats Stats { get; set; }

        public void SetTarget(Transform t)
        {
            target = t;
            enemy = target.GetComponent<Enemy>();
        }

        public void UpdateMaterial()
        {
            meshRenderer.material = Stats.material;
        }

        private void Update()
        {
            if(!target)
            {
                Release();
                return;
            }

            Vector3 dir = target.position - transform.position;
            float distance = Stats.speed * Time.deltaTime;

            if (dir.magnitude <= distance)
            {
                if(enemy)
                    ProjectileProcessor.ProcessCollision(this, enemy);

                target = null;
                return;
            }

            transform.Translate(dir.normalized * distance, Space.World);
            //transform.LookAt(target);
        }
    }
}
