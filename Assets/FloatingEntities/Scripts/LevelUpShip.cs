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
    public float LevelR = 0.2f; // 물고기가 잡힐 최대 확률
    public float Levelr = 0f; //물고기를 잡힐 최소 확률


    // 물고기 한 마리당 얻는 골드
    public int baseGoldPerFish = 1;
    public int extraGoldPerLevel = 1;
    public float fishCatchRate = 1.0f;
    void Awake()
    {
        ppb = GetComponent<PropellerBoats>();
    }

    private void Update()
    {
        // 배가 멈추어 있을 때 f키를 눌러 낚시를 합니다.
        if (ppb.engine_rpm == 0 && Input.GetKey(KeyCode.F))
        {
            // 물고기 잡기 시도 -> 재구현 필요할 것!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (Random.Range(Levelr, LevelR) < fishCatchRate * Time.deltaTime)
            {
                // 레벨에 따른 골드 획득량 계산
                int goldPerFish = baseGoldPerFish + extraGoldPerLevel * (currentLevel);

                // 골드 획득
                GainGold(goldPerFish);

                //잡았다면 콘솔이나 UI에 이벤트 코드 구현
                Debug.Log("잡았다!!");
                Debug.Log("현재 골드 : ");
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
                    Debug.Log("레벨 업!");
                    break;
                case 2: LevelUp3(); Debug.Log("레벨 업!"); break;
                case 3: LevelUp4(); Debug.Log("레벨 업!"); break;
                case 4: LevelUp5(); Debug.Log("레벨 업!"); break;
                case 5:
                    Debug.Log("게임 종료");
                    endgame(); break;
            }
            
        }

    }
     
    public void LevelUp2()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        
        LevelR += 0.2f;

        // 성능 향상 코드
        ppb.engine_max_rpm += 100F;
        ppb.acceleration_cst += 2.0F;
    }
    public void LevelUp3()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        LevelR += 0.1f;

        // 성능 향상 코드
        ppb.engine_max_rpm += 300f;
       

    }
    public void LevelUp4()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        LevelR += 0.2f;

        // 성능 향상 코드
        ppb.engine_max_rpm += 400f;
        ppb.acceleration_cst += 2.0F;
    }
    public void LevelUp5()
    {
        currentLevel++;
        currentGold -= extoLevelup[currentLevel-1];
        LevelR += 0.2f;


        // 성능 향상 코드
        ppb.engine_max_rpm += 500f;
        ppb.acceleration_cst += 3.0F;
    }
    
    public void endgame()
    {
        //게임 클리어 실행
    }
}
