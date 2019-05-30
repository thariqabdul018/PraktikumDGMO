using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class photonConnect : MonoBehaviour
{
    public string versionName = "0.1";
    public GameObject sectionView1, sectionView2, sectionView3;
    public void connectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting...");
    }

    private void onConnectedtoMaster()
    {
        PhotonNetwork.JoinLobby(typedLobby.default);
        Debug.Log("CONNECTED!");
    }

    private void onJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        Debug.Log("On Joined Lobby");
    }

    private void onDisconnectedfromPhoton()
    {
        if (sectionView1.active)
        {
            sectionView1.SetActive(false);
        }
        if (sectionView2.active)
        {
            sectionView2.SetActive(false);
        }
        sectionView3.SetActive(true);
        Debug.Log("Lost Connection!");
    }
}
