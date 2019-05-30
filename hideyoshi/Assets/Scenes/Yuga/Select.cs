using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] private RectTransform owan;
    [SerializeField] private RectTransform chagashi;
    [SerializeField] private RectTransform selected;
    [SerializeField] private RectTransform check;
    [SerializeField] private Animator anim;
    [SerializeField] private Image button;

    private RectTransform window;
    public int page;
    private Vector3 before;
    private Vector3 after;
    private float t;
    private int elements;

    private void Awake()
    {
        page = 0;
        t = 0;
        elements = 1;
        before = Vector3.up * 300f;
        after = Vector3.up * 300f;
        window = owan;
    }
    private void Start()
    {
        window.gameObject.SetActive(true);
    }

    private void Update()
    {
        t += Time.deltaTime * 1f;
        window.position = Vector3.Lerp(before, after, t);
    }

    public void Slide(int next)
    {
        t = 0;
        if(page < elements && next == 1)
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

    public void ModeSelect(GameObject mode)
    {
        window.gameObject.SetActive(false);
        window = mode.GetComponent<RectTransform>();
        window.gameObject.SetActive(true);

        switch (mode.name)
        {
            case "owanSelect":
                elements = 1;
                if (Parameters.owan < 0)
                {
                    page = 0;
                    window.position = before = after = Vector3.up*300f;
                }
                else
                {
                    page = Parameters.owan;
                    check.gameObject.transform.SetParent(window.transform.GetChild(page).GetChild(0));
                    check.anchoredPosition = Vector2.zero;
                    window.position = before = after = new Vector3(-page * 720f, 300f, 0);
                }
                break;
            case "chagashiSelect":
                elements = 2;
                if (Parameters.chagashi < 0)
                {
                    page = 0;
                    window.position = before = after = Vector3.up * 300f;
                }
                else
                {
                    page = Parameters.chagashi;
                    check.gameObject.transform.SetParent(window.transform.GetChild(page).GetChild(0));
                    check.anchoredPosition = Vector2.zero;
                    window.position = before = after = new Vector3(-page * 720f,300f,0);
                }
                break;
        }
    }

    public void Determine()
    {
        check.gameObject.transform.SetParent(window.transform.GetChild(page).GetChild(0));
        switch (window.gameObject.name)
        {
            case "owanSelect":
                Parameters.owan = page;
                check.anchoredPosition = Vector2.zero;
                break;
            case "chagashiSelect":
                Parameters.chagashi = page;
                check.anchoredPosition = Vector2.zero;
                break;
        }
        if (IsSelected())
        {
            button.color = Color.white;
        }
    }

    public void ToMazemaze()
    {
        if (!IsSelected())
        {
            anim.SetTrigger("Warning");
            return;
        }
        SceneManager.LoadSceneAsync("Mazemaze");
    }
    private bool IsSelected()
    {
        if (Parameters.owan==-1) return false;
        if (Parameters.chagashi==-1) return false;
        return true;
    }
}
