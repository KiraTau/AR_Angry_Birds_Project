using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;
// using System;
using sys = System;
using TMPro;

public class Launch_with_Audio : MonoBehaviour
{


    // public GameObject projectile;
    // public float launchVelocity = 7f;
    // public AudioClip shootsound;
    // public float lowVolumeRange = .5f;
    // public float highVolumeRange = 1.0f;
    // private AudioSource source;
    // private int count = 0;


    // private UnityEngine.Vector3 firstPosition;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     source = GetComponent<AudioSource>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         Touch touch = Input.GetTouch(0);

    //         UnityEngine.Vector2 distVect = touch.deltaPosition;
    //         float dist = distVect.magnitude;

    //         // Debug.Log("Input");
    //         // Debug.Log(Input.Touch);
    //         // UnityEngine.Vector3 secondPosition = Input.Touch;
    //         // Debug.Log("Diff");
    //         // // Debug.Log(firstPosition - secondPosition);

    //         // float dist = Vector3.Distance(firstPosition,secondPosition);
    //         dist = dist / 10;
    //         Debug.Log(dist);
    //         // launchVelocity = launchVelocity * dist;
    //         // sys.DateTime start = sys.DateTime.UtcNow;
    //         // while (! Input.GetButtonUp("Fire1")) {
    //         //     Debug.Log("waiting for up button");
    //         //     // do nothing
    //         // }
    //         // sys.DateTime end = sys.DateTime.UtcNow;
    //         // sys.TimeSpan timeDiff = end - start;
    //         // double factor = sys.Convert.ToInt32(timeDiff.TotalMilliseconds);
    //         // factor = factor / 1000;
    //         // Debug.Log(factor);

    //         float vol = Random.Range(lowVolumeRange, highVolumeRange);
    //         source.PlayOneShot(shootsound, vol);

    //         GameObject launchThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
    //         launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity * dist, 0));

    //         // launchVelocity = 7f;
    //     }
    // }

//---------------------------------------------------- cellphone 2
    public GameObject projectile;
    public float launchVelocity = 2f;
    public AudioClip shootsound;
    public float lowVolumeRange = .5f;
    public float highVolumeRange = 1.0f;
    private AudioSource source;
    public int turnCount;

    public TextMeshProUGUI turnText;
    public GameObject gameOverText;
    public GameObject lastPigText;    

    private bool startup = true;
    private float distance;
    private bool prevHasInput = false;

    public bool doublePoints = false;


    private UnityEngine.Vector3 firstPosition;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        turnCount = 0;
        DisplayTurn(turnCount);
        gameOverText.SetActive(false);
        lastPigText.SetActive(false);
    }

    void DisplayTurn(int turnCount) {
        if (turnCount % 2 == 0) {
            turnText.text = "Player 1's Turn!";
        } else {
            turnText.text = "Player 2's Turn!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            prevHasInput = true;

            Touch touch = Input.GetTouch(0);
            UnityEngine.Vector2 distVect = touch.deltaPosition;
            float dist = distVect.magnitude;
            dist = dist / 10;
            distance = dist;
            // Debug.Log(dist);

            // // Debug.Log("Input");
            // // Debug.Log(Input.mousePosition);
            // // Debug.Log("Diff");
            // // Debug.Log(firstPosition - secondPosition);

            // Touch touch = Input.GetTouch(0);
            // UnityEngine.Vector2 distVect = touch.deltaPosition;
            // float dist = distVect.magnitude;
            // dist = dist / 10;
            // Debug.Log(dist);
            // // launchVelocity = launchVelocity * dist;
            // // sys.DateTime start = sys.DateTime.UtcNow;
            // // while (! Input.GetButtonUp("Fire1")) {
            // //     Debug.Log("waiting for up button");
            // //     // do nothing
            // // }
            // // sys.DateTime end = sys.DateTime.UtcNow;
            // // sys.TimeSpan timeDiff = end - start;
            // // double factor = sys.Convert.ToInt32(timeDiff.TotalMilliseconds);
            // // factor = factor / 1000;
            // // Debug.Log(factor);

            // float vol = Random.Range(lowVolumeRange, highVolumeRange);
            // source.PlayOneShot(shootsound, vol);

            // GameObject launchThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            // launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity * dist, 0));

            // // launchVelocity = 7f;
            // turnCount = turnCount + 1;
            // Debug.Log("turnCount");
            // Debug.Log(turnCount);

            // DisplayTurn(turnCount);
        } else {
            if (prevHasInput)
            {
                float vol = Random.Range(lowVolumeRange, highVolumeRange);
                source.PlayOneShot(shootsound, vol);

                GameObject launchThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity * distance, 0));

                // launchVelocity = 7f;
                turnCount = turnCount + 1;
                Debug.Log("turnCount");
                Debug.Log(turnCount);

                DisplayTurn(turnCount);            
            }        
                
            prevHasInput = false;
        }

        int totalPigs = GameObject.FindGameObjectsWithTag("Pig").Length;
        if (totalPigs == 1) {
            // gameOverText.text = "GAME OVER";
            lastPigText.SetActive(true);

            doublePoints = true;
        }        
        else if (totalPigs == 0) {
            // gameOverText.text = "GAME OVER";
            // turnCount = turnCount + 1;
            // DisplayTurn(turnCount, true);

            lastPigText.SetActive(false);
            gameOverText.SetActive(true);
        }
    }




