using UnityEngine;
using UnityEngine.UI;

    // Set OnClick() to LevelManager.StartGame()
public class StartButton : MonoBehaviour
{
    private Button button = null;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { LevelManager.instance.StartGame(); });
    }
}
