using UnityEngine;
using System.Collections;

namespace Assets.Inventory
{
    public class DropScript : MonoBehaviour
    {

        [SerializeField]
        private int dropID;
        
        private InventoryScript inventoryObject;

        void Start()
        {
            inventoryObject = GameObject.Find("InventoryObject").GetComponent<InventoryScript>();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                inventoryObject.GetComponent<InventoryScript>().AddItem(dropID);
                Destroy(gameObject);
            }
        }
    }
}
