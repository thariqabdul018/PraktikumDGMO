using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour {

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

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "bullet" || coll.gameObject.tag == "Player2" || coll.gameObject.tag == "pesawatP2") {
			Ilang ();
		}
	}

	void Ilang (){
		Destroy (gameObject);
	}
}
