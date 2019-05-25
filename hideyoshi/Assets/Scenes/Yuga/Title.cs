using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void ToSelect()
    {
        SceneManager.LoadSceneAsync("Select");
    }
}
