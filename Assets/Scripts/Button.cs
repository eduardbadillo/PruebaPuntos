using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button : MonoBehaviour {

    //public Color defaultColour;
    //public Color selectedColour;
    //public Color stayColor;
    public Material materialReposo;
    public Material materialActivo;


    void Start()
    {
        GetComponent<Renderer>().material = materialReposo;
        //mat = GetComponent<Renderer>().material;
        //mat.color = defaultColour;
    }

    void OnTouchDown(List<GameObject> activeRunes)
    {
        GetComponent<Renderer>().material = materialActivo;
    }

    void OnTouchUp(List<GameObject> activeRunes)
    {
        GetComponent<Renderer>().material = materialReposo;
        //foreach (GameObject runes in activeRunes)
        //{
        //    runes.GetComponent<Renderer>().material.color = defaultColour;
        //}
        //mat.color = defaultColour;
    }

    void OnTouchStay(List<GameObject> activeRunes)
    {
        GetComponent<Renderer>().material = materialActivo;
    }

    void OnTouchExit(List<GameObject> activeRunes)
    {
        //mat.color = defaultColour;
        GetComponent<Renderer>().material = materialReposo;
    }
}
