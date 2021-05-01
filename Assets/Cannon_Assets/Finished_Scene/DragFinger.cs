using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DragFinger : MonoBehaviour
{
    public GameObject Bird;

    public GameObject thesling;

    private GameObject currBird;

    public GameObject cylinder;

    private bool ready = true;

    private float offsetx = -0.2f;

    private Vector3 touchPressDownPos;

    private Vector3 touchReleasePos;

    private Vector3 Dist;

    public float forceMultiplier = 1.5f;

    private Vector3 Force;

    private bool isShoot;

    private bool isTouching;

    Action<Touch> touchUp;

    public TextMeshProUGUI displaytext;

    public TextMeshProUGUI displayforce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            currBird = Instantiate(Bird);
            currBird.transform.parent = thesling.transform;//Attach red to sling
            currBird.transform.localPosition = new Vector3(offsetx, 0, 0);
            currBird.transform.rotation = cylinder.transform.rotation;
            Debug.Log(cylinder.transform.rotation.eulerAngles);
            ready = false;
        }

        if (Input.touchCount == 1)
        {
            isTouching = true;
            Touch touch = Input.GetTouch(0);    
            touchPressDownPos = touch.position;
            displaytext.text = "touchdown: " + touchPressDownPos;
        }

        if (Input.touchCount > 1)
        {
            isTouching = true;
            Touch touch = Input.GetTouch(0);
            touchReleasePos = touch.position;
            displaytext.text = "touchdown: " + touchReleasePos;
        }

        if (isTouching)
        {
            if (touchUp != null)
            {
                displaytext.text = "touch release";
                currBird.transform.parent = null;
                Rigidbody rb = currBird.GetComponent<Rigidbody>();
                Dist = touchReleasePos - touchPressDownPos;
                Force = new Vector3(Dist.x, 1.5f * Mathf.Sqrt(Dist.x * Dist.x + Dist.y * Dist.y), -Dist.y);
                displayforce.text = "Force: " + Force;
                rb.AddRelativeForce((Force) * forceMultiplier);
                rb.useGravity = true;
                StartCoroutine(ExampleCoroutine());
                isTouching = false;
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //reset after 1 second
        yield return new WaitForSeconds(1);

        ready = true;
    }
}
