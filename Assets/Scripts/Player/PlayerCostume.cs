using System.Xml.Schema;
using SimTask.Inventory;
using SimTask.UI;
using UnityEngine;
using UnityEngine.UI;

namespace SimTask.Player
{
    public class PlayerCostume : MonoBehaviour
    {
        [SerializeField] private InventoryObject playerInventory;
        [SerializeField] private SpriteRenderer costumeRenderer;
        [SerializeField] private CostumeObject startingCostume;
        [SerializeField] private Image costumeIcon;
        [SerializeField] private Sprite empty;
        private CostumeObject _currentCostume;

        private void Start()
        {
            costumeRenderer.sprite = empty;
            costumeIcon.sprite = empty;
            if (startingCostume)
            {
                SetCostume(startingCostume);
            }

            InventorySlotUI.OnRightClick += ChangeCostume;
        }

        private void ChangeCostume(ItemObject costume, InventoryObject inventory)
        {
            if (!(costume is CostumeObject) || inventory != playerInventory)
                return;
            
            if (_currentCostume != null)
                playerInventory.AddItem(_currentCostume);
            
            SetCostume((CostumeObject)costume);
            playerInventory.RemoveItem(costume);
        }
        
        private void SetCostume(CostumeObject costume)
        {
            _currentCostume = costume;

            costumeRenderer.sprite = _currentCostume.GetSprite();
            costumeIcon.sprite = _currentCostume.GetIcon();
        }
    }
}