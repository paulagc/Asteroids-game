using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    float elapsedTime;
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        elapsedTime = 0;
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedTime += Time.deltaTime;
            int elapsedInt = (int)elapsedTime;
            scoreText.text = elapsedInt.ToString();
        }

    }

    public void StropGameTimer()
    {
        running = false;
    }
}
