using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class bullet : MonoBehaviourPun
{

    public float speed = 10f;
    public float destroyTime = 2f;

    public PhotonView pv;
    public GameObject CharPrefab;
    public GameObject BulletPrefab;

    IEnumerator DestroyBullets()
    {
        yield return new WaitForSeconds(destroyTime);
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
    }

    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.tag == "Bullets")
            {
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "pesawatP2")
            {
                score.scorePyOne += 1;
                Destroy(this.gameObject);
            }
        }
        else if (this.gameObject.tag == "Bullets")
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "pesawatP1")
            {
                score.scorePyTwo += 1;
                Destroy(this.gameObject);
            }
        }

        /*if (photonView.IsMine)
        {
            if (gameObject.tag == "Bullet")
            {
                if (collision.gameObject.tag == "Bullets")
                {
                    Destroy(collision.gameObject);
                }

                if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "pesawatP2")
                {
                    score.scorePyOne += 1;
                    Destroy(this.gameObject);
                }
            }
            else if (gameObject.tag == "Bullets")
            {
                if (collision.gameObject.tag == "Bullet")
                {
                    Destroy(collision.gameObject);
                }

                if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "pesawatP1")
                {
                    score.scorePyTwo += 1;
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            if (gameObject.tag == "Bullets")
            {
                if (collision.gameObject.tag == "Bullet")
                {
                    Destroy(collision.gameObject);
                }

                if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "pesawatP1")
                {
                    score.scorePyTwo += 1;
                    Destroy(this.gameObject);
                }
            }
            else if (gameObject.tag == "Bullet")
            {
                if (collision.gameObject.tag == "Bullets")
                {
                    Destroy(collision.gameObject);
                }

                if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "pesawatP2")
                {
                    score.scorePyOne += 1;
                    Destroy(this.gameObject);
                }
            }
        }*/
    }

    /*void Die()
    {
        score.scorePyTwo += 1;
        Destroy(this.gameObject);
    }

    void Matek()
    {
        score.scorePyOne += 1;
        Destroy(this.gameObject);
    }*/

    void Update()
    {
        if (photonView.IsMine)
        {
            if (BulletPrefab.tag == "Bullet")
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }

            else if (BulletPrefab.tag == "Bullets")
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
        }

        else
        {
            if (BulletPrefab.tag == "Bullet")
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }

            else if (BulletPrefab.tag == "Bullets")
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
        }
    }

    [PunRPC]
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
