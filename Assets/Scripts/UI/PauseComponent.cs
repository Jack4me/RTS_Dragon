using UnityEngine;

namespace UI {
    public class PauseComponent : MonoBehaviour
    {
        private void OnEnable()
        {
            Time.timeScale = 0;
        }
        private void OnDisable()
        {
            Time.timeScale = 1;
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
