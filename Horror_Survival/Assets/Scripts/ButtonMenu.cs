using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(2);
    }
}
