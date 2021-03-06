﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField] private RectTransform owan;
    [SerializeField] private RectTransform chagashi;

    private RectTransform window;
    public int page;
    private Vector3 before;
    private Vector3 after;
    private float t;
    private int max;

    private bool hint;

    private void Start()
    {
        page = 0;
        t = 0;
        max = 1;
        hint = false;
        before = Vector3.up * 360f;
        after = Vector3.up * 360f;
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
        switch (window.gameObject.name)
        {
            case "owanSelect":
                Parameters.owan = page;
                break;
            case "wagashiSelect":
                Parameters.chagashi = page;
                break;
        }

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
                Parameters.owan = page;
                break;
            case "wagashiSelect":
                max = 2;
                Parameters.chagashi = page;
                break;
        }
        page = 0;
        before = Vector3.up * 360f;
        after = Vector3.up * 360f;
    }

    public void HintDispplay()
    {
        if (hint)
        {

        }
        else
        {

        }
    }
}
