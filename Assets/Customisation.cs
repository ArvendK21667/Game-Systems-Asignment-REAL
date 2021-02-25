using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour
{

    private void OnGUI()
    {
        CustomiseOnGUI();
    }


    private void CustomiseOnGUI()

    {
        if(GUI.Button(new Rect(20, 40, 20, 20), "<"))
        {
            Debug.Log("Left");
        }
        
        GUI.Label(new Rect(45, 40, 60, 20), "Skin");

        if (GUI.Button(new Rect(90, 40, 20, 20), ">"))
        {

            Debug.Log("Right");
        }

        if (GUI.Button(new Rect(20, 40, 20, 20), "<"))
        {

            Debug.Log("Left");
        }
        GUI.Label(new Rect(45, 40, 60, 20),"Eye");
        if (GUI.Button(new Rect(90, 40, 20, 20), "y"))
        {

            Debug.Log("Right");
        }

        if (GUI.Button(new Rect(20, 40, 20, 20), "<"))
             {

            Debug.Log("Left");
        }
        GUI.Label(new Rect(45, 40, 60, 20), "Hair");
        if (GUI.Button(new Rect(90, 40, 20, 20), ">"))
        {

            Debug.Log("Right");
        }

    }

}
    














