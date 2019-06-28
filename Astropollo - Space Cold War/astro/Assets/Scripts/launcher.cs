using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class launcher : MonoBehaviourPunCallbacks
{
    public GameObject connectedScreen;
    public GameObject disconnectedScreen;
    public GameObject PleaseWait;
    public GameObject Historia;
    public static launcher instance;

    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(gameObject);
        PlayGamesPlatform.Activate();
        OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
    }

    void Start()
    {
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //PlayGamesPlatform.InitializeInstance(config);
        //PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform.Activate();
        SignIn();
    }

    // Update is called once per frame
    private void SignIn()
    {
        Social.localUser.Authenticate(success =>
        {
            OnConnectionResponse(success);
        });
    }

    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, (bool success) =>
        {

        });
    }

    public void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public void ShowAchievement()
    {
        Social.ShowAchievementsUI();
    }

    public void ShowAchievements()
    {
        instance.ShowAchievement();
    }

    public void OnConnectionResponse(bool authenticated)
    {
        if (authenticated)
        {
            PleaseWait.SetActive(true);
            disconnectedScreen.SetActive(false);
        }
        else
        {
            PleaseWait.SetActive(false);
            disconnectedScreen.SetActive(true);
        }
    }

    // Start is called before the first frame update
    public void On_Connect()
    {
        launcher.instance.UnlockAchievement(GPGSIds.achievement_play);
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Iki Konek Cok");
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
        Debug.Log("Iki Gak Konek");
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

    public void historya()
    {
        launcher.instance.UnlockAchievement(GPGSIds.achievement_history);
        Historia.SetActive(true);
        connectedScreen.SetActive(false);
        PleaseWait.SetActive(false);
        disconnectedScreen.SetActive(false);
    }

    public void backTomenu()
    {
        PleaseWait.SetActive(true);
        connectedScreen.SetActive(false);
        Historia.SetActive(false);
        disconnectedScreen.SetActive(false);
    }

    public void exitGemu()
    {
        Application.Quit();
    }
}
