using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Simple animation scale
    /// </summary>
    public class AnimationScale : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float amplitude;

        void Update()
        {
            transform.localScale = Vector3.one + (amplitude * Mathf.Sin(Time.timeSinceLevelLoad * speed) * Vector3.one);
        }
    }
}
