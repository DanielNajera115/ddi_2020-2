using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleEngine : MonoBehaviour
{
    public GameObject[] objects;
    public Text timeLabel,pointLabel;
    private float timeLeft = 5f;
    private float[] timeArray = {5f,4f,3f};
    public bool isPressed = false;
    private int points=0;
    public int lastCard = 0, newCard = 4;

    void Start()
    {
        for(int i=0;i<4;i++){
            objects[i].SetActive(false);
        }
        objects[newCard].SetActive(true);
    }

    private void SetTime(){
        if(points < 50){
            timeLeft = timeArray[0];
        }else if(points < 70){
            timeLeft = timeArray[1];
        }else{
            timeLeft = timeArray[2];
        }
    }
    public void SetPressed(bool pressedPoints){
            SetTime();
            lastCard = newCard;
            newCard=Random.Range(0,4);
            objects[newCard].SetActive(true);
            objects[lastCard].SetActive(false);
            if(pressedPoints)
                points +=2;
            else
                points -=1;
        pointLabel.text = points.ToString();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLabel.text = timeLeft.ToString("0.0"); 

        if(timeLeft < 0.2){
            SetPressed(false);
        }
    }
}
