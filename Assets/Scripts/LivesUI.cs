using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    public Text lives;
    public GameObject gamemanager;
    // Update is called once per frame
    void Update()
    {
        lives.text = gamemanager.GetComponent<Stats>().gameHealth.ToString();
    }
}
