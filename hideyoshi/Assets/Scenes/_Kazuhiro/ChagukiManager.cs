using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChagukiManager : MonoBehaviour
{
    
    float Chaguki_rad=0.2f;
    [SerializeField]
    GameObject Chawan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(1);
        Vector3 touchpos=Input.mousePosition;
    }
}
