using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeDefense {

    /// <summary>
    /// Turrets can be selected with UnityEvent system, when a turret is selected it gets animated and its range can be shown
    /// </summary>
    public class TurretSelection : MonoBehaviour, IPointerClickHandler, IDeselectHandler, ISelectHandler
    {
        [SerializeField] private Turret turret;
        private bool isSelected;
        private Vector3 orgScale;

        private void Start()
        {
            orgScale = turret.turretAxis.localScale;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        public void OnSelect(BaseEventData eventData)
        {
            isSelected = true;
            turret.rangeObject.SetActive(true);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            isSelected = false;
            turret.rangeObject.SetActive(false);
            turret.turretAxis.localScale = orgScale;
        }
        void SimpleAnimation()
        {
            if (!isSelected)
                return;
            turret.turretAxis.localScale = orgScale + 0.1f * Mathf.Sin(Time.timeSinceLevelLoad * 4f) * Vector3.one;
        }

        void Update()
        {
            SimpleAnimation();
        }
    }
}
