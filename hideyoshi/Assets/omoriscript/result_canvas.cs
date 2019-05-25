using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result_canvas : MonoBehaviour
{
    public Vector2 SPEED = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 800)
        {
            Move();
        }
    }
    
    private void Move()
    {
        Vector2 Position = transform.position;
        this.transform.position += Vector3.up * SPEED.y;
    }
}
