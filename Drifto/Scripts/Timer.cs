using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject az;

    float currentTime = 0f;
    Car c;

    [SerializeField] Text _timer;
    [SerializeField] Text _info;
    [SerializeField] Text _endScreen;
    [SerializeField] Text _tryAgain;
    [SerializeField] Text _text;

    public bool flag = false;
    bool b = true;

    void Start()
    {
        c = az.GetComponent < Car > ();
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool restart = Input.GetKey(KeyCode.R);
        if (restart)
        {
            currentTime = 0;
            _timer.text = "0";
            flag = false;
            c.enabled = true;
            _endScreen.enabled = false;
            _tryAgain.enabled = false;
            _timer.enabled = true;
            _text.enabled = true;
            b = true;
        }

        if (currentTime == 0)
        {
            _info.text = "Forward: UpArrow or w\nBack: DownArrow or s\nLeft:LeftArrow or a\nRight:RightArrow or d\nRestart: R\nEnd Game: ESC";
        }
        else
        {
            _info.enabled = false;
        }

        //kraj
        if (!c.enabled && b)
        {
            b = false;
            _endScreen.enabled = true;
            _endScreen.text = "TIME: " + currentTime.ToString("0");
            _tryAgain.enabled = true;
            _timer.enabled = false;
            _text.enabled = false;
        }    

        bool start = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        if (start)
        {
            flag = true;
        }
        if (flag)
        {
            currentTime += 1 * Time.deltaTime;
            _timer.text = currentTime.ToString("0");
        }

    

    }
}
