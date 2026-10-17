using System;
using UnityEngine;

public class BattleManager :TickBasedManager, ManagerBase
{
    private PlayerController _player;

    public BattleManager(int tick, int maxEnemyCount, int EnemyGroupCount) : base(tick)
    {
        if (SetPlayer())
            throw new MissingComponentException();

        if (SetEnemy())
            throw new MissingComponentException();
    }

    private bool SetPlayer()
    {
        // 지금은 기본 정보만 가져와서 세팅
        // 나중에 저장 기반 정보 갖고 세팅 예정

        // 플레이어 정보는 무조건 0
        var data = Database.GetData<PlayerDataSO>(0);
        _player = UnitCreator.Instantiate(data.Model).
            GetComponent<PlayerController>();

        if (_player == null)
            return false;

        try
        {
            _player.Initialize(0);
        }
        catch(Exception e)
        {
            return false;
        }

        return true;
    }

    private bool SetEnemy()
    {
        return true;
    }

    public override void Evaluate()
    {
        // 버프처리
        // 
    }

    public void Initialize()
    {

    }
}
