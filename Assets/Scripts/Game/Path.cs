using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// A class to store and request waypoints
    /// </summary>
    public class Path : MonoBehaviour
    {
        private Transform[] children;
        public int Count
        {
            get => children.Length;
        }

        public Transform this[int index]
        {
            get => children[index];
        }

        public Transform LastPoint
        {
            get => children.Last();
        }

        public bool IsComplete(int index)
        {
            return index >= children.Length;
        }
        private void Awake()
        {
            children = transform.Cast<Transform>().ToArray();
        }
    }
}
