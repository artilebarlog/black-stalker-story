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
    //Сколько патронов в обойме
    protected int ammoCurrent;
    //Сколько патронов помещается в обойму
    protected int ammoMax;
    //Сколько патронов в запасе
    protected int ammoBackPack;
    
    //Переменная для отображения текста на UI
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
            //если у нас кол-во патронов в обойме НЕ максимальное ИЛИ, если в запасе патронов больше нуля, то
            if (ammoCurrent != ammoMax || ammoBackPack != 0)
            {
                //активируем метод перезарядки с задержкой
                //время задержки можно установить самостоятельно
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
        //создаем временную переменную, которая высчитывает сколько патронов нам нужно добавить
        int ammoNeed = ammoMax - ammoCurrent;
        //если кол-во патронов в запасе больше или равно кол-ву, которое нам нужно добавить то,
        if (ammoBackPack >= ammoNeed)
        {
            //из кол-ва патронов в запасе вычитаем кол-во, которое добавляем в обойму
            ammoBackPack -= ammoNeed;
            //в обойму добавляем нужное количество патронов
            ammoCurrent += ammoNeed;
        }
        //иначе(если в запасе меньше патронов, чем нам нужно)
        else
        {
            //добавляем в обойму столько патронов, сколько осталось в запасе
            ammoCurrent += ammoBackPack;
            //обнуляем кол-во патронов в запасе
            ammoBackPack = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //если у нас кол-во патронов в обойме НЕ максимальное ИЛИ, если в запасе патронов больше нуля, то
            if (ammoCurrent != ammoMax || ammoBackPack != 0)
            {
                //активируем метод перезарядки с задержкой
                //время задержки можно установить самостоятельно
                Invoke("Reload", 1);
            }
        }
    }
}
