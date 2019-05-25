using UnityEngine;


/// <summary>
/// シーン間の変数
/// </summary>
/// 

public enum Owan { };
public enum Feeling { };
public enum Chagashi { };
public class Parameters : MonoBehaviour
{
    public static Owan owan;
    public static Feeling feeling;
    public static Chagashi chagashi;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
