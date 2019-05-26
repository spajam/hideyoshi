using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class result_cal : MonoBehaviour
{
    public Text point;
    public Text grade;
    // Start is called before the first frame update
    void Start()
    {

        point = GameObject.Find("point").GetComponent<Text>();
        grade = GetComponent<Text>();
        float result = Math.Abs(cal()*1000);

        point.text = result.ToString();
    }
    public float cal()
    {
        float m, a, x, h, b, r, c, s, o;
        m = Parameters.Mazescore;
        a = Parameters.owan;
        x = Parameters.charaPersonality;
        h = Parameters.charaHealth;
        b = Parameters.charaFeeling;
        o = Parameters.douzo;
        s = (float)Math.Exp((-1) * (Math.Pow(x - a, 2)) / (Math.Pow(h, 2)));
        c = (float)Math.Exp((-1) * (Math.Pow(x - a, 2)) / (Math.Pow(b, 2)));
        r = (c + s - m) / o;
        return r;
    }
}
