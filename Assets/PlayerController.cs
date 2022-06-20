using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    Rigidbody2D rigidbody;
    Vector2 curMovementInput;
    public float speedMultiplier;
    public float frictionAmount;
    Vector2 curRBmovement;
    private Animator animation;
    //[SerializeField] private FieldofView fieldofView;


    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = 2;
        frictionAmount = 15;
        rigidbody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        curMovementInput.x = Input.GetAxisRaw("Horizontal");
        curMovementInput.y = Input.GetAxisRaw("Vertical");

        /*
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y)
        Vector3 aimDir = (Worldpos2D - vObject.GetPosition()).normalized;
        fieldofView.SetAimDirection(aimDir);
        fieldofView.SetOrigin(transform.position);
        */

        if(rigidbody.velocity.x > 0 || rigidbody.velocity.y > 0)
        {
            animation.enabled = true;
        }
        else
        {
            animation.enabled = false;
        }

    }

    //runs every certain amount of real world time
    private void FixedUpdate()
    {
        curRBmovement.x = rigidbody.velocity.x;
        curRBmovement.y = rigidbody.velocity.y;

        

        rigidbody.AddForce(curMovementInput * speedMultiplier * frictionAmount);
        rigidbody.AddForce(-curRBmovement * frictionAmount);
    }

}

// gaming gaming I love gaming