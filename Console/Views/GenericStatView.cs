using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ConsoleUtility
{
    [RegisterStatView("game")]
    class GenericStatView : View
    {
        public GenericStatView() : base(15f) { }

        public override string GetDebugViewString()
        {
            var active = SceneManager.GetActiveScene();
            StringBuilder scenes = new StringBuilder();
            int count = SceneManager.sceneCount;
            for (int i = 0; i < count; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                scenes.Append($" {s.name}{(s == active ? "*" : "")}{(i < count - 1 ? "," : "")}");
            }

            return $@"
    Game Statistics
    ===============

    Loaded Scenes: {scenes}

    Time :
        » Total Time : {Time.unscaledTime.ToString("F2")} seconds
        » Since Level Load : {Time.timeSinceLevelLoad.ToString("F2")} seconds
        » Scale : {Time.timeScale.ToString("F2")}x

    Cameras ({Camera.allCameras.Length} in scene) : 
        » Main Camera {Camera.main?.name}
            » Position : {Camera.main?.transform.position}
";
        }
    }


}


