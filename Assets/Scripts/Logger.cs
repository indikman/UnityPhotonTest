using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logger : MonoBehaviour
{

    private static Logger Instance;

    public static Logger GetInstance()
    {
        return Instance;
    }

    public static void Log(string text)
    {
        GetInstance().LOG(text);
    }

    void CheckSingleton()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Awake()
    {
        CheckSingleton();
    }

    [SerializeField] private TMP_Text logText;
    [SerializeField] private int maxLines=10;

    private Queue<string> logData = new Queue<string>();

    private string logString = "";

    private void LOG(string text)
    {
        logString = "";
        if(logData.Count > maxLines)
        {
            logData.Dequeue();
        }

        logData.Enqueue(text);

        foreach(string t in logData)
        {
            logString += t + "<br>";
        }

        logText.SetText("");
        logText.SetText(logString);
    }



    
}
