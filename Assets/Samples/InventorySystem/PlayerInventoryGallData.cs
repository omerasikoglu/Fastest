using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/GallItemData", order = 1)]
    public class PlayerInventoryGallData : AbstractPlayerInventoryItemData {
        public override void CreateIntoTheInventory(PlayerInventoryController playerInventoryController)
        {
            Debug.Log("GallItemData");
        }
    }
}