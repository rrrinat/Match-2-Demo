using Match2.Partial.Loading.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match2.Partial.Loading
{
    public class BootstrapStage : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(SceneType.MainMenu.ToString());
        }
    }
}
