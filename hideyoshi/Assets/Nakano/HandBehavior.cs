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
    private float overRange = 1;
    private Camera camera;

    private bool flag = false;//trueで茶碗の移動off

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, startPoint);
        camera = cameraOb.GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && flag == false)
        {
            touch = Input.GetTouch(0);
            TouchMove();
        }
    }

    /// <summary>
    /// 茶碗の移動、減点距離の加算、Finish関数の呼び出し
    /// </summary>
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
        transform.position = new Vector2(0, Mathf.Clamp(transform.position.y, startPoint, endPoint));
        if (transform.position.y >= endPoint)
        {
            Finish(overRange);
        }
    }

    /// <summary>
    /// 終了、フェードしてシーン遷移するコルーチンの呼び出し
    /// </summary>
    /// <param name="overRange">減点距離</param>
    void Finish(float overRange)
    {
        flag = true;
        score = (int)(score / (overRange * deduction));
        Parameters.douzo = overRange * deduction;
        Debug.Log(" O: " + overRange * deduction);
        StartCoroutine(Transition());
    }

    /// <summary>
    /// フェードエフェクト、シーン遷移
    /// </summary>
    /// <returns></returns>
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
        SceneManager.LoadScene("Jucdge");
        yield break;
    }
}
