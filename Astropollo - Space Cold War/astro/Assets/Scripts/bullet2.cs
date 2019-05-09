using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour {

	public float velX = 0f;
	public float velY = 0f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (velX, velY);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "bullet" || coll.gameObject.tag == "Player1" || coll.gameObject.tag == "pesawatP1")
        {
            Ilang();
        }
    }

    void Ilang()
    {
        Destroy(gameObject);
    }
}
