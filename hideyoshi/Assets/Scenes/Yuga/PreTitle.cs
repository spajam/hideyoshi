using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreTitle : MonoBehaviour
{
    public void ToTitle()
    {
        SceneManager.LoadSceneAsync("Select");
    }
}
