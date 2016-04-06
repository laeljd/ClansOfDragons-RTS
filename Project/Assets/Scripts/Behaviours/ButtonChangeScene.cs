using UnityEngine;
namespace FATEC.ClansOfDragons.Behaviours {
    /// <summary>
    /// Change scene by int
    /// </summary>
    public class ButtonChangeScene : MonoBehaviour {
        public void ChangeScene(int scene) {
            Application.LoadLevel(scene);
        }
	}
}
