using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {
    public class PlayerInventoryController : MonoBehaviour {
        [SerializeField] private AbstractPlayerInventoryItemData[] playerInventoryItemDataArray;

        public void Start() {
            InitializeInventory();
        }

        private void InitializeInventory() {
            foreach (var itemData in playerInventoryItemDataArray) {
                itemData.CreateIntoTheInventory(this);
            }
        }
    }
}
