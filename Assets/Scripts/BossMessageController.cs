using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossMessageController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textmesh;
    void Start()
    {
        textmesh = GetComponentInChildren<TextMeshProUGUI>();
    }


    public Canvas canvas;



    void Update()

    {
        canvas.transform.rotation = Camera.main.transform.rotation;
    }

    public float ShowText(string str)
    {
        textmesh.SetText(LanguageManager.Instance.GetString(str));
        return 2.0f;
    }
}
