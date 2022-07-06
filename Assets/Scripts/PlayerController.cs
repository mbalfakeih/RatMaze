using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private new Rigidbody2D rigidbody;
    //SpriteRenderer sprite;
    Vector2 curMovementInput;
    public float speedMultiplier;
    public float frictionAmount;
    Vector2 curRBmovement;
    private new Animator animation;
    public float Rotatespeed = 5f;
    bool start = false;
    //[SerializeField] private FieldofView fieldofView;

    private float nextActionTime = 0.0f;
    // every 1f = 1 second
    public float period = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
        animation.enabled = false;
        
        StartCoroutine(Wait());
        
        speedMultiplier = 1.5f;
        frictionAmount = 15;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(10);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start) //after intro cutscene
        {
            //basic movement
            curMovementInput.x = Input.GetAxisRaw("Horizontal");
            curMovementInput.y = Input.GetAxisRaw("Vertical");

            //running animation
            if (System.Math.Abs(rigidbody.velocity.x) > 0 || System.Math.Abs(rigidbody.velocity.y) > 0)
            {
                animation.enabled = true;
            }
            else
            {
                animation.enabled = false;
            }

            //rotation
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 270;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Rotatespeed * Time.deltaTime);

            if (Time.time > nextActionTime && Input.GetKey(KeyCode.Space))
            {
                speedMultiplier = 2.5f;
                nextActionTime = Time.time + 0.2f;
                StaminaBar.instance.UseStamina(0.5f);
            }
            else if(Time.time > nextActionTime)
            {
                speedMultiplier = 1.5f;
            }

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