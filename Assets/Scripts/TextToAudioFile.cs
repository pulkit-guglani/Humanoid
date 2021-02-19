using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

public class TextToAudioFile : MonoBehaviour
{
    // Start is called before the first frame update
   /* async void Start()
    {
       // await SynthesizeAudioAsync();
    }*/

    public async void ConvertTextToAudio(List<string> files,string path)
    {
        await SynthesizeAudioAsync(files,path);
    }
    public static async Task SynthesizeAudioAsync(List<string> files, string path)
    {
        var config = SpeechConfig.FromSubscription("da4ded0242f647c2a38cff2ab51a5470", "southeastasia");

        for (int i = 1; i <= files.Count; i++)
        {
             var audioConfig = AudioConfig.FromWavFileOutput(path + "AudioFiles/File" + i + ".wav");
             var synthesizer = new SpeechSynthesizer(config, audioConfig);
           // var synthesizer = new SpeechSynthesizer(config, null);
           // string text = "<speak version=\"1.0\" xmlns=\"https://www.w3.org/2001/10/synthesis \"xml:lang=\"en-US\">" +
            //    " <voice name=\"en-AU-WilliamNeural\">" + files[i - 1] + "</voice></speak>" ;

           // print(text);
          
          // var result = await synthesizer.SpeakSsmlAsync(text);
           //  var stream = AudioDataStream.FromResult(result);
           // await stream.SaveToWaveFileAsync(path + "AudioFiles/File" + i + ".wav");
              await synthesizer.SpeakTextAsync(files[i-1]);
        }
        FindObjectOfType<PlayAudioContinuously>().AddAudioClips(path,files.Count);
        Debug.Log("####### Success #######");
    }
   
}
