using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void ReloadOnRegister()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToHomePage()
    {
        SceneManager.LoadScene(3);
    }

    public void ContinueOnLogin()
    {
        SceneManager.LoadScene("MainGameScene");
    }    

    public void LoadProfile()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadTrajectInfo()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadTrajectView()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadAppointmentView()
    {
        SceneManager.LoadScene(2);
    }
}
