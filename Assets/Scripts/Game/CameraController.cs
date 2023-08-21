using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Simple Camera controller, attach it to a Camera
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        protected const string HorizontalAxis = "Horizontal";
        protected const string VerticalAxis = "Vertical";
        private const string ScrollAxis = "Mouse ScrollWheel";

        [SerializeField] private float speed = 10;
        [SerializeField] private float zoomSpeed = 50;

        void Update()
        {
            transform.Translate(
                Input.GetAxis(HorizontalAxis) * speed * Time.deltaTime,
                -Input.GetAxis(ScrollAxis) * zoomSpeed * Time.deltaTime,
                Input.GetAxis(VerticalAxis) * speed * Time.deltaTime, Space.World);
        }
    }
}
