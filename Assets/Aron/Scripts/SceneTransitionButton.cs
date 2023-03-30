using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    public string sceneName; // name of the scene to transition to
    

    private Button button; // reference to the attached button component

    private void Start()
    {
        // get a reference to the attached button component
        button = GetComponent<Button>();

        // register a method to be called when the button is clicked
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // load the target scene by name
        SceneManager.LoadScene(sceneName);

    }
}
