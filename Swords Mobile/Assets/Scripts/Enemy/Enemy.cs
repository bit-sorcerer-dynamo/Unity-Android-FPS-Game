using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerViewPoint;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 lookAtPos = transform.position - playerViewPoint.position;
        transform.forward = Vector3.Slerp(transform.forward, lookAtPos, Time.deltaTime * rotateSpeed);

        FollowTarget(playerViewPoint.position);
    }

    void FollowTarget(Vector3 direction)
    {
        rb.MovePosition(direction * Time.deltaTime * moveSpeed);
    }

}
