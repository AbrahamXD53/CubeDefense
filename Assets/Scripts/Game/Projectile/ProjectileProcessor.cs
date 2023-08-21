using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Static class to gather all AProjectileCollision resolvers
    /// </summary>
    public static class ProjectileProcessor
    {
        private static Dictionary<ProjectileType, AProjectileCollision> collisions;
        static ProjectileProcessor()
        {
            collisions = new Dictionary<ProjectileType, AProjectileCollision>();
            var allCollisions = Assembly.GetAssembly(typeof(AProjectileCollision)).GetTypes().Where(c => typeof(AProjectileCollision).IsAssignableFrom(c) && !c.IsAbstract);

            foreach ( var collision in allCollisions )
            {
                AProjectileCollision colInstance = Activator.CreateInstance(collision) as AProjectileCollision;
                collisions.Add(colInstance.projectileType, colInstance);
            }
        }

        public static void ProcessCollision(Projectile proj, Enemy enemy)
        {
            AProjectileCollision processor = collisions[proj.Stats.projectileType];
            processor.Collided(proj, enemy);
        }

    }
}