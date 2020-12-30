using SimTask.Core;
using SimTask.Inventory;
using SimTask.Player;
using SimTask.UI;
using UnityEngine;

namespace SimTask.Shop
{
    public class ShopTradeHandler : MonoBehaviour
    {
        [SerializeField] private InventoryObject playerInventory;
        [SerializeField] private InventoryObject shopInventory;
        private Wallet _wallet;

        private void Awake()
        {
            _wallet = Wallet.Instance;
            InventorySlotUI.OnLeftClick += CheckLeftClickAction;
        }

        private void BuyFromShop(ItemObject item, int amount = 1)
        {
            var cost = item.GetCost() * amount;
            if (!_wallet.CanAfford(cost)) 
                return;
            
            _wallet.TryWithdraw(cost);
            playerInventory.AddItem(item, amount);
            shopInventory.RemoveItem(item, amount);
        }

        private void SellToShop(ItemObject item, int amount = 1)
        {
            var cost = item.GetCost() * amount;
            _wallet.Add(cost);
            playerInventory.RemoveItem(item, amount);
            shopInventory.AddItem(item, amount);
        }

        private void CheckLeftClickAction(ItemObject item, InventoryObject inventory)
        {
            if (PlayerState.CurrentState != PlayerState.State.Trading)
                return;

            if (inventory == shopInventory)
                BuyFromShop(item);
            else if (inventory == playerInventory)
                SellToShop(item);
        }
        
    }
}