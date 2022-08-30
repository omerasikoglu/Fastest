using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {
    public abstract class AbstractPlayerInventoryItemBaseSO : ScriptableObject {

        public abstract void CreateIntoTheInventory(PlayerInventoryController playerInventoryController);


    }

}