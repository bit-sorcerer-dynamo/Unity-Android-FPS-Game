using Cinemachine;
using UnityEngine;

public class SetVirtualCamera : MonoBehaviour
{
    [SerializeField] private Transform camPosition;
    [SerializeField] private CinemachineVirtualCamera virtualCam;

    [SerializeField] private CameraViewPointTracker cameraViewPointTracker;

    public CinemachineVirtualCamera VirtualCamera { get; private set; }

    [Space(10)]
    [Tooltip("The Target at which Camera Locks at!")]
    [SerializeField] private Transform selectedEnemyViewPoint;

    private void Awake()
    {

        VirtualCamera = virtualCam;

        VirtualCamera.Follow = camPosition;
        
        // TODO :: Call Set Enemy View Point At an Event
    }

    private void Update()
    {
        VirtualCamera.LookAt = cameraViewPointTracker.transform;
    }

}
