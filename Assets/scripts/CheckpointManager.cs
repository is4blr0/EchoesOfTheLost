using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }
    private Vector3 currentCheckpoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentCheckpoint(Vector3 checkpointPosition)
    {
        currentCheckpoint = checkpointPosition;
    }

    public Vector3 GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
}