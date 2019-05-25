using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChagukiManager : MonoBehaviour
{
    Vector3 LastPos;
    [SerializeField]
    Camera _camera;
    Vector3 Motutoko;
    float Chaguki_rad=1.9f;
    [SerializeField]
    Sprite[] ChawanImage;
    [SerializeField]
    GameObject Chawan,ChagukiAnchor;
    Transform Chaguki;
    [SerializeField]
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
        //  Touch touch = Input.GetTouch(1);
        Chawan.GetComponent<SpriteRenderer>().sprite = ChawanImage[0];
        Chaguki = ChagukiAnchor.transform;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    Vector2 ReturnRad(Vector2 vec)
    {
        float r = vec.magnitude;

        // float x = Mathf.Floor(vec.x * 10) / 10.0f;
        //float y = Mathf.Floor(vec.y * 10) / 10.0f;

        float arc = -(float)System.Math.Atan2(vec.y, vec.x);
        return new Vector2(Mathf.Cos(arc) * r, Mathf.Sin(arc) * 2 * r);
    }

    public void HoldChaguki()
    {
        Vector3 touchpos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 DelitaVec = touchpos - LastPos;
        if ((DelitaVec).sqrMagnitude > 0.05)
        { audio.mute = false;
        }
        else
            audio.mute = true;
       
        Chaguki.Translate(new Vector3(DelitaVec.x, DelitaVec.y, 0), Space.World);
        Vector3 lp = Chaguki.transform.localPosition;
             if (lp.x * lp.x + lp.y * lp.y  > Chaguki_rad * Chaguki_rad)
        {

           Vector3 v= Vector3.Normalize(lp);
           Chaguki.transform.localPosition = new Vector3( v.x*Chaguki_rad, v.y * Chaguki_rad);
        }
       
        LastPos = touchpos;
    }
   
    public void Holdbegun()
    {
        LastPos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Holdend() {
        audio.mute = true;
    }
}
