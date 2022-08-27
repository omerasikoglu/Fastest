using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TestDynamicResolution : MonoBehaviour {


    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            float renderScale = 0.1f;
            ScalableBufferManager.ResizeBuffers(renderScale, renderScale);
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            float renderScale = 1f;
            ScalableBufferManager.ResizeBuffers(renderScale, renderScale);
        }

        if (Input.GetKeyDown(KeyCode.U)) {
            float renderScale = 0.1f;
            ((UniversalRenderPipelineAsset)GraphicsSettings.defaultRenderPipeline).renderScale = renderScale;
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            float renderScale = 1f;
            ((UniversalRenderPipelineAsset)GraphicsSettings.defaultRenderPipeline).renderScale = renderScale;
        }
    }

    private void OnDestroy() {
        float renderScale = 1f;
        ScalableBufferManager.ResizeBuffers(renderScale, renderScale);
    }

}