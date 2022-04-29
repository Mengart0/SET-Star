using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextLink : MonoBehaviour
{
    public Text link;
    string avatarText;

    public Button buttonOne;
    public Button Quit;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = buttonOne.GetComponent<Button>();
        btn.onClick.AddListener(Tik);
        btn.onClick.AddListener(load);
        Button quitbtn = Quit.GetComponent<Button>();
        quitbtn.onClick.AddListener(exit);
    }
    void Tik()
    {
        avatarText = link.text;
        PlayerPrefs.SetString("link", avatarText);


    }
    void load()
    {
        SceneManager.LoadScene("FirstMap");

    }
    void exit()
    {
        Application.Quit();


    }
     
    
}
