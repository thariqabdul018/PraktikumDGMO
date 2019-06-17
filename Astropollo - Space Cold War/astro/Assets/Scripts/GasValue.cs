using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasValue : MonoBehaviour
{
    Image Gas;
    public float maximumGas;
    public static float GasState;
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
    }
}
