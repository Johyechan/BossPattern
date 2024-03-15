using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatterns : MonoBehaviour
{
    // �̸� ���� ���ϵ� ����� �ΰ� ���߿� �ʿ��� �͵鸸 ����� ���� ��ũ��Ʈ
    // pooling�� �ȵǾ� ����

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
        //StartCoroutine(One(30, 2, 1, 2)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �߻� Ƚ��
        //StartCoroutine(Two(6, 2, 0.2f, 10, 50)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����ϱ� �����ϴ� Ƚ��, ȸ�� Ƚ��
        //StartCoroutine(Three(3, 100, 5, this.transform, 3)); // �Ѿ� ����, ȸ�� �ӵ�, �����Ǵ� �ð�, �θ� ��ġ, ������
        //StartCoroutine(Four(4, 2, 3, 2)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �߻� Ƚ��
        //StartCoroutine(Five(30, 5, 0.1f, 20, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����ϱ� �����ϴ� Ƚ��, ȸ�� Ƚ��
        //StartCoroutine(Six(4, 2, 2, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �߻� Ƚ��
        //StartCoroutine(Seven(5, 5)); // ���� �ӵ�, ���� �ð�
        //StartCoroutine(Eight(6, 5, 1f, 1)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, ������
        //StartCoroutine(Nine(5, 1, 5, -5, 2, -2)); // ��ź ����, ��� �ð�, x�� �ִ� ��ġ, x�� �ּ� ��ġ, y�� �ִ� ��ġ, y�� �ּ� ��ġ
        //StartCoroutine(Ten(6, 1, 3, 2)); // ����� ����, ��� �ð�, �� ����� Ƚ��, ó�� ������
        //StartCoroutine(Eleven(3, 1, 1)); // ��� ���� ���� �ٴϴ� �ð�, �������� ��� ���� ��� ���߰� ������ �ð�, �������� �������� �ð�
        //StartCoroutine(Twelve(7, 2, 1, 2, 4, 20)); // �Ѿ� ����, �Ѿ� �ӵ�, ������ �ٲ�� �ð�, �����Ǳ� �����ϴ� Ƚ��, ���� ��, ����
        //StartCoroutine(Thirteen(6, 2, 0.5f)); // ������ �߻� Ƚ��, ������ �߻� �ӵ�(Time.deltaTime * speed ������), ��� �ð�
        //StartCoroutine(Fourteen(3, 2, 1, 2, 2, 30)); // �Ѿ� ����, �Ѿ� �ӵ�, �Ѿ� ��� �ð�, ���� �ð�, ���� ��, ����
        //StartCoroutine(Fifteen(8, 3, 0.5f, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �л� Ƚ��
        //StartCoroutine(Sixteen(10, 2, 0.5f, 1, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ���ٶ󺸴� Ƚ��
        //StartCoroutine(Seventeen(8, 3, 1, 2, 5)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ��, ���� Ƚ��
        //StartCoroutine(Eighteen(52, 2, 2, 2, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ��, ���� Ƚ��
        //StartCoroutine(Nineteen(30, 4, 0.1f, 20, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ��, ȸ�� Ƚ��
        //StartCoroutine(Twenty(10, 6, 8, 2, 0.1f, 2, 2, 2)); // �Ѿ� ����, ū �Ѿ� ����, �п��� �� �Ѿ� ����, �Ѿ� �ӵ�, ���� �Ѿ� �ӵ�, ū �Ѿ��� ���ߴ� �ð�, ū �Ѿ��� �п��Ǵ� �ð�, �����Ǵ� �ð�
        //StartCoroutine(TwentyOne(30, 2, 3, 1, 2)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ��, ���� Ƚ��
        //StartCoroutine(TwentyTwo(30, 2, 1, 3, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ��, ���� Ƚ��
        //StartCoroutine(TwentyThree(30, 2, 0.3f, 20)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ��
        //StartCoroutine(TwentyFour(10, 30, 1, 100, 0.5f, 3)); // �Ѿ� ����, ������ �߻� �Ѿ� ����, �Ѿ� �ӵ�, ȸ�� �ӵ�, ��� �ð�, ȸ�� Ƚ��
        //StartCoroutine(TwentyFive(30, 2, 1, 2, 3)); // �Ѿ� ����, �Ѿ� �ӵ�, ��� �ð�, �����Ǳ� �����ϴ� Ƚ��, ���� Ƚ��
    }

    // �����
    private IEnumerator One(int bulletCount, float speed, float time, int burstCount) // �� ���� - ���������� �� ���� �Ѿ� �߻�
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

                // ������� ��� �Ѿ��� �߻� �������� ȸ��
                //Vector3 rotation = Vector3.forward * 360 * i / bulletCount + Vector3.forward * 90;
                //bullet.transform.Rotate(rotation);
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Two(int bulletCount, float speed, float time, int turnCount) // �� ���� - ���� �� �߻� ������ �ٲ�鼭 �߻�
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

                // ������� ��� �Ѿ��� �߻� �������� ȸ�� <- �̰� ȸ���� �̻��� (�ϴ��� �� ������ ���� �Ѿ˷θ� �ϱ�)
                //Vector3 rotation = Vector3.forward * 360 * j / 5 + Vector3.forward * 90 - Vector3.forward * 10 * i;
                //bullet.transform.Rotate(rotation);
            }

            yield return new WaitForSeconds(time);
        }
    }

    private IEnumerator Three(int bulletCount, float speed, float returnTime, Transform trans, float r) // �� - ������ũ �� �ƿ�� �нú� (������ ���� ����)
    {
        float deg = 0; // ����
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
                    bullets[i].transform.position = trans.position + new Vector3(x, y); // ����
                    bullets[i].transform.rotation = Quaternion.Euler(0, 0, (deg + i * 360 / bullets.Length) * -1); // ����
                }
            }
            else
                deg = 0;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator Four(int bulletCount, float speed, float time, int burstCount) // �� ���� - �� ��° ������ ���� �Ѿ��� ���� �������� ������
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

    private IEnumerator Five(int bulletCount, float speed, float time, int end) // �� ���� - ȸ���� ġ�� ���� �׸��� �Ѿ� �߻�
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

                // ������� ��� �Ѿ��� �߻� �������� ȸ��
                //Vector3 rotation = Vector3.forward * 360 * counting / bulletCount + Vector3.forward * 90;
                //bullet.transform.Rotate(rotation);

                yield return new WaitForSeconds(time);
            }
        }
    }

    private IEnumerator Six(int bulletCount, float speed, float time, int burstCount) // �ҿ� ����Ʈ - �Ѿ��� ���� �������� ���ư��� �Ѿ��� �������鼭 �� �Ѿ��� �¿�� �߻�
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
    } // �Ѿ��� �¿�� �߻��ϰ� ���ִ� �Լ�

    private IEnumerator Seven(float speed, float time) // �ҿ� ����Ʈ - �÷��̾� �������� ����
    {
        _seven = true;
        Vector2 dir = _player.transform.position - transform.position;
        _rigid.velocity = dir.normalized * speed;

        yield return new WaitForSeconds(time);

        _rigid.velocity = Vector2.zero;
    }

    private IEnumerator Eight(int bulletCount, float speed, float time, int r) // �� ���� - ���������� �Ѿ��� ���� �� ��� �� ƨ��� �Ѿ� �߻� 
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

    private IEnumerator Nine(int bombCount, float time, float maxX, float minX, float maxY, float minY) // �� ���� - ������ ��ġ�� ����
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

    // �����
    private IEnumerator Ten(int shockCount, float time, int waveCount, float r) // �ҿ� ����Ʈ - �����
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

    private IEnumerator Eleven(float followTime, float chargingTime, float returnTime) // �ҿ� ����Ʈ - �÷��̾ ����ٴϴ� ��� ���� �ִٰ� ��� �� �������� �߻�
    {
        float t = 0;
        float angle = 0;

        GameObject warning = _type0;
        warning.transform.position = transform.position;

        while(t < followTime)
        {
            angle = Mathf.Atan2(_player.transform.position.y - transform.position.y, _player.transform.position.x - transform.position.x) * Mathf.Rad2Deg; // �� �������� ������ ����(�÷��̾������ ������ ����)
            warning.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward); // angle �������� ������ ȸ��

            t += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Quaternion rot = warning.transform.rotation;

        yield return new WaitForSeconds(chargingTime);

        GameObject laser = _laser;
        laser.transform.position = transform.position;
        laser.transform.rotation = rot;
    }

    private IEnumerator Twelve(int bulletCount, float speed, float time, int directionCount, float angle) // �� ���� - ���� �������� �Ѿ��� ���η� �Ϸ� ���� ���� ������
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

    private IEnumerator Thirteen(int shotCount, float speed, float time) // �� ���� - ���ư��鼭 �������� �߻�
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

    // �����
    private IEnumerator Fourteen(int bulletCount, float speed, float time, float returnTime, int burstCount, float angle) // ���� �� ���� - �÷��̾� �������� ���� 
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

    // �����
    private IEnumerator Fifteen(int bulletCount, float speed, float time, int splitCount) // ���� �� ���� - �л�
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

    private IEnumerator Sixteen(int bulletCount, float speed, float time, int returnCount, int watchCount) // ���� �� ���� - ��Ʋ�� �� ����
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

    private IEnumerator Seventeen(int bulletCount, float speed, float time, int returnCount, int burstCount) // ���� �� ���� - ���ҰŸ��� �Ѿ� ���� �� �߻�
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

    private IEnumerator Eighteen(int bulletCount, float speed, float time, int returnCount, int burstCount) // ���� �� ���� - ��������� �����⿡ �Ѿ� �߻�
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

    private IEnumerator Nineteen(int bulletCount, float speed, float time, int returnCount, int turnCount) // ���� �� ���� - ȸ���� �� �ٵ� ���ʿ��� �Ѿ��� ����
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

    // �����
    private IEnumerator Twenty(int bulletCount, int bigBulletCount, int splitBulletCount, float speed, float slowSpeed, float bigBulletStopTime, float bigBulletSplitTime, float returnTime) // �� ���� - ū �Ѿ��� ���� �� ���� �Ѿ˵��� �罽ó�� ��� ��ܼ� ��Ʈ����
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

    private IEnumerator TwentyOne(int bulletCount, float speed, float time, int returnCount, int burstCount) // ���� �� ���� - ���������� �Ѿ��� �߻� �� �� �Ѿ˵��� �����¿� ���� �������� ���ư���
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

    private IEnumerator TwentyTwo(int bulletCount, float speed, float time, int returnCount, int burstCount) // ���� �� ���� - ���������� �Ѿ��� �߻� �� �� �Ѿ˵��� ���ư��ٰ� ����ٰ� �ٽ� ���ư���
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

    private IEnumerator TwentyThree(int bulletCount, float speed, float time, int returnCount) // ���� �� ���� - �� �ʿ��� ������ �������� �Ѿ� ���� - ���� �ʿ�
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

    private IEnumerator TwentyFour(int bulletCount, int omnidirBulletCount, float bulletSpeed, float turnSpeed, float time, int turnCount) // ���� �� ���� - �Ѿ˷� ���ڸ���� ����� ȸ�� ��Ű�鼭 ���� ȸ������ ���������� �Ѿ��� ���
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

    private IEnumerator TwentyFive(int bulletCount, float speed, float time, int returnCount, int burstCount) // �� ���� - ������ �������� �Ѿ��� ���� �� ������ ��� �� �÷��̾� �������� �Ѿ˵��� ������ ���ư���
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
