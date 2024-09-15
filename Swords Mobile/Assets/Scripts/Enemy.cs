using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerViewPoint;

    void Update()
    {
        Vector3 lookAtPos = playerViewPoint.position;
        transform.LookAt(lookAtPos);

    }

}
