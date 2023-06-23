using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static System.Math;

public class CameraDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;

    private MeshRenderer render;

    private Plane[] cameraFrustum;

    private Bounds bounds;

    public bool isSeen;

    public TextMeshProUGUI pressF;

    public GameObject character;

    private Vector3 difference;

    private Vector3 desired;

    private Vector3 bigDesired;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        bounds = GetComponent<Collider>().bounds;

        desired = new Vector3(5, 5, 5);
        bigDesired = new Vector3(55, 5, 230);
    }

    // Update is called once per frame
    void Update()
    {
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);

        difference = transform.position - camera.transform.position;

        if (checkDistance())
        {

            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds) && gameObject.CompareTag("Bucket") &&
                !character.GetComponent<PickingEngine>().isPicked)
            {
                pressF.text = "Presiona F para coger el cubo";
                isSeen = true;
            }
             
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds) && gameObject.CompareTag("fire"))
            {
                pressF.text = "Presiona F para apagar el fuego";
                isSeen = true;
            }

        }
        else if(checkBigDistance() && gameObject.CompareTag("water"))
        {
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds) && !character.GetComponent<PickingEngine>().isFilled &&  character.GetComponent<PickingEngine>().isPicked && !character.GetComponent<PickingEngine>().isFilled)
            {
                Debug.Log("Aquí");
                pressF.text = "Presiona F para llenar el cubo";
                isSeen = true;
            }
        }
        else
        {
            isSeen = false;
            pressF.text = "";
        }
        
        
}
    
    private bool checkDistance()
    {
        return Math.Abs(difference.x) < desired.x && Math.Abs(difference.y) < desired.y &&
               Math.Abs(difference.z) < desired.z;
        
    }
    
     private bool checkBigDistance()
        {
            return Math.Abs(difference.x) < bigDesired.x && Math.Abs(difference.y) < bigDesired.y &&
                   Math.Abs(difference.z) < bigDesired.z;
            
        }
}
