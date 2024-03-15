using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatterns : MonoBehaviour
{
    // 미리 보스 패턴들 만들어 두고 나중에 필요한 것들만 들고가기 위한 스크립트
    // pooling은 안되어 있음

    public LayerMask _mask;

    private Rigidbody2D _rigid;

    public GameObject _type0;
    public GameObject _type1;
    public GameObject _type2;
    public GameObject _type3;
    public GameObject _type4;
    public GameObject _laser;
    public GameObject _warning0;
    public GameObject _warning1;


    [SerializeField]
    private GameObject _player;

    private bool _seven = false;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        if(_seven)
            _seven = false;
    }

    void Start()
    {
        //StartCoroutine(One(30, 2, 1, 2)); // 총알 개수, 총알 속도, 대기 시간, 발사 횟수
        //StartCoroutine(Two(6, 2, 0.2f, 10, 50)); // 총알 개수, 총알 속도, 대기 시간, 삭제하기 시작하는 횟수, 회전 횟수
        //StartCoroutine(Three(3, 100, 5, this.transform, 3)); // 총알 개수, 회전 속도, 삭제되는 시간, 부모 위치, 반지름
        //StartCoroutine(Four(4, 2, 3, 2)); // 총알 개수, 총알 속도, 대기 시간, 발사 횟수
        //StartCoroutine(Five(30, 5, 0.1f, 20, 3)); // 총알 개수, 총알 속도, 대기 시간, 삭제하기 시작하는 횟수, 회전 횟수
        //StartCoroutine(Six(4, 2, 2, 3)); // 총알 개수, 총알 속도, 대기 시간, 발사 횟수
        //StartCoroutine(Seven(5, 5)); // 돌진 속도, 돌진 시간
        //StartCoroutine(Eight(6, 5, 1f, 1)); // 총알 개수, 총알 속도, 대기 시간, 반지름
        //StartCoroutine(Nine(5, 1, 5, -5, 2, -2)); // 폭탄 개수, 대기 시간, x축 최대 위치, x축 최소 위치, y축 최대 위치, y축 최소 위치
        //StartCoroutine(Ten(6, 1, 3, 2)); // 충격파 개수, 대기 시간, 총 충격파 횟수, 처음 반지름
        //StartCoroutine(Eleven(3, 1, 1)); // 경고 선이 따라 다니는 시간, 레이저를 쏘기 위해 경고를 멈추고 모으는 시간, 레이저가 없어지는 시간
        //StartCoroutine(Twelve(7, 2, 1, 2, 4, 20)); // 총알 개수, 총알 속도, 방향이 바뀌는 시간, 삭제되기 시작하는 횟수, 방향 수, 각도
        //StartCoroutine(Thirteen(6, 2, 0.5f)); // 레이저 발사 횟수, 레이저 발사 속도(Time.deltaTime * speed 형태임), 대기 시간
        //StartCoroutine(Fourteen(3, 2, 1, 2, 2, 30)); // 총알 개수, 총알 속도, 총알 대기 시간, 삭제 시간, 점사 수, 각도
        //StartCoroutine(Fifteen(8, 3, 0.5f, 3)); // 총알 개수, 총알 속도, 대기 시간, 분산 횟수
        //StartCoroutine(Sixteen(10, 2, 0.5f, 1, 3)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수바라보는 횟수
        //StartCoroutine(Seventeen(8, 3, 1, 2, 5)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수, 점사 횟수
        //StartCoroutine(Eighteen(52, 2, 2, 2, 3)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수, 점사 횟수
        //StartCoroutine(Nineteen(30, 4, 0.1f, 20, 3)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수, 회전 횟수
        //StartCoroutine(Twenty(10, 6, 8, 2, 0.1f, 2, 2, 2)); // 총알 개수, 큰 총알 개수, 분열할 때 총알 개수, 총알 속도, 느린 총알 속도, 큰 총알이 멈추는 시간, 큰 총알이 분열되는 시간, 삭제되는 시간
        //StartCoroutine(TwentyOne(30, 2, 3, 1, 2)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수, 점사 횟수
        //StartCoroutine(TwentyTwo(30, 2, 1, 3, 3)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수, 점사 횟수
        //StartCoroutine(TwentyThree(30, 2, 0.3f, 20)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수
        //StartCoroutine(TwentyFour(10, 30, 1, 100, 0.5f, 3)); // 총알 개수, 전방향 발사 총알 개수, 총알 속도, 회전 속도, 대기 시간, 회전 횟수
        //StartCoroutine(TwentyFive(30, 2, 1, 2, 3)); // 총알 개수, 총알 속도, 대기 시간, 삭제되기 시작하는 횟수, 점사 횟수
    }

    // 사용함
    private IEnumerator One(int bulletCount, float speed, float time, int burstCount) // 내 생각 - 전방향으로 한 번에 총알 발사
    {
        for(int i = 0; i < burstCount; i++)
        {
            for (int j = 0; j < bulletCount; j++)
            {
                GameObject bullet = _type0;
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                rigid.velocity = dir.normalized * speed;

                // 원기둥의 경우 총알이 발사 방향으로 회전
                //Vector3 rotation = Vector3.forward * 360 * i / bulletCount + Vector3.forward * 90;
                //bullet.transform.Rotate(rotation);
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Two(int bulletCount, float speed, float time, int turnCount) // 내 생각 - 조금 씩 발사 방향이 바뀌면서 발사
    {
        for(int i = 0; i < turnCount; i++)
        {
            for (int j = 0; j < bulletCount; j++)
            {
                GameObject bullet = _type0;
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / 5 + i * 2), Mathf.Sin(Mathf.PI * 2 * j / 5 + i * 2));
                rigid.velocity = dir.normalized * speed;

                // 원기둥의 경우 총알이 발사 방향으로 회전 <- 이거 회전이 이상함 (일단은 이 패턴은 원형 총알로만 하기)
                //Vector3 rotation = Vector3.forward * 360 * j / 5 + Vector3.forward * 90 - Vector3.forward * 10 * i;
                //bullet.transform.Rotate(rotation);
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Three(int bulletCount, float speed, float returnTime, Transform trans, float r) // 롤 - 리메이크 전 아우솔 패시브 (주위를 도는 유성)
    {
        float deg = 0; // 각도
        float timeCounting = 0;
        GameObject[] bullets = new GameObject[bulletCount];

        for(int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = _type0;
        }
        

        while (timeCounting < returnTime)
        {
            deg += Time.deltaTime * speed;
            timeCounting += Time.deltaTime;

            if (deg < 360)
            {
                for (int i = 0; i < bullets.Length; i++)
                {
                    var rad = Mathf.Deg2Rad * (deg + i * 360 / bullets.Length);
                    var x = r * Mathf.Cos(rad);
                    var y = r * Mathf.Sin(rad);
                    bullets[i].transform.position = trans.position + new Vector3(x, y); // 공전
                    bullets[i].transform.rotation = Quaternion.Euler(0, 0, (deg + i * 360 / bullets.Length) * -1); // 자전
                }
            }
            else
                deg = 0;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator Four(int bulletCount, float speed, float time, int burstCount) // 내 생각 - 세 번째 패턴을 가진 총알을 여러 방향으로 날린다
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];

        for(int i = 0; i < burstCount; i++)
        {
            for(int j = 0; j < bulletCount; j++)
            {
                bullets[i, j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                rigid.velocity = dir.normalized * speed;

                StartCoroutine(Three(2, UnityEngine.Random.Range(100, 500), time * 1.3f, bullets[i, j].transform, 2));
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Five(int bulletCount, float speed, float time, int end) // 내 생각 - 회오리 치듯 원을 그리며 총알 발사
    {
        GameObject[,] bullets = new GameObject[end, bulletCount];

        for(int i = 0; i < end; i++)
        {
            for(int j = 0; j < bulletCount; j++)
            {
                bullets[i, j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                rigid.velocity = dir.normalized * speed;

                // 원기둥의 경우 총알이 발사 방향으로 회전
                //Vector3 rotation = Vector3.forward * 360 * counting / bulletCount + Vector3.forward * 90;
                //bullet.transform.Rotate(rotation);

                yield return new WaitForSeconds(time);
            }
        }
    }

    private IEnumerator Six(int bulletCount, float speed, float time, int burstCount) // 소울 나이트 - 총알이 여러 방향으로 날아가고 총알이 지나가면서 또 총알을 좌우로 발사
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];

        for (int i = 0; i < burstCount; i++)
        {
            for (int j = 0; j < bulletCount; j++)
            {
                bullets[i, j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                rigid.velocity = dir.normalized * speed;

                StartCoroutine(SixCo(bullets[i, j].transform, speed / 2, dir, (int)time * 3, (int)time, 1));
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator SixCo(Transform trans, float speed, Vector2 vec, int burstCount, int returnCount, float time)
    {
        GameObject[,] bullets = new GameObject[burstCount, 2];

        Rigidbody2D[] rigids = new Rigidbody2D[2];

        int returnCounting = 0;

        yield return new WaitForSeconds(time);

        for (int i = 0; i < burstCount; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                bullets[i, j] = _type0;
                bullets[i, j].transform.position = trans.position;
                bullets[i, j].transform.rotation = Quaternion.identity;
                rigids[j] = bullets[i, j].GetComponent<Rigidbody2D>();
            }

            if (vec == Vector2.right || vec == Vector2.left)
            {
                rigids[0].velocity = Vector2.up * speed;
                rigids[1].velocity = Vector2.down * speed;
            }
            else
            {
                rigids[0].velocity = Vector2.right * speed;
                rigids[1].velocity = Vector2.left * speed;
            }

            yield return new WaitForSeconds(time);
        }
    } // 총알을 좌우로 발사하게 해주는 함수

    private IEnumerator Seven(float speed, float time) // 소울 나이트 - 플레이어 방향으로 돌진
    {
        _seven = true;
        Vector2 dir = _player.transform.position - transform.position;
        _rigid.velocity = dir.normalized * speed;

        yield return new WaitForSeconds(time);

        _rigid.velocity = Vector2.zero;
    }

    private IEnumerator Eight(int bulletCount, float speed, float time, int r) // 내 생각 - 전방향으로 총알을 만든 뒤 잠시 후 튕기는 총알 발사 
    {
        GameObject[] bullets = new GameObject[bulletCount];

        for(int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = _type1;
            var rad = Mathf.Deg2Rad * i * 360 / bulletCount;
            var x = r * Mathf.Cos(rad);
            var y = r * Mathf.Sin(rad);
            bullets[i].transform.position = transform.position + new Vector3(x, y);
            bullets[i].transform.rotation = Quaternion.identity;
        }

        yield return new WaitForSeconds(time);

        for(int i = 0; i < bullets.Length; i++)
        {
            Rigidbody2D rigid = bullets[i].GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bullets.Length), Mathf.Sin(Mathf.PI * 2 * i / bullets.Length));
            rigid.velocity = dir.normalized * speed;
        }

        yield return new WaitForSeconds(time * 5);
    }

    private IEnumerator Nine(int bombCount, float time, float maxX, float minX, float maxY, float minY) // 내 생각 - 랜덤한 위치에 폭발
    {
        Vector2[] bombVecs = new Vector2[bombCount];
        GameObject[] warnings = new GameObject[bombCount];
        GameObject[] bombs = new GameObject[bombCount];

        for(int i = 0; i < bombCount; i++)
        {
            GameObject warning = _type1;
            warnings[i] = warning;
            float x = UnityEngine.Random.Range(minX, maxX);
            float y = UnityEngine.Random.Range(minY, maxY);
            warning.transform.position = new Vector2(x, y);
            warning.transform.rotation = Quaternion.identity;
            bombVecs[i] = new Vector2(x, y);
        }

        yield return new WaitForSeconds(time);
        for(int i = 0; i < bombCount; i++)
        {
            bombs[i] = _type3;
            bombs[i].transform.position = bombVecs[i];
            bombs[i].transform.rotation = Quaternion.identity;
        }
    }

    // 사용함
    private IEnumerator Ten(int shockCount, float time, int waveCount, float r) // 소울 나이트 - 충격파
    {
        GameObject[] shocks = new GameObject[shockCount];

        for(int i = 0; i < shockCount; i++)
        {
            shocks[i] = _type4;
        }
        for(int i = 1; i <= waveCount; i++)
        {
            for (int j = 0; j < shockCount; j++)
            {
                var rad = Mathf.Deg2Rad * j * 360 / shockCount;
                var x = i * r * Mathf.Cos(rad);
                var y = i * r * Mathf.Sin(rad);
                shocks[j].transform.position = transform.position + new Vector3(x, y);
                shocks[j].transform.rotation = Quaternion.identity;
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Eleven(float followTime, float chargingTime, float returnTime) // 소울 나이트 - 플레이어를 따라다니는 경고 선이 있다가 잠시 후 레이저를 발사
    {
        float t = 0;
        float angle = 0;

        GameObject warning = _type0;
        warning.transform.position = transform.position;

        while(t < followTime)
        {
            angle = Mathf.Atan2(_player.transform.position.y - transform.position.y, _player.transform.position.x - transform.position.x) * Mathf.Rad2Deg; // 한 점까지의 각도를 구함(플레이어까지의 각도를 구함)
            warning.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward); // angle 기준으로 각도를 회전

            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Quaternion rot = warning.transform.rotation;

        yield return new WaitForSeconds(chargingTime);

        GameObject laser = _laser;
        laser.transform.position = transform.position;
        laser.transform.rotation = rot;
    }

    private IEnumerator Twelve(int bulletCount, float speed, float time, int directionCount, float angle) // 내 생각 - 여러 방향으로 총알을 가로로 일렬 여러 개씩 날린다
    {
        GameObject[,] bullets = new GameObject[directionCount, bulletCount];

        int bc = 0;
        if (bulletCount % 2 != 0)
            bc = bulletCount / 2 + 1;
        else
            bc = bulletCount / 2;

        for(int i = 0; i < directionCount; i++)
        {
            for(int j = -(bulletCount / 2); j < bc ; j++)
            {
                bullets[i, j + bulletCount / 2] = _type0;
                bullets[i, j + bulletCount / 2].transform.position = transform.position;
                bullets[i, j + bulletCount / 2].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j + bulletCount / 2].GetComponent<Rigidbody2D>();
                Vector2 standard = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / directionCount), Mathf.Sin(Mathf.PI * 2 * i / directionCount)).normalized;
                Vector2 dir = Quaternion.Euler(0, 0, j * angle) * standard;
                rigid.velocity = dir.normalized * speed;
            }
            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Thirteen(int shotCount, float speed, float time) // 내 생각 - 돌아가면서 레이저를 발사
    {
        float y = 0;
        for (int i = 0; i < shotCount; i++)
        {
            GameObject laser = _laser;
            laser.transform.localScale = new Vector3(1, y, 1);
            laser.transform.position = transform.position;
            laser.transform.rotation = Quaternion.Euler(0, 0, 360 * i / shotCount);

            while(y < 1)
            {
                y += Time.deltaTime * speed;
                laser.transform.localScale = new Vector3(1, y, 1);
                yield return new WaitForSeconds(Time.deltaTime);
            }

            y = 1;
            laser.transform.localScale = new Vector3(1, y, 1);

            yield return new WaitForSeconds(time);
            y = 0;
        }
    }

    // 사용함
    private IEnumerator Fourteen(int bulletCount, float speed, float time, float returnTime, int burstCount, float angle) // 엔터 더 건전 - 플레이어 방향으로 점사 
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];
        int bc = 0;
        Vector2 dir = (_player.transform.position - transform.position).normalized;
        if (bulletCount % 2 == 0)
            bc = bulletCount / 2;
        else
            bc = bulletCount / 2 + 1;

        for (int i = 0; i < burstCount; i++)
        {
            for(int j = -(bulletCount / 2); j < bc; j++)
            {
                bullets[i, j + bulletCount / 2] = _type0;
                bullets[i, j + bulletCount / 2].transform.position = transform.position;
                bullets[i, j + bulletCount / 2].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j + bulletCount / 2].GetComponent<Rigidbody2D>();
                Vector2 temp = Quaternion.Euler(0, 0, j * angle) * dir;
                rigid.velocity = temp.normalized * speed;
            }

            yield return new WaitForSeconds(time);
        }
    }

    // 사용함
    private IEnumerator Fifteen(int bulletCount, float speed, float time, int splitCount) // 엔터 더 건전 - 분산
    {
        List<GameObject> bulletList = new List<GameObject>();
        List<Transform> transList = new List<Transform>();
        GameObject beforeBullet;
        Vector2 originSize;

        GameObject bullet = _type0;
        originSize = bullet.transform.localScale;
        bullet.transform.localScale = originSize * 2;
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;
        bulletList.Add(bullet);
        beforeBullet = bullet;

        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.up * speed;

        yield return new WaitForSeconds(time);

        transList.Add(bulletList[0].transform);
        bulletList[0].transform.localScale = originSize;
        Destroy(bulletList[0]);
        bulletList.Clear();

        for(int i = 1; i < splitCount; i++)
        {
            for(int j = 0; j < transList.Count; j++)
            {
                for(int k = 0; k < bulletCount; k++)
                {
                    GameObject bulleT = _type0;
                    bulleT.transform.position = transList[j].position;
                    bulleT.transform.rotation = Quaternion.identity;
                    bulleT.transform.localScale = new Vector3(beforeBullet.transform.localScale.x - beforeBullet.transform.localScale.x / (splitCount + 1),
                        beforeBullet.transform.localScale.y - beforeBullet.transform.localScale.y / (splitCount + 1));
                    bulletList.Add(bulleT);

                    Rigidbody2D rigid2d = bulleT.GetComponent<Rigidbody2D>();
                    Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * k / bulletCount), Mathf.Sin(Mathf.PI * 2 * k / bulletCount));
                    rigid2d.velocity = dir.normalized * speed;
                }
            }

            transList.Clear();
            beforeBullet = bulletList[0];

            yield return new WaitForSeconds(time * i * 2);

            for(int j = 0; j < bulletList.Count; j++)
            {
                transList.Add(bulletList[j].transform);
                bulletList[j].transform.localScale = originSize;
                if (bulletList[j].activeSelf)
                    Destroy(bulletList[j]);
            }

            bulletList.Clear();
        }
    }

    private IEnumerator Sixteen(int bulletCount, float speed, float time, int returnCount, int watchCount) // 엔터 더 건전 - 개틀링 건 난사
    {
        GameObject[,] bullets = new GameObject[watchCount, bulletCount];
        int returnCounting = 0;

        for(int i = 0; i < watchCount; i++)
        {
            Vector2 vec = (_player.transform.position - transform.position).normalized;
            for(int j = 0; j < bulletCount; j++)
            {
                int angle = UnityEngine.Random.Range(-30, 30);

                bullets[i, j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = Quaternion.Euler(0, 0, angle) * vec;
                rigid.velocity = dir.normalized * speed;

                yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.3f));
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Seventeen(int bulletCount, float speed, float time, int returnCount, int burstCount) // 엔터 더 건전 - 구불거리는 총알 여러 발 발사
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];
        int returnCounting = 0;

        for(int i = 0; i < burstCount; i++)
        {
            if (i >= returnCount)
            {
                for (int j = 0; j < bulletCount; j++)
                {
                    if (bullets[returnCounting, j].activeSelf)
                        Destroy(bullets[i, j]);

                    yield return new WaitForSeconds(0.1f);
                }
                returnCounting++;
            }

            Vector2 vec = (_player.transform.position - transform.position).normalized;

            int angle = UnityEngine.Random.Range(-30, 30);

            for(int j = 0; j < bulletCount; j++)
            {
                bullets[i, j] = _type2;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = Quaternion.Euler(0, 0, angle) * vec;
                rigid.velocity = dir.normalized * speed;

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Eighteen(int bulletCount, float speed, float time, int returnCount, int burstCount) // 엔터 더 건전 - 기어모양으로 전방향에 총알 발사
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];
        bool plus = true;
        float r = 1;
        int returnCounting = 0;

        for (int i = 0; i < burstCount; i++)
        {
            for(int j = 0; j < bulletCount; j++)
            {
                if (r > 1.1f)
                    plus = false;
                else if (r == 1)
                    plus = true;
                bullets[i, j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount)) * r;
                rigid.velocity = dir * speed;

                if (plus)
                    r += 0.1f;
                else
                    r -= 0.1f;
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Nineteen(int bulletCount, float speed, float time, int returnCount, int turnCount) // 엔터 더 건전 - 회오리 샷 근데 양쪽에서 총알이 나옴
    {
        GameObject[,] bullets1 = new GameObject[turnCount, bulletCount];
        GameObject[,] bullets2 = new GameObject[turnCount, bulletCount];

        int returnCounting1 = 0;
        int returnCounting2 = 0;

        for(int i = 0; i < turnCount; i++)
        {
            for(int j = 0; j < bulletCount; j++)
            {
                bullets1[i, j] = _type0;
                bullets2[i, j] = _type0;

                bullets1[i, j].transform.position = transform.position;
                bullets1[i, j].transform.rotation = Quaternion.identity;

                bullets2[i, j].transform.position = transform.position;
                bullets2[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid1 = bullets1[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir1 = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));

                Rigidbody2D rigid2 = bullets2[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir2 = new Vector2(-Mathf.Cos(Mathf.PI * 2 * j / bulletCount), -Mathf.Sin(Mathf.PI * 2 * j / bulletCount));

                rigid1.velocity = dir1.normalized * speed;
                rigid2.velocity = dir2.normalized * speed;
                yield return new WaitForSeconds(time);
            }
        }
    }

    // 사용함
    private IEnumerator Twenty(int bulletCount, int bigBulletCount, int splitBulletCount, float speed, float slowSpeed, float bigBulletStopTime, float bigBulletSplitTime, float returnTime) // 내 생각 - 큰 총알을 날린 뒤 작은 총알들을 사슬처럼 쏘고 당겨서 터트린다
    {
        GameObject[,] bullets = new GameObject[bulletCount, bigBulletCount];
        GameObject[,] splitBullets = new GameObject[bigBulletCount, splitBulletCount];
        GameObject[] bigBullets = new GameObject[bigBulletCount];
        Vector3[] pos = new Vector3[bigBulletCount];
        
        for(int i = 0; i < bigBulletCount; i++)
        {
            bigBullets[i] = _type0;
            bigBullets[i].transform.localScale = bigBullets[i].transform.localScale * 2;
            bigBullets[i].transform.position = transform.position;
            bigBullets[i].transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = bigBullets[i].GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bigBulletCount), Mathf.Sin(Mathf.PI * 2 * i / bigBulletCount));
            rigid.velocity = dir.normalized * speed;
        }

        yield return new WaitForSeconds(bigBulletStopTime);

        for(int i = 0; i < bigBulletCount; i++)
        {
            Rigidbody2D rigid = bigBullets[i].GetComponent<Rigidbody2D>();
            rigid.velocity = Vector2.zero;
        }

        for(int i = 0; i < bulletCount; i++)
        {
            for(int j = 0; j < bigBulletCount; j++)
            {
                bullets[i, j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bigBulletCount), Mathf.Sin(Mathf.PI * 2 * j / bigBulletCount));
                rigid.velocity = dir.normalized * speed;
            }
            yield return new WaitForSeconds(bigBulletStopTime / bulletCount);
        }

        for (int i = 0; i < bulletCount; i++)
        {
            for (int j = 0; j < bigBulletCount; j++)
            {
                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bigBulletCount), Mathf.Sin(Mathf.PI * 2 * j / bigBulletCount));
                rigid.velocity = -dir.normalized * slowSpeed;
            }
        }

        for(int i = 0; i < bigBulletCount; i++)
        {
            for(int j = 0; j < splitBulletCount; j++)
            {
                splitBullets[i, j] = _type0;
                splitBullets[i, j].transform.position = pos[i];
                splitBullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = splitBullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / splitBulletCount), Mathf.Sin(Mathf.PI * 2 * j / splitBulletCount));
                rigid.velocity = dir.normalized * speed;
            }
        }

        for (int i = 0; i < bulletCount; i++)
        {
            for (int j = 0; j < bigBulletCount; j++)
            {
                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * UnityEngine.Random.Range(0 , 361) / 360), Mathf.Sin(Mathf.PI * 2 * UnityEngine.Random.Range(0, 361) / 360));
                rigid.velocity = dir.normalized * speed;
            }
        }
    }

    private IEnumerator TwentyOne(int bulletCount, float speed, float time, int returnCount, int burstCount) // 엔터 더 건전 - 전방향으로 총알을 발사 한 후 총알들이 상하좌우 랜덤 방향으로 날아간다
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];

        for(int i = 0; i < burstCount; i++)
        {
            for(int j = 0; j < bulletCount; j++)
            {
                bullets[i, j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                rigid.velocity = dir.normalized * speed;
            }

            yield return new WaitForSeconds(time);

            int rand = UnityEngine.Random.Range(1, 5);
            Vector2 nextDir;
            switch (rand)
            {
                case 1:
                    nextDir = Vector2.up;
                    break;
                case 2:
                    nextDir = Vector2.down;
                    break;
                case 3:
                    nextDir = Vector2.left;
                    break;
                case 4:
                    nextDir = Vector2.right;
                    break;
                default:
                    nextDir = Vector2.left;
                    break;
            }

            for (int j = 0; j < bulletCount; j++)
            {
                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                rigid.velocity = nextDir.normalized * speed;
            }
        }
    }

    private IEnumerator TwentyTwo(int bulletCount, float speed, float time, int returnCount, int burstCount) // 엔터 더 건전 - 전방향으로 총알을 발사 한 후 총알들이 날아가다가 멈췄다가 다시 날아간다
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];

        int returnCounting = 1;

        for(int i = 0; i < burstCount; i++)
        {
            for(int j = 0; j < bulletCount; j++)
            {
                bullets[i, j] = _type0;
                bullets[i, j].name = $"{i}th";
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                rigid.velocity = dir.normalized * speed;
            }

            yield return new WaitForSeconds(time);

            if(i > 0)
                for(int j = 0; j < bulletCount; j++)
                {
                    Rigidbody2D rigid = bullets[i - 1, j].GetComponent<Rigidbody2D>();
                    Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                    rigid.velocity = dir.normalized * speed;
                }

            for(int j = 0; j < bulletCount; j++)
            {
                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                rigid.velocity = Vector2.zero;
            }
        }

        yield return new WaitForSeconds(time);

        int counting = 0;
        int aCount = 0;

        while(returnCounting < burstCount)
        {
            if(counting > 0)
                for(int i = 0; i < bulletCount; i++)
                {
                    Rigidbody2D rigid = bullets[counting - 1, i].GetComponent<Rigidbody2D>();
                    Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bulletCount), Mathf.Sin(Mathf.PI * 2 * i / bulletCount));
                    rigid.velocity = dir.normalized * speed;
                }
            else if(counting == 0)
                for (int i = 0; i < bulletCount; i++)
                {
                    Rigidbody2D rigid = bullets[burstCount - 1, i].GetComponent<Rigidbody2D>();
                    Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bulletCount), Mathf.Sin(Mathf.PI * 2 * i / bulletCount));
                    rigid.velocity = dir.normalized * speed;
                }

            for (int i = 0; i < bulletCount; i++)
            {
                Rigidbody2D rigid = bullets[counting, i].GetComponent<Rigidbody2D>();
                rigid.velocity = Vector2.zero;
            }

            if (counting >= burstCount - 1)
                counting = 0;
            else
                counting++;

            aCount++;

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator TwentyThree(int bulletCount, float speed, float time, int returnCount) // 엔터 더 건전 - 양 쪽에서 랜덤한 방향으로 총알 난사 - 수정 필요
    {
        GameObject[] bullets1 = new GameObject[bulletCount];
        GameObject[] bullets2 = new GameObject[bulletCount];

        int returnCounting = 0;

        for(int i = 0; i < bulletCount; i++)
        {
            bullets1[i] = _type0;
            bullets2[i] = _type0;

            bullets1[i].transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            bullets1[i].transform.rotation = Quaternion.identity;

            bullets2[i].transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            bullets2[i].transform.rotation = Quaternion.identity;

            Rigidbody2D rigid1 = bullets1[i].GetComponent<Rigidbody2D>();
            Rigidbody2D rigid2 = bullets2[i].GetComponent<Rigidbody2D>();
            Vector2 dir1 = new Vector2(Mathf.Cos(Mathf.PI * 1.5f * UnityEngine.Random.Range(90, 271) / 270), Mathf.Sin(Mathf.PI * 1.5f * UnityEngine.Random.Range(90, 271) / 270));
            Vector2 dir2 = new Vector2(Mathf.Cos(Mathf.PI * 1.5f * UnityEngine.Random.Range(90, 271) / 270), Mathf.Sin(Mathf.PI * 1.5f * UnityEngine.Random.Range(90, 271) / 270));
            rigid1.velocity = -dir1.normalized * speed;
            rigid2.velocity = dir2.normalized * speed;

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator TwentyFour(int bulletCount, int omnidirBulletCount, float bulletSpeed, float turnSpeed, float time, int turnCount) // 엔터 더 건전 - 총알로 십자모양을 만들고 회전 시키면서 일정 회전마다 전방향으로 총알을 쏜다
    {
        GameObject[,] bullets1 = new GameObject[4, bulletCount];

        for(int i = 0; i < bulletCount; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                bullets1[j, i] = _type0;
                bullets1[j, i].transform.position = transform.position;
                bullets1[j, i].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets1[j, i].GetComponent<Rigidbody2D>();
                Vector2 dir;
                switch (j)
                {
                    case 0:
                        dir = Vector2.right;
                        break;
                    case 1:
                        dir = Vector2.up;
                        break;
                    case 2:
                        dir = Vector2.left;
                        break;
                    case 3:
                        dir = Vector2.down;
                        break;
                    default:
                        dir = Vector2.right;
                        break;
                }
                rigid.velocity = dir.normalized * bulletSpeed;
            }

            yield return new WaitForSeconds(time);
        }

        for(int i = 0; i < bulletCount; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                Rigidbody2D rigid = bullets1[j, i].GetComponent<Rigidbody2D>();
                rigid.velocity = Vector2.zero;
            }
        }

        yield return new WaitForSeconds(time);

        GameObject[] bullets2 = new GameObject[omnidirBulletCount];

        int turnCounting = 0;
        float currentTime = 0;
        bool first = true;

        while(turnCounting < turnCount)
        {
            currentTime += Time.deltaTime * turnSpeed;

            if (currentTime < 360)
            {
                for (int i = 0; i < bulletCount; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        var rad = Mathf.Deg2Rad * (currentTime + j * 360 / 4);
                        var x = (i + 1) * time * Mathf.Cos(rad);
                        var y = (i + 1) * time * Mathf.Sin(rad);
                        bullets1[j, i].transform.position = transform.position + new Vector3(x, y);
                    }
                }

                if(currentTime % 180 >= 0 && currentTime % 180 <= 1)
                {
                    if(!first)
                    {
                        for (int i = 0; i < omnidirBulletCount; i++)
                        {
                            if (bullets2[i].activeSelf)
                                Destroy(bullets2[i]);
                        }
                    }
                    else
                        first = false;

                    for (int i = 0; i < omnidirBulletCount; i++)
                    {
                        bullets2[i] = _type0;
                        bullets2[i].transform.position = transform.position;
                        bullets2[i].transform.rotation = Quaternion.identity;

                        Rigidbody2D rigid = bullets2[i].GetComponent<Rigidbody2D>();
                        Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / omnidirBulletCount), Mathf.Sin(Mathf.PI * 2 * i / omnidirBulletCount));
                        rigid.velocity = dir.normalized * bulletSpeed * 2;
                    }
                }
            }
            else
            {
                currentTime = 0;
                turnCounting++;
                for (int i = 0; i < omnidirBulletCount; i++)
                {
                    if (bullets2[i].activeSelf)
                        Destroy(bullets2[i]);
                }
                for (int i = 0; i < omnidirBulletCount; i++)
                {
                    bullets2[i] = _type0;
                    bullets2[i].transform.position = transform.position;
                    bullets2[i].transform.rotation = Quaternion.identity;

                    Rigidbody2D rigid = bullets2[i].GetComponent<Rigidbody2D>();
                    Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / omnidirBulletCount), Mathf.Sin(Mathf.PI * 2 * i / omnidirBulletCount));
                    rigid.velocity = dir.normalized * bulletSpeed * 2;
                }
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator TwentyFive(int bulletCount, float speed, float time, int returnCount, int burstCount) // 내 생각 - 랜덤한 방향으로 총알을 여러 발 날리고 잠시 후 플레이어 방향으로 총알들이 빠르게 날아간다
    {
        GameObject[,] bullets = new GameObject[burstCount, bulletCount];

        int returnCounting = 0;

        for(int i = 0; i < burstCount; i++)
        {
            for (int j = 0; j < bulletCount; j++)
            {
                bullets[i ,j] = _type0;
                bullets[i, j].transform.position = transform.position;
                bullets[i, j].transform.rotation = Quaternion.identity;

                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletCount), Mathf.Sin(Mathf.PI * 2 * j / bulletCount));
                rigid.velocity = dir.normalized * speed;
            }

            yield return new WaitForSeconds(time);

            for (int j = 0; j < bulletCount; j++)
            {
                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                rigid.velocity = Vector2.zero;
            }

            yield return new WaitForSeconds(Time.deltaTime);

            Vector3 nextDir = _player.transform.position;

            for (int j = 0; j < bulletCount; j++)
            {
                Rigidbody2D rigid = bullets[i, j].GetComponent<Rigidbody2D>();
                Vector2 dir = nextDir - bullets[i, j].transform.position;
                rigid.velocity = dir.normalized * speed * 2;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_seven)
        {
            Vector2 dir = _rigid.velocity;

            RaycastHit2D rHit = Physics2D.Raycast(transform.position, Vector2.right, 0.55f, _mask);
            RaycastHit2D lHit = Physics2D.Raycast(transform.position, Vector2.left, 0.55f, _mask);
            RaycastHit2D uHit = Physics2D.Raycast(transform.position, Vector2.up, 0.55f, _mask);
            RaycastHit2D dHit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, _mask);

            if ((rHit.collider != null || lHit.collider != null) && (uHit.collider != null || dHit.collider != null))
                _rigid.velocity = new Vector2(-dir.x, -dir.y);
            else if (rHit.collider != null || lHit.collider != null)
                _rigid.velocity = new Vector2(-dir.x, dir.y);
            else if (uHit.collider != null || dHit.collider != null)
                _rigid.velocity = new Vector2(dir.x, -dir.y);
        }
    }
}
