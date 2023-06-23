using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static System.Math;

public class PhoneDetector : MonoBehaviour
{
    public Camera camera;
    
        private MeshRenderer render;
    
        private Plane[] cameraFrustum;
        
        private Bounds bounds;
        
        private Vector3 desired;
        
        private Vector3 difference;
        
        public bool isSeen;

        public TextMeshProUGUI pressF;
        

        
    
    
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        bounds = GetComponent<Collider>().bounds;
        
        desired = new Vector3(5, 5, 5);
        isSeen = false;
    }

    // Update is called once per frame
    void Update()
    {
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);

        difference = transform.position - camera.transform.position;

        if (checkDistance())
        {
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds) && gameObject.CompareTag("phone"))
            {
                pressF.text = "Presiona F para llamar al helicóptero";
                isSeen = true;
            }
        }
        
    }
    
    
    
    private bool checkDistance()
    {
        return Math.Abs(difference.x) < desired.x && Math.Abs(difference.y) < desired.y &&
               Math.Abs(difference.z) < desired.z;
        
    }
}
