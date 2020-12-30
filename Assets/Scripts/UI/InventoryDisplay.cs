using System.Collections.Generic;
using SimTask.Inventory;
using UnityEngine;

namespace SimTask.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        [Header("Grid")]
        [Range(1, 10)]
        [SerializeField] private int rows = 3;
        [Range(2, 5)] 
        [SerializeField] private int columns = 2;
        [SerializeField] private int baseOffset = 24;
        [SerializeField] private int slotOffset = 86;
        
        [Header("Prefab connections")]
        [SerializeField] private Transform inventoryBackground;
        [SerializeField] private InventorySlotUI slot;
        [SerializeField] private InventoryObject inventory;

        private List<InventorySlotUI> _slots = new List<InventorySlotUI>();
        
        private void Awake()
        {
            CreateSlots(inventory);
            inventory.InventoryChanged += UpdateSlots;
        }

        /// <summary>
        /// Useful then changing shops, for example.
        /// </summary>
        public void SetOwner(InventoryObject newOwner)
        {
            foreach (var slotUI in _slots)
            {
                slotUI.SetOwner(newOwner);
            }
            UpdateSlots();
        }
        
        private void CreateSlots(InventoryObject owner)
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var newSlot = Instantiate(slot.gameObject, Vector3.zero, 
                        Quaternion.identity, inventoryBackground);
                    newSlot.transform.localPosition = new Vector2(baseOffset + slotOffset * j, -baseOffset - slotOffset * i);
                    _slots.Add(newSlot.GetComponent<InventorySlotUI>());
                }
            }
            SetOwner(owner);
            
        }

        private void UpdateSlots()
        {
            ClearSlots();
            var drawn = 0;
            foreach (var item in inventory.Items)
            {
                _slots[drawn].SetVisual(item);
                drawn++;
            }
        }

        private void ClearSlots()
        {
            foreach (var slotUI in _slots)
            {
                slotUI.Clear();
            }
        }
    }
}