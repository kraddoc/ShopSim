using UnityEngine;

namespace SimTask.Inventory
{
    [CreateAssetMenu(fileName = "Costume Item", menuName = "Items/Costumes", order = 0)]
    public class CostumeObject : ItemObject
    {
        [SerializeField] private Sprite sprite;

        public Sprite GetSprite()
        {
            return sprite;
        }
    }
}