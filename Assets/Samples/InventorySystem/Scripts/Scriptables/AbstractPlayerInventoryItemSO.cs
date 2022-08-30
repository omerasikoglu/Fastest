using UnityEngine;

namespace InventorySystem {
    public enum InventoryItemDataType { Cho, Gall }

    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
    public abstract class AbstractPlayerInventoryItemSO<T> : AbstractPlayerInventoryItemBaseSO where T : AbstractPlayerInventoyItemMono {

        [SerializeField] private string ItemID;
        [SerializeField] protected InventoryItemDataType item;
        [SerializeField] protected T pf;

        

        protected T InstantiatePfIntoTheParent(Transform parent) {
            return Instantiate(pf, parent);
        }


    }
}
