using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandBehavior : MonoBehaviour
{
    public int score;

    [SerializeField] private GameObject cameraOb;
    [SerializeField] private GameObject curtain;
    [SerializeField] private float startPoint;
    [SerializeField] private float endPoint;
    [SerializeField] private float limitVel;
    [SerializeField] private float currentVel;
    [SerializeField] private int deduction;

    [SerializeField] private float testc;

    private float diff;
    private Touch touch;
    private float overRange;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, startPoint);
        camera = cameraOb.GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            TouchMove();
        }
    }

    void TouchMove()
    {
        float movement = camera.ScreenToWorldPoint(touch.deltaPosition).y + 5;
        testc = movement;
        currentVel = movement / touch.deltaTime;
        if (Mathf.Abs(currentVel) > limitVel)
        {
            overRange += movement;
        }
        transform.Translate(new Vector2(0, movement));
        if (transform.position.y > endPoint)
        {
            Finish(overRange);
        }
    }

    void Finish(float overRange)
    {
        score -= (int)overRange * deduction;
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        SpriteRenderer curtainRenderer = curtain.GetComponent<SpriteRenderer>();
        float t = 0;
        while (t < 1)
        {
            curtainRenderer.color = new Color(1f, 1f, 1f, t);
            t += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("Judge");
        yield break;
    }
}
