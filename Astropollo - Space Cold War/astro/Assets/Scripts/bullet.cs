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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "pesawatP2")
        {
            Die();
        }

        if (this.gameObject.tag == "bullet") {
            if (collision.gameObject.tag == "bullet2")
            {
                Destroy(collision.gameObject);
            }
        }

        else if (this.gameObject.tag == "bullet2")
        {
            if (collision.gameObject.tag == "bullet")
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void Die()
    {
        score.scorePyOne += 1;
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }

    [PunRPC]
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
