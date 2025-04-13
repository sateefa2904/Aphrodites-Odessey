using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void GoToScene(string sceneName){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load scene following click
        SceneManager.LoadScene("TopDownDemo3D");

    }
    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
    
}
