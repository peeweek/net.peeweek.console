using System.Text;
using UnityEngine;
using UnityEngine.Profiling;
using Unity.Profiling;
using System.Collections.Generic;

namespace ConsoleUtility
{
    [RegisterStatView("fps")]
    public class PerformanceView : View
    {
        public PerformanceView() : base(20f) { }

        Profiler mainThread;
        Profiler renderThread;
        Profiler gpu;
        Profiler drawCall;
        Profiler triangles;
        Profiler shadowCasters;


        public override void OnEnable()
        {
            base.OnEnable();
            mainThread = new Profiler(ProfilerCategory.Internal, "Main Thread");
            renderThread = new Profiler(ProfilerCategory.Internal, "Gfx.WaitForRenderThread");
            gpu = new Profiler(ProfilerCategory.Internal, "Gfx.PresentFrame");
            drawCall = new Profiler(ProfilerCategory.Render, "Draw Calls Count");
            triangles = new Profiler(ProfilerCategory.Render, "Triangles Count");
            shadowCasters = new Profiler(ProfilerCategory.Render, "Shadow Casters Count");
        }

        public override void OnDisable()
        {
            base.OnDisable();


        }

        public override string GetDebugViewString()
        {
            float ms = Time.deltaTime;

            return $@"
    Performance Statistics
    ======================

    Framerate:                    {(1f / ms).ToString("F2")}FPS
        » Overall       :         {(ms * 1000).ToString("F2")} ms
        » Main Thread   :         {(mainThread.GetMilliseconds()).ToString("F2")} ms
        » Render Thread :         {(renderThread.GetMilliseconds()).ToString("F2")} ms
        » GPU           :         {(gpu.GetMilliseconds()).ToString("F2")} ms
    Other:
        » DrawCalls     :         {(drawCall.GetValue())} calls
        » Triangles     :         {(triangles.GetValue())} triangles
        » ShadowCasters :         {(shadowCasters.GetValue())} calls


";
        }

        class Profiler
        {
            ProfilerRecorder m_Recorder;

            public Profiler(ProfilerCategory category, string name, int samples = 5)
            {
                m_Recorder = ProfilerRecorder.StartNew(category, name, samples);
                m_Samples = new List<ProfilerRecorderSample>(samples);
            }

            ~Profiler()
            {
                m_Recorder.Dispose();
            }

            List<ProfilerRecorderSample> m_Samples;

            public float GetMilliseconds()
            {
                return GetValue() * 0.000001f;
            }

            public long GetValue()
            {
                int samplesCount = m_Recorder.Capacity;
                if (samplesCount == 0)
                    return 0;

                m_Recorder.CopyTo(m_Samples);

                long r = 0;
                for (var i = 0; i < m_Samples.Count; ++i)
                    r += m_Samples[i].Value;

                r /= m_Samples.Count;

                return r;
            }
        }
    }
}


