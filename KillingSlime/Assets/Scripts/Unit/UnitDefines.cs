using UnityEngine;

namespace UnitDefines
{ 
    public enum UnitState // 기본 상태(살아만 있다, 전투 중이다, 죽었다)
    {
        Idle,
        Battle,
        OutofBattle, // 기절 등의 효과로 일시적으로 전투 불능 상태
        Death,
    }


}

