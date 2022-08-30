using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ChoItemData", order = 1)]
    public class PlayerInventoryChoData : AbstractPlayerInventoryItemData {
        public override void CreateIntoTheInventory(PlayerInventoryController playerInventoryController)
        {
            Debug.Log("ChoItemData");
        }
    }
}