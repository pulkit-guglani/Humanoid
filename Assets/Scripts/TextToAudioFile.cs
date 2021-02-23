using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.IO;

enum Voices
{
   AU_Female,
   AU_Male 
}

public class TextToAudioFile : MonoBehaviour
{
    
    [SerializeField]
    private Voices selectVoice;
    public static List<string> Heading;
    public static List<string> Headline;

    private static Voices voice;
    // Start is called before the first frame update
    /* async void Start()
     {
        // await SynthesizeAudioAsync();
     }*/

    private void Start()
    {
        voice = selectVoice;
        Headline = new List<string>();
        Heading = new List<string>();
    }

    public async void ConvertTextToAudio(List<string> files,string path)
    {
        await SynthesizeAudioAsync(files,path);
    }
    public static async Task SynthesizeAudioAsync(List<string> files, string path)
    {
        var voicesName = new List<string> { "en-AU-NatashaNeural", "en-AU-WilliamNeural" };

        var config = SpeechConfig.FromSubscription("da4ded0242f647c2a38cff2ab51a5470", "southeastasia");

        for (int i = 1; i <= files.Count; i++)
        {
             var synthesizer = new SpeechSynthesizer(config, null);
           
            var XML1 = Resources.Load<TextAsset>("Text/XML1");
            var XML2 = Resources.Load<TextAsset>("Text/XML2");
            var XML3 = Resources.Load<TextAsset>("Text/XML3");

            List<string> separtedText = GetSeparatedText(files[i - 1]);
            Heading.Add(separtedText[0]);
            Headline.Add(separtedText[1]);
            string XMLFinal = XML1.text + voicesName[(int)voice] + XML2.text + separtedText[2] + XML3.text;
           
             print(XMLFinal);
          
             var result = await synthesizer.SpeakSsmlAsync(XMLFinal);
             var stream = AudioDataStream.FromResult(result);
             await stream.SaveToWaveFileAsync(path + "AudioFiles/File" + i + ".wav");
            
        }
        FindObjectOfType<PlayAudioContinuously>().AddAudioClips(path,files.Count);
        Debug.Log("####### Success #######");
    }

    static List<string> GetSeparatedText(string text)
    {
         var reader = new StringReader(text);

        List<string> separatedText = new List<string>
        {
            reader.ReadLine(),
            reader.ReadLine(),
            reader.ReadToEnd()
        };
        return separatedText;


    }

}
