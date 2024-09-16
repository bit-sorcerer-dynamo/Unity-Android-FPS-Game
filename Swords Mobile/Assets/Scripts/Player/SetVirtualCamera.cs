using Cinemachine;
using UnityEngine;

public class SetVirtualCamera : MonoBehaviour
{
    [SerializeField] private Transform camPosition;
    [SerializeField] private CinemachineVirtualCamera virtualCam;

    //private float perlinFrequency = 1f;
    //private float perlinAmplitude = 1f;
    //private float shakeDuration = 1f;

    //private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    //private float timeRemainingForScreenShake;
    //private bool isShaking;
    
    public CinemachineVirtualCamera VirtualCamera { get; private set; }

    [Space(10)]
    [Tooltip("The Target at which Camera Locks at!")]
    [SerializeField] private Transform selectedEnemyViewPoint;

    private void Awake()
    {
        VirtualCamera = virtualCam;

        VirtualCamera.Follow = camPosition;
        VirtualCamera.LookAt = selectedEnemyViewPoint;

        //cinemachineBasicMultiChannelPerlin = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    //public void ShakeScreen()
    //{
    //    timeRemainingForScreenShake = shakeDuration;
    //    Debug.Log("ShakeScreen");
    //    isShaking = true;

    //    while(timeRemainingForScreenShake > 0)
    //    {
    //        timeRemainingForScreenShake -= Time.deltaTime;

    //        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = perlinFrequency;
    //        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = perlinAmplitude;
    //        Debug.Log("ShakeScreen");

    //    }

    //    cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0f;
    //    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
    //    isShaking = false;
    //}
}
