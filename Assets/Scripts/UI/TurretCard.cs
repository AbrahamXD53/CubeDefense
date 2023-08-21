using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace CubeDefense
{
    /***
     * UI Element Used to show a turret item;
     */
    public class TurretCard : Selectable, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public TurretDescription Description { get; private set; }

        [SerializeField] private Image background;
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI label;

        private Transform prevParent;
        private Vector3 prevPosition;
        private Color dragColor;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!interactable)
            {
                eventData.pointerDrag = null;
                return;
            }

            dragColor = background.color;
            dragColor.a = 0.3f;
            background.color = dragColor;
            prevParent = transform.parent;
            prevPosition = transform.position;
            background.raycastTarget = false;

            AudioManager.Instance.PlaySfx(AudioManager.CIdClick);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragColor.a = 1.0f;
            background.color = dragColor;

            transform.SetParent(prevParent);
            transform.position = prevPosition;
            background.raycastTarget = true;

            AudioManager.Instance.PlaySfx(AudioManager.CIdClick);
        }

        public void SetUp(TurretDescription turretDescription)
        {
            icon.sprite = turretDescription.sprite;
            label.text = turretDescription.price.ToString();

            Description = turretDescription;
        }
    }
}