using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;

    //extra functionality
    public float speed = 20;
    public bool diagonalMovement = false;
    public float verticalIncline = 70;
    float xComponent;

    void Start()
    {
        //instead of dragging the component to script inside Unity
        rb = GetComponent<Rigidbody2D>();
    }

    //other (eg. visual) updates
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

    }

    //physics update
    void FixedUpdate()
    {
        if (diagonalMovement && Mathf.Abs(movement.y) > 0 && Mathf.Sin(verticalIncline) != 0){ //use verticalIncline to add/remove x value in movement
            xComponent = Mathf.Cos(Mathf.Deg2Rad * verticalIncline) / Mathf.Sin(Mathf.Deg2Rad * verticalIncline);
            movement.x = (movement.y > 0 ? movement.x + xComponent : movement.x - xComponent);
        }
        
        rb.MovePosition((Vector2)transform.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
