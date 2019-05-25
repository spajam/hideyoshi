using UnityEngine;


/// <summary>
/// シーン間の変数
/// </summary>
/// 

public enum Owan { };
public enum Feeling { };
public class Parameters : MonoBehaviour
{
    public static Owan owan;
    public static Feeling feeling;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
