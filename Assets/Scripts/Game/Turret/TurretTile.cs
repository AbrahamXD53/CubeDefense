using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeDefense
{
    /// <summary>
    /// Terrain tile where a turret can be placed
    /// </summary>
    public class TurretTile : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        readonly static Color selectedColor = new Color32(61, 110, 112, 1);

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private new Collider collider;

        private bool isPointerOver;
        private Material material;
        private Color prevColor;

        private void Start()
        {
            //Default tile has its folliage in the second material
            material = meshRenderer.materials[1];
            prevColor = material.color;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!eventData.pointerDrag)
                return;

            isPointerOver = false;
            collider.enabled = false;

            TurretCard card = eventData.pointerDrag.GetComponent<TurretCard>();
            if (!card)
                return;

            GameManager.Instance.CreateTurret(this, card.Description);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!eventData.dragging || !eventData.pointerDrag)
                return;

            isPointerOver = true;
            Blink();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!eventData.dragging || !eventData.pointerDrag)
                return;

            isPointerOver = false;
            material.color = prevColor;
        }

        //Temp Simple animation
        async void Blink()
        {
            while (isPointerOver)
            {
                material.color = selectedColor;
                await Task.Delay(300);
                material.color = prevColor;
                await Task.Delay(300);
            }
        }
    }
}