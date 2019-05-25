using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField] private RectTransform window;
    public int page;
    private Vector3 before;
    private Vector3 after;
    float t;
    int max;

    private void Start()
    {
        page = 0;
        t = 0;
        max = 2;
        before = Vector3.up * 360f;
        after = Vector3.up * 360f;
    }

    private void Update()
    {
        t += Time.deltaTime * 1f;
        window.position = Vector3.Lerp(before, after, t);
    }

    public void Slide(int next)
    {
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
        after = new Vector3(-720f * page, 360f, 0);
    }

    public void ToMazemaze()
    {
        SceneManager.LoadSceneAsync("Mazemaze");
        Parameters.owan = page;
    }
}
