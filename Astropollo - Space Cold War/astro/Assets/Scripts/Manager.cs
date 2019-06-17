using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviourPun
{
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public Transform Spawn1;
    public Transform Spawn2;
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnPlayer1();
        }
        else
        {
            SpawnPlayer2();
        }
    }

    // Update is called once per frame
    void SpawnPlayer1()
    {
        playerPrefab1 = PhotonNetwork.Instantiate(playerPrefab1.name, Spawn1.transform.position, Quaternion.identity, 0);
    }

    void SpawnPlayer2()
    {
        playerPrefab2 = PhotonNetwork.Instantiate(playerPrefab2.name, Spawn2.transform.position, Quaternion.identity, 0);
    }
}
