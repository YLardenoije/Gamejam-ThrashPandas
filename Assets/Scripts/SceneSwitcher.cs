using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToSocial(string scene)
    {
        SceneManager.LoadScene("Interaction");
        SceneManager.UnloadSceneAsync(scene);
    }
    public void SwitchToHotspot(string scene)
    {
        SceneManager.LoadScene("Hotspot");
        SceneManager.UnloadSceneAsync(scene);
    }
    public void SwitchToTamafoodchi(string scene)
    {
        
        SceneManager.LoadSceneAsync("Tamafoodchi");
        SceneManager.UnloadSceneAsync(scene);
    }
}
