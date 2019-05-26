using UnityEngine;


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
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
