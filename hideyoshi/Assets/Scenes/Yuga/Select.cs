using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField] private RectTransform owan;
    [SerializeField] private RectTransform chagashi;
    [SerializeField] private RectTransform selected;

    private RectTransform window;
    public int page;
    private Vector3 before;
    private Vector3 after;
    private float t;
    private int max;

    private int cur_owan;
    private int cur_chagashi;

    private void Start()
    {
        cur_owan = 0;
        cur_chagashi = 0;

        page = 0;
        t = 0;
        max = 1;
        before = Vector3.up * 300f;
        after = Vector3.up * 300f;
        window = owan;
        window.gameObject.SetActive(true);
    }

    private void Update()
    {
        t += Time.deltaTime * 1f;
        window.position = Vector3.Lerp(before, after, t);
    }

    public void Slide(int next)
    {
        //修正予定
        t = 0;
        if(page < max && next == 1)
        {
            page++;
        }
        if (page > 0 && next == -1)
        {
            page--;
        }
        before = window.position;
        after = new Vector3(-720f * page, 300f, 0);
    }

    public void SelectedTransform(float x)
    {
        selected.anchoredPosition = new Vector2(x, 600f);
    }

    public void ToMazemaze()
    {
        Parameters.owan = cur_owan;
        Parameters.chagashi = cur_chagashi;
        SceneManager.LoadSceneAsync("Mazemaze");
        //switch (window.gameObject.name)
        //{
        //    case "owanSelect":
        //        //逆??
        //        Parameters.owan = Parameters.owans[page];
        //        Debug.Log("お椀に代入 = " + Parameters.owan);
        //        break;
        //    case "wagashiSelect":
        //        //逆??
        //        Parameters.chagashi = Parameters.chagashis[page];
        //        Debug.Log("茶菓子に代入 = " + Parameters.chagashi);
        //        break;
        //}

    }

    public void ModeSelect(GameObject mode)
    {
        window.gameObject.SetActive(false);
        window = mode.GetComponent<RectTransform>();
        window.gameObject.SetActive(true);
        switch (mode.name)
        {
            case "owanSelect":
                max = 1;
                Parameters.chagashi = cur_chagashi;
                Debug.Log("茶菓子に代入 = " + Parameters.chagashi);
                break;
            case "wagashiSelect":
                max = 2;
                Parameters.owan = cur_owan;
                Debug.Log("お椀選択 = " );
                break;
        }
        page = 0;
        before = Vector3.up * 300f;
        after = Vector3.up * 300f;
    }
}
