using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadTextFile : MonoBehaviour
{

    List<string> texts;
    [SerializeField]
    private string path = "C:/ProgramData/Humanoid/";
    // Start is called before the first frame update
    void Start()
    {
        texts = new List<string>();
        LoadTheFile(); 
    }

    public void LoadTheFile()
    {
     
        string a = null;
        DirectoryInfo d = new DirectoryInfo(path+"TextFiles");

        if (!d.Exists)
        {
            Directory.CreateDirectory(path + "TextFiles");
            d = new DirectoryInfo(path + "TextFiles");
        }


        for (int i = 1; i <= d.GetFiles().Length; i++)
        {
            a = File.ReadAllText(d.FullName + "/File"+i+".txt");
            texts.Add(a);
           
        }

        var TTS = FindObjectOfType<TextToAudioFile>();
         TTS.ConvertTextToAudio(texts,path);    

        // print(d.GetFiles().Length);
        //a = File.ReadAllText("C:/ProgramData/Humanoid/TextFiles/text1.txt");
        //  TextAsset asset = Resources.Load("text1") as TextAsset;

        //Print the text from the file
        // Debug.Log(asset.ToString());
    }

  
}
