using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2 : MonoBehaviour {

	public Vector2 jumpForce = new Vector2 (0, 200);

	public GameObject projectilePrefab;
	private List<GameObject> Projectiles = new List<GameObject> ();
	private float projectileVelocity;

	public Slider gasPytwo;
	private float gasValue;

	// Use this for initialization
	void Start () {
		projectileVelocity = 3;
		gasValue = gasPytwo.value;
	}

	// Update is called once per frame
	void Update () {
		gasPytwo.value = gasValue;
		gasValue += 7 * Time.deltaTime;
		if (gasValue > 100) {
			gasValue = 100;
		}

		if (Input.GetKeyDown (KeyCode.L) && gasValue > 15) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().AddForce (jumpForce);
			gasValue -= 15;
		}

		if (Input.GetKeyUp (KeyCode.K)) {
			GameObject bullet = (GameObject)Instantiate (projectilePrefab, transform.position, Quaternion.Euler (new Vector3(0, -180, 0)));
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

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "bullet") {
			Die ();
		}
	}

	void Die() {
		score.scorePyOne +=1;
	}


    /*void usaMenang()
    {
        if (score.scorePyTwo > score.scorePyOne)
        {
            Application.LoadLevel("usamenang");

        }
    }*/
}
