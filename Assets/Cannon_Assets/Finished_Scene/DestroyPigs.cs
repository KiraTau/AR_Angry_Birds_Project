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

    // Start is called before the first frame update.
    void Start()
    {
        count_player1 = 0;
        count_player2 = 0;

        SetCountText();
    }


    // Displays score of each player.
    void SetCountText() {
        int pigValue = 50; // amount of points each destroyed pig is worth
    	countText_player1.text = "P1 Score: " + (count_player1 * 50).ToString();
    	countText_player2.text = "P2 Score: " + (count_player2 * 50).ToString();
    }

    // Destroys the pigs upon collision with Projectile. Keeps track of score for 
    // each player.
	void OnCollisionEnter(Collision other)
	{
	        if (other.gameObject.tag == "Projectile")
	       {
	       		Destroy (gameObject);

	       		int turnCount = GameObject.Find("Launch_Origin").GetComponent<Launch_with_Audio>().turnCount;
                // if doublePoints is true, increase points doubly
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

	            Destroy (gameObject);
	            SetCountText();
	       }
	}
}