// //----------------------------------------------------- computer
    // public GameObject projectile;
    // public float launchVelocity = 7f;
    // public AudioClip shootsound;
    // public float lowVolumeRange = .5f;
    // public float highVolumeRange = 1.0f;
    // private AudioSource source;
    // public int turnCount;

    // public TextMeshProUGUI turnText;
    // public GameObject gameOverText;    


    // private UnityEngine.Vector3 firstPosition;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     source = GetComponent<AudioSource>();
    //     turnCount = 0;
    //     DisplayTurn(turnCount);
    //     gameOverText.SetActive(false);
    // }

    // void DisplayTurn(int turnCount) {
    //     if (turnCount % 2 == 0) {
    //         turnText.text = "Player 1's Turn!";
    //     } else {
    //         turnText.text = "Player 2's Turn!";
    //     }
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetButtonDown("Fire1")) {
    //         // Debug.Log("got down");
    //         firstPosition = Input.mousePosition;
    //     }
    //     if (Input.GetButtonUp("Fire1"))
    //     {
    //         // Debug.Log("Input");
    //         // Debug.Log(Input.mousePosition);
    //         UnityEngine.Vector3 secondPosition = Input.mousePosition;
    //         // Debug.Log("Diff");
    //         // Debug.Log(firstPosition - secondPosition);

    //         float dist = Vector3.Distance(firstPosition,secondPosition);
    //         dist = dist / 10;
    //         Debug.Log(dist);
    //         // launchVelocity = launchVelocity * dist;
    //         // sys.DateTime start = sys.DateTime.UtcNow;
    //         // while (! Input.GetButtonUp("Fire1")) {
    //         //     Debug.Log("waiting for up button");
    //         //     // do nothing
    //         // }
    //         // sys.DateTime end = sys.DateTime.UtcNow;
    //         // sys.TimeSpan timeDiff = end - start;
    //         // double factor = sys.Convert.ToInt32(timeDiff.TotalMilliseconds);
    //         // factor = factor / 1000;
    //         // Debug.Log(factor);

    //         float vol = Random.Range(lowVolumeRange, highVolumeRange);
    //         source.PlayOneShot(shootsound, vol);

    //         GameObject launchThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
    //         launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity * dist, 0));

    //         // launchVelocity = 7f;
    //         turnCount = turnCount + 1;
    //         Debug.Log("turnCount");
    //         Debug.Log(turnCount);

    //         DisplayTurn(turnCount);
    //     }

    //     int totalPigs = GameObject.FindGameObjectsWithTag("Pig").Length;
    //     if (totalPigs == 0) {
    //         // gameOverText.text = "GAME OVER";
    //         gameOverText.SetActive(true);
    //     }
    // }

}
