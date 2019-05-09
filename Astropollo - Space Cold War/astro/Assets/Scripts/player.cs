﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public Vector2 jumpForce = new Vector2 (0, 200);

	public GameObject projectilePrefab;
	private List<GameObject> Projectiles = new List<GameObject> ();
	private float projectileVelocity;

	public Text pyOneWin;

	public Slider gasPyone;
	private float gasValue;

    private SpriteRenderer terbang1;

	// Use this for initialization
	void Start () {
		projectileVelocity = 3;
		gasValue = gasPyone.value;
	}

	// Update is called once per frame
	void Update () {
		gasPyone.value = gasValue;
		gasValue += 7 * Time.deltaTime;
		if (gasValue > 100) {
			gasValue = 100;
		}

		if (Input.GetKeyDown (KeyCode.A) && gasValue > 15) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().AddForce (jumpForce);
			gasValue -= 15;

		}

		if (Input.GetKeyUp (KeyCode.S)) {
			GameObject bullet = (GameObject)Instantiate (projectilePrefab, transform.position, Quaternion.identity);
			Projectiles.Add (bullet);
		}

		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject goBullet = Projectiles [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (0, -1) * Time.deltaTime * projectileVelocity);

				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0) {
					DestroyObject (goBullet);
					Projectiles.Remove (goBullet);
				}
			}
		}
	}

	/*void OnCollisionEnter2D(Collision2D other){
		Die();
	}*/

	/*void kondisiMenang (){
		if (score.scorePyOne = 10) {
			Time.timeScale = 0;
			pyOneWin.GetComponent<RectTransform> ().position = new Vector3 (0, 0);
		}
	}*/

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "bullet") {
			Die ();
		}
	}

    void Die()
    {
        score.scorePyTwo += 1;
    }

    public void resetGemu () {
		score.scorePyOne = 0;
		score.scorePyTwo = 0;
	}


	public void metuGemu (){
		Application.Quit ();
	}

    /*void sovietMenang()
    {
        if (score.scorePyOne > score.scorePyTwo)
        {
            Application.LoadLevel("sovietmenang");

        }
    }*/

}
