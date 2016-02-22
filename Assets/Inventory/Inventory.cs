using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Assets.Inventory
{
    public class Inventory : MonoBehaviour
    {
        GameObject inventoryPanel;
        GameObject slotPanel;
        private ItemDataBase _dataBase;
        [SerializeField]
        GameObject inventorySlot;
        [SerializeField]
        GameObject inventoryItem;

        private int slotAmount;
        public List<Item> items = new List<Item>();
        public List<GameObject> slots = new List<GameObject>();

        void Start()
        {
            _dataBase = GetComponent<ItemDataBase>();

            slotAmount = 12;
            inventoryPanel = GameObject.Find("Inventory Panel");
            slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
            for (int i = 0; i < slotAmount; i++)
            {
                items.Add(new Item());
                slots.Add(Instantiate(inventorySlot));
                slots[i].transform.SetParent(slotPanel.transform);
            }
            AddItem(1);
            AddItem(0);
        }

        public void AddItem(int id)
        {
            Item itemToAdd = _dataBase.FetchItemByID(id);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    //itemObj.transform.position = Vector2.zero;
                    itemObj.name = itemToAdd.Title;
                    break;
                }
            }
        }
    }
}