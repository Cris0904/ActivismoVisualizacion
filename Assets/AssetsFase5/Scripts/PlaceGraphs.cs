using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.UI;

public class PlaceGraphs : MonoBehaviour
{
    [SerializeField]
    GameObject m_PlacedPrefab;


    //[SerializeField]
    //GameObject JuegoDOA;

    public Camera camera;
    //public bool Colocar;
    float suelo = 0;
    Quaternion rotacion = new Quaternion(0, 0, 0, 0);

    [SerializeField]
    Text dist;

    Vector2 touchPosition = default;
    /*
    [SerializeField]
    PhysicsRaycaster raycasterPhysics;
     */

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }



    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }



    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        //PhysicsRayvasting();

        if (spawnedObject == null)
        {
            if (m_RaycastManager.Raycast(new Vector2(Random.Range(100, 1000), Random.Range(300, 1000)), s_Hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = s_Hits[0].pose;
                Hallarsuelo(hitPose.position.y);
                //dist.text = hitPose.position.x.ToString() + " /// " + hitPose.position.y.ToString();
                rotacion = hitPose.rotation;
            }
        }

        if (Input.touchCount > 0)
        {
            /*Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            //dist.text = touchPosition.x.ToString() + " /// " + touchPosition.y.ToString();

            //Vector3 dir = new Vector3 (touchPosition.x, touchPosition.y,50f);
            Ray ray = camera.ScreenPointToRay(touch.position);
            RaycastHit hitObject;
            //dist.text = "0";
            if (Physics.Raycast(ray, out hitObject))
            {
                //dist.text = "1";
                interaccionesCerdo interaccionesScript = hitObject.transform.gameObject.GetComponent<interaccionesCerdo>();

                if (interaccionesScript != null)
                {

                }
                else
                {
                    Mesa mesa = hitObject.transform.gameObject.GetComponent<Mesa>();

                    dist.text = "XD";
                    if (mesa != null)
                    {

                    }
                }
            }*/
        }

    }

    float Hallarsuelo(float hitposeY)
    {
        if (hitposeY < suelo)
        {
            suelo = hitposeY;
        }
        return suelo;
    }

    public void aparecerGraphs()
    {
        if (spawnedObject == null)
        {

            Vector3 cerca = new Vector3(camera.transform.position.x, suelo, camera.transform.position.z);
            spawnedObject = Instantiate(m_PlacedPrefab, cerca, rotacion);
            spawnedObject.transform.LookAt(camera.transform);
            var rotationVector = spawnedObject.transform.rotation.eulerAngles;
            rotationVector.z = 0;
            rotationVector.x = 0;
            rotationVector.y +=180;
            spawnedObject.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }



    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    ARRaycastManager m_RaycastManager;
    /*
    void PhysicsRayvasting()
    {
        PointerEventData data = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        raycasterPhysics.Raycast(data, results);

        results.RemoveAll(r => r.gameObject.tag == "plane");
    }*/
}
