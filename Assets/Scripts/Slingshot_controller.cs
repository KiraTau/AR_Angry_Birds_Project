using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

using TMPro;

public class Slingshot_controller : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
    	Debug.Log("Started");
        rb = GetComponent<Rigidbody>();

    }

    // private void OnMove(InputValue movementValue)
    // {
    // 	Debug.Log("OnMove");
    //     Vector2 movementVector = movementValue.Get<Vector2>();

    //     movementX = movementVector.x;
    //     movementY = movementVector.y;

    //     Debug.Log("Values" + movementX);
    // }

    // private void FixedUpdate()
    // {
    // 	// Debug.Log("Update");
    //     Vector3 movement = new Vector3(movementX, 0.0f, movementY);

    //     rb.AddForce(movement * speed);
    // }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed primary button.");

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
    }
 //    public bool clickAgainToDrop;

 //    bool clicked;

 //    float xoffset;
 //    float yoffset;

 //    // Happens every frame
 //    void Update() {
 //    	Debug.Log("Update loooop");

 //        // If the user has clicked this, follow the mouse
 //        if (clicked) {

 //            // Change the position of the object based on the mouse position but also applying the difference between the mouse position and the objects position when you clicked it
 //            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + xoffset, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + yoffset, 0);
 //        }
 //    }

 //    // User clicks the object, ~ The object needs to have some kind of collision on it ~
 //    void OnMouseDown() {
 //    	Debug.Log("print");

 //        if (!clicked) {
 //            clicked = true;

 //            // Save the difference in position from where the mouse is to where the center of the object is
 //            // This means the object won't automatically jump to the cursors position when you click it
 //            xoffset = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
 //            yoffset = transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
 //        }
 //        // If we are using click again to drop, then drop the object now
 //        else if (clicked & clickAgainToDrop) {

 //            clicked = false;
 //        }
 //    }

 //    // Release the mouse button
 //    // Don't drop if using click again to drop
 //    void OnMouseUp() {
 //        if (clicked & !clickAgainToDrop) {

 //            clicked = false;
 //        }
 //    }
}
