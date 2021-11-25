using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTransparency : MonoBehaviour
{
    public float trans;

    Renderer renderer;
    Color oldColor;
    Color NewColor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        oldColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10 * 1.5f * Time.deltaTime, 0, 0);

        NewColor = new Color(oldColor.r, oldColor.g, oldColor.b, trans);
        renderer.material.SetColor("_Color", NewColor);
        if(trans == 0)
        {
            renderer.enabled = false;
        }
        else
        {
            renderer.enabled = true;
        }
        // 100% Transparency.
    }

    public void Change(float transp)
    {
        trans = transp;
    }
    /*
    public void Change(float transp)
    {
        trans = scale(0, 1, 0, 255, transp);
    }

    float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }*/
}

