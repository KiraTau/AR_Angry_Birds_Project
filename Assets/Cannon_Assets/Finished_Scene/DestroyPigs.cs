using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DestroyPigs : MonoBehaviour
{
	private static int count_player1;
	private static int count_player2;
	public TextMeshProUGUI countText_player1;
	public TextMeshProUGUI countText_player2;
	// public TextMeshProUGUI countText_player2;
	private int totalPigs;
	private int playerTurn;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting");

        // totalPigs = GameObject.FindGameObjectsWithTag("Pig").Length;
        // playerTurn = 1;
        count_player1 = 0;
        count_player2 = 0;
        // count = 0;
        // count_player1 = GameObject.Find("Launch_Origin").GetComponent<Launch_with_Audio>().turnCount;
        // Debug.Log(count_player1);
        // Launch_with_Audio.turnCount = 1;

        SetCountText();
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     other.gameObject.SetActive(false);
    //     Debug.Log("HERE!");
    // //     if (other.gameObject.CompareTag("Pig"))
    // //     {
    // //         Debug.Log("HERE2");
    // //         other.gameObject.SetActive(false);
    // //         count = count + 1;

    // //         // Run the 'SetCountText()' function (see below)
    // //         // SetCountText();
    // //     }
    // // }
    // }

    void SetCountText() {
    	countText_player1.text = "P1 Score: " + (count_player1 * 50).ToString();
    	countText_player2.text = "P2 Score: " + (count_player2 * 50).ToString();
    }

	void OnCollisionEnter(Collision other)
	{
	        if (other.gameObject.tag == "Projectile")
	       {
	       		Destroy (gameObject);

	       		int turnCount = GameObject.Find("Launch_Origin").GetComponent<Launch_with_Audio>().turnCount;
                bool doublePoints = GameObject.Find("Launch_Origin").GetComponent<Launch_with_Audio>().doublePoints;

	       		if (turnCount % 2 == 1) {
	       			count_player1 = count_player1 + 1;

                    if (doublePoints) {
                        count_player1 = count_player1 + 1;                        
                    }
	       		} else {
	       			count_player2 = count_player2 + 1;

                    if (doublePoints) {
                        count_player2 = count_player2 + 1;                        
                    }
	       		}

	       		// count = count + 1;
				// Debug.Log("Destroying");
				// Debug.Log(count_player1);
	            Destroy (gameObject);
	                //or gameObject.SetActive(false);
	            // count_player1 = count_player1 + 1;
	            // count_player1 = totalPigs - GameObject.FindGameObjectsWithTag("Pig").Length + 1;
	            SetCountText();
	       }
	}
}
