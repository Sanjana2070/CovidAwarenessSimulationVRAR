using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void gotoFaceTracking()
    {
        SceneManager.LoadScene("FaceTracking");
    }

    public void gotoMeasurement()
    {
        SceneManager.LoadScene("Measurement");
    }

}
