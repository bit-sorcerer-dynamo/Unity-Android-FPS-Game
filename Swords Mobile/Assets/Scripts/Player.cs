using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private SetVirtualCamera setVirtualCamera;

    #region Dodge Values
    [Space(10), Header("Dash Values"), Space(10)]
    [SerializeField] private float dodgeForce;
    [SerializeField] private float dodgeDuration;

    public AnimationCurve dodgeCurve;

    private Vector3 dodgeDirection;
    private float dodgeTime;
    private bool isDodging;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setVirtualCamera = GetComponent<SetVirtualCamera>();
    }

    void Update()
    {
        UpdatePlayerRotation(); 

        #region Horizontal Dodge
        if (Input.GetKeyDown(KeyCode.A) && !isDodging) StartDodge(-transform.right);
        else if (Input.GetKeyDown(KeyCode.D) && !isDodging) StartDodge(transform.right);

        if (isDodging) UpdateDodge();
        #endregion
    }

    // Updates Player Rotation as Per the Virtual Camera's Rotation
    private void UpdatePlayerRotation()
    {
        Vector3 camDir = setVirtualCamera.VirtualCamera.transform.forward;
        camDir.y = 0; // Ignore the Y Axis Rotation

        if (camDir != Vector3.zero) transform.forward = camDir;
    }

    #region Dodging

    // Sets up the Direction and A timer for Dashing
    private void StartDodge(Vector3 direction)
    {
        dodgeDirection = direction;

        // set the dash time and flag
        dodgeTime = 0f;
        isDodging = true;

        rb.AddForce(dodgeDirection * dodgeForce, ForceMode.VelocityChange);
    }

    private void UpdateDodge()
    {
        dodgeTime += Time.deltaTime;

        float t = dodgeTime / dodgeDuration;
        float curveValue = dodgeCurve.Evaluate(t);

        // End the dash
        if (dodgeTime >= dodgeDuration)
        {
            isDodging = false;
            rb.velocity = Vector3.zero;
        }
    }
    #endregion
}
