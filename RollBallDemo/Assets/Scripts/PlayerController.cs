using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text pickupCountText;
    public Text completionText;
    private Rigidbody rb;
    private int pickupCount;
    private int totalCount;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        pickupCount = 0;
        totalCount = 12;
        SetPickupCountText();
        completionText.text = "";
    }

    // Update is called before physics calculations
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Handle collisions with Pickup cubes
        if (other.gameObject.CompareTag("Pickup"))
        {
            // remove pickup from view
            other.gameObject.SetActive(false);
            // update counting information
            pickupCount += 1;
            SetPickupCountText();
            // set game winning text
            if (pickupCount == totalCount)
            {
                completionText.text = "All Done!";
            }
        }
    }

    // Update UI text
    private void SetPickupCountText()
    {
        string text = "Count: " + pickupCount.ToString();
        pickupCountText.text = text;
    }
}
