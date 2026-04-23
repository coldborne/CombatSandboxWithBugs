using UnityEngine;

namespace Core
{
    public class Logger : MonoBehaviour
    {
        public void LogInfo(string message)
        {
            Debug.Log("[INFO] " + message);
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning("[WARNING] " + message);
        }

        public void LogError(string message)
        {
            Debug.LogError("[ERROR] " + message);
        }

        public void LogScenario(string scenarioName, string message)
        {
            Debug.Log("[SCENARIO][" + scenarioName + "] " + message);
        }

        public void LogAssertion(bool condition, string message)
        {
            if (condition)
            {
                Debug.Log("[ASSERT PASSED] " + message);
            }
            else
            {
                Debug.LogError("[ASSERT FAILED] " + message);
            }
        }
    }
}