using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    [SerializeField] GameObject gameobject;
    public bool torigger;
   public void Ontouch()
    {
        torigger = !torigger;
        gameobject.SetActive(torigger);
    }
}
