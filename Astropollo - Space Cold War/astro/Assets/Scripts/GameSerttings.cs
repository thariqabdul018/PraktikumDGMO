using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSerttings : MonoBehaviour
{
    public static GameSerttings GS;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (GameSerttings.GS == null)
        {
            GameSerttings.GS = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
