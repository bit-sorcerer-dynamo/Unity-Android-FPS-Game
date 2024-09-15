using System;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    private SetVirtualCamera _virtualCamera;

    [Space(10),Header("Charge Attack"), Space(10)]
    [SerializeField] private float maxChargeAttackDistance;
    [SerializeField] private float chargeAttackForce = 25f;
    [SerializeField] private LayerMask enemyLayer;

    private Rigidbody rb;

    private Vector3 chargeAttackDir;
    private Vector3 chargeAttackStartPos;
    private bool canChargeAttack; // -> Used By Player Script to Do Not Overlap Dash with Charge Attack
    private bool isChargeAttacking;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _virtualCamera = GetComponent<SetVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isChargeAttacking) StartChargeAttack();
        if (isChargeAttacking) UpdateChargeAttack(); 
    }

    #region Dash Attack
    private void StartChargeAttack()
    {
        Ray startRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitRef;

        if(Physics.Raycast(startRay, out hitRef, maxChargeAttackDistance, enemyLayer)) {

            // Calculate Direction Towards Enemy
            Vector3 targetPos = hitRef.point;
            chargeAttackDir = (targetPos - transform.position).normalized;

            // Store the Start Position of Player
            chargeAttackStartPos = transform.position;

            isChargeAttacking = true;
            rb.velocity = chargeAttackDir * chargeAttackForce;

        }
    }
    private void UpdateChargeAttack()
    {
        // Check if Player has Moved Beyond Attack Range
        if (Vector3.Distance(chargeAttackStartPos, transform.position) >= maxChargeAttackDistance) 
            StopChargeAttack();

    }

    private void StopChargeAttack()
    {
        isChargeAttacking = false;
        rb.velocity = Vector3.zero;
    }
#endregion

    private void OnCollisionEnter(Collision collision)
    {
        // If Collided with enemy
        if (collision.collider.CompareTag("Enemy")){
            StopChargeAttack();
            _virtualCamera.ShakeScreen();
        }
    }
}
