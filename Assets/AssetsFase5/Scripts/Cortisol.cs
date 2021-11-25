using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cortisol : MonoBehaviour
{
    public float veg;

    [SerializeField]
    GameObject CerdoEnjaulado;

    [SerializeField]
    GameObject msgVeg;

    [SerializeField]
    Transform cortisol;

    [SerializeField]
    Transform Camera;

    [SerializeField]
    GameObject text;

    [SerializeField]
    GameObject GOacercarse;

    [SerializeField]
    TextMeshPro CortisolCrated;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("AR Camera").GetComponent<Transform>();
        msgVeg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (calcularDistancia3d() < 2.5f)
        {
            text.SetActive(true);
            GOacercarse.SetActive(false);
        }
        else
        {
            text.SetActive(false);
            GOacercarse.SetActive(true);
        }

        if (veg  == 1)
        {
            CerdoEnjaulado.SetActive(false);
            msgVeg.SetActive(true);
            cortisol.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            CortisolCrated.text = "Nivel de cortisol: 7.5 ng/ml";

        }
        else
        {
            CerdoEnjaulado.SetActive(true);
            msgVeg.SetActive(false);
            cortisol.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            CortisolCrated.text = "Nivel de cortisol: 25 ng/ml";
        }

        
    }

    public void change(float slider)
    {
        veg = slider;
    }

    public float calcularDistancia3d()
    {
        Vector2 Objeto1 = new Vector2(Camera.position.x, Camera.position.z);
        Vector2 Objeto2 = new Vector2(GOacercarse.transform.position.x, GOacercarse.transform.position.z);
        float distancia = Vector2.Distance(Objeto1, Objeto2);

        return distancia;
    }
}
