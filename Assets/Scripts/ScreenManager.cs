using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public Canvas Home;
    public Canvas Traject;
    public Canvas Profile;
    public Canvas TrajectInfo;
    public Canvas Appointment;
    public void LoadHomePage()
    {
        Home.gameObject.SetActive(true);
        Traject.gameObject.SetActive(false);
        Profile.gameObject.SetActive(false);
        Appointment.gameObject.SetActive(false);
        TrajectInfo.gameObject.SetActive(false);

    }

    public void LoadScreen(string scene)
    {
        Home.gameObject.SetActive(false);
        Traject.gameObject.SetActive(false);
        Profile.gameObject.SetActive(false);
        Appointment.gameObject.SetActive(false);
        TrajectInfo.gameObject.SetActive(false);

        switch (scene)
        {
            case "Home":
                LoadHomePage();
                break;
            case "Traject":
                Traject.gameObject.SetActive(true);
                break;
            case "TrajectInfo":
                TrajectInfo.gameObject.SetActive(true);
                break;
            case "Appointment":
                Appointment.gameObject.SetActive(true);
                break;
            case "Profile":
                Profile.gameObject.SetActive(true);
                break;
        }
    }

}
