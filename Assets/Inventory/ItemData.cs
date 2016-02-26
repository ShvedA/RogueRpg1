using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

namespace Assets.Inventory
{

    public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        public Item item;
        public int amount;
        public int slot;
        public Transform originalParent;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (item != null)
            {
                originalParent = this.transform.parent;
                this.transform.SetParent(this.transform.parent.parent);
                this.transform.position = eventData.position;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (item != null)
            {
                this.transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(originalParent);
            this.transform.position = originalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}