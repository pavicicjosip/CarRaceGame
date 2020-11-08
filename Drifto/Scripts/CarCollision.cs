
using System.Threading;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public Car movement;

    bool cp1 = false;
    bool cp2 = false;
    bool cp3 = false;
    bool cp4 = false;
    bool cp5 = false;
    bool cp6 = false;
    bool cp7 = false;
    bool cp8 = false;
    bool cp9 = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))  //ugasi igru
            Application.Quit();

        if (Input.GetKey(KeyCode.R))
        {
            cp1 = false;
            cp2 = false;
            cp3 = false;
            cp4 = false;
            cp5 = false;
            cp6 = false;
            cp7 = false;
            cp8 = false;
            cp9 = false;
        }    
    }

    void OnTriggerEnter(Collider col)
    {

        switch(col.name)
        {
            case "Start":
                if (cp1 && cp2 && cp3 && cp4 && cp5 && cp6 && cp7 && cp8 && cp9)
                    movement.enabled = false;
                break;
            case "CheckPoint1": cp1 = true; Debug.Log(cp1); break;
            case "CheckPoint2": cp2 = true; Debug.Log(cp2); break;
            case "CheckPoint3": cp3 = true; Debug.Log("CheckPoint3"); break;
            case "CheckPoint4": cp4 = true; Debug.Log("CheckPoint4"); break;
            case "CheckPoint5": cp5 = true; Debug.Log("CheckPoint5"); break;
            case "CheckPoint6": cp6 = true; Debug.Log("CheckPoint6"); break;
            case "CheckPoint7": cp7 = true; Debug.Log("CheckPoint7"); break;
            case "CheckPoint8": cp8 = true; Debug.Log("CheckPoint8"); break;
            case "CheckPoint9": cp9 = true; Debug.Log("CheckPoint9"); break;
            default: break;
        }               
    }
}
