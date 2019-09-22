using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeChanger : MonoBehaviour
{

    public Animator animator;
    private string sceneToLoad;

    private enum Operations {
        Scene,
        Exit
    }

    private Operations ops;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToScene(string newScene) {
        ops = Operations.Scene;
        sceneToLoad = newScene;
        animator.SetTrigger("FadeOut");
    }

    public void FadeAndExit() {
        ops = Operations.Exit;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        switch(ops) {
            case Operations.Scene:
                SceneManager.LoadScene(sceneToLoad);
                break;
            case Operations.Exit:
                Application.Quit();
                break;
            default:
                break;
        }
    }

    // public void FadeAndExit() {
    //     animator
    // }
}
