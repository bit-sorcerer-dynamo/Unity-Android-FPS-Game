using Cinemachine;
using UnityEngine;

public class SetVirtualCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform camPosition;

    [Space(10)]
    [Tooltip("The Target at which Camera Locks at!")]
    [SerializeField] private Transform selectedEnemyViewPoint;

    private void Awake()
    {
        virtualCamera.Follow = camPosition;
        virtualCamera.LookAt = selectedEnemyViewPoint;   
    }
}
