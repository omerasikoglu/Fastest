using UnityEngine;

namespace InventorySystem {
    public enum InventoryItemDataType { Cho, Gall }

    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
    public abstract class AbstractPlayerInventoryItemData : ScriptableObject {

        [SerializeField] private string ItemID;
        [SerializeField] protected InventoryItemDataType item;
        [SerializeField] protected Transform pfTransform;

        public abstract void CreateIntoTheInventory(PlayerInventoryController playerInventoryController);

        protected void InstantiatePfIntoTheParent(Transform parent){
            Instantiate(pfTransform, parent);
        }


    }
}
