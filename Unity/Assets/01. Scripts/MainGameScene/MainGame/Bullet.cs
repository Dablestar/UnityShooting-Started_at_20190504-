using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void Start ()
    {
        Destroy(gameObject, 10.0f);
	}

    //float _curTestRot = 0;	 // 임시 변수
    float _speed = 2.5f;
    float _speedRate = -4.0f;
    float _angle = 0.0f;
    float _angleRate = 1.0f;
    void Update ()
    {
		Vector3 curPos = transform.position;
		Vector3 nextPos = curPos + (transform.forward * _speed * Time.deltaTime);
		transform.position = nextPos;

        _speed += (_speedRate * Time.deltaTime);
        transform.Rotate(Vector3.up, _angle);
        _angle += (_angleRate * Time.deltaTime);

		//transform.Rotate(Vector3.up, _curTestRot);
		//_curTestRot -= 0.01f;
	}

	[SerializeField] GameObject _effectPrefab;
    void OnTriggerEnter(Collider other)
    {
		// 총알
		// 태그가 캐릭터이면
		// other.gameObject 에서 캐릭터 스크립트 컴포넌트를 뽑아냄
		// 죽었으면, 패스
		// 태그가 건물이면
		// other.gameObject 에서 건물 스크립트 컴포넌트를 뽑아냄
		// 죽었으면(파괴되었으면), 패스
		// 우리게임에서 사용하는 게임 오브젝트인가?
		// 공통된 스크립트 컴포넌트를 뽑아냄.
		// 컴포넌트가 충돌 가능한가를 체크.
		// 충돌 또는 패스

		// 내 총알의 주인이 부딪쳤으면 패스
		if (true == other.gameObject.tag.Equals("Character"))
		{
			Character character = other.gameObject.GetComponent<Character>();
			if (_shotCharType == character.GetCharacterType())
				return;
		}


		// 폭발 효과 실행 (스프라이트)
		GameObject effObject = GameObject.Instantiate(_effectPrefab);
		effObject.transform.position = transform.position;
		effObject.transform.localScale = Vector3.one;
		Destroy(effObject, 1.5f);

		Destroy(gameObject);
	}

	Character.CharType _shotCharType;

	public Character.CharType ShotCharacterType()
	{
		return _shotCharType;
	}

	public void SetShotCharacterType(Character.CharType charType)
	{
		_shotCharType = charType;
	}

    public void setSpeedRate(float speedRate)
    {
        _speedRate = speedRate;
    }
    public void setAngleRate(float angleRate)
    {
        _angleRate = angleRate;
    }
}
