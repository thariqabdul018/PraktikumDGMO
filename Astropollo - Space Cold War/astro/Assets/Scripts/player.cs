using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class player : MonoBehaviourPun, IPunObservable
{
    public PhotonView pv;
    public float jumpforce = 20f;
    float directionX;

    public static bool Gasku, Gasmu;

    public GameObject projectilePrefab;
	private List<GameObject> Projectiles = new List<GameObject> ();
	private float projectileVelocity = 3;

    public Transform bulletSpawn;

	//public Text pyOneWin;

    public Rigidbody2D rb;
    public float moveSpeed = 10f;

    private SpriteRenderer terbang1;
    private Vector3 gerakMulus;

    public static bool aku;
    public static bool kamu;
	// Use this for initialization
	void Start () {
        if (photonView.IsMine)
        {
            this.gameObject.tag = "Player1";
            projectilePrefab.tag = "Bullet";
            aku = true;
            kamu = false;
        }
        else
        {
            this.gameObject.tag = "Player2";
            projectilePrefab.tag = "Bullets";
            aku = false;
            kamu = true;
        }
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject goBullet = Projectiles [i];
            
		    //Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
            //if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0)
            //{
                //Destroy(goBullet);
                //Projectiles.Remove(goBullet);
            //}
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

    private void ProcessInputs()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
               menColot();
        }
        if (CrossPlatformInputManager.GetButtonDown("Shoot"))
        {
            if (aku == true || kamu == true)
            {
                meNembak();
            }
        }
    }

    private void alusGerake()
    {
        transform.position = Vector3.Lerp(transform.position, gerakMulus, Time.deltaTime * 10);
    }

    public void resetGemu () {
		score.scorePyOne = 0;
		score.scorePyTwo = 0;
	}


	public void metuGemu (){
		Application.Quit ();
	}

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
    }

    public void menColot()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Force);
        }
    }

    public void meNembak()
    {
        GameObject bullet;
        bullet = PhotonNetwork.Instantiate(projectilePrefab.name, bulletSpawn.position, Quaternion.identity);
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
