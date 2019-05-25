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
    GameObject Chawan,ChagukiAnchor,Shibuki;
    Transform Chaguki;
    [SerializeField]
    AudioSource audio;
    Vector2 SumVec=Vector2.zero;
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
    bool shakeble = true;
    public void HoldChaguki()
    {
        if (shakeble)
        {
            Vector3 touchpos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 DelitaVec = touchpos - LastPos;
            SumVec += new Vector2(Mathf.Abs(DelitaVec.x), Mathf.Abs(DelitaVec.y));

            if ((DelitaVec).sqrMagnitude > 0.05)
            {
                audio.mute = false;
            }
            else
                audio.mute = true;

            Chaguki.Translate(new Vector3(DelitaVec.x, DelitaVec.y, 0), Space.World);
            Vector3 lp = Chaguki.transform.localPosition;

            LastPos = touchpos;
            Debug.Log(SumVec.y / SumVec.x);

            if (lp.sqrMagnitude > Chaguki_rad * Chaguki_rad)
            {

                Vector3 v = Vector3.Normalize(lp);
                Chaguki.transform.localPosition = new Vector3(v.x * Chaguki_rad, v.y * Chaguki_rad);
            }
            
            if (((new Vector2 (touchpos.x, touchpos.y)).sqrMagnitude > 6))
            {//こぼれる
                Debug.Log(LastPos);
                /*
                shakeble = false;
                float x = touchpos.x;
                float y = touchpos.y;
                 StartCoroutine(breaking(Vector2 vec); */
            }

        }
    }

    IEnumerator breaking(Vector2 vec) {
        
        Debug.Log("OK");
        GameObject shibuki = Instantiate(Shibuki);
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.1f);
            shibuki.transform.localPosition = vec / (6 - i);
            shibuki.transform.localScale=new Vector3(0.6f,0.6f,1) / (6 - i);
            
        }
        shakeble = true;
    }

    public void Holdbegun()
    {
        LastPos = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Holdend() {
        audio.mute = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.SetActive(false);
        
    }
    [SerializeField]
    GameObject ScoreText;
    IEnumerator AddScore10() {
        Debug.Log("Call");
        //360-500
      //  ScoreText=Instantiate(ScoreText,new Vector3(0, 360, 0),);
        ScoreText.SetActive(true);
        for (int i = 0; i < 28; i++)
        {
            ScoreText.transform.localPosition = new Vector3(0, 360 + 5 * i, 0);

            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.4f);
        ScoreText.SetActive(false);
    }
    int Score = 0;
    public void Go() {
        Debug.Log("Call");
        StartCoroutine("AddScore10");
        if (SumVec.magnitude < 400)
            Score += (int)SumVec.magnitude /10;
        else if (SumVec.magnitude > 1200)
            Score += 0;
        else if (SumVec.magnitude > 800)
            Score += (int)(1200 - SumVec.magnitude) / 10;
        else
            Score += 40;
        Debug.Log(SumVec.magnitude);
        if (SumVec.y / SumVec.x > 6)
            Score += 40;
        else
            Score += (int)(40 * SumVec.y /( SumVec.x*6));
        //Dama=20
        Debug.Log(Score);
    }
}
