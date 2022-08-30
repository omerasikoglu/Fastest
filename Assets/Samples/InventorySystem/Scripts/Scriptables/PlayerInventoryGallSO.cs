using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/GallItemData", order = 3)]
    public class PlayerInventoryGallSO : AbstractPlayerInventoryItemSO<AbstractPlayerInventoyItemMono> {
        public override void CreateIntoTheInventory(PlayerInventoryController playerInventoryController)
        {

            var instantiate = Instantiate(pf, playerInventoryController.Parent);
            Debug.Log("GallItemData");
        }
    }
}