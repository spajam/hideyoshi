using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// シーン間の変数
/// </summary>
/// 
public class Parameters : MonoBehaviour
{
    public static int owan;
    public static int chagashi;
    public static int feeling;
    public static int Mazescore;
    public static float douzo;
    private void Awake()
    {
        //selectの都合上owan,chagashi未選択を-1にする。
        owan = -1;
        chagashi = -1;
        DontDestroyOnLoad(this.gameObject);
    }


    //以下中野が具体的な数値を記述
    public static float charaPersonality = 0;//キャラの性格:x
    public static float charaFeeling = 8f;//キャラの気分:b
    public static float charaHealth = 7f;//キャラの健康状態:h
    public static List<float> owans = new List<float>() { -2, 5 };
    public static List<float> chagashis = new List<float>() { -3, 4, 8 };
    //説明：キャラ性格のxと茶菓子・お椀のaが近いほど相性がいい。気分・健康状態が高いほどスコアが下がりにくい。

}
