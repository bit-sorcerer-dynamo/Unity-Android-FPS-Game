using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerViewPoint;
    [SerializeField] private float speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 lookAtPos = playerViewPoint.position;
        transform.LookAt(lookAtPos);

        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(transform.right * Time.deltaTime * speed, ForceMode.Impulse);
        else if (Input.GetKey(KeyCode.D))
            rb.AddForce(-transform.right * Time.deltaTime * speed, ForceMode.Impulse);
    }
}
