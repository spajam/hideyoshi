using UnityEngine;


/// <summary>
/// シーン間の変数
/// </summary>
/// 
public enum Owan { };
public enum Chagashi { };
public  enum Feeling { };
public class Parameters : MonoBehaviour
{
    public static Owan owan;
    public static Chagashi chagashi;
    public static Feeling feeling;
    public static int Mazescore;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
