using System.Collections.Generic;
using SimTask.Inventory;
using UnityEngine;

namespace SimTask.Shop
{
    public class ShopSetStartingInventory : MonoBehaviour
    {
        // this class adds starting merchandise to the shop 
        
        [SerializeField] private List<ItemObject> items = new List<ItemObject>();
        [SerializeField] private int itemsAmount = 1;
        [SerializeField] private InventoryObject inventory;
        
        private void Start()
        {
            foreach (var item in items)
            {
                inventory.AddItem(item, itemsAmount);
            }
        }
    }
}