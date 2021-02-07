using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleUtility
{
    public class StatView : DebugView
    {
        public StatView() : base(15f) { }

        public override string GetView()
        {
            return $@"
    Current Scene: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}

    Time Since Level Load : {Time.timeSinceLevelLoad} seconds
    FPS : {1f / Time.deltaTime}
    Delta Time : {Time.smoothDeltaTime * 1000}ms 
    Time Scale : {Time.timeScale}x

    Camera : {Camera.main?.name}
    Position : {Camera.main?.transform.position}

";
        }
    }
}
