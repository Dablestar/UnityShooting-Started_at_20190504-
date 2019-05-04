using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void Start ()
    {
        Destroy(gameObject, 5.0f);
	}

    //float _curTestRot = 0;//임시변수

    void Update ()
    {
        // z 축을 변경 (양의 값으로)
        /*
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(curPos.x, curPos.y, curPos.z + 0.1f);
        transform.position = nextPos;
        */

        // for test
        /*
        transform.position = transform.position + (transform.forward * 0.1f);
        transform.Rotate(Vector3.up, _curTestRot);
        _curTestRot -= 0.01f;*/

        Vector3 curPos = transform.position;
        Vector3 nextPos = curPos + (transform.forward * 0.1f);

        transform.position = nextPos;
       // transform.Rotate(Vector3.up, _curTestRot);
        //_curTestRot -= 0.01f;
        //_curTestRot = Mathf.Cos(Time.deltaTime) * 100.0f;
    }
    [SerializeField] GameObject _effectPrefab;
    void OnTriggerEnter(Collider other)
    {
        //폭발 파티클 실행(스프라이트-)
        GameObject effObject = GameObject.Instantiate(_effectPrefab);
        effObject.transform.position = transform.position;
        effObject.transform.localScale = Vector3.one;
        Destroy(effObject, 0.5f);
        Destroy(gameObject);
    }

    public void setShotCharacterType(Character.CharType charType)
    {
        _charType = charType;
    }

    public Character.CharType IsPlayer()
    {
        return _charType;
    }
}
