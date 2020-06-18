using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class Time
    {
        private static IL2Property propertyTime = null;
        public static float time
        {
            get
            {
                if (propertyTime == null)
                {
                    propertyTime = Instance_Class.GetProperty("time");
                    if (propertyTime == null)
                        return default;
                }

                return propertyTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyTimeSinceLevelLoad = null;
        public static float timeSinceLevelLoad
        {
            get
            {
                if (propertyTimeSinceLevelLoad == null)
                {
                    propertyTimeSinceLevelLoad = Instance_Class.GetProperty("timeSinceLevelLoad");
                    if (propertyTimeSinceLevelLoad == null)
                        return default;
                }

                return propertyTimeSinceLevelLoad.GetGetMethod().Invoke().Unbox<float>();
            }
        }
        private static IL2Property propertyDeltaTime = null;
        public static float deltaTime
        {
            get
            {
                if (propertyDeltaTime == null)
                {
                    propertyDeltaTime = Instance_Class.GetProperty("deltaTime");
                    if (propertyDeltaTime == null)
                        return default;
                }

                return propertyDeltaTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyFixedTime = null;
        public static float fixedTime
        {
            get
            {
                if (propertyFixedTime == null)
                {
                    propertyFixedTime = Instance_Class.GetProperty("fixedTime");
                    if (propertyFixedTime == null)
                        return default;
                }

                return propertyFixedTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyUnscaledTime = null;
        public static float unscaledTime
        {
            get
            {
                if (propertyUnscaledTime == null)
                {
                    propertyUnscaledTime = Instance_Class.GetProperty("unscaledTime");
                    if (propertyUnscaledTime == null)
                        return default;
                }

                return propertyUnscaledTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyFixedUnscaledTime = null;
        public static float fixedUnscaledTime
        {
            get
            {
                if (propertyFixedUnscaledTime == null)
                {
                    propertyFixedUnscaledTime = Instance_Class.GetProperty("fixedUnscaledTime");
                    if (propertyFixedUnscaledTime == null)
                        return default;
                }

                return propertyFixedUnscaledTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyUnscaledDeltaTime = null;
        public static float unscaledDeltaTime
        {
            get
            {
                if (propertyUnscaledDeltaTime == null)
                {
                    propertyUnscaledDeltaTime = Instance_Class.GetProperty("unscaledDeltaTime");
                    if (propertyUnscaledDeltaTime == null)
                        return default;
                }

                return propertyUnscaledDeltaTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }
        
        private static IL2Property propertyFixedUnscaledDeltaTime = null;
        public static float fixedUnscaledDeltaTime
        {
            get
            {
                if (propertyFixedUnscaledDeltaTime == null)
                {
                    propertyFixedUnscaledDeltaTime = Instance_Class.GetProperty("fixedUnscaledDeltaTime");
                    if (propertyFixedUnscaledDeltaTime == null)
                        return default;
                }

                return propertyFixedUnscaledDeltaTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyFixedDeltaTime = null;
        public static float fixedDeltaTime
        {
            get
            {
                if (propertyFixedDeltaTime == null)
                {
                    propertyFixedDeltaTime = Instance_Class.GetProperty("fixedDeltaTime");
                    if (propertyFixedDeltaTime == null)
                        return default;
                }

                return propertyFixedDeltaTime.GetGetMethod().Invoke().Unbox<float>();
            }
            set
            {
                if (propertyFixedDeltaTime == null)
                {
                    propertyFixedDeltaTime = Instance_Class.GetProperty("fixedDeltaTime");
                    if (propertyFixedDeltaTime == null)
                        return;
                }

                propertyFixedDeltaTime.GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyMaximumDeltaTime = null;
        public static float maximumDeltaTime
        {
            get
            {
                if (propertyMaximumDeltaTime == null)
                {
                    propertyMaximumDeltaTime = Instance_Class.GetProperty("maximumDeltaTime");
                    if (propertyMaximumDeltaTime == null)
                        return default;
                }

                return propertyMaximumDeltaTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertySmoothDeltaTime = null;
        public static float smoothDeltaTime
        {
            get
            {
                if (propertySmoothDeltaTime == null)
                {
                    propertySmoothDeltaTime = Instance_Class.GetProperty("smoothDeltaTime");
                    if (propertySmoothDeltaTime == null)
                        return default;
                }
                
                return propertySmoothDeltaTime.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyTimeScale = null;
        public static float timeScale
        {
            get
            {
                if (propertyTimeScale == null)
                {
                    propertyTimeScale = Instance_Class.GetProperty("timeScale");
                    if (propertyTimeScale == null)
                        return default;
                }

                return propertyTimeScale.GetGetMethod().Invoke().Unbox<float>();
            }
            set
            {
                if (propertyTimeScale == null)
                {
                    propertyTimeScale = Instance_Class.GetProperty("timeScale");
                    if (propertyTimeScale == null)
                        return;
                }

                propertyTimeScale.GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyFrameCount = null;
        public static int frameCount
        {
            get
            {
                if (propertyFrameCount == null)
                {
                    propertyFrameCount = Instance_Class.GetProperty("frameCount");
                    if (propertyFrameCount == null)
                        return default;
                }

                return propertyFrameCount.GetGetMethod().Invoke().Unbox<int>();
            }
        }

        private static IL2Property propertyRenderedFrameCount = null;
        public static int renderedFrameCount
        {
            get
            {
                if (propertyRenderedFrameCount == null)
                {
                    propertyRenderedFrameCount = Instance_Class.GetProperty("renderedFrameCount");
                    if (propertyRenderedFrameCount == null)
                        return default;
                }

                return propertyRenderedFrameCount.GetGetMethod().Invoke().Unbox<int>();
            }
        }

        private static IL2Property propertyRealtimeSinceStartup = null;
        public static float realtimeSinceStartup
        {
            get
            {
                if (propertyRealtimeSinceStartup == null)
                {
                    propertyRealtimeSinceStartup = Instance_Class.GetProperty("realtimeSinceStartup");
                    if (propertyRealtimeSinceStartup == null)
                        return default;
                }

                return propertyRealtimeSinceStartup.GetGetMethod().Invoke().Unbox<float>();
            }
        }

        private static IL2Property propertyCaptureFramerate = null;
        public static int captureFramerate
        {
            get
            {
                if (propertyCaptureFramerate == null)
                {
                    propertyCaptureFramerate = Instance_Class.GetProperty("captureFramerate");
                    if (propertyCaptureFramerate == null)
                        return default;
                }

                return propertyCaptureFramerate.GetGetMethod().Invoke().Unbox<int>();
            }
        }

        private static IL2Property propertyInFixedTimeStep = null;
        public static bool inFixedTimeStep
        {
            get
            {
                if (propertyInFixedTimeStep == null)
                {
                    propertyInFixedTimeStep = Instance_Class.GetProperty("inFixedTimeStep");
                    if (propertyInFixedTimeStep == null)
                        return default;
                }

                return propertyInFixedTimeStep.GetGetMethod().Invoke().Unbox<bool>();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Time", "UnityEngine");
    }
}
