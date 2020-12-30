using System;
using SimTask.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace SimTask.UI
{
    public class ItemDescriptor : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Text description;
        [SerializeField] private Text itemName;
        [SerializeField] private Text price;

        private void Start()
        {
            InventorySlotUI.OnMouseOver += SetDescription;
        }

        private void SetDescription(ItemObject item, InventoryObject inventory)
        {
            icon.sprite = item.GetIcon();
            itemName.text = item.GetName();
            description.text = item.GetDescription();
            price.text = item.GetCost().ToString("N0");
        }
    }
}