using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result_cal : MonoBehaviour
{
    public Text point;
    public Text grade;
    // Start is called before the first frame update
    void Start()
    {
        point = GetComponent<Text>();
        grade = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
