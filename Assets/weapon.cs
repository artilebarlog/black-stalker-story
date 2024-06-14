using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] protected GameObject particle;
    [SerializeField] protected GameObject cam;
    protected bool auto = false;
    protected float cooldown = 0;
    protected float timer = 0;
    //������� �������� � ������
    protected int ammoCurrent;
    //������� �������� ���������� � ������
    protected int ammoMax;
    //������� �������� � ������
    protected int ammoBackPack;
    
    //���������� ��� ����������� ������ �� UI
    [SerializeField] TMP_Text ammoText;
    // Start is called before the first frame update
    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //���� � ��� ���-�� �������� � ������ �� ������������ ���, ���� � ������ �������� ������ ����, ��
            if (ammoCurrent != ammoMax || ammoBackPack != 0)
            {
                //���������� ����� ����������� � ���������
                //����� �������� ����� ���������� ��������������
                Invoke("Reload", 1);
            }
        }
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        AmmoTextUpdate();
    }
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                if (ammoCurrent > 0)
                {
                    OnShoot();
                    timer = 0;
                    ammoCurrent = ammoCurrent - 1;
                }
            }
        }
    }
    private void AmmoTextUpdate()
    {
        //ammoText.text = ammoCurrent + " / " + ammoBackPack;
    }
    protected virtual void OnShoot()
    {
    }
    private void Reload()
    {
        //������� ��������� ����������, ������� ����������� ������� �������� ��� ����� ��������
        int ammoNeed = ammoMax - ammoCurrent;
        //���� ���-�� �������� � ������ ������ ��� ����� ���-��, ������� ��� ����� �������� ��,
        if (ammoBackPack >= ammoNeed)
        {
            //�� ���-�� �������� � ������ �������� ���-��, ������� ��������� � ������
            ammoBackPack -= ammoNeed;
            //� ������ ��������� ������ ���������� ��������
            ammoCurrent += ammoNeed;
        }
        //�����(���� � ������ ������ ��������, ��� ��� �����)
        else
        {
            //��������� � ������ ������� ��������, ������� �������� � ������
            ammoCurrent += ammoBackPack;
            //�������� ���-�� �������� � ������
            ammoBackPack = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //���� � ��� ���-�� �������� � ������ �� ������������ ���, ���� � ������ �������� ������ ����, ��
            if (ammoCurrent != ammoMax || ammoBackPack != 0)
            {
                //���������� ����� ����������� � ���������
                //����� �������� ����� ���������� ��������������
                Invoke("Reload", 1);
            }
        }
    }
}
