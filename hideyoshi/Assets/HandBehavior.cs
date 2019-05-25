using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private float startPoint;
    [SerializeField] private float endPoint;
    [SerializeField] private float limitAcceleration;
    [SerializeField] 
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, startPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 vector2 = new Vector2(0, Input.GetTouch(0).position.y);
            transform.position = camera.GetComponent<Camera>().ScreenToWorldPoint();
        }
    }
}
