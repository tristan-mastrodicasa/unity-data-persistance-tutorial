using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = GameManager.instance.BestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
