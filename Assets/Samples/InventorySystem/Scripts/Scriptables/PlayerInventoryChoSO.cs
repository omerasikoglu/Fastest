using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ChoItemData", order = 2)]
    public class PlayerInventoryChoSO : AbstractPlayerInventoryItemSO<AbstractPlayerInventoyItemMono> {
        public override void CreateIntoTheInventory(PlayerInventoryController playerInventoryController)
        {
            var instantiate = Instantiate(pf, playerInventoryController.Parent);
            Debug.Log("ChoItemData"); 
        }
    }
}