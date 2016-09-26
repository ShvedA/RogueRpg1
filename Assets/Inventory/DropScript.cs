using UnityEngine;
using System.Collections;

namespace Assets.Inventory {
    public class DropScript : MonoBehaviour {
        [SerializeField] private int dropID;

        private InventoryScript inventoryObject;

        private void Start() {
            inventoryObject = GameObject.Find("InventoryObject").GetComponent<InventoryScript>();
        }

        private void OnCollisionStay2D(Collision2D col) {
            if (col.gameObject.tag == "Player") {
                inventoryObject.GetComponent<InventoryScript>().AddItem(dropID);
                Destroy(gameObject);
            }
        }
    }
}