using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoad : MonoBehaviour
{
    [SerializeField] int levelNumber = 1;
    void Start()
    {
        SceneManager.LoadScene(levelNumber);
    }
}
