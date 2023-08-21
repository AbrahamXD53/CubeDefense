using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Healthbar, object requires special Shader UI/HealthBar
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        private const string ShaderFillField = "_Fill";
        private MeshRenderer meshRenderer;
        private Transform cameraTrans;
        private MaterialPropertyBlock matBlock;

        private void Awake()
        {
            cameraTrans = Camera.main.transform;
            meshRenderer = GetComponent<MeshRenderer>();
            matBlock = new MaterialPropertyBlock();

            meshRenderer.GetPropertyBlock(matBlock);
        }

        public void UpdateFill(float fill)
        {
            matBlock.SetFloat(ShaderFillField, 1-Mathf.Clamp01(fill));
            meshRenderer.SetPropertyBlock(matBlock);
        }

        public void AlignCamera()
        {
            if (!cameraTrans)
                return;

            var forward = transform.position - cameraTrans.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, cameraTrans.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}
