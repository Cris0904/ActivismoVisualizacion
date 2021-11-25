using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AguaController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> tanques;

    public float slider;
    public float aguakm;

    [SerializeField]
    Transform Camera;

    [SerializeField]
    GameObject text;

    [SerializeField]
    GameObject GOacercarse;

    [SerializeField]
    TextMeshPro Agua;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("AR Camera").GetComponent<Transform>();
        for (int i = 0; i < 9; i++)
        {
            tanques[i].SetActive(false);
        }
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

        for (int j = 0; j < 9; j++)
        {
            tanques[j].SetActive(false);
        }

        for (int i= 0; i<slider; i++)
        {
            tanques[i].SetActive(true);
        }

        if (slider == 8)
        {
            tanques[8].SetActive(true);
        }
        
        int km = Mathf.RoundToInt(1767 + aguakm);

        Agua.text =km.ToString() + " km3";

    }

    public void Change(float trans)
    {
        slider = Mathf.RoundToInt(scale(0, 1, 0, 8, trans));
        aguakm = Mathf.RoundToInt(scale(0, 1, 0, 883, trans));
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
        Vector2 Objeto1 = new Vector2(Camera.position.x,Camera.position.z);
        Vector2 Objeto2 = new Vector2(GOacercarse.transform.position.x, GOacercarse.transform.position.z);
        float distancia = Vector2.Distance(Objeto1, Objeto2);

        return distancia;
    }

}
