using CubeDefense;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;

namespace CubeDefense
{
    /// <summary>
    /// MonoBehaviour implementation of INavigator
    /// </summary>
    public class EnemyMover : MonoBehaviour, INavigator
    {
        protected const float StopingDistance = 0.4f;

        #region Navigation
        public Path NavigationPath { get; set; }
        public int PathIndex { get; set; }
        public float Speed { get; set; }
        public Transform Target { get; set; }
        #endregion

        private float maxSpeed;
        public UnityAction OnPathUpdated;
        public UnityAction OnPathCompleted;

        public void Navigate()
        {
            if (!Target)
                return;

            transform.Translate(Speed * Time.deltaTime * (Target.position - transform.position).normalized, Space.World);
            Vector3 rotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rotation.x, rotation.y, Mathf.Cos(Time.timeSinceLevelLoad * Speed * 5f) * 10);

            if (Vector3.Distance(transform.position, Target.position) <= StopingDistance)
            {
                PathIndex++;
                if (NavigationPath.IsComplete(PathIndex))
                {
                    Target = null;
                    NavigationCompleted();
                    return;
                }

                Target = NavigationPath[PathIndex];
                NavigationUpdated();
            }
        }

        private void Update()
        {
            Navigate();
        }

        public virtual void SetNavigationStrategy(Path mainPath)
        {
            NavigationPath = mainPath;
            PathIndex = 0;
            Target = NavigationPath[PathIndex];
        }

        private void NavigationCompleted()
        {
            OnPathCompleted?.Invoke();
        }

        private void NavigationUpdated()
        {
            transform.LookAtY(Target.position - transform.position);
            OnPathUpdated?.Invoke();
        }

        public void SlowIt(float factor)
        {
            Speed = Speed * factor;
        }

        public void SetUp(float baseSpeed)
        {
            maxSpeed = baseSpeed;
            Speed = maxSpeed;
        }
    }
}