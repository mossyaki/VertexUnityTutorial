using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController : MonoBehaviour {

    

    #region Deklaracja zmiennych
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float groundCheckRaycastRange;
    [SerializeField]
    private float verticalSpeedJumpTreshold;
    #endregion
    

    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void LateUpdate () {
        float horizontalMovement = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.W);

        transform.Translate(horizontalMovement * velocity * Vector2.right);
        if(jump == true && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < verticalSpeedJumpTreshold & IsGrounded() == true)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce * Vector2.up);
        }
        Debug.DrawRay(transform.position,groundCheckRaycastRange*Vector2.down, Color.green);
        

	}

    private bool IsGrounded()
    {
        RaycastHit2D rayHit =Physics2D.Raycast(transform.position, Vector2.down, groundCheckRaycastRange);
        if(rayHit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
