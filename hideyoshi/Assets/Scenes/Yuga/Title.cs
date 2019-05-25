using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private Image titleBack;
    [SerializeField] private Text comment;
    [SerializeField] private string[] selives;
    [SerializeField] private Animator titleAnim;
    
    private void SetFeeling()
    {
        int num = Random.Range(0, 3);
        titleBack.sprite = images[num];
        comment.text = selives[num];
    }

    public void ToSelect()
    {
        titleAnim.SetTrigger("ToSelect");
    }
}
