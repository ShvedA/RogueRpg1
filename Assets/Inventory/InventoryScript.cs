using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Assets.Inventory
{
    public class InventoryScript : MonoBehaviour
    {
        [SerializeField]
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

            slotAmount = 20;
            //inventoryPanel = GameObject.Find("Inventory Panel");
            slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
            for (int i = 0; i < slotAmount; i++)
            {
                items.Add(new Item());
                slots.Add(Instantiate(inventorySlot));
                slots[i].GetComponent<Slot>().id = i;
                slots[i].transform.SetParent(slotPanel.transform);
            }
            AddItem(1);
            AddItem(0);
            AddItem(0);
            AddItem(0);
            AddItem(1);
        }

        public void AddItem(int id)
        {
            Item itemToAdd = _dataBase.FetchItemByID(id);
            if (itemToAdd.Stackable && FindItemInInventory(id) != -2)
            {
                ItemData data = slots[FindItemInInventory(id)].transform.GetChild(0).GetComponent<ItemData>();
                data.amount++;
                data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
            }
            else
            {
                int slotNumber = FindItemInInventory(-1);
                if (slotNumber != 2)
                {
                    items[slotNumber] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = slotNumber;
                    itemObj.transform.SetParent(slots[slotNumber].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    //itemObj.transform.position = Vector2.zero;
                    itemObj.name = itemToAdd.Title;
                    if (itemToAdd.Stackable)
                    {
                        ItemData data = slots[slotNumber].transform.GetChild(0).GetComponent<ItemData>();
                        data.amount++;
                        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    }
                }      
            }
        }

        int FindItemInInventory(int id) // -2 if didn't find
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                    return i;
            }
            return -2;
        }

    }
}