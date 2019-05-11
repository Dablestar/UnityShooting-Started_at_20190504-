using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModule : CharacterModule
{
    // 생성할 때, 캐릭터를 바로 세팅하는 생성자  함수
    public PlayerModule(Character character) : base(character)
    {
    }

    override public void BuildStateList()
    {
        base.BuildStateList();
        _character.GetStateDic().Add(Character.eState.IDLE, new PlayerIdleState());

        for (int i = 0; i < _character.GetStateDic().Count; i++)
        {
            Character.eState state = (Character.eState)i;
            _character.GetStateDic()[state].SetCharacter(_character);
        }

        _character.ChangeState(Character.eState.IDLE);
    }

    override public void UpdateAI()
    {
        base.UpdateAI();

        // 키 입력에 따라 8방향으로 이동 (WASD)
        Vector3 curPos = _character.transform.position;
        Vector3 destPos = curPos;

        if (true == Input.GetKey(KeyCode.D)) // 우
        {
            destPos.x = destPos.x + 1;
        }
        else if (true == Input.GetKey(KeyCode.A)) // 좌
        {
            destPos.x = destPos.x - 1;
        }

        if (true == Input.GetKey(KeyCode.W)) // 전
        {
            destPos.z = destPos.z + 1;
        }
        else if (true == Input.GetKey(KeyCode.S)) // 후
        {
            destPos.z = destPos.z - 1;
        }

        _character.SetDestination(destPos);

        Character.eState nextState = Character.eState.IDLE;
        if (false == curPos.Equals(destPos))
        {
            nextState = Character.eState.RUN;
        }
        if (nextState != _character.GetStateType())
        {
            _character.ChangeState(nextState);
        }


        // 총알 발사 (마우스 왼쪽 버튼)
        if (true == Input.GetMouseButton(0))
        {
            _character.Fire();
		}
    }
}
