using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace CubeDefense {

    /// <summary>
    /// Projectile factory that handles creation and recycling
    /// </summary>
    public class ProjectileManager : MonoBehaviour
    {
        private IObjectPool<Projectile> projectilePool;
        [SerializeField] private ProjectileCollection collection;

        private void Awake()
        {
            projectilePool = new ObjectPool<Projectile>(OnCreateProjectile, GetProjectile, OnReleaseProjectile, OnDestroyProjectile);       
        }

        public Projectile Instantiate(ProjectileType projectile, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Projectile proj = projectilePool.Get();
            proj.Stats = collection.projectileStats[(int)projectile];
            proj.UpdateMaterial();

            proj.transform.position = position;
            proj.transform.rotation = rotation;
            
            if(parent)
                proj.transform.parent = parent;
            else
                proj.transform.parent = transform;

            return proj;
        }

        private void OnReleaseProjectile(Projectile obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void GetProjectile(Projectile obj)
        {
            obj.gameObject.SetActive(true);
        }

        private Projectile OnCreateProjectile()
        {
            var proj = Instantiate(collection.projPrefab);
            proj.Pool = projectilePool;
            return proj;
        }

        private void OnDestroyProjectile(Projectile obj)
        {
            Destroy(obj.gameObject);
        }
    }
}
