using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class UIHendler : MonoBehaviourPunCallbacks
{
    public InputField createRoom;

    void Start()
    {

    }

    public void OnClick_JoinorCreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(createRoom.text, new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnJoinedRoom()
    {
        print("Room Joined Success");
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Failed To Join Room" + returnCode + "Message" + message);
    }
}
