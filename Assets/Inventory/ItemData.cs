using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

namespace Assets.Inventory {
    public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
        public Item item;
        [HideInInspector] public int amount;
        [HideInInspector] public int slot;
        [HideInInspector] public Transform originalParent;
        private InventoryScript inv;

        private TooltipScript tooltip;

        private void Start() {
            inv = GameObject.Find("InventoryObject").GetComponent<InventoryScript>();
            tooltip = inv.GetComponent<TooltipScript>();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (item != null) {
                originalParent = this.transform.parent;
                this.transform.SetParent(this.transform.parent.parent);
                this.transform.position = eventData.position;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (item != null) {
                this.transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            this.transform.SetParent(originalParent);
            this.transform.position = originalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            tooltip.Activate(item);
        }

        public void OnPointerExit(PointerEventData eventData) {
            tooltip.Deactivate();
        }
    }
}