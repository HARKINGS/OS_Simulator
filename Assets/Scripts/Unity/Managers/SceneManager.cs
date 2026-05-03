using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Canvas inputScene;
    [SerializeField] private Canvas outputScene;

    public void LoadInputScene()
    {
        inputScene.gameObject.SetActive(true);
        outputScene.gameObject.SetActive(false);
    }

    public void LoadOutputScene()
    {
        inputScene.gameObject.SetActive(false);
        outputScene.gameObject.SetActive(true);
    }
}
