using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerViewPoint;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;

    public enum AttackType
    {
        Rapid,
        Combo,
        ShortRanged,
        LongRanged
    }
    public Transform attackPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 lookAtPos = transform.position - playerViewPoint.position;
        transform.forward = Vector3.Slerp(transform.forward, lookAtPos, Time.deltaTime * rotateSpeed);

        // TODO :: call this function only when the enemy is not attacking
        MoveTowardsPlayer(); 
    }

    // Gets Distance From Player
    public float GetDistanceFromPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(this.transform.position, attackPoint.position);
        return distanceFromPlayer;
    }

    // FIXME :: Move According to Attack Type
    public void MoveTowardsPlayer()
    {
        if (GetDistanceFromPlayer() >= 5)
        {
            Vector3 moveDir = attackPoint.position - this.transform.position;
            rb.velocity = moveDir * moveSpeed;
        }
        else rb.velocity = Vector3.zero;
    }


    #region Enemy Attacks
    public void PerformAttack(AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.Rapid:
                RapidAttack();
                break;
            case AttackType.Combo:
                ComboAttack();
                break;
            case AttackType.ShortRanged:
                ShortRangedAttack();
                break;
            case AttackType.LongRanged:
                LongRangedAttack();
                break;
            default:
                Debug.LogWarning("Unknown Attack Type!");
                break;
        }
    }

    private void RapidAttack() {
        //Debug.Log("Rapid Attack!" + this.gameObject.tag);
    }
    private void ComboAttack() {
        //Debug.Log("Combo Attack!" + this.gameObject.tag);
    }
    private void ShortRangedAttack() {
        //Debug.Log("Short Ranged Attack!" + this.gameObject.tag);
    }
    private void LongRangedAttack() {
        //Debug.Log("Long Ranged Attack!" + this.gameObject.tag);
    }

    #endregion
}
