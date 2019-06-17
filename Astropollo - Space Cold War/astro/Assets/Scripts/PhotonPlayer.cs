using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject MyChar ;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int spawnPlayer = Random.Range(0, GameSerttings.GS.spawnPoints.Length);
        if (PV.IsMine)
        {
            MyChar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MyChara"), GameSerttings.GS.spawnPoints[spawnPlayer].position
                , GameSerttings.GS.spawnPoints[spawnPlayer].rotation, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
