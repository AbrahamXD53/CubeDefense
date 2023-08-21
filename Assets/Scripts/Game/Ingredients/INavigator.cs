using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Interface to be implemented when traveling a <see cref="Path"/>
    /// </summary>
    public interface INavigator
    {
        public Transform Target { get; set; }
        public float Speed { get; set; }
        public Path NavigationPath { get; set; }
        public int PathIndex { get; set; }

        public void SetNavigationStrategy(Path mainPath);

        public void Navigate();
        
    }
}
