using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text swordScore;
    public Text shieldScore;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwordIncriment(int score)
    {
        string scoreString = score.ToString();
        swordScore.text = scoreString;
      // swordScore = GameObject.Find("ScoreSword").GetComponent<Text>();
    }
    public void ShieldIncriment(int score)
    {
        string scoreString = score.ToString();
        shieldScore.text = scoreString;
    }
}
