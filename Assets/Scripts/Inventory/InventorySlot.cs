using System;
using UnityEngine;

namespace SimTask.Inventory
{
    public class InventorySlot
    {
        //This is a construct for representing an Item in slot as well as amount of items.
        //The same thing can be achieved by creating a Dictionary<ItemObject, int> with int representing amount,
        //but I found this way to be more intuitive and flexible.

        public ItemObject Item { get; private set; }
        public int Amount { get; private set; }

        public InventorySlot(ItemObject item, int amount)
        {
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount));
            Item = item;
            Amount = amount;
        }

        public void AddAmount(int amount)
        {
            if (amount < 1)
            {
                Debug.Log("Trying to add 0 or negative amount to inventory slot");
                return;
            }

            Amount += amount;
        }

        public void RemoveAmount(int amount)
        {
            if (amount < 1)
            {
                Debug.Log("Trying to remove 0 or negative amount from inventory slot.");
                return;
            }

            Amount -= amount;
        }
    }
}