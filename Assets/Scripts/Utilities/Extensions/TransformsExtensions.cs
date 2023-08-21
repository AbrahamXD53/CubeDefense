using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Custom transform extensions
    /// </summary>
    public static class TransformsExtensions
    {
        /// <summary>
        /// Extension method to rotate a transform only in y axis to match a target, with lerp
        /// </summary>
        /// <param name="transform">Target transform</param>
        /// <param name="dir">Where to look at</param>
        /// <param name="factor">Lerp factor defaults to 1.0f</param>
        public static void LookAtY(this Transform transform, Vector3 dir, float factor = 1.0f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, factor).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }
}
