using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    // Start is called before the first frame update
    int sceneNo = 0;
   
    public void goTo(int index)
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        SceneManager.LoadScene(index);
    }
}
