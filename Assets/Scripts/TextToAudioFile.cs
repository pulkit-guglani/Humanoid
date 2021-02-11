using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

public class TextToAudioFile : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
       // await SynthesizeAudioAsync();
    }

    static async Task SynthesizeAudioAsync()
    {
        var config = SpeechConfig.FromSubscription("da4ded0242f647c2a38cff2ab51a5470", "southeastasia");
        var audioConfig = AudioConfig.FromWavFileOutput("C:/ProgramData/Humanoid/AudioFiles/file.wav");
        var synthesizer = new SpeechSynthesizer(config, audioConfig);
        await synthesizer.SpeakTextAsync("I am a news reporter");
        Debug.Log("####### Success #######");
    }
   
}
