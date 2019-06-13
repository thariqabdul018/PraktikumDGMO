using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviour
{
    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public Transform Spawn1;
    public Transform Spawn2;
    void Start()
    {
        SpawnPlayer1();
        SpawnPlayer2();
    }

    // Update is called once per frame
    void SpawnPlayer1()
    {
        PhotonNetwork.Instantiate(playerPrefab1.name, Spawn1.position, playerPrefab1.transform.rotation);
    }

    void SpawnPlayer2()
    {
        PhotonNetwork.Instantiate(playerPrefab2.name, Spawn2.position, playerPrefab2.transform.rotation);
    }
}
