using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Habilities))]
public class Touch : MonoBehaviour
{
    public LayerMask touchInputMask;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private List<string> listaRunas = new List<string>();

    public Camera cam;

    //private RaycastHit hit;
    private Ray pulsacion;
    private RaycastHit colision;
    private RaycastHit hit;

    private bool cast = false;
    private List<GameObject> activeRunes = new List<GameObject>();
    public Color defaultColour;
    public Text texto;

    private Habilities habilities;

    void Start(){
        habilities = GetComponent<Habilities>();
    }

    void Update()
    {
        if (Input.touches.Length > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.Clear();
            cast = true;
            foreach (UnityEngine.Touch touch in Input.touches)
            {
                pulsacion = cam.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(pulsacion, out hit))
                {
                    //Objeto sobre el que trabajamos(Estamos tocando)
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    activeRunes.Add(recipient);

                    //Nombre de la runa
                    string nombreRuna = recipient.transform.name;

                    //Mostrara el nombre de la runa que tocamos por pantalla
                    //                texto.text = recipient.transform.name;
                    //Si no tiene la runa previamente añadida a la lista
                    bool coinciden = false;
                    foreach (string runa in listaRunas)
                    {
                        if (nombreRuna.Equals(runa))
                        {
                            coinciden = true;
                        }

                    }
                    //Si no ha coincidido
                    if (!coinciden)
                    {
                        listaRunas.Add(nombreRuna);
                    }

                    string concatenaRunas = "";

                    foreach (string runa in listaRunas)
                    {
                        concatenaRunas += runa;
                    }

                    // texto.text = concatenaRunas;

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", activeRunes, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchStay", activeRunes, SendMessageOptions.DontRequireReceiver);
                    }

                }
            }
            touchList.CopyTo(touchesOld);


            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else
        {
            texto.text = habilities.habilidadLanzada(listaRunas);
           
            //No se esta casteando
            cast = false;
            //Limpiamos la lista de runas
            activeRunes.Clear();
            listaRunas.Clear();
            //Ponesmo todas las runas a por defecto
            GameObject[] hexagonActive = GameObject.FindGameObjectsWithTag("Hexagon");
            foreach (GameObject hexagon in hexagonActive)
            {
                hexagon.SendMessage("OnTouchExit", activeRunes, SendMessageOptions.DontRequireReceiver);
            }

        }
    }
}

	
	
	

