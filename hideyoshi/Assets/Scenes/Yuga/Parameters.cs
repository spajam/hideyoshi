using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// シーン間の変数
/// </summary>
/// 
public class Parameters : MonoBehaviour
{
    private static int _owan;
    private static int _chagashi;
    public static int owan
    {
        get
        {
            return _owan;
        }
        set
        {
            _owan = owans[value];
        }
    }
    public static int chagashi
    {
        get
        {
            return _chagashi;
        }
        set
        {
            _chagashi = chagashis[value];
        }
    }
    public static float feeling;
    public static float Mazescore;
    public static float douzo;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //以下中野が具体的な数値を記述
    public static float charaPersonality = 0;//キャラの性格:x
    public static float charaFeeling = 8f;//キャラの気分:b
    public static float charaHealth = 7f;//キャラの健康状態:h
    public static List<int> owans = new List<int>() { -2, 5 };
    public static List<int> chagashis = new List<int>() { -3, 4, 8 };
    //説明：キャラ性格のxと茶菓子・お椀のaが近いほど相性がいい。気分・健康状態が高いほどスコアが下がりにくい。

}
