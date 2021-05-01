using UnityEngine;
using System.Collections;

public class SlingshotController : MonoBehaviour {
	/*** https://gist.github.com/benswinden/f308c738e61bb048233b ***/

    public bool clickAgainToDrop;

    bool clicked;

    float xoffset;
    float yoffset;

    // Happens every frame
    void Update() {

        // If the user has clicked this, follow the mouse
        if (clicked) {

            // Change the position of the object based on the mouse position but also applying the difference between the mouse position and the objects position when you clicked it
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + xoffset, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + yoffset, 0);
        }
    }

    // User clicks the object, ~ The object needs to have some kind of collision on it ~
    void OnMouseDown() {
        if (!clicked) {
            clicked = true;

            // Save the difference in position from where the mouse is to where the center of the object is
            // This means the object won't automatically jump to the cursors position when you click it
            xoffset = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            yoffset = transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        }
        // If we are using click again to drop, then drop the object now
        else if (clicked & clickAgainToDrop) {

            clicked = false;
        }
    }

    // Release the mouse button
    // Don't drop if using click again to drop
    void OnMouseUp() {
        if (clicked & !clickAgainToDrop) {

            clicked = false;
        }
    }

    // // Used for hovering the mouse over an object
    // void OnMouseEnter() {

    //     // Ex. Change the objects color to green
    // }

    // void OnMouseExit() {

    //     // Ex. Change the objects color back to white
    // }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;

// public class SlingshotController : MonoBehaviour
// {
// 	// Transform projectile;
// 	// float speed = 5f;

// 	// void Update()
// 	// {
// 	//     if(Input.GetMouseButtonDown(0))
// 	//     {
// 	//         Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// 	//         target.z = projectile.position.z;

// 	//         Vector3 offset = target - projectile.position;
// 	//         Vector3 direction = offset.normalized;
// 	//         float power = offset.magnitude;
// 	//         projectile.GetComponent<RigidBody>().AddForce(direction * power * speed);
// 	//     }
// 	// }


//     Rigidbody m_Rigidbody;
//     public float m_Speed = 5f;
// 	private Vector3 screenPoint;
// 	private Vector3 offset;       
// 	private Vector3 curPosition_;

//     void Start()
//     {
//         //Fetch the Rigidbody from the GameObject with this script attached
//         m_Rigidbody = GetComponent<Rigidbody>();
//     }

// 	void Update()
// 	{
// 	    if(Input.GetMouseButtonDown(0))
// 	    {
// 	        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// 	        target.z = projectile.position.z;

// 	        Vector3 offset = target - projectile.position;
// 	        Vector3 direction = offset.normalized;
// 	        float power = offset.magnitude;
// 	        projectile.GetComponent<RigidBody>().AddForce(direction * power * speed);
// 	    }
// 	}



 //    void OnMouseDown() {
	// 	screenPoint = Camera.main.WorldToScreenPoint(Input.mousePosition);
	// 	offset = Input.mousePosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
 //    }

	// void OnMouseDrag()
	// {
	//   Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
	//   Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
	//   curPosition_ = curPosition;
	      
	// }    

 //    void FixedUpdate()
 //    {
 //        //Store user input as a movement vector
 //        // Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

 //        //Apply the movement vector to the current position, which is
 //        //multiplied by deltaTime and speed for a smooth MovePosition
 //        m_Rigidbody.MovePosition(curPosition_ + m_Input * Time.deltaTime * m_Speed);
 //    }

 //    public float speed = 0;

 //    private Rigidbody rb;
 //    // private int count;

 //    // private float movementX;
 //    // private float movementY;

	// private Vector3 screenPoint;
	// private Vector3 offset;    

 //    // Start is called before the first frame update
 //    void Start()
 //    {
 //        rb = GetComponent<Rigidbody>();
 //        // count = 0;

 //    }

 //    // private void OnMove(InputValue movementValue)
 //    // {
 //    //     Vector2 movementVector = movementValue.Get<Vector2>();

 //    //     movementX = movementVector.x;
 //    //     movementY = movementVector.y;
 //    // }

	//  void OnMouseDown()
	//   {
	//       screenPoint = Camera.main.WorldToScreenPoint(Input.mousePosition);
	//       offset = Input.mousePosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
	//   }

	// void OnMouseDrag()
	// {
	//   Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
	//   Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
	//   rb.position = curPosition;
	      
	// }


 //    private void FixedUpdate()
 //    {
 //        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

 //        rb.AddForce(movement * speed);
 //    }

}

// // MoveToClickPoint.cs
// using UnityEngine;
// using UnityEngine.AI;

// public class MoveToClickPoint : MonoBehaviour {
//     NavMeshAgent agent;
    
//     void Start() {
//         agent = GetComponent<NavMeshAgent>();
//     }
    
//     void Update() {
//         if (Input.GetMouseButtonDown(0)) {
//             RaycastHit hit;
            
//             if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
//                 agent.destination = hit.point;
//             }
//         }
//     }
// }