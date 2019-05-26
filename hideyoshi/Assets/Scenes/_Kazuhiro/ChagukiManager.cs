using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChagukiManager : MonoBehaviour
{
    Vector3 LastPos;
    [SerializeField]
    Camera _camera;
    Vector3 Motutoko;
    float Chaguki_rad=0.6f;
   
    [SerializeField]
    GameObject Chawan,ChagukiAnchor,Shibuki,Dama;
    Transform Chaguki;
    [SerializeField]
    AudioSource audio;
    Vector2 SumVec=Vector2.zero;
    [SerializeField]
    SpriteRenderer[] Macha;
    int favkosa;
    // Start is called before the first frame update
    void Start()
    {
        Machacolor = 0;
           favkosa = Random.Range(3, 3);
        kosalevel = 1;
        Score = 0;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(1);
        }
        Chaguki = ChagukiAnchor.transform;
        Debug.Log(favkosa);
        DamaCrea();
        DamaCrea();
    }

    void DamaCrea() {
        float r = Random.Range(0.4f, Chaguki_rad-0.2f);
        float d = Random.Range(0, 2 * Mathf.PI);
        GameObject dama = Instantiate(Dama, new Vector3(r*Mathf.Cos(d), r * Mathf.Sin(d), 0), Quaternion.Euler(0, 0, Random.Range(-10, 10)));
        dama.SetActive(true);
    }

    [SerializeField]
    Slider Azibar;
    int kosalevel=1;
    int Machacolor = 1;
    // Update is called once per frame
    void Update()
    {
        float kosa = SumVec.magnitude;
        if ( kosalevel * 100< kosa)
        {
            
            if (kosalevel < favkosa+1)
                StartCoroutine("AddScore10");
            else 
            StartCoroutine("NoScore");
            if (kosalevel == 2)
                Machacolor++;
            kosalevel++;
        }
        Azibar.value = kosa;
        if (kosa < 400)
        {
            Color c = Macha[Machacolor].color;
            Macha[Machacolor].color = new Color(c.r, c.g, c.b, 255 * (200 - (kosa % 200)));
        }
    }
    bool shakeble = true;
    public void HoldChaguki()
    {
        Vector3 touchpos = new Vector3();
        Vector3 DelitaVec = new Vector3();
        if (Input.touchCount > 0)
        {
            touchpos = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            DelitaVec = touchpos - LastPos;

        }
        else { touchpos = _camera.ScreenToWorldPoint(Input.mousePosition);
            DelitaVec = touchpos - LastPos;
        }

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
        if (shakeble)
        {
            if (((new Vector2(touchpos.x, touchpos.y-0.4f)).sqrMagnitude > 18))
            {//こぼれる
                Debug.Log(LastPos);

                shakeble = false;
                float x = touchpos.x;
                float y = touchpos.y;
                StartCoroutine(breaking(touchpos));
                StartCoroutine("NoScore");
            }
        }
        
    }

    IEnumerator breaking(Vector2 vec) {
        
        Debug.Log("OK");
        GameObject shi = Instantiate(Shibuki, new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0), Quaternion.Euler(0,0,Random.Range(0,180)));
        shi.transform.localScale = Vector3.zero;
        shi.SetActive(true);
        for (int i = 0; i < 12; i++)
        {
           
            shi.transform.localPosition = vec / (12 - i);
            shi.transform.localScale=new Vector3(0.6f,0.6f,1) / (12 - i);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        shakeble = true;
        Color c = shi.GetComponent<SpriteRenderer>().color;
            for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.2f);
            c = new Color(c.r, c.g, c.b, c.a -0.01f);
            shi.GetComponent<SpriteRenderer>().color = c;
        }

    }

    public void Holdbegun()
    {
        LastPos = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
    }
    public void Holdend() {
        audio.mute = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.SetActive(false);
        StartCoroutine("AddScore10");

    }
    [SerializeField]
    GameObject ScoreText, ScoreText2;


    IEnumerator NoScore()
    {
        Score -= 5;
        GameObject scoreText = Instantiate(ScoreText2, new Vector3(0, 360, 0), Quaternion.identity, ScoreText2.transform.parent);
        
        scoreText.SetActive(true);
        for (int i = 0; i < 28; i++)
        {
            scoreText.transform.localPosition = new Vector3(0, 360 + 5 * i, 0);

            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.4f);
        Destroy(scoreText);
    }

    IEnumerator AddScore10() {
        Score += 10;
        //360-500
        GameObject scoreText=Instantiate(ScoreText,new Vector3(0, 360, 0),Quaternion.identity, ScoreText.transform.parent);
        scoreText.SetActive(true);
        for (int i = 0; i < 28; i++)
        {
            scoreText.transform.localPosition = new Vector3(0, 360 + 5 * i, 0);

            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.4f);
        Destroy(scoreText);
    }
    int Score = 0;
    public void Go() {
       
        StartCoroutine("Nonoji");
        
        
        if (SumVec.y / SumVec.x > 6)
            Score += 40;
        else
            Score += (int)(40 * SumVec.y /( SumVec.x*6));
        Score=Score * 10 / (6 + favkosa);

        Parameters.Mazescore = Score;


    }

    IEnumerator Nonoji()
    {
        Chaguki.GetComponent<Animator>().speed = 0.6f;
        for (int i = 0; i < 28; i++)
        {
            Chaguki.transform.localPosition = Chaguki.transform.localPosition*(27-i)/27;
            
            yield return new WaitForSeconds(0.02f);
            if (Chaguki.transform.localPosition == Vector3.zero)
                break;
        }
        Chaguki.GetComponent<Animator>().SetTrigger("Nonoji");
        yield return new WaitForSeconds(5f);
       SceneManager.LoadScene("Douzo");
    }
}
