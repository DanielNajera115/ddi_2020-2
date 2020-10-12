using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOption : MonoBehaviour
{
    private bool pauseTooggle=false;
    private Text resume,options,exit;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resume = GameObject.Find("ResumeLabel").GetComponent<Text>();
        options = GameObject.Find("OptionsLabel").GetComponent<Text>();
        exit = GameObject.Find("ExitLabel").GetComponent<Text>();
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!pauseTooggle){
                Time.timeScale = 0;
                pauseTooggle = true;
                resume.text = "Resume";
                options.text = "Options";
                exit.text = "Exit";
            }else{
                Time.timeScale = 1;
                pauseTooggle = false;
                resume.text = "";
                options.text = "";
                exit.text = "";
                
            }
        }
        
    }
}
