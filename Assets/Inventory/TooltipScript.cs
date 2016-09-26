using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Inventory
{
    public class TooltipScript : MonoBehaviour
    {

        private Item item;
        private string data;
        [SerializeField]
        private GameObject tooltip;


        void Update()
        {
            if (tooltip.activeSelf)
            {
                tooltip.transform.position = Input.mousePosition;
            }
        }

        public void Activate(Item item)
        {
            this.item = item;
            ConstructDataString();
            tooltip.SetActive(true);
        }

        public void Deactivate()
        {
            tooltip.SetActive(false);
        }

        public void ConstructDataString()
        {
            data = "<b>" + item.Title + "</b>\n\n" + item.Description;
            tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
        }

    }
}

