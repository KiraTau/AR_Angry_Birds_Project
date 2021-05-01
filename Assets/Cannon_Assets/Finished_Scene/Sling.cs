using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sling : MonoBehaviour
{
    public GameObject Bird;

    public GameObject thesling;

    private GameObject currBird;

    public GameObject cylinder;

    private bool ready = true;

    private float offsetx = -0.05f;

    private float offsety = -0.05f;

    private float offsetz = 0.05f;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Vector3 Dist;
    public float forceMultiplier = 0.1f;
    private Vector3 Force;

    public TextMeshProUGUI turnText;
    public GameObject gameOverText;
    public int turnCount;

    public AudioClip shootsound;
    private AudioSource source;
    public float lowVolumeRange = .5f;
    public float highVolumeRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        turnCount = 0;
        DisplayTurn(turnCount);
        gameOverText.SetActive(false);
    }

    void DisplayTurn(int turnCount)
    {
        if (turnCount % 2 == 0)
        {
            turnText.text = "Player 1's Turn!";
        }
        else
        {
            turnText.text = "Player 2's Turn!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            currBird = Instantiate(Bird);
            currBird.transform.parent = thesling.transform;//Attach red to sling
            currBird.transform.rotation = cylinder.transform.rotation;
            currBird.transform.localPosition = new Vector3(offsetx, offsety, offsetz);
            Debug.Log(cylinder.transform.rotation.eulerAngles);
            ready = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePressDownPos = Input.mousePosition;
            //Debug.Log(mousePressDownPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseReleasePos = Input.mousePosition;
            //Debug.Log(mouseReleasePos);
            currBird.transform.parent = null;
            Rigidbody rb = currBird.GetComponent<Rigidbody>();
            Dist = mouseReleasePos - mousePressDownPos;
            Force = new Vector3(Dist.x, 1.5f * Mathf.Sqrt(Dist.x * Dist.x + Dist.y * Dist.y), -Dist.y);
            Debug.Log(Force);
            //vector = Quaternion.AngleAxis(-45, Vector3.up) * vector;
            float vol = Random.Range(lowVolumeRange, highVolumeRange);
            source.PlayOneShot(shootsound, vol);
            rb.AddRelativeForce((Force) * forceMultiplier);
            rb.useGravity = true;
            turnCount = turnCount + 1;
            Debug.Log("turnCount");
            Debug.Log(turnCount);
            DisplayTurn(turnCount);
            StartCoroutine(ExampleCoroutine());
        }

        int totalPigs = GameObject.FindGameObjectsWithTag("Pig").Length;
        if (totalPigs == 0)
        {
            // gameOverText.text = "GAME OVER";
            gameOverText.SetActive(true);
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //reset after 1 second
        yield return new WaitForSeconds(1);

        ready = true;
    }
}
