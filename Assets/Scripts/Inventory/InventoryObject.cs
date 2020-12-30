using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimTask.Inventory
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Systems/Inventory", order = 0)]
    public class InventoryObject : ScriptableObject
    {
        public Action InventoryChanged;
        
        public List<InventorySlot> Items { get; private set; } = new List<InventorySlot>();

        public void AddItem(ItemObject item, int amount = 1)
        {
            if (Contains(item, out var foundSlot))
            {
                foundSlot.AddAmount(amount);
                InventoryChanged?.Invoke();
                return;
            }
            Items.Add(new InventorySlot(item, amount));
            InventoryChanged?.Invoke();
        }

        public void RemoveItem(ItemObject item, int amount = 1)
        {
            if (!Contains(item, out var foundSlot))
                throw new Exception($"Doesn't contain {item.name}.");
            
            if (foundSlot.Amount < amount)
                throw new Exception($"Doesn't contain {item.name} in sufficient quantity.");
            
            foundSlot.RemoveAmount(amount);
            if (foundSlot.Amount == 0)
                Items.Remove(foundSlot);
            
            InventoryChanged?.Invoke();
        }
        
        /// <summary>
        /// Checks if any of inventory slots contain and item and returns this slot as out parameter.
        /// </summary>
        private bool Contains(ItemObject item, out InventorySlot foundSlot)
        {
            foreach (var slot in Items.Where(slot => slot.Item == item))
            {
                foundSlot = slot;
                return true;
            }

            foundSlot = null;
            return false;
        }
    }
}