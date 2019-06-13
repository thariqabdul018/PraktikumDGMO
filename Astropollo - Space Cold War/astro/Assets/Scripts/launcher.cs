using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class launcher : MonoBehaviourPunCallbacks
{
    public GameObject connectedScreen;
    public GameObject disconnectedScreen;
    public GameObject PleaseWait;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        disconnectedScreen.SetActive(true);
        PleaseWait.SetActive(false);
        connectedScreen.SetActive(false);
    }

    public override void OnJoinedLobby()
    {
        if (disconnectedScreen.activeSelf)
        {
            disconnectedScreen.SetActive(false);
            PleaseWait.SetActive(false);
            //connectedScreen.SetActive(true);
        }
        PleaseWait.SetActive(false);
        connectedScreen.SetActive(true);
    }
}
