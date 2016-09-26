using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

namespace Assets.Inventory {
    public class Slot : MonoBehaviour, IDropHandler {
        public int id;

        private InventoryScript inv;

        private void Start() {
            inv = GameObject.Find("InventoryObject").GetComponent<InventoryScript>();
        }

        public void OnDrop(PointerEventData eventData) {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
            if (inv.items[id].ID == -1 || id == droppedItem.slot) {
                inv.items[droppedItem.slot] = new Item();
                inv.items[id] = droppedItem.item;
                droppedItem.originalParent = this.transform;
                droppedItem.slot = id;
            }
            else {
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().slot = droppedItem.slot;
                item.transform.SetParent(inv.slots[droppedItem.slot].transform);
                item.transform.position = inv.slots[droppedItem.slot].transform.position;
                droppedItem.originalParent = this.transform;
                droppedItem.slot = id;
                inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                inv.items[id] = droppedItem.item;
            }
        }
    }
}