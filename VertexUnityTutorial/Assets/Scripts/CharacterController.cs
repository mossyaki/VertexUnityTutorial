using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController : MonoBehaviour {

    

    #region Deklaracja obiektow
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float groundCheckRaycastRange;
    [SerializeField]
    private float verticalSpeedJumpTreshold;
    //[SerializeField]                          //nowe pole
    //private float losowaRzecz;                //wielka litera = nowe slowo
    #endregion
    

    // Use this for initialization - when game starts
    void Start () {
		
	}

    //when object is created
    private void Awake()
    {
        
    }

    // Update is called once per frame
    //Update() - co klatke, LateUpdate() - co klatke, wykonuje sie po update wszystkich obj; FixedUpdate() - co x czasu, uzywany do fizyki
    void Update () {
        float horizontalMovement = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.W);

        //GetKey - zbiera kiedy trzyma; GetKeyDown/Up - zbiera kiedy zmienia sie stan[klika/puszcza]

        transform.Translate(horizontalMovement * velocity * Vector2.right * Time.deltaTime);
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
