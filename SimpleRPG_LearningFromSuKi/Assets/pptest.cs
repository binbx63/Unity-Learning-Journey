using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class pptest : MonoBehaviour
{
    void Start()
    {
        // 获取当前的摄像机
        Camera cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("找不到摄像机组件！");
            return;
        }

        // 获取摄像机上的 URP 数据
        UniversalAdditionalCameraData camData = cam.GetUniversalAdditionalCameraData();
        
        if (camData == null)
        {
            Debug.LogError("摄像机没有 UniversalAdditionalCameraData 组件！");
            return;
        }

        // 【关键测试】：强制开启抗锯齿和后处理
        camData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
        camData.antialiasingQuality = AntialiasingQuality.High;
        camData.renderPostProcessing = true;

        // 打印确认
        Debug.Log($"测试成功：后处理已强制开启。抗锯齿模式：{camData.antialiasing}");
    }
}