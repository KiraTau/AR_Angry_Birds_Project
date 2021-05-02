// Launch_with_Audio with input from phone's touch screen.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sys = System;
using TMPro;

public class Launch_with_Audio : MonoBehaviour
{
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

    // Start is called before the first frame update.
    void Start()
    {
        source = GetComponent<AudioSource>();
        turnCount = 0;
        DisplayTurn(turnCount);
        gameOverText.SetActive(false);
        lastPigText.SetActive(false);
    }

    // Display text to show player's turn.
    void DisplayTurn(int turnCount) {
        if (turnCount % 2 == 0) {
            turnText.text = "Player 1's Turn!";
        } else {
            turnText.text = "Player 2's Turn!";
        }
    }

    // Update is called once per frame. Registers touch, instantiates, and launches projectile.
    // If only one pig is left, sets doublePoints variable to true. If no pigs are left, 
    // displays game over text.
    void Update()
    {
        if (Input.touchCount > 0) {
            // Get furthest distance of swipe
            prevHasInput = true;
            Touch touch = Input.GetTouch(0);
            UnityEngine.Vector2 distVect = touch.deltaPosition;
            float dist = distVect.magnitude;
            dist = dist / 10;
            distance = dist;

        } else {
            if (prevHasInput)
            {
                float vol = Random.Range(lowVolumeRange, highVolumeRange);
                source.PlayOneShot(shootsound, vol);

                // Instantiate and launch projectile object
                GameObject launchThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity * distance, 0));

                turnCount = turnCount + 1; // Increment turn count

                DisplayTurn(turnCount); // Display player's turn
            }        
                
            prevHasInput = false;
        }

        // Actions that depend on total pigs left in game
        int totalPigs = GameObject.FindGameObjectsWithTag("Pig").Length;
        if (totalPigs == 1) {
            lastPigText.SetActive(true);

            doublePoints = true;
        }        
        else if (totalPigs == 0) {
            // Display text
            lastPigText.SetActive(false);
            gameOverText.SetActive(true);
        }
    }


}
