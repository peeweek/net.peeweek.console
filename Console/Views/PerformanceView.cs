using System.Text;
using UnityEngine;
using UnityEngine.Profiling;
using Unity.Profiling;

namespace ConsoleUtility
{
    [RegisterStatView("fps")]
    public class PerformanceView : View
    {
        ProfilerRecorder mainThreadTimeRecorder;
        ProfilerRecorder renderThreadTimeRecorder;


        public PerformanceView() : base(20f) { }

        public override void OnEnable()
        {
            base.OnEnable();
            mainThreadTimeRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread", 1);
            renderThreadTimeRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Render Thread", 1);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            mainThreadTimeRecorder.Dispose();
            renderThreadTimeRecorder.Dispose();
        }

        public override string GetDebugViewString()
        {
            float ms = Time.smoothDeltaTime;
            float main =    (float) (mainThreadTimeRecorder.LastValueAsDouble * (1e-6)); 
            float render =  (float) (renderThreadTimeRecorder.LastValueAsDouble * (1e-6));

            return $@"
    Performance Statistics
    ======================

    Framerate:              {(1f / ms).ToString("F2")}FPS
        » Overall :         {(ms * 1000).ToString("F2")} ms
        » Main Thread :     {(main).ToString("F2")}ms
        » Render Thread :   {(render).ToString("F2")} ms

";
        }
    }
}


