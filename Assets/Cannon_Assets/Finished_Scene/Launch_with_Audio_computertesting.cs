// Launch_with_Audio with input from computer mouse click, for debugging purposes.
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sys = System;
using TMPro;

public class Launch_with_Audio : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 7f;
    public AudioClip shootsound;
    public float lowVolumeRange = .5f;
    public float highVolumeRange = 1.0f;
    private AudioSource source;
    public int turnCount;

    public TextMeshProUGUI turnText;
    public GameObject gameOverText;    


    private UnityEngine.Vector3 firstPosition;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        turnCount = 0;
        DisplayTurn(turnCount);
        gameOverText.SetActive(false);
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
        if (Input.GetButtonDown("Fire1")) {
            // Debug.Log("got down");
            firstPosition = Input.mousePosition;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            // Debug.Log("Input");
            // Debug.Log(Input.mousePosition);
            UnityEngine.Vector3 secondPosition = Input.mousePosition;
            // Debug.Log("Diff");
            // Debug.Log(firstPosition - secondPosition);

            float dist = Vector3.Distance(firstPosition,secondPosition);
            dist = dist / 10;
            Debug.Log(dist);

            float vol = Random.Range(lowVolumeRange, highVolumeRange);
            source.PlayOneShot(shootsound, vol);

            GameObject launchThis = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            launchThis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity * dist, 0));

            // launchVelocity = 7f;
            turnCount = turnCount + 1;
            Debug.Log("turnCount");
            Debug.Log(turnCount);

            DisplayTurn(turnCount);
        }

        int totalPigs = GameObject.FindGameObjectsWithTag("Pig").Length;
        if (totalPigs == 0) {
            // gameOverText.text = "GAME OVER";
            gameOverText.SetActive(true);
        }
    }

}
*/