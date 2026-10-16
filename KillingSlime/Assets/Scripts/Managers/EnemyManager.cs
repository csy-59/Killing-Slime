using UnityEngine;

public class EnemyManager : ManagerBase
{
    private bool isInitialized = false;

    public void Initialize()
    {
        if (isInitialized == true)
            return;

        isInitialized = true;
    }
}
