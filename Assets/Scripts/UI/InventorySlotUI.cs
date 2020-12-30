using SimTask.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimTask.UI
{
    public class InventorySlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
    {
        public delegate void PointerInteract(ItemObject clickedItem, InventoryObject inventory);
        public static event PointerInteract OnLeftClick;
        public static event PointerInteract OnMouseOver;
        public static event PointerInteract OnRightClick;
        
        [SerializeField] private Image icon;
        [SerializeField] private Text amount;
        [SerializeField] private Sprite blank;
        private ItemObject _containedItem;
        private InventoryObject _inventory;

        public void SetOwner(InventoryObject inventory)
        {
            _inventory = inventory;
        }
        
        public void SetVisual(InventorySlot itemSlot)
        {
            icon.sprite = itemSlot.Item.GetIcon();
            amount.text = itemSlot.Amount.ToString();
            _containedItem = itemSlot.Item;
        }

        public void Clear()
        {
            icon.sprite = blank;
            amount.text = "";
            _containedItem = null;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_containedItem)
                return;

            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    OnLeftClick?.Invoke(_containedItem, _inventory);
                    break;
                case PointerEventData.InputButton.Right:
                    OnRightClick?.Invoke(_containedItem, _inventory);
                    break;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_containedItem)
                return;
            
            OnMouseOver?.Invoke(_containedItem, _inventory);
        }
    }
}