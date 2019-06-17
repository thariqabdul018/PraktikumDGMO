using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class player : MonoBehaviourPun, IPunObservable
{

    //public Vector2 jumpForce = new Vector2 (0, 200);
    public float jumpforce = 20f;
    float directionX;

    public GameObject projectilePrefab;
	private List<GameObject> Projectiles = new List<GameObject> ();
	private float projectileVelocity;

    public Transform bulletSpawn;

	public Text pyOneWin;

	//public Slider gasPyone;
	//private float gasValue;

    public Rigidbody2D rb;

    private SpriteRenderer terbang1;

    private Vector3 gerakMulus;
	// Use this for initialization
	void Start () {
		projectileVelocity = 3;
		//gasValue = gasPyone.value;
	}

	// Update is called once per frame
	void Update () {
        //gasPyone.value = gasValue;
        GasValue.GasState += 7 * Time.deltaTime;
		if (GasValue.GasState > 100) {
			//gasValue = 100;
		}

		/*if (Input.GetKeyDown (KeyCode.A) && gasValue > 15) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().AddForce (jumpForce);
			gasValue -= 15;

		}

		if (Input.GetKeyUp (KeyCode.S)) {
			GameObject bullet = (GameObject)Instantiate (projectilePrefab, transform.position, Quaternion.identity);
			Projectiles.Add (bullet);
		}*/

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

        if (photonView.IsMine)
        {
            ProcessInputs();
        }
        else
        {
            alusGerake();
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

    private void ProcessInputs()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            menColot();
        }

        if (CrossPlatformInputManager.GetButtonDown("Shoot"))
        {
            meNembak();
        }
    }

    private void alusGerake()
    {
        transform.position = Vector3.Lerp(transform.position, gerakMulus, Time.deltaTime * 10);
    }

    /*void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "bullet") {
			Die ();
		}
	}

    void Die()
    {
        score.scorePyTwo += 1;
    }*/

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

    public void menColot()
    {
        if (GasValue.GasState >= 15)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Force);
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //GetComponent<Rigidbody2D>().AddForce(jumpforce);
            GasValue.GasState -= 15;
        }
    }

    public void meNembak()
    {
        GameObject bullet;

        bullet = PhotonNetwork.Instantiate(projectilePrefab.name, bulletSpawn.position, Quaternion.identity); 
        //Projectiles.Add(bullet);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            gerakMulus = (Vector3)stream.ReceiveNext();
        }
    }
}
