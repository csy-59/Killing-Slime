using UnityEngine;

public class EnemyManager : ManagerBase
{
    private bool isInitialized = false;
    private EnemyDataSet _datas;

    public void Initialize()
    {
        if (isInitialized == true)
            return;

        _datas = Managers.Instance.GetManager<ResourcesManager>().
            LoadData<EnemyDataSet>(EnemyDefine.EnemyDefines.EnemyDataSetRoute);

        if(_datas == null)
        {
            return;
        }

        isInitialized = true;
    }
}
