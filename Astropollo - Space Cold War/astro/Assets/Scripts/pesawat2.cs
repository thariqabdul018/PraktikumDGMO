using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pesawat2 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            Die();
        }
    }

    void Die()
    {
        score.scorePyOne += 1;
    }
}