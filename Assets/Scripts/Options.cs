using CrazyMinnow.SALSA;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject options;
    [SerializeField] Salsa salsa;
    FileBrowserTest fileBrowser;
    // Start is called before the first frame update


    private void Start()
    {
        fileBrowser = GetComponent<FileBrowserTest>();
    }
    public void OnOptionClick()
    {
        options.SetActive(!options.activeSelf);
    }
    public void OnPlayClick()
    {
        salsa.audioSrc.Play();
    }
    public void OnPauseClick()
    {
        salsa.audioSrc.Pause();
    }
    public void OnStopClick()
    {
        salsa.audioSrc.Stop();
    }
    public void OnUploadClick()
    {
        fileBrowser.LoadFile();
    }

  
}
