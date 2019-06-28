using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasValue : MonoBehaviour
{
    Image Gas;
    public float maximumGas;
    public static float GasState;
    public GameObject playerPrefab;
    public bool cok = false;
    // Start is called before the first frame update
    void Start()
    {
       
        maximumGas = 100f;
        Gas = GetComponent<Image>();
        GasState = maximumGas;
    }

    // Update is called once per frame
    void Update()
    {
        Gas.fillAmount = GasState / maximumGas;
        if (playerPrefab.gameObject.tag == "Player1")
        {
            Gas.tag = "Gasku";
            cok = true;
            this.gameObject.tag = "Gasku";
        }
        else if (playerPrefab.gameObject.tag == "Player2")
        {
            Gas.tag = "Gasku";
            this.gameObject.tag = "Gasmu";
        }
    }
}
