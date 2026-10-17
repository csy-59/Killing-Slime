using UnityEngine;

public class PlayerController : UnitController
{
    protected override void SetDatas(int id)
    {
        DataID = id;
        _status = new PlayerData(id);
        _view = GetComponent<PlayerView>();
        _brain = new PlayerBrain(this);
    }
}
