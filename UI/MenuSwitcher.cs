using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSwitcher : MonoBehaviour {

    public GameObject ActiveCanvas;

    public void SwitchOnClick(GameObject canvas)
    {
        ActiveCanvas.SetActive(false);
        canvas.SetActive(true);
        ActiveCanvas = canvas;
    }

    public void ClouseApplicationOnClick()
    {
        Application.Quit();
    }

    public void LoadOnCLick(int index)
    {
        Application.LoadLevel(index);
    }

    public void SetActive(bool value)
    {
        ActiveCanvas.SetActive(value);
    }
}
