using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TierraAgricola : MonoBehaviour
{
    [SerializeField]
    TextMeshPro porcentaje;

    [SerializeField]
    Transform Camera;

    [SerializeField]
    GameObject GOacercarse;


    string msg = "40 %";
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("AR Camera").GetComponent<Transform>();
    }



    // Update is called once per frame
    void Update()
    {

        if (calcularDistancia3d() < 2f)
        {
            GOacercarse.SetActive(false);
        }
        else
        {
            GOacercarse.SetActive(true);
        }

        porcentaje.text = msg;
    }

    public void cambiarMsg(float c)
    {
        msg = Mathf.RoundToInt(scale(0, 1, 40, 10, c)).ToString() + " %"; 
    }

    float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
    
    public float calcularDistancia3d()
    {
        Vector2 Objeto1 = new Vector2(Camera.position.x, Camera.position.z);
        Vector2 Objeto2 = new Vector2(GOacercarse.transform.position.x, GOacercarse.transform.position.z);
        float distancia = Vector2.Distance(Objeto1, Objeto2);

        return distancia;
    }
}
