using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    [SerializeField]public Text scoreText;
    public static GameManager inst;
    [SerializeField] playerMovement pm;
    public void IncrementScore()
    {
        score++;
        scoreText.text="SCORE: "+score;
        pm.speed+=pm.speedIncreasePerPoint;
    }
    private void Awake()
    {
        inst=this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
