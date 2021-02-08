using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleUtility
{
    public class StatView : View
    {
        public StatView() : base(15f) { }

        public override string GetDebugViewString()
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
