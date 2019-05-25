using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChagukiManager : MonoBehaviour
{
    Vector3 LastPos;
    [SerializeField]
    Camera _camera;
    Vector3 Motutoko;
    float Chaguki_rad=4f;
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

    public void HoldChaguki()
    {
       //(Input.GetTouch(0).deltaPosition / Time.deltaTime * Time.deltaTime);
        Vector3 touchpos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 DelitaVec = touchpos - LastPos;
        if ((DelitaVec).sqrMagnitude > 0.05)
        { audio.mute = false;
        }
        else
            audio.mute = true;
        Debug.Log(DelitaVec);
        Chaguki.transform.position += new Vector3(DelitaVec.x, DelitaVec.y,0);
        
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
