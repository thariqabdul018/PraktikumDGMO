using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class o2countdown : MonoBehaviour
{
    public static int oCount = 10;
    public Text countDownTxt;
    public GameObject sovietMenang;
    public GameObject unitedStatesMenang;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        countDownTxt.text = ("Oxygen = " + oCount);
        if (oCount <= 0)
        {
            StopCoroutine("LoseTime");
            countDownTxt.text = ("OXYGEN HAS RUN OUT!");
            Time.timeScale = 0;
            /*if (score.scorePyTwo > score.scorePyOne)
            {
                Application.LoadLevel("usamenang");
            }*/
            if (score.scorePyOne > score.scorePyTwo)
            {
                sovietMenang.gameObject.SetActive(true);
            }

            if (score.scorePyOne < score.scorePyTwo)
            {
                unitedStatesMenang.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            oCount--;
        }
    }
}
