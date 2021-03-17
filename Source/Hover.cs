﻿using UnityEngine;

namespace PawnPeeker
{
    static class Hover
    {
        public static float StartTime = float.NaN;
        public static float StopTime = float.NaN;

        public static bool TryStart()
        {
            if (float.IsNaN(Hover.StartTime))
            {
                Hover.StartTime = Time.realtimeSinceStartup;

                return true;
            }

            return false;
        }

        public static bool TryStop()
        {
            if (float.IsNaN(Hover.StopTime))
            {
                Hover.StopTime = Time.realtimeSinceStartup;

                return true;
            }

            return false;
        }

        public static bool IsStarted()
        {
            return !float.IsNaN(Hover.StartTime) &&
                   ((Time.realtimeSinceStartup - Hover.StartTime) >= Settings.Hover.StartDelaySeconds);
        }

        public static bool DidStartWaitTimeout()
        {
            return !float.IsNaN(Hover.StopTime) &&
                   ((Time.realtimeSinceStartup - Hover.StopTime) >= Settings.Hover.StartDelayTimeoutSeconds);
        }
    }
}
