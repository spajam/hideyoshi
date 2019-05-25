using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChagukiManager : MonoBehaviour
{
    Vector3 LastPos;
    [SerializeField]
    Camera _camera;
    Vector3 Motutoko;
    float Chaguki_rad=2f;
    [SerializeField]
    Sprite[] ChawanImage;
    [SerializeField]
    GameObject Chawan,ChagukiAnchor;
    Transform Chaguki;
    [SerializeField]
    AudioClip Shake;
    // Start is called before the first frame update
    void Start()
    {
       
      //  Touch touch = Input.GetTouch(1);
        Chawan.GetComponent<SpriteRenderer>().sprite = ChawanImage[0];
        Chaguki = ChagukiAnchor.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void HoldChaguki() {
        Debug.Log(_camera.ScreenToWorldPoint(Input.mousePosition));
        Vector3 touchpos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 deltaPos = LastPos - touchpos;
        Chaguki.transform.position = new Vector3(touchpos.x, touchpos.y,0);
        LastPos = touchpos;
    }
}
