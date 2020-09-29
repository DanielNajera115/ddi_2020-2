using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeProblem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int[] ar = {8,1,2,2,3};
        solvingProblem(ar);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void solvingProblem(int[] Array){
        int i,j,k=0;
        int[] newArray = new int[Array.Length];

        for(i=0;i<Array.Length;i++){
            k = Array[i];
            for(j=0;j<Array.Length;j++){
                if(i!=j){
                    if(k>Array[j])
                        newArray[i]++;
                }
            }
        }

        for(i=0;i<Array.Length;i++){
            Debug.Log(newArray[i]);
        }


    }

}
