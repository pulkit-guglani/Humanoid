using CrazyMinnow.SALSA;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayAudioContinuously : MonoBehaviour
{
	private List<AudioClip> audioClips;
	[SerializeField]
	private Button playButton;
	[SerializeField] Salsa salsa;
	[SerializeField] AudioSource normalAudioSource;
	[SerializeField]
	private TMP_InputField headline;
	[SerializeField]
	private TMP_InputField heading;
	// Start is called before the first frame update
	void Start()
    {
		audioClips = new List<AudioClip>();
    }

	public void AddAudioClips(string dir, int totalFiles)
    {
		StartCoroutine(GetAudioClip(dir, totalFiles));
    }

	IEnumerator GetAudioClip(string path, int totalFiles)
	{
		for (int i = 1; i <= totalFiles; i++)
		{
			using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + path + "AudioFiles/File" + i + ".wav", AudioType.WAV))
			{
				yield return www.SendWebRequest();
				while (!www.isDone)
				{
					yield return new WaitForEndOfFrame();
				}

				if (www.isNetworkError)
				{
					Debug.Log(www.error);
				}
				else
				{
					AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
					audioClips.Add(myClip);
				}
			}
		}
		playButton.interactable = true;
		yield return null;
	}

	public void PlayContinuously(float delay)
    {
		StartCoroutine(PlayEachAudio(delay));
	}

	IEnumerator PlayEachAudio(float delay)
    {
		
		for(int i = 0; i < audioClips.Count; i++)
        {
			headline.text = TextToAudioFile.Headline[i];
			heading.text = TextToAudioFile.Heading[i];
			salsa.audioSrc.clip = audioClips[i];
			normalAudioSource.clip = audioClips[i];

			salsa.audioSrc.Play();
			yield return new WaitForSeconds(delay);

			if (salsa.audioSrc.isPlaying)
			{
				normalAudioSource.Play();
			}
			yield return new WaitForSeconds(audioClips[i].length);
        }
    }
}
