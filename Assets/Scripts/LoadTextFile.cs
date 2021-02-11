using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadTextFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadTheFile(); 
    }

   public void LoadTheFile()
    {
       AssetDatabase.ImportAsset("Assets/Resources/text1.txt");
        string a = null;
        DirectoryInfo d = new DirectoryInfo("C:/ProgramData/Humanoid/TextFiles");
     
        if(!d.Exists)
        Directory.CreateDirectory("C:/ProgramData/Humanoid/TextFiles");
        else
        {
            print(d.GetFiles().Length);
            a = File.ReadAllText("C:/ProgramData/Humanoid/TextFiles/text1.txt");
        }


        print(a);
      //  TextAsset asset = Resources.Load("text1") as TextAsset;

        //Print the text from the file
      // Debug.Log(asset.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
