using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpShip : MonoBehaviour
{
    public int[] extoLevelup = new int[] { 100, 200, 400, 700, 1200 };
    public int currentGold = 0;
    public int currentLevel = 0;
    private PropellerBoats ppb;
    public int ShipLevelUp = 1;
    public float LevelR = 0.2f; // ����Ⱑ ���� �ִ� Ȯ��
    public float Levelr = 0f; //����⸦ ���� �ּ� Ȯ��


    // ����� �� ������ ��� ���
    public int baseGoldPerFish = 1;
    public int extraGoldPerLevel = 1;
    public float fishCatchRate = 1.0f;
    void Awake()
    {
        ppb = GetComponent<PropellerBoats>();
    }

    private void Update()
    {
        // �谡 ���߾� ���� �� fŰ�� ���� ���ø� �մϴ�.
        if (ppb.engine_rpm == 0 && Input.GetKey(KeyCode.F))
        {
            // ����� ��� �õ� -> �籸�� �ʿ��� ��!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (Random.Range(Levelr, LevelR) < fishCatchRate * Time.deltaTime)
            {
                // ������ ���� ��� ȹ�淮 ���
                int goldPerFish = baseGoldPerFish + extraGoldPerLevel * (currentLevel);

                // ��� ȹ��
                GainGold(goldPerFish);

                //��Ҵٸ� �ܼ��̳� UI�� �̺�Ʈ �ڵ� ����
                Debug.Log("��Ҵ�!!");
                Debug.Log("���� ��� : ");
                Debug.Log(currentGold);
            }
        }
    }

    public void GainGold(int Gold)
    {
        currentGold += Gold;

        if(currentLevel<extoLevelup.Length && currentGold >= extoLevelup[currentLevel])
        {
            ++ShipLevelUp;

            switch (ShipLevelUp)
            {
                case 1: LevelUp2();
                    Debug.Log("���� ��!");
                    break;
                case 2: LevelUp3(); Debug.Log("���� ��!"); break;
                case 3: LevelUp4(); Debug.Log("���� ��!"); break;
                case 4: LevelUp5(); Debug.Log("���� ��!"); break;
                case 5:
                    Debug.Log("���� ����");
                    endgame(); break;
            }
            
        }

    }
     
    public void LevelUp2()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        
        LevelR += 0.2f;

        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 100F;
        ppb.acceleration_cst += 2.0F;
    }
    public void LevelUp3()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        LevelR += 0.1f;

        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 300f;
       

    }
    public void LevelUp4()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        LevelR += 0.2f;

        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 400f;
        ppb.acceleration_cst += 2.0F;
    }
    public void LevelUp5()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        LevelR += 0.2f;


        // ���� ��� �ڵ�
        ppb.engine_max_rpm += 500f;
        ppb.acceleration_cst += 3.0F;
    }
    
    public void endgame()
    {
        //���� Ŭ���� ����
    }
}
