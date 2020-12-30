using UnityEngine;

namespace SimTask.Inventory
{
    public abstract class ItemObject : ScriptableObject
    {
        [SerializeField] protected string inventoryName;
        [TextArea(15,25)]
        [SerializeField] protected string description;
        [SerializeField] protected int cost;
        [SerializeField] protected Sprite inventoryIcon;


        public Sprite GetIcon()
        {
            return inventoryIcon;
        }

        public int GetCost()
        {
            return cost;
        }

        public string GetName()
        {
            return inventoryName;
        }

        public string GetDescription()
        {
            return description;
        }

    }
}