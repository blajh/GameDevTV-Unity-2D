using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCanvas : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject creditsCanvas;

    private bool menuVisible = true;

    private void Start() {
        menuVisible = true;
        SetCanvas(menuVisible);
    }

    public void SetCanvas (bool menuVisible) {
        menuCanvas.SetActive(menuVisible);
        creditsCanvas.SetActive(!menuVisible); 
    }
}
