using UnityEngine;


/// <summary>
/// シーン間の変数
/// </summary>
public class Parameters : MonoBehaviour
{
    public static int owan,feelings,maze;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
