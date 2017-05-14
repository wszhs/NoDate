using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    // 抖动目标的transform(若未添加引用，怎默认为当前物体的transform)
    private Transform camTransform;

    //持续抖动的时长
    private float shake = 0.0f;

    // 抖动幅度（振幅）
    //振幅越大抖动越厉害
    private float shakeAmount = 10.0f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    public void ShakeEvent() {
        shake = 2.0f;
    }
    void Awake()
    {
        camTransform=transform;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shake > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}
