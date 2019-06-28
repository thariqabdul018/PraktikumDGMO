using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class player2 : MonoBehaviourPun, IPunObservable
{

    //public Vector2 jumpForce = new Vector2 (0, 200);
    public float jumpforce = 20f;
    float directionX;

    public GameObject projectilePrefab;
    private List<GameObject> Projectiles = new List<GameObject>();
    private float projectileVelocity;

    public Transform bulletSpawn;

    //public Slider gasPyone;
    //private float gasValue;

    public Rigidbody2D rb;

    private SpriteRenderer terbang1;

    private Vector3 gerakMulus;

    // Use this for initialization
    void Start () {
		projectileVelocity = 3;
        
    }

	// Update is called once per frame
	void Update () {
        GasValue.GasState += 7 * Time.deltaTime;
        if (GasValue.GasState > 100)
        {
            //gasValue = 100;
        }

        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goBullet = Projectiles[i];
            if (goBullet != null)
            {
                goBullet.transform.Translate(new Vector3(0, -1) * Time.deltaTime * projectileVelocity);

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0)
                {
                    DestroyObject(goBullet);
                    Projectiles.Remove(goBullet);
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

    private void ProcessInputs()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (PhotonNetwork.CountOfPlayers >= 2)
            {
                menColot();
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("Shoot"))
        {
            if (PhotonNetwork.CountOfPlayers >= 2)
            {
                meNembak();
            }
        }
    }
    /*void OnCollisionEnter2D(Collision2D other){
		Die();
	}*/
    private void alusGerake()
    {
        transform.position = Vector3.Lerp(transform.position, gerakMulus, Time.deltaTime * 10);
    }

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
