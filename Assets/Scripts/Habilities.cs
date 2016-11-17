using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Habilities : MonoBehaviour
{

    //private List<string> listaRunasHabilidad = new List<string>() { "Fuego1", "Fuego2", "Fuego3" };
    private List<string> habilidad1 = new List<string>() { "Fuego1" };
    [SerializeField]
    private GameObject goh1;
    private List<string> habilidad2 = new List<string>() { "Fuego1", "Fuego2", "Fuego3" };
    [SerializeField]
    private GameObject goh2;
    private List<string> habilidad3 = new List<string>() { "Fuego1", "Fuego2", "Fuego3", "Fuego4", "Fuego5", "Fuego6" };
    [SerializeField]
    private GameObject goh3;

    public string habilidadLanzada(List<string> listaRunas) {
        if (comprobacionHabilidadCorrecta(listaRunas, habilidad1))
        {
            GameObject go = Instantiate(goh1);
            Destroy(go, 2);
            return "Has seleccionado la habilidad 1";
        }else if (comprobacionHabilidadCorrecta(listaRunas, habilidad2))
        {
            GameObject go = Instantiate(goh2);
            Destroy(go, 2);
            return "Has seleccionado la habilidad 2";
        }
        else if (comprobacionHabilidadCorrecta(listaRunas, habilidad3))
        {
            GameObject go = Instantiate(goh3);
            Destroy(go, 2);
            return "Has seleccionado la habilidad 3";
        }
        else
        {
            return "Lanza Hechizo!!!";
        }               
    }

    private bool comprobacionHabilidadCorrecta(List<string> listaRunas, List<string> habilidad)
    {
        if (listaRunas.Count > 0 && listaRunas.Count == habilidad.Count)
        {
            bool habilidadErronia = false;
            bool contieneRuna = false;
            foreach (string runa in listaRunas)
            {
                foreach (string runaHabilidad in habilidad)
                {
                    contieneRuna = false;
                    if (runa.Equals(runaHabilidad))
                    {
                        contieneRuna = true;
                        break;
                    }
                }
                if (!contieneRuna)
                {
                    habilidadErronia = true;
                    break;
                }
                else
                {
                    habilidadErronia = false;
                }
            }

            if (!habilidadErronia)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
