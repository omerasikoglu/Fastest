using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnObjectAddressables : MonoBehaviour {

    private const string WORLD_KEY = "Assets/Game/Prefabs/pfWorld.prefab";
    //private const string SYSTEMS_KEY = "Assets/Game/Prefabs/pfSystems.prefab";

    private List<AsyncOperationHandle<GameObject>> asyncOperationHandleList;

    void Start() {
        asyncOperationHandleList = new List<AsyncOperationHandle<GameObject>>
        {
            Addressables.LoadAssetAsync<GameObject>(WORLD_KEY), 
            //Addressables.LoadAssetAsync<GameObject>(SYSTEMS_KEY),
        };

        foreach (var asyncOperationHandle in asyncOperationHandleList) {
            asyncOperationHandle.Completed += AsyncOperationHandle_Completed;
        }

    }

    private void AsyncOperationHandle_Completed(AsyncOperationHandle<GameObject> asyncOperationHandle) {
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded) {
            Instantiate(asyncOperationHandle.Result);
        }
        else {

        }
    }
}
