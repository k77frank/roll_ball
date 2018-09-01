using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text coinCount;
    private int totalCoins;

    public GameObject levelComplete;

	private void Start()
	{
        rb = GetComponent<Rigidbody>();
        count = 0;
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        setCoinText();
	}

	private void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(move * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin")) 
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCoinText();
        }
    }

    void setCoinText()
    {
        coinCount.text = "Count: " + count.ToString() + "/" + totalCoins.ToString();
    }

	private void Update()
	{
		if (transform.position.y < -1.0f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (count == totalCoins)
        {
            levelComplete.SetActive(true);
            Invoke("loadNext", 2f);

        }
	}

    private void loadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
