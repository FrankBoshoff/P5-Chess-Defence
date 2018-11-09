using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuIndicator : MonoBehaviour {

    public Transform gems;

    public void ShowGem(RectTransform r)
    {
        gems.gameObject.SetActive(true);
        //gems.SetParent(r);
        gems.position = r.position;
    }

    public void HideGem()
    {
        gems.gameObject.SetActive(false);
    }
}
