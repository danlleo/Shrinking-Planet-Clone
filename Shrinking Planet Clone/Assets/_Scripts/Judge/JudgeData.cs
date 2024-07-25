using UnityEngine;

namespace Judge
{
    public class JudgeData
    {
        public Vector3 SpawnPosition;
        public Quaternion SpawnRotation;

        public JudgeData(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            SpawnPosition = spawnPosition;
            SpawnRotation = spawnRotation;
        }
    }
}
