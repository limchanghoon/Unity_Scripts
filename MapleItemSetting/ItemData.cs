using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ItemDictionary
{
    public List<Item> ringList = new List<Item>();
    public List<Item> pocketList = new List<Item>();
    public List<Item> pendantList = new List<Item>();
    public List<Item> weaponList = new List<Item>();
    public List<Item> beltList = new List<Item>();
    public List<Item> helmetList = new List<Item>();
    public List<Item> faceList = new List<Item>();
    public List<Item> eyeList = new List<Item>();
    public List<Item> shirtList = new List<Item>();
    public List<Item> pantsList = new List<Item>();
    public List<Item> shoesList = new List<Item>();
    public List<Item> earringList = new List<Item>();
    public List<Item> shoulderList = new List<Item>();
    public List<Item> glovesList = new List<Item>();
    public List<Item> androidList = new List<Item>();
    public List<Item> emblemList = new List<Item>();
    public List<Item> badgeList = new List<Item>();
    public List<Item> medalList = new List<Item>();
    public List<Item> subWeaponList = new List<Item>();
    public List<Item> capeList = new List<Item>();
    public List<Item> heartList = new List<Item>();

    public List<List<Item>> itemListList = new List<List<Item>>();

    public ItemDictionary()
    {
        itemListList.Add(ringList);
        itemListList.Add(pocketList);
        itemListList.Add(pendantList);
        itemListList.Add(weaponList);
        itemListList.Add(beltList);
        itemListList.Add(helmetList);
        itemListList.Add(faceList);
        itemListList.Add(eyeList);
        itemListList.Add(shirtList);
        itemListList.Add(pantsList);
        itemListList.Add(shoesList);
        itemListList.Add(earringList);
        itemListList.Add(shoulderList);
        itemListList.Add(glovesList);
        itemListList.Add(androidList);
        itemListList.Add(emblemList);
        itemListList.Add(badgeList);
        itemListList.Add(medalList);
        itemListList.Add(subWeaponList);
        itemListList.Add(capeList);
        itemListList.Add(heartList);

        int t = 0;

        #region 0.반지

        t = 0;

        ringList.Add(new Item(ItemType.Ring, "연금술사의 반지", 10, 1, 1, 1, 1, 150, 0, 0, 0, 0, 0, 0, 2, 999));
        t++;

        ringList.Add(new Item(ItemType.Ring, "버서커의 임모탈 링", 30, 5, 5, 5, 5, 0, 2, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalHero;
        ringList.Add(new Item(ItemType.Ring, "가디언의 임모탈 링", 30, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalHero;
        ringList.Add(new Item(ItemType.Ring, "버서커의 마이스터 임모탈 링", 90, 5, 5, 5, 5, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalMeisterHero;
        ringList.Add(new Item(ItemType.Ring, "가디언의 마이스터 임모탈 링", 90, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalMeisterHero;

        ringList.Add(new Item(ItemType.Ring, "아크로드의 이터널 링", 30, 5, 5, 5, 5, 0, 0, 2, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalHero;
        ringList.Add(new Item(ItemType.Ring, "오라클의 이터널 링", 30, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalHero;
        ringList.Add(new Item(ItemType.Ring, "아크로드의 마이스터 이터널 링", 90, 5, 5, 5, 5, 0, 0, 3, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalMeisterHero;
        ringList.Add(new Item(ItemType.Ring, "오라클의 마이스터 이터널 링", 90, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalMeisterHero;

        ringList.Add(new Item(ItemType.Ring, "올마이티링", 30, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 3, 99));
        t++;
        ringList.Add(new Item(ItemType.Ring, "마이스터 올마이티링", 75, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 3, 99));
        t++;

        ringList.Add(new Item(ItemType.Ring, "마이스터링", 140, 5, 5, 5, 5, 200, 1, 1, 0, 0, 0, 0, 2, 99));
        ringList[t].setName = SetName.Meister;
        ringList[t++].basicMaxMP = 200;

        ringList.Add(new Item(ItemType.Ring, "실버블라썸 링", 110, 5, 5, 5, 5, 0, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t++].setName = SetName.BossTrinket;
        ringList.Add(new Item(ItemType.Ring, "고귀한 이피아의 반지", 120, 5, 5, 5, 5, 100, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t].setName = SetName.BossTrinket;
        ringList[t++].basicMaxMP = 100;
        ringList.Add(new Item(ItemType.Ring, "가디언 엔젤 링", 160, 5, 5, 5, 5, 200, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t].setName = SetName.BossTrinket;
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "여명의 가디언 엔젤 링", 160, 5, 5, 5, 5, 200, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t].setName = SetName.DawnBoss;
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "거대한 공포", 200, 5, 5, 5, 5, 250, 4, 4, 0, 0, 0, 0, 3, 5));
        ringList[t].setName = SetName.BlackBossTrinket;
        ringList[t++].basicMaxMP = 250;


        ringList.Add(new Item(ItemType.Ring, "무르무르의 로드 링", 100, 7, 7, 7, 7, 200, 2, 0, 0, 0, 0, 0, 2, 99));
        t++;
        ringList.Add(new Item(ItemType.Ring, "무르무르의 메이지 링", 100, 7, 7, 7, 7, 0, 0, 2, 0, 0, 0, 0, 2, 99));
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "구미호의 혼령반지", 100, 7, 7, 7, 7, 200, 2, 0, 0, 0, 0, 0, 2, 99));
        t++;
        ringList.Add(new Item(ItemType.Ring, "구미호의 주술반지", 100, 7, 7, 7, 7, 0, 0, 2, 0, 0, 0, 0, 2, 99));
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "스칼렛 링", 135, 4, 4, 4, 4, 150, 1, 1, 0, 0, 0, 0, 2, 99));
        ringList[t].isLucky = true;
        ringList[t++].basicMaxMP = 150;


        ringList.Add(new Item(ItemType.Ring, "리스트레인트 링", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "웨폰퍼프 링", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "컨티뉴어스 링", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "리스크테이커 링", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "얼티메이덤 링", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;


        //이벤트 링

        ringList.Add(new Item(ItemType.Ring, "오닉스 링(STR)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 30;
        ringList[t].spellSTR = 47;
        ringList[t].spellDEX = 7;
        ringList[t].spellINT = 7;
        ringList[t].spellLUK = 7;
        ringList[t].spellMaxHP = 70;
        ringList[t].spellMaxMP = 70;
        ringList[t].spellATK = 10;
        ringList[t].SetCompletedUpgrade(10);
        ringList[t].isBasicGrowth = true;
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t].downPotentialPossible = false;
        ringList[t].upPotentialGrade = OptionGrade.Epic;
        ringList[t++].upPotential1 = "크리티컬 데미지 : +5%";

        ringList.Add(new Item(ItemType.Ring, "오닉스 링(DEX)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 30;
        ringList[t].spellSTR = 7;
        ringList[t].spellDEX = 47;
        ringList[t].spellINT = 7;
        ringList[t].spellLUK = 7;
        ringList[t].spellMaxHP = 70;
        ringList[t].spellMaxMP = 70;
        ringList[t].spellATK = 10;
        ringList[t].SetCompletedUpgrade(10);
        ringList[t].isBasicGrowth = true;
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t].downPotentialPossible = false;
        ringList[t].upPotentialGrade = OptionGrade.Epic;
        ringList[t++].upPotential1 = "크리티컬 데미지 : +5%";

        ringList.Add(new Item(ItemType.Ring, "오닉스 링(INT)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 30;
        ringList[t].spellSTR = 7;
        ringList[t].spellDEX = 7;
        ringList[t].spellINT = 47;
        ringList[t].spellLUK = 7;
        ringList[t].spellMaxHP = 70;
        ringList[t].spellMaxMP = 70;
        ringList[t].spellMAG = 10;
        ringList[t].SetCompletedUpgrade(10);
        ringList[t].isBasicGrowth = true;
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t].downPotentialPossible = false;
        ringList[t].upPotentialGrade = OptionGrade.Epic;
        ringList[t++].upPotential1 = "크리티컬 데미지 : +5%";

        ringList.Add(new Item(ItemType.Ring, "오닉스 링(LUK)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 30;
        ringList[t].spellSTR = 7;
        ringList[t].spellDEX = 7;
        ringList[t].spellINT = 7;
        ringList[t].spellLUK = 47;
        ringList[t].spellMaxHP = 70;
        ringList[t].spellMaxMP = 70;
        ringList[t].spellATK = 10;
        ringList[t].SetCompletedUpgrade(10);
        ringList[t].isBasicGrowth = true;
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t].downPotentialPossible = false;
        ringList[t].upPotentialGrade = OptionGrade.Epic;
        ringList[t++].upPotential1 = "크리티컬 데미지 : +5%";

        ringList.Add(new Item(ItemType.Ring, "오닉스 링(MaxHP)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 7;
        ringList[t].spellSTR = 7;
        ringList[t].spellDEX = 7;
        ringList[t].spellINT = 7;
        ringList[t].spellLUK = 7;
        ringList[t].spellMaxHP = 2070;
        ringList[t].spellMaxMP = 70;
        ringList[t].spellATK = 10;
        ringList[t].SetCompletedUpgrade(10);
        ringList[t].isBasicGrowth = true;
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t].downPotentialPossible = false;
        ringList[t].upPotentialGrade = OptionGrade.Epic;
        ringList[t++].upPotential1 = "크리티컬 데미지 : +5%";

        ringList.Add(new Item(ItemType.Ring, "오닉스 링(올스탯)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 30;
        ringList[t].spellSTR = 27;
        ringList[t].spellDEX = 27;
        ringList[t].spellINT = 27;
        ringList[t].spellLUK = 27;
        ringList[t].spellMaxHP = 70;
        ringList[t].spellMaxMP = 70;
        ringList[t].spellATK = 10;
        ringList[t].SetCompletedUpgrade(10);
        ringList[t].isBasicGrowth = true;
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t].downPotentialPossible = false;
        ringList[t].upPotentialGrade = OptionGrade.Epic;
        ringList[t++].upPotential1 = "크리티컬 데미지 : +5%";

        ringList.Add(new Item(ItemType.Ring, "리부트 오닉스 링", 30, 23, 23, 23, 23, 1030, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 30;
        ringList[t].spellSTR = 7;
        ringList[t].spellDEX = 7;
        ringList[t].spellINT = 7;
        ringList[t].spellLUK = 7;
        ringList[t].spellMaxHP = 70;
        ringList[t].spellMaxMP = 70;
        ringList[t].basicATK = 10;
        ringList[t].basicMAG = 10;
        ringList[t].isBasicGrowth = true;
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t].downPotentialPossible = false;
        ringList[t].upPotentialGrade = OptionGrade.Epic;
        ringList[t++].upPotential1 = "크리티컬 데미지 : +5%";


        ringList.Add(new Item(ItemType.Ring, "벤젼스 링", 120, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].spellSTR = 20;
        ringList[t].spellDEX = 20;
        ringList[t].spellINT = 20;
        ringList[t].spellLUK = 20;
        ringList[t].spellMaxHP = 2000;
        ringList[t].spellMaxMP = 2000;
        ringList[t].spellATK = 20;
        ringList[t].spellMAG = 20;
        ringList[t].SetCompletedUpgrade(20);
        ringList[t++].isStarForce = false;

        ringList.Add(new Item(ItemType.Ring, "리부트 벤젼스 링", 120, 20, 20, 20, 20, 2000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 2000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "코스모스 링", 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        ringList[t].spellSTR = 20;
        ringList[t].spellDEX = 20;
        ringList[t].spellINT = 20;
        ringList[t].spellLUK = 20;
        ringList[t].spellMaxHP = 2000;
        ringList[t].spellMaxMP = 2000;
        ringList[t].spellATK = 20;
        ringList[t].spellMAG = 20;
        ringList[t].SetCompletedUpgrade(20);
        ringList[t++].isStarForce = false;

        ringList.Add(new Item(ItemType.Ring, "리부트 코스모스 링", 50, 20, 20, 20, 20, 2000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 2000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "SS급 마스터 쥬얼링", 120, 30, 30, 30, 30, 3000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 3000;
        ringList[t++].isStarForce = false;

        ringList.Add(new Item(ItemType.Ring, "결속의 반지(풀 세트)", 120, 5, 5, 5, 5, 500, 10, 10, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 500;
        ringList[t].spellSTR = 25;
        ringList[t].spellDEX = 25;
        ringList[t].spellINT = 25;
        ringList[t].spellLUK = 25;
        ringList[t].spellMaxHP = 2500;
        ringList[t].spellMaxMP = 2500;
        ringList[t].spellATK = 10;
        ringList[t].spellMAG = 10;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "어드벤쳐 딥다크 크리티컬링", 130, 20, 20, 20, 20, 1500, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 1500;
        ringList[t].basicCriPro = 15;
        ringList[t].basicCriDamage = 5;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "카오스 링", 130, 30, 30, 30, 30, 3000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 3000;
        // 추옵!
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "테네브리스 원정대 반지", 120, 10, 10, 10, 10, 1000, 10, 10, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 1000;
        ringList[t].spellSTR = 30;
        ringList[t].spellDEX = 30;
        ringList[t].spellINT = 30;
        ringList[t].spellLUK = 30;
        ringList[t].spellMaxHP = 3000;
        ringList[t].spellMaxMP = 3000;
        ringList[t].spellATK = 15;
        ringList[t].spellMAG = 15;
        ringList[t].SetCompletedUpgrade(3);
        ringList[t++].isStarForce = false;

        ringList.Add(new Item(ItemType.Ring, "리부트 테네브리스 원정대 반지", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "글로리온 링(슈프림)", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "어웨이크 링", 120, 10, 10, 10, 10, 1000, 10, 10, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 1000;
        ringList[t].spellSTR = 30;
        ringList[t].spellDEX = 30;
        ringList[t].spellINT = 30;
        ringList[t].spellLUK = 30;
        ringList[t].spellMaxHP = 3000;
        ringList[t].spellMaxMP = 3000;
        ringList[t].spellATK = 15;
        ringList[t].spellMAG = 15;
        ringList[t].SetCompletedUpgrade(3);
        ringList[t++].isStarForce = false;

        ringList.Add(new Item(ItemType.Ring, "리부트 어웨이크 링", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "이터널 플레임 링", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t].upPotentialGrade = OptionGrade.Unique;
        ringList[t].upPotential1 = "잠재능력이 봉인되어 있습니다.";
        ringList[t++].isStarForce = false;


        #endregion



        #region 1.포켓
        t = 0;

        pocketList.Add(new Item(ItemType.Pocket, "영생의 돌", 0, 3, 3, 3, 3, 0, 3, 3, 0, 0, 0, 0, 0, -1));
        pocketList[t++].setName = SetName.BossTrinket;
        pocketList.Add(new Item(ItemType.Pocket, "핑크빛 성배", 140, 5, 5, 5, 5, 50, 5, 5, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BossTrinket;
        pocketList[t++].basicMaxMP = 50;
        pocketList.Add(new Item(ItemType.Pocket, "저주받은 적의 마도서", 160, 20, 10, 10, 10, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;
        pocketList.Add(new Item(ItemType.Pocket, "저주받은 청의 마도서", 160, 10, 10, 20, 10, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;
        pocketList.Add(new Item(ItemType.Pocket, "저주받은 녹의 마도서", 160, 10, 20, 10, 10, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;
        pocketList.Add(new Item(ItemType.Pocket, "저주받은 황의 마도서", 160, 10, 10, 10, 20, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;


        #endregion



        #region 2.펜던트
        t = 0;

        pendantList.Add(new Item(ItemType.Pendant, "그리드 펜던트", 75, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 7, -1));
        pendantList[t++].isNormalAdditional = true;
        pendantList.Add(new Item(ItemType.Pendant, "베어스 그린 펜던트", 100, 4, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;
        pendantList.Add(new Item(ItemType.Pendant, "울프스 그린 펜던트", 100, 0, 4, 0, 0, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;
        pendantList.Add(new Item(ItemType.Pendant, "아울스 그린 펜던트", 100, 0, 0, 4, 0, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;
        pendantList.Add(new Item(ItemType.Pendant, "피콕스 그린 펜던트", 100, 0, 0, 0, 4, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;

        pendantList.Add(new Item(ItemType.Pendant, "베어스 레드 펜던트", 110, 8, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;
        pendantList.Add(new Item(ItemType.Pendant, "울프스 레드 펜던트", 110, 0, 8, 0, 0, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;
        pendantList.Add(new Item(ItemType.Pendant, "아울스 레드 펜던트", 110, 0, 0, 8, 0, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;
        pendantList.Add(new Item(ItemType.Pendant, "피콕스 레드 펜던트", 110, 0, 0, 0, 8, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;

        pendantList.Add(new Item(ItemType.Pendant, "혼테일의 목걸이", 120, 7, 7, 7, 7, 0, 0, 0, 0, 0, 0, 0, 3, 99));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t++].isNormalAdditional = true;
        pendantList.Add(new Item(ItemType.Pendant, "매커네이터 펜던트", 120, 10, 10, 10, 10, 250, 1, 1, 0, 0, 0, 0, 3, 10));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t++].basicMaxMP = 250;
        pendantList.Add(new Item(ItemType.Pendant, "카오스 혼테일의 목걸이", 120, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 3, 99));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t].isNormalAdditional = true;
        pendantList[t].basicMaxHP_Per = 10;
        pendantList[t++].basicMaxMP_Per = 10;

        pendantList.Add(new Item(ItemType.Pendant, "베어스 핑크 펜던트", 120, 12, 0, 0, 0, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;
        pendantList.Add(new Item(ItemType.Pendant, "울프스 핑크 펜던트", 120, 0, 12, 0, 0, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;
        pendantList.Add(new Item(ItemType.Pendant, "아울스 핑크 펜던트", 120, 0, 0, 12, 0, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;
        pendantList.Add(new Item(ItemType.Pendant, "피콕스 핑크 펜던트", 120, 0, 0, 0, 12, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;

        pendantList.Add(new Item(ItemType.Pendant, "베어스 퍼플 펜던트", 130, 16, 0, 0, 0, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "울프스 퍼플 펜던트", 130, 0, 16, 0, 0, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "아울스 퍼플 펜던트", 130, 0, 0, 16, 0, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "피콕스 퍼플 펜던트", 130, 0, 0, 0, 16, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;

        pendantList.Add(new Item(ItemType.Pendant, "라이징 썬 펜던트", 130, 16, 16, 16, 16, 180, 2, 2, 0, 0, 0, 0, 5, 10));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "피어리스 펜던트", 130, 20, 20, 20, 20, 150, 3, 3, 0, 0, 0, 0, 5, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].isBasicGrowth = true;


        pendantList.Add(new Item(ItemType.Pendant, "데이브레이크 펜던트", 140, 8, 8, 8, 8, 0, 2, 2, 0, 0, 0, 0, 6, 10));
        pendantList[t].setName = SetName.DawnBoss;
        pendantList[t++].basicMaxHP_Per = 5;
        pendantList.Add(new Item(ItemType.Pendant, "도미네이터 펜던트", 140, 20, 20, 20, 20, 0, 3, 3, 0, 0, 0, 0, 6, 10));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t].basicMaxHP_Per = 10;
        pendantList[t++].basicMaxMP_Per = 10;
        pendantList.Add(new Item(ItemType.Pendant, "고통의 근원", 160, 10, 10, 10, 10, 0, 3, 3, 0, 0, 0, 0, 6, 5));
        pendantList[t].setName = SetName.BlackBossTrinket;
        pendantList[t++].basicMaxHP_Per = 5;

        pendantList.Add(new Item(ItemType.Pendant, "정령의 펜던트", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        pendantList[t].isStarForce = false;
        pendantList[t].isAdditionalOption = false;
        pendantList[t].upPotentialPossible = false;
        pendantList[t++].downPotentialPossible = false;
        pendantList.Add(new Item(ItemType.Pendant, "준비된 정령의 펜던트", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        pendantList[t].isStarForce = false;
        pendantList[t].isAdditionalOption = false;
        pendantList[t].upPotentialPossible = false;
        pendantList[t++].downPotentialPossible = false;



        #endregion



        #region 3.무기
        t = 0;

        //전사
        weaponList.Add(new Item(ItemType.Weapon, "파프니르 빅 마운틴", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 파일 갓", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 엘라하", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 엘라하", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 데스브링어", 150, 40, 0, 0, 0, 2000, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 데스페라도", 160, 60, 0, 0, 0, 2250, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 데스페라도", 200, 100, 0, 0, 0, 2500, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 데스페라도", 200, 150, 0, 0, 0, 2800, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellMaxHP = 1600;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "해방된 카이세리움", 150, 200, 200, 0, 0, 0, 400, 0, 0, 0, 0, 0, 2, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "파프니르 페니텐시아", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 브로드세이버", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 투핸드소드", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 투핸드소드", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 배틀클리버", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 브로드엑스", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 투핸드엑스", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 투핸드엑스", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 라이트닝어", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 브로드해머", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 투핸드해머", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 투핸드해머", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 브류나크", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 피어싱스피어", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 스피어", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 스피어", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "라즐리 7형", 170, 40, 40, 0, 0, 0, 169, 0, 30, 10, 0, 0, 9, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t].reqClass = CharacterClass.Zero;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "라즐리 8형", 180, 60, 60, 0, 0, 0, 203, 0, 30, 10, 0, 0, 9, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t].reqClass = CharacterClass.Zero;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "라즐리 9형", 200, 100, 100, 0, 0, 0, 293, 0, 30, 20, 0, 0, 9, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t].reqClass = CharacterClass.Zero;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 라즐리", 200, 150, 150, 0, 0, 0, 337, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].reqClass = CharacterClass.Zero;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 포기브니스", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 튜너", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 튜너", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 튜너", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 문글레이브", 150, 40, 40, 0, 0, 0, 153, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 핼버드", 160, 60, 60, 0, 0, 0, 184, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 폴암", 200, 100, 100, 0, 0, 0, 264, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 폴암", 200, 150, 150, 0, 0, 0, 304, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 미스틸테인", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 세이버", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 세이버", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 세이버", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 트윈클리버", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 엑스", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 엑스", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 엑스", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 골디언해머", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 비트해머", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 해머", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 해머", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;




        // 궁수
        weaponList.Add(new Item(ItemType.Weapon, "파프니르 듀얼윈드윙", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 듀얼보우건", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 듀얼보우건", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 듀얼보우건", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 나이트체이서", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 브레스 슈터", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 브레스 슈터", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 브레스 슈터", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 윈드윙슈터", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 크로스보우", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 크로스보우", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 크로스보우", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 에인션트 보우", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 에인션트 보우", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 에인션트 보우", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 에인션트 보우", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 윈드체이서", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 슈팅보우", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 보우", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 보우", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;



        // 마법사
        weaponList.Add(new Item(ItemType.Weapon, "파프니르 ESP리미터", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 ESP리미터", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 ESP리미터", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 ESP리미터", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 매직 건틀렛", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 매직 건틀렛", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 매직 건틀렛", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 매직 건틀렛", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 마나크래들", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 샤이닝로드", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 샤이닝로드", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 샤이닝로드", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 마나크라운", 150, 0, 0, 40, 40, 0, 126, 204, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 스펠링스태프", 160, 0, 0, 60, 60, 0, 151, 245, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 스태프", 200, 0, 0, 100, 100, 0, 218, 353, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 스태프", 200, 0, 0, 150, 150, 0, 251, 406, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 마나테이커", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 스펠링완드", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 완드", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 완드", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;



        // 도적
        weaponList.Add(new Item(ItemType.Weapon, "파프니르 다마스커스", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 슬래셔", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 대거", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 대거", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 용선", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 괴선", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 초선", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 창세선", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 리스크홀더", 150, 0, 40, 0, 40, 0, 86, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 리벤지가즈", 160, 0, 60, 0, 60, 0, 103, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 가즈", 200, 0, 100, 0, 100, 0, 149, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 가즈", 200, 0, 150, 0, 150, 0, 172, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 체인", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 체인", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 체인", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 체인", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 클레르시엘", 150, 0, 40, 0, 40, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 핀쳐케인", 160, 0, 60, 0, 60, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 케인", 200, 0, 100, 0, 100, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 케인", 200, 0, 150, 0, 150, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 차크람", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 차크람", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 차크람", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 이클립스", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;



        // 해적
        weaponList.Add(new Item(ItemType.Weapon, "파프니르 첼리스카", 150, 40, 40, 0, 0, 0, 125, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 포인팅건", 160, 60, 60, 0, 0, 0, 150, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 피스톨", 200, 100, 100, 0, 0, 0, 216, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 피스톨", 200, 150, 150, 0, 0, 0, 249, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 펜리르탈론", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 블로우너클", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 클로", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 클로", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 엔젤릭슈터", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 소울슈터", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 소울슈터", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 소울슈터", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 러스터캐논", 150, 40, 40, 0, 0, 0, 175, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 블래스트캐논", 160, 60, 60, 0, 0, 0, 210, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 시즈건", 200, 100, 100, 0, 0, 0, 302, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 시즈건", 200, 150, 150, 0, 0, 0, 348, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;






        // 제논
        weaponList.Add(new Item(ItemType.Weapon, "파프니르 스플릿엣지(도적)", 150, 0, 40, 0, 40, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 에너지소드(도적)", 160, 0, 60, 0, 60, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 에너지체인(도적)", 200, 0, 100, 0, 100, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 에너지체인(도적)", 200, 0, 150, 0, 150, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;


        weaponList.Add(new Item(ItemType.Weapon, "파프니르 스플릿엣지(해적)", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "앱솔랩스 에너지소드(해적)", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "아케인셰이드 에너지체인(해적)", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "제네시스 에너지체인(해적)", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;

        #endregion



        #region 4.벨트

        t = 0;

        beltList.Add(new Item(ItemType.Belt, "골든 클로버 벨트", 140, 15, 15, 15, 15, 150, 1, 1, 0, 0, 0, 0, 4, 10));
        beltList[t].setName = SetName.BossTrinket;
        beltList[t++].basicMaxMP = 150;
        beltList.Add(new Item(ItemType.Belt, "분노한 자쿰의 벨트", 150, 18, 18, 18, 18, 150, 1, 1, 0, 0, 0, 0, 4, 10));
        beltList[t].setName = SetName.BossTrinket;
        beltList[t++].basicMaxMP = 150;
        beltList.Add(new Item(ItemType.Belt, "몽환의 벨트", 200, 50, 50, 50, 50, 150, 6, 6, 0, 0, 0, 0, 4, 5));
        beltList[t].setName = SetName.BlackBossTrinket;
        beltList[t++].basicMaxMP = 150;

        beltList.Add(new Item(ItemType.Belt, "타일런트 히아데스 벨트", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        beltList.Add(new Item(ItemType.Belt, "타일런트 케이론 벨트", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        beltList.Add(new Item(ItemType.Belt, "타일런트 헤르메스 벨트", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Magician;
        beltList.Add(new Item(ItemType.Belt, "타일런트 리카온 벨트", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Thief;
        beltList.Add(new Item(ItemType.Belt, "타일런트 알테어 벨트", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Pirate;

        #endregion



        #region 5.모자

        t = 0;

        helmetList.Add(new Item(ItemType.Helmet, "카오스 반반 투구", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 11, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;
        helmetList.Add(new Item(ItemType.Helmet, "카오스 퀸의 티아라", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 11, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;
        helmetList.Add(new Item(ItemType.Helmet, "카오스 피에르 모자", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 11, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;
        helmetList.Add(new Item(ItemType.Helmet, "카오스 벨룸의 헬름", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 12, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;



        helmetList.Add(new Item(ItemType.Helmet, "하이네스 워리어헬름", 150, 40, 40, 0, 0, 360, 2, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "하이네스 레인져베레", 150, 40, 40, 0, 0, 360, 2, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "하이네스 던위치햇", 150, 0, 0, 40, 40, 360, 0, 2, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "하이네스 어새신보닛", 150, 0, 40, 0, 40, 360, 2, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "하이네스 원더러햇", 150, 40, 40, 0, 0, 360, 2, 0, 0, 10, 0, 0, 12, 10));

        helmetList[t].basicMaxMP = 360;
        helmetList[t].setName = SetName.Rootabis_Warrior;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        helmetList[t].basicMaxMP = 360;
        helmetList[t].setName = SetName.Rootabis_Bowman;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        helmetList[t].basicMaxMP = 360;
        helmetList[t].setName = SetName.Rootabis_Magician;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Magician;
        helmetList[t].basicMaxMP = 360;
        helmetList[t].setName = SetName.Rootabis_Thief;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Thief;
        helmetList[t].basicMaxMP = 360;
        helmetList[t].setName = SetName.Rootabis_Pirate;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Pirate;




        helmetList.Add(new Item(ItemType.Helmet, "앱솔랩스 나이트헬름", 160, 45, 45, 0, 0, 0, 3, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "앱솔랩스 아처후드", 160, 45, 45, 0, 0, 0, 3, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "앱솔랩스 메이지크라운", 160, 0, 0, 45, 45, 0, 0, 3, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "앱솔랩스 시프캡", 160, 0, 45, 0, 45, 0, 3, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "앱솔랩스 파이렛페도라", 160, 45, 45, 0, 0, 0, 3, 0, 0, 10, 0, 0, 12, 10));

        helmetList[t].setName = SetName.Absolute_Warrior;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        helmetList[t].setName = SetName.Absolute_Bowman;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        helmetList[t].setName = SetName.Absolute_Magician;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Magician;
        helmetList[t].setName = SetName.Absolute_Thief;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Thief;
        helmetList[t].setName = SetName.Absolute_Pirate;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Pirate;




        helmetList.Add(new Item(ItemType.Helmet, "아케인셰이드 나이트햇", 200, 65, 65, 0, 0, 0, 7, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "아케인셰이드 아처햇", 200, 65, 65, 0, 0, 0, 7, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "아케인셰이드 메이지햇", 200, 0, 0, 65, 65, 0, 0, 7, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "아케인셰이드 시프햇", 200, 0, 65, 0, 65, 0, 7, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "아케인셰이드 파이렛햇", 200, 65, 65, 0, 0, 0, 7, 0, 0, 15, 0, 0, 12, 10));


        helmetList[t].setName = SetName.Arcane_Warrior;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        helmetList[t].setName = SetName.Arcane_Bowman;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        helmetList[t].setName = SetName.Arcane_Magician;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Magician;
        helmetList[t].setName = SetName.Arcane_Thief;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Thief;
        helmetList[t].setName = SetName.Arcane_Pirate;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Pirate;




        helmetList.Add(new Item(ItemType.Helmet, "에테르넬 나이트헬름", 250, 80, 80, 0, 0, 0, 10, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "에테르넬 아처햇", 250, 80, 80, 0, 0, 0, 10, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "에테르넬 메이지햇", 250, 0, 0, 80, 80, 0, 0, 10, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "에테르넬 시프반다나", 250, 0, 80, 0, 80, 0, 10, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "에테르넬 파이렛햇", 250, 80, 80, 0, 0, 0, 10, 0, 0, 15, 0, 0, 12, 10));


        helmetList[t].setName = SetName.Eternel_Warrior;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        helmetList[t].setName = SetName.Eternel_Bowman;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        helmetList[t].setName = SetName.Eternel_Magician;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Magician;
        helmetList[t].setName = SetName.Eternel_Thief;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Thief;
        helmetList[t].setName = SetName.Eternel_Pirate;
        helmetList[t++].reqClassGroup = CharacterClassGroup.Pirate;

        #endregion



        #region 6.얼굴장식
        t = 0;

        faceList.Add(new Item(ItemType.Face, "레드 워리어 마이스터 심볼", 100, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "레드 아처 마이스터 심볼", 100, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "레드 매지션 마이스터 심볼", 100, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "레드 시프 마이스터 심볼", 100, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "레드 파이렛 마이스터 심볼", 100, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 99));

        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Magician;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Thief;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Pirate;



        faceList.Add(new Item(ItemType.Face, "샤이니 레드 워리어 마이스터 심볼", 130, 3, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "샤이니 레드 아처 마이스터 심볼", 130, 3, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "샤이니 레드 매지션 마이스터 심볼", 130, 0, 0, 3, 3, 0, 0, 3, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "샤이니 레드 시프 마이스터 심볼", 130, 0, 3, 0, 3, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "샤이니 레드 파이렛 마이스터 심볼", 130, 3, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 99));

        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Magician;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Thief;
        faceList[t].isNormalAdditional = true;
        faceList[t++].reqClassGroup = CharacterClassGroup.Pirate;



        faceList.Add(new Item(ItemType.Face, "응축된 힘의 결정석", 110, 5, 5, 5, 5, 0, 5, 5, 0, 0, 0, 0, 6, 10));
        faceList[t++].setName = SetName.BossTrinket;
        faceList.Add(new Item(ItemType.Face, "트와일라이트 마크", 140, 5, 5, 5, 5, 0, 5, 5, 0, 0, 0, 0, 4, 10));
        faceList[t++].setName = SetName.DawnBoss;
        faceList.Add(new Item(ItemType.Face, "루즈 컨트롤 머신 마크", 160, 10, 10, 10, 10, 0, 10, 10, 0, 0, 0, 0, 6, 5));
        faceList[t++].setName = SetName.BlackBossTrinket;

        #endregion



        #region 7.눈장식
        t = 0;


        eyeList.Add(new Item(ItemType.Eye, "미카엘의 새 안경", 75, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 6, 99));
        eyeList[t++].isNormalAdditional = true;
        eyeList.Add(new Item(ItemType.Eye, "미카엘라의 새 안경", 75, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 0, 6, 99));
        eyeList[t++].isNormalAdditional = true;
        eyeList.Add(new Item(ItemType.Eye, "아쿠아틱 레터 눈장식", 100, 6, 6, 6, 6, 0, 1, 1, 0, 0, 0, 0, 4, 10));
        eyeList[t++].setName = SetName.BossTrinket;
        eyeList.Add(new Item(ItemType.Eye, "블랙빈 마크", 135, 7, 7, 7, 7, 0, 1, 1, 0, 0, 0, 0, 6, 10));
        eyeList[t++].setName = SetName.BossTrinket;
        eyeList.Add(new Item(ItemType.Eye, "파풀라투스 마크", 145, 8, 8, 8, 8, 0, 1, 1, 0, 0, 0, 0, 6, 10));
        eyeList[t++].setName = SetName.BossTrinket;
        eyeList.Add(new Item(ItemType.Eye, "마력이 깃든 안대", 160, 15, 15, 15, 15, 0, 3, 3, 0, 0, 0, 0, 4, 5));
        eyeList[t++].setName = SetName.BlackBossTrinket;

        #endregion



        #region 8.상의
        t = 0;

        shirtList.Add(new Item(ItemType.Shirt, "이글아이 워리어아머", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "이글아이 레인져후드", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "이글아이 던위치로브", 150, 0, 0, 30, 30, 0, 0, 2, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "이글아이 어새신셔츠", 150, 0, 30, 0, 30, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "이글아이 원더러코트", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));

        shirtList[t].setName = SetName.Rootabis_Warrior;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shirtList[t].setName = SetName.Rootabis_Bowman;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shirtList[t].setName = SetName.Rootabis_Magician;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shirtList[t].setName = SetName.Rootabis_Thief;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shirtList[t].setName = SetName.Rootabis_Pirate;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        shirtList.Add(new Item(ItemType.Shirt, "에테르넬 나이트아머", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "에테르넬 아처후드", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "에테르넬 메이지로브", 250, 0, 0, 50, 50, 0, 0, 6, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "에테르넬 시프셔츠", 250, 0, 50, 0, 50, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "에테르넬 파이렛코트", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));


        shirtList[t].setName = SetName.Eternel_Warrior;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shirtList[t].setName = SetName.Eternel_Bowman;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shirtList[t].setName = SetName.Eternel_Magician;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shirtList[t].setName = SetName.Eternel_Thief;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shirtList[t].setName = SetName.Eternel_Pirate;
        shirtList[t++].reqClassGroup = CharacterClassGroup.Pirate;

        #endregion



        #region 9.하의
        t = 0;

        pantsList.Add(new Item(ItemType.Pants, "트릭스터 워리어팬츠", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "트릭스터 레인져팬츠", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "트릭스터 던위치팬츠", 150, 0, 0, 30, 30, 0, 0, 2, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "트릭스터 어새신팬츠", 150, 0, 30, 0, 30, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "트릭스터 원더러팬츠", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));

        pantsList[t].setName = SetName.Rootabis_Warrior;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        pantsList[t].setName = SetName.Rootabis_Bowman;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        pantsList[t].setName = SetName.Rootabis_Magician;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Magician;
        pantsList[t].setName = SetName.Rootabis_Thief;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Thief;
        pantsList[t].setName = SetName.Rootabis_Pirate;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        pantsList.Add(new Item(ItemType.Pants, "에테르넬 나이트팬츠", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "에테르넬 아처팬츠", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "에테르넬 메이지팬츠", 250, 0, 0, 50, 50, 0, 0, 6, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "에테르넬 시프팬츠", 250, 0, 50, 0, 50, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "에테르넬 파이렛팬츠", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));

        pantsList[t].setName = SetName.Eternel_Warrior;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        pantsList[t].setName = SetName.Eternel_Bowman;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        pantsList[t].setName = SetName.Eternel_Magician;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Magician;
        pantsList[t].setName = SetName.Eternel_Thief;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Thief;
        pantsList[t].setName = SetName.Eternel_Pirate;
        pantsList[t++].reqClassGroup = CharacterClassGroup.Pirate;

        #endregion



        #region 10.신발
        t = 0;

        shoesList.Add(new Item(ItemType.Shoes, "앱솔랩스 나이트슈즈", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "앱솔랩스 아처슈즈", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "앱솔랩스 메이지슈즈", 160, 0, 0, 20, 20, 0, 0, 5, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "앱솔랩스 시프슈즈", 160, 0, 20, 0, 20, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "앱솔랩스 파이렛슈즈", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));


        shoesList[t].setName = SetName.Absolute_Warrior;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shoesList[t].setName = SetName.Absolute_Bowman;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shoesList[t].setName = SetName.Absolute_Magician;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shoesList[t].setName = SetName.Absolute_Thief;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shoesList[t].setName = SetName.Absolute_Pirate;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Pirate;




        shoesList.Add(new Item(ItemType.Shoes, "아케인셰이드 나이트슈즈", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "아케인셰이드 아처슈즈", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "아케인셰이드 메이지슈즈", 200, 0, 0, 40, 40, 0, 0, 9, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "아케인셰이드 시프슈즈", 200, 0, 40, 0, 40, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "아케인셰이드 파이렛슈즈", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));

        shoesList[t].setName = SetName.Arcane_Warrior;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shoesList[t].setName = SetName.Arcane_Bowman;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shoesList[t].setName = SetName.Arcane_Magician;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shoesList[t].setName = SetName.Arcane_Thief;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shoesList[t].setName = SetName.Arcane_Pirate;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Pirate;



        shoesList.Add(new Item(ItemType.Shoes, "타일런트 히아데스 부츠", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "타일런트 케이론 부츠", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "타일런트 헤르메스 부츠", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "타일런트 리카온 부츠", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "타일런트 알테어 부츠", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));

        shoesList[t].isSuperior = true;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shoesList[t].isSuperior = true;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shoesList[t].isSuperior = true;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shoesList[t].isSuperior = true;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shoesList[t].isSuperior = true;
        shoesList[t++].reqClassGroup = CharacterClassGroup.Pirate;

        #endregion



        #region 11.귀고리
        t = 0;

        earringList.Add(new Item(ItemType.Earring, "하프 이어링", 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 999));
        earringList[t++].isNormalAdditional = true;
        earringList.Add(new Item(ItemType.Earring, "데아 시두스 이어링", 130, 5, 5, 5, 5, 0, 2, 2, 0, 0, 0, 0, 7, 10));
        earringList[t++].setName = SetName.BossTrinket;
        earringList.Add(new Item(ItemType.Earring, "지옥의 불꽃", 130, 7, 7, 7, 7, 100, 2, 2, 0, 0, 0, 0, 6, 10));
        earringList[t].setName = SetName.BossTrinket;
        earringList[t++].basicMaxMP = 100;
        earringList.Add(new Item(ItemType.Earring, "스칼렛 이어링", 135, 6, 6, 6, 6, 200, 3, 3, 0, 0, 0, 0, 7, 10));
        earringList[t].isLucky = true;
        earringList[t++].basicMaxMP = 200;
        earringList.Add(new Item(ItemType.Earring, "샤먼 이어링", 140, 5, 5, 5, 5, 150, 0, 0, 0, 0, 0, 0, 7, 10));
        earringList[t++].basicMaxMP = 150;
        earringList.Add(new Item(ItemType.Earring, "마이스터 이어링", 140, 5, 5, 5, 5, 500, 4, 4, 0, 0, 0, 0, 7, 10));
        earringList[t].setName = SetName.Meister;
        earringList[t++].basicMaxMP = 500;
        earringList.Add(new Item(ItemType.Earring, "오션 글로우 이어링", 150, 7, 7, 7, 7, 750, 5, 5, 0, 0, 0, 0, 8, 10));
        earringList[t++].basicMaxMP = 750;
        earringList.Add(new Item(ItemType.Earring, "에스텔라 이어링", 160, 7, 7, 7, 7, 300, 2, 2, 0, 0, 0, 0, 7, 10));
        earringList[t].setName = SetName.DawnBoss;
        earringList[t++].basicMaxMP = 300;
        earringList.Add(new Item(ItemType.Earring, "커맨더 포스 이어링", 200, 7, 7, 7, 7, 500, 5, 5, 0, 0, 0, 0, 7, 5));
        earringList[t].setName = SetName.BlackBossTrinket;
        earringList[t++].basicMaxMP = 500;


        #endregion



        #region 12.어깨장식
        t = 0;

        shoulderList.Add(new Item(ItemType.Shoulder, "로얄 블랙메탈 숄더", 120, 10, 10, 10, 10, 0, 6, 6, 0, 0, 0, 0, 2, 0));
        shoulderList[t++].setName = SetName.BossTrinket;
        shoulderList.Add(new Item(ItemType.Shoulder, "스칼렛 숄더", 135, 12, 12, 12, 12, 400, 7, 7, 0, 0, 0, 0, 2, 10));
        shoulderList[t].isLucky = true;
        shoulderList[t++].isAdditionalOption = true;
        shoulderList.Add(new Item(ItemType.Shoulder, "마이스터 숄더", 140, 13, 13, 13, 13, 0, 9, 9, 0, 0, 0, 0, 2, 99));
        shoulderList[t++].setName = SetName.Meister;

        shoulderList.Add(new Item(ItemType.Shoulder, "앱솔랩스 나이트숄더", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "앱솔랩스 아처숄더", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "앱솔랩스 메이지숄더", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "앱솔랩스 시프숄더", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "앱솔랩스 파이렛숄더", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));

        shoulderList[t].setName = SetName.Absolute_Warrior;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shoulderList[t].setName = SetName.Absolute_Bowman;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shoulderList[t].setName = SetName.Absolute_Magician;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shoulderList[t].setName = SetName.Absolute_Thief;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shoulderList[t].setName = SetName.Absolute_Pirate;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Pirate;



        shoulderList.Add(new Item(ItemType.Shoulder, "아케인셰이드 나이트숄더", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "아케인셰이드 아처숄더", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "아케인셰이드 메이지숄더", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "아케인셰이드 시프숄더", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "아케인셰이드 파이렛숄더", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));

        shoulderList[t].setName = SetName.Arcane_Warrior;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shoulderList[t].setName = SetName.Arcane_Bowman;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shoulderList[t].setName = SetName.Arcane_Magician;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shoulderList[t].setName = SetName.Arcane_Thief;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shoulderList[t].setName = SetName.Arcane_Pirate;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Pirate;




        shoulderList.Add(new Item(ItemType.Shoulder, "에테르넬 나이트숄더", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "에테르넬 아처숄더", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "에테르넬 메이지숄더", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "에테르넬 시프숄더", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "에테르넬 파이렛숄더", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));

        shoulderList[t].setName = SetName.Eternel_Warrior;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        shoulderList[t].setName = SetName.Eternel_Bowman;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        shoulderList[t].setName = SetName.Eternel_Magician;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Magician;
        shoulderList[t].setName = SetName.Eternel_Thief;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Thief;
        shoulderList[t].setName = SetName.Eternel_Pirate;
        shoulderList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        #endregion



        #region 13.장갑
        t = 0;

        glovesList.Add(new Item(ItemType.Gloves, "앱솔랩스 나이트글러브", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "앱솔랩스 아처글러브", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "앱솔랩스 메이지글러브", 160, 0, 0, 20, 20, 0, 0, 5, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "앱솔랩스 시프글러브", 160, 0, 20, 0, 20, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "앱솔랩스 파이렛글러브", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));

        glovesList[t].setName = SetName.Absolute_Warrior;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        glovesList[t].setName = SetName.Absolute_Bowman;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        glovesList[t].setName = SetName.Absolute_Magician;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Magician;
        glovesList[t].setName = SetName.Absolute_Thief;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Thief;
        glovesList[t].setName = SetName.Absolute_Pirate;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Pirate;



        glovesList.Add(new Item(ItemType.Gloves, "아케인셰이드 나이트글러브", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "아케인셰이드 아처글러브", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "아케인셰이드 메이지글러브", 200, 0, 0, 40, 40, 0, 0, 9, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "아케인셰이드 시프글러브", 200, 0, 40, 0, 40, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "아케인셰이드 파이렛글러브", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));

        glovesList[t].setName = SetName.Arcane_Warrior;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        glovesList[t].setName = SetName.Arcane_Bowman;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        glovesList[t].setName = SetName.Arcane_Magician;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Magician;
        glovesList[t].setName = SetName.Arcane_Thief;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Thief;
        glovesList[t].setName = SetName.Arcane_Pirate;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        glovesList.Add(new Item(ItemType.Gloves, "타일런트 히아데스 글러브", 150, 12, 12, 0, 0, 300, 15, 0, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "타일런트 케이론 글러브", 150, 12, 12, 0, 0, 300, 15, 0, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "타일런트 헤르메스 글러브", 150, 0, 0, 12, 12, 0, 0, 15, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "타일런트 리카온 글러브", 150, 0, 12, 0, 12, 300, 15, 0, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "타일런트 알테어 글러브", 150, 12, 12, 0, 0, 300, 15, 0, 0, 0, 0, 0, 3, 10));

        glovesList[t].isSuperior = true;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        glovesList[t].isSuperior = true;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        glovesList[t].basicMaxMP = 300;
        glovesList[t].isSuperior = true;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Magician;
        glovesList[t].isSuperior = true;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Thief;
        glovesList[t].isSuperior = true;
        glovesList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        #endregion



        #region 14.안드로이드
        t = 0;

        androidList.Add(new Item(ItemType.Android, "무공로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "뉴트로 데미안로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "뉴트로 알리샤로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "뉴트로 루시드로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "할로캣로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "돌의 정령로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "웡키로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "르네로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "리오로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "들꽃정령로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "슈퍼스타 핑크빈로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "작은 무토로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "스텔라로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "리스로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "엘리로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "아기 리스로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "아기 엘리로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "미스터 이그니션로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "DJ 셀레나로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "진로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "세라로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "네온 슈피겔만로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "카링로이드", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        #endregion



        #region 15.엠블렘
        t = 0;

        emblemList.Add(new Item(ItemType.Emblem, "골드 메이플리프 엠블렘(모험가)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "골드 시그너스 엠블렘(시그너스)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "골드 레지스탕스 엠블렘(레지스탕스)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "골드 데몬 엠블렘(데몬)", 100, 10, 10, 10, 10, 500, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "하이브리드 하트(제논)", 100, 0, 0, 0, 0, 300, 2, 2, 0, 0, 0, 0, 0, 999));
        emblemList[t].reqClassGroup = CharacterClassGroup.Hybrid;
        emblemList[t++].basicMaxMP = 100;
        emblemList.Add(new Item(ItemType.Emblem, "골드 히어로즈 엠블렘(아란)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "골드 히어로즈 엠블렘(에반)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "골드 히어로즈 엠블렘(루미너스)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "골드 히어로즈 엠블렘(메르세데스)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        emblemList.Add(new Item(ItemType.Emblem, "골드 히어로즈 엠블렘(팬텀)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "골드 히어로즈 엠블렘(은월)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        emblemList.Add(new Item(ItemType.Emblem, "드래곤 엠블렘(카이저)", 100, 10, 10, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 999));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "골드 에이전트 엠블렘(카데나)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "엔젤 엠블렘(엔젤릭버스터)", 100, 10, 10, 0, 0, 400, 2, 2, 0, 0, 0, 0, 0, 999));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        emblemList.Add(new Item(ItemType.Emblem, "골드 나이트 엠블렘(아델)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "골드 크리스탈 엠블렘(일리움)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "골드 체이서 엠블렘(칼리)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "골드 어비스 엠블렘(아크)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        emblemList.Add(new Item(ItemType.Emblem, "금빛 풍수사 엠블렘(라라)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "금빛 천지인 엠블렘(호영)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "이터널 타임 엠블렘(제로)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "골드 키네시스 엠블렘(키네시스)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;

        emblemList.Add(new Item(ItemType.Emblem, "미트라의 분노 - 전사", 200, 40, 40, 0, 0, 700, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "미트라의 분노 - 마법사", 200, 0, 0, 40, 40, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "미트라의 분노 - 궁수", 200, 40, 40, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        emblemList.Add(new Item(ItemType.Emblem, "미트라의 분노 - 도적", 200, 0, 40, 0, 40, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "미트라의 분노 - 해적", 200, 40, 40, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        #endregion



        #region 16.뱃지
        t = 0;

        badgeList.Add(new Item(ItemType.Badge, "칠요의 뱃지", 100, 7, 7, 7, 7, 0, 7, 7, 0, 10, 0, 0, 0, -1));
        badgeList[t++].setName = SetName.SevenDays;
        badgeList.Add(new Item(ItemType.Badge, "크리스탈 웬투스 뱃지", 130, 10, 10, 10, 10, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        badgeList[t++].setName = SetName.BossTrinket;
        badgeList.Add(new Item(ItemType.Badge, "창세의 뱃지", 200, 15, 15, 15, 15, 0, 10, 10, 0, 10, 0, 0, 0, 0));
        badgeList[t++].setName = SetName.BlackBossTrinket;

        #endregion



        #region 17.훈장
        t = 0;

        medalList.Add(new Item(ItemType.Medal, "칠요의 몬스터파커", 100, 7, 7, 7, 7, 0, 7, 7, 0, 10, 0, 0, 0, -1));
        medalList[t++].setName = SetName.SevenDays;
        medalList.Add(new Item(ItemType.Medal, "도로시 챌린저", 110, 10, 10, 10, 10, 300, 10, 10, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 300;
        medalList.Add(new Item(ItemType.Medal, "프리토의 친구", 0, 10, 10, 10, 10, 500, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 500;
        medalList.Add(new Item(ItemType.Medal, "폴로의 친구", 0, 15, 15, 15, 15, 1000, 5, 5, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "카오스 벨룸 킬러", 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "우르스 격파왕", 100, 7, 7, 7, 7, 0, 7, 7, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "신의 컨트롤 보유자", 100, 8, 8, 8, 8, 0, 8, 8, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "우르스 SSS 컬렉터", 100, 7, 7, 7, 7, 0, 7, 7, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "우르스 SSS 슈퍼 컬렉터", 100, 8, 8, 8, 8, 0, 8, 8, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "악몽의 주인 격파자", 200, 15, 15, 15, 15, 1000, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "진실을 꿰뚫는 자", 200, 15, 15, 15, 15, 1000, 4, 4, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "미궁의 깊이를 아는 자", 200, 15, 15, 15, 15, 1000, 5, 5, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "프리미엄 PC방", 0, 8, 8, 8, 8, 300, 10, 10, 0, 0, 0, 0, 0, -1));
        medalList[t].starforce = 15;
        medalList[t].arc = 30;
        medalList[t++].basicMaxMP = 300;
        medalList.Add(new Item(ItemType.Medal, "본 투 비 골드", 0, 3, 3, 3, 3, 0, 3, 3, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "본 투 비 다이아", 0, 5, 5, 5, 5, 500, 5, 5, 5, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 500;
        medalList.Add(new Item(ItemType.Medal, "본 투 비 레드", 0, 7, 7, 7, 7, 700, 7, 7, 5, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 700;
        medalList.Add(new Item(ItemType.Medal, "나는야 럭키가이★", 10, 5, 5, 5, 5, 300, 5, 5, 0, 0, 0, 0, 0, 0));
        medalList[t++].basicMaxMP = 300;
        medalList.Add(new Item(ItemType.Medal, "★★13개의 별★★", 13, 13, 13, 13, 13, 0, 13, 13, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "★15번가 셀럽★", 0, 15, 15, 15, 15, 750, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 750;
        medalList.Add(new Item(ItemType.Medal, "BURNING", 0, 5, 5, 5, 5, 250, 1, 1, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 250;
        medalList.Add(new Item(ItemType.Medal, "★내가 바로 메잘알★", 0, 5, 5, 5, 5, 0, 5, 5, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "뉴트로 히어로", 0, 16, 16, 16, 16, 750, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 750;
        medalList.Add(new Item(ItemType.Medal, "호텔 메이플 VIP 멤버", 0, 17, 17, 17, 17, 850, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 850;
        medalList.Add(new Item(ItemType.Medal, "블랙스완", 0, 6, 6, 6, 6, 613, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 613;
        medalList.Add(new Item(ItemType.Medal, "♠블루밍 메이플♠", 0, 18, 18, 18, 18, 950, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 950;
        medalList.Add(new Item(ItemType.Medal, "♣메이플 모멘트리♣", 0, 19, 19, 19, 19, 950, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 950;
        medalList.Add(new Item(ItemType.Medal, "진 천사", 0, 12, 12, 12, 12, 1204, 4, 4, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1204;
        medalList.Add(new Item(ItemType.Medal, "진 악마", 0, 12, 12, 12, 12, 1204, 4, 4, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1204;
        medalList.Add(new Item(ItemType.Medal, "BLACK", 0, 6, 6, 6, 6, 808, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 808;
        medalList.Add(new Item(ItemType.Medal, "PINK", 0, 6, 6, 6, 6, 808, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 808;
        medalList.Add(new Item(ItemType.Medal, "☆메이프릴 아일랜드☆", 0, 20, 20, 20, 20, 1000, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "HYPER BURNING", 200, 6, 6, 6, 6, 0, 6, 6, 0, 0, 0, 0, 0, -1));
        t++;

        #endregion



        #region 18.보조무기
        t = 0;

        // 히어로
        subWeaponList.Add(new Item(ItemType.SubWeapon, "버츄스 메달", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 버츄스 메달", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 메달", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 메달", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 팔라딘
        subWeaponList.Add(new Item(ItemType.SubWeapon, "세이크리드 로자리오", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 세이크리드 로자리오", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 로자리오", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 로자리오", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 다크나이트
        subWeaponList.Add(new Item(ItemType.SubWeapon, "버서크 체인", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 버서크 체인", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 체인", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 체인", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 방패(전사)
        subWeaponList.Add(new Item(ItemType.Shield, "데이모스 워리어 실드", 130, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 아크메이지(불,독)
        subWeaponList.Add(new Item(ItemType.SubWeapon, "적녹의 서 (종장)", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 적녹의 서 (종장)", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "적녹의 서 (블랙)", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "적녹의 서 (메이플 트레져)", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 아크메이지(썬,콜)
        subWeaponList.Add(new Item(ItemType.SubWeapon, "청은의 서 (종장)", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 청은의 서 (종장)", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "청은의 서 (블랙)", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "청은의 서 (메이플 트레져)", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 비숍
        subWeaponList.Add(new Item(ItemType.SubWeapon, "백금의 서 (종장)", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 백금의 서 (종장)", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "백금의 서 (블랙)", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "백금의 서 (메이플 트레져)", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 방패(마법사)
        subWeaponList.Add(new Item(ItemType.Shield, "타임리스 프렐류드", 120, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList.Add(new Item(ItemType.Shield, "피어리스 프렐류드", 125, 0, 0, 10, 5, 0, 0, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Shield, "데이모스 세이지 실드", 130, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 보우마스터
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블라스트 페더", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 블라스트 페더", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 페더", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 페더", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // 신궁
        subWeaponList.Add(new Item(ItemType.SubWeapon, "전발적중", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 전발적중", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 전발적중", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 전발적중", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // 패스파인더
        subWeaponList.Add(new Item(ItemType.SubWeapon, "퍼펙트 렐릭", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 퍼펙트 렐릭", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 렐릭", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // 나이트로드
        subWeaponList.Add(new Item(ItemType.SubWeapon, "파사부", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 파사부", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 파사부", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 파사부", 110, 0, 9, 0, 9, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 섀도어
        subWeaponList.Add(new Item(ItemType.SubWeapon, "슬래싱 섀도우", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 슬래싱 섀도우", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 섀도우", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 섀도우", 110, 0, 9, 0, 9, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 듀얼블레이드
        subWeaponList.Add(new Item(ItemType.Blade, "파프니르 래피드엣지", 150, 0, 0, 0, 30, 0, 81, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Blade, "앱솔랩스 블레이드", 160, 0, 0, 0, 40, 0, 97, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Blade, "아케인셰이드 블레이드", 200, 0, 0, 0, 65, 0, 140, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 방패(도적)
        subWeaponList.Add(new Item(ItemType.Shield, "타임리스 리스트", 120, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList.Add(new Item(ItemType.Shield, "피어리스 리스트", 125, 0, 5, 0, 10, 0, 0, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Shield, "데이모스 다크니스 실드", 130, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 바이퍼
        subWeaponList.Add(new Item(ItemType.SubWeapon, "리스트 아머", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 리스트 아머", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 리스트 아머", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 리스트아머", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // 캡틴
        subWeaponList.Add(new Item(ItemType.SubWeapon, "팔콘아이", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 팔콘아이", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 팔콘아이", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 팔콘아이", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // 캐논슈터
        subWeaponList.Add(new Item(ItemType.SubWeapon, "봄버드 센터파이어", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 봄버드 센터파이어", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 센터파이어", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 센터파이어", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // 시그너스 기사단
        subWeaponList.Add(new Item(ItemType.SubWeapon, "에레브의 광휘", 100, 10, 10, 10, 10, 0, 3, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 에레브의 광휘", 100, 10, 10, 10, 10, 0, 5, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 에레브의 광휘", 100, 8, 8, 8, 8, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 에레브의 광휘", 110, 9, 9, 9, 9, 0, 6, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;


        // 미하일
        subWeaponList.Add(new Item(ItemType.SubWeapon, "정의의 소울실드", 100, 12, 12, 0, 0, 600, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 정의의 소울실드", 100, 12, 12, 0, 0, 600, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 소울실드", 100, 10, 10, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 소울실드", 110, 11, 11, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t].basicMaxMP = 110;
        subWeaponList[t].spellSTR = 9;
        subWeaponList[t].spellDEX = 9;
        subWeaponList[t].spellMaxHP = 200;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].basicMaxMP = 110;
        subWeaponList[t].spellSTR = 9;
        subWeaponList[t].spellDEX = 9;
        subWeaponList[t].spellMaxHP = 200;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].basicMaxMP = 100;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].basicMaxMP = 100;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 블래스터
        subWeaponList.Add(new Item(ItemType.SubWeapon, "익스플로시브 필(3호)", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 익스플로시브 필(3호)", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 익스플로시브 필", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 배틀메이지
        subWeaponList.Add(new Item(ItemType.SubWeapon, "맥시마이즈 볼", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 맥시마이즈 볼", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 맥시마이즈 볼", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 메모라이즈볼", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 와일드헌터
        subWeaponList.Add(new Item(ItemType.SubWeapon, "와일드 팡", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 와일드 팡", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 와일드 팡", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 와일드비크", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // 메카닉
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이터널 매그넘", 100, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 이터널 매그넘", 100, 0, 10, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 매그넘", 100, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 매그넘", 110, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // 데몬
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "극한의 포스실드", 100, 12, 12, 0, 0, 600, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "극한의 포스실드(HP)", 100, 12, 0, 0, 0, 700, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "이볼빙 극한의 포스실드", 100, 12, 12, 0, 0, 600, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "이볼빙 극한의 포스실드(HP)", 100, 12, 0, 0, 0, 700, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "블랙 포스실드", 100, 10, 10, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "루인 포스실드", 100, 10, 10, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "메이플 트레져 포스실드", 110, 11, 11, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t].maxDF = 110;
        subWeaponList[t].spellSTR = 9;
        subWeaponList[t].spellDEX = 9;
        subWeaponList[t].spellMaxHP = 200;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].maxDF = 110;
        subWeaponList[t].spellSTR = 9;
        subWeaponList[t].spellMaxHP = 200;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].maxDF = 110;
        subWeaponList[t].spellSTR = 9;
        subWeaponList[t].spellDEX = 9;
        subWeaponList[t].spellMaxHP = 200;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].maxDF = 110;
        subWeaponList[t].spellSTR = 9;
        subWeaponList[t].spellMaxHP = 200;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].maxDF = 100;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].maxDF = 100;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].maxDF = 100;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 제논
        subWeaponList.Add(new Item(ItemType.SubWeapon, "옥타코어 컨트롤러", 100, 2, 2, 2, 2, 900, 0, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 옥타코어 컨트롤러", 100, 2, 2, 2, 2, 900, 2, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 옥타코어 컨트롤러", 100, 2, 2, 2, 2, 800, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 컨트롤러", 110, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t].basicMaxMP = 500;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        subWeaponList[t].basicMaxMP = 500;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        subWeaponList[t].basicMaxMP = 450;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        subWeaponList[t].basicMaxMP = 450;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;


        // 아란
        subWeaponList.Add(new Item(ItemType.SubWeapon, "천룡추", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 천룡추", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 천룡추", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 천룡추", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 에반
        subWeaponList.Add(new Item(ItemType.SubWeapon, "드래곤마스터의 유산", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 드래곤마스터의 유산", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 드래곤마스터의 유산", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져의 유산", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 루미너스
        subWeaponList.Add(new Item(ItemType.SubWeapon, "카르마 오브", 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 카르마 오브", 100, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 오브", 100, 0, 0, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 오브", 110, 0, 0, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 메르세데스
        subWeaponList.Add(new Item(ItemType.SubWeapon, "무한의 마법 화살", 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 무한의 마법 화살", 100, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 마법 화살", 100, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 마법화살", 110, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // 팬텀
        subWeaponList.Add(new Item(ItemType.SubWeapon, "데르니에 카르트", 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 데르니에 카르트", 100, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 카르트", 100, 0, 8, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 카르트", 110, 0, 9, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 은월
        subWeaponList.Add(new Item(ItemType.SubWeapon, "황금빛 여우구슬", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 황금빛 여우구슬", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 여우구슬", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져 여우구슬", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // 카이저
        subWeaponList.Add(new Item(ItemType.SubWeapon, "진리의 노바의 정수", 100, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 진리의 노바의 정수", 100, 10, 10, 10, 10, 0, 2, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 노바의 정수", 100, 8, 8, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "메이플 트레져의 정수", 110, 9, 9, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 카인
        subWeaponList.Add(new Item(ItemType.SubWeapon, "D100 커스텀 웨폰 벨트", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 D100 웨폰 벨트", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 D100 웨폰 벨트", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // 카데나
        subWeaponList.Add(new Item(ItemType.SubWeapon, "트랜스미터 type_A", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 트랜스미터 type_A", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 트랜스미터", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 엔젤릭버스터
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "그린 소울링", 100, 10, 10, 10, 10, 900, 0, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "이볼빙 그린 소울링", 100, 10, 10, 10, 10, 900, 2, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "블랙 소울링", 100, 8, 8, 8, 8, 800, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "메이플 트레져 소울링", 110, 9, 9, 9, 9, 800, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // 아델
        subWeaponList.Add(new Item(ItemType.SubWeapon, "노블 브레이슬릿", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 노블 브레이슬릿", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 샤이니 브레이슬릿", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // 일리움
        subWeaponList.Add(new Item(ItemType.SubWeapon, "글로리 매직윙", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 글로리 매직윙", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 매직윙", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 칼리
        subWeaponList.Add(new Item(ItemType.SubWeapon, "인피니트 헥스시커", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 인피니트 헥스시커", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 인피니트 헥스시커", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 아크
        subWeaponList.Add(new Item(ItemType.SubWeapon, "얼티밋 패스", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 얼티밋 패스", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 패스", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // 라라
        subWeaponList.Add(new Item(ItemType.SubWeapon, "빛나는 사옥 노리개", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 사옥 노리개", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 사옥 노리개", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 호영
        subWeaponList.Add(new Item(ItemType.SubWeapon, "월장석 선추", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 월장석 선추", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "블랙 황수정 선추", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // 키네시스
        subWeaponList.Add(new Item(ItemType.SubWeapon, "체스피스 디 퀸", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "이볼빙 체스피스 디 퀸", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "체스피스 블랙 퀸", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // 제로
        subWeaponList.Add(new Item(ItemType.Lapis, "라피스 7형", 170, 40, 40, 0, 0, 0, 173, 0, 30, 10, 0, 0, 9, -1));
        subWeaponList.Add(new Item(ItemType.Lapis, "라피스 8형", 180, 60, 60, 0, 0, 0, 207, 0, 30, 10, 0, 0, 9, -1));
        subWeaponList.Add(new Item(ItemType.Lapis, "라피스 9형", 200, 100, 100, 0, 0, 0, 297, 0, 30, 20, 0, 0, 9, -1));
        subWeaponList.Add(new Item(ItemType.Lapis, "제네시스 라피스", 200, 150, 150, 0, 0, 0, 342, 0, 30, 20, 0, 0, 0, -1));
        subWeaponList[t].isNormalAdditional = true;
        subWeaponList[t].reqClass = CharacterClass.Zero;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].isNormalAdditional = true;
        subWeaponList[t].reqClass = CharacterClass.Zero;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].isNormalAdditional = true;
        subWeaponList[t].reqClass = CharacterClass.Zero;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t].isNormalAdditional = true;
        subWeaponList[t].spellATK = 72;
        subWeaponList[t].spellSTR = 32;
        subWeaponList[t].SetCompletedUpgrade(8);
        subWeaponList[t].starforce = 22;
        subWeaponList[t].isStarForce = false;
        subWeaponList[t].reqClass = CharacterClass.Zero;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;





        #endregion



        #region 19.망토
        t = 0;

        capeList.Add(new Item(ItemType.Cape, "앱솔랩스 나이트케이프", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "앱솔랩스 아처케이프", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "앱솔랩스 메이지케이프", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "앱솔랩스 시프케이프", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "앱솔랩스 파이렛케이프", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));

        capeList[t].setName = SetName.Absolute_Warrior;
        capeList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        capeList[t].setName = SetName.Absolute_Bowman;
        capeList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        capeList[t].setName = SetName.Absolute_Magician;
        capeList[t++].reqClassGroup = CharacterClassGroup.Magician;
        capeList[t].setName = SetName.Absolute_Thief;
        capeList[t++].reqClassGroup = CharacterClassGroup.Thief;
        capeList[t].setName = SetName.Absolute_Pirate;
        capeList[t++].reqClassGroup = CharacterClassGroup.Pirate;



        capeList.Add(new Item(ItemType.Cape, "아케인셰이드 나이트케이프", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "아케인셰이드 아처케이프", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "아케인셰이드 메이지케이프", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "아케인셰이드 시프케이프", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "아케인셰이드 파이렛케이프", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));

        capeList[t].setName = SetName.Arcane_Warrior;
        capeList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        capeList[t].setName = SetName.Arcane_Bowman;
        capeList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        capeList[t].setName = SetName.Arcane_Magician;
        capeList[t++].reqClassGroup = CharacterClassGroup.Magician;
        capeList[t].setName = SetName.Arcane_Thief;
        capeList[t++].reqClassGroup = CharacterClassGroup.Thief;
        capeList[t].setName = SetName.Arcane_Pirate;
        capeList[t++].reqClassGroup = CharacterClassGroup.Pirate;




        capeList.Add(new Item(ItemType.Cape, "타일런트 히아데스 클록", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "타일런트 케이론 클록", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "타일런트 헤르메스 클록", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "타일런트 리카온 클록", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "타일런트 알테어 클록", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));

        capeList[t].isSuperior = true;
        capeList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        capeList[t].isSuperior = true;
        capeList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        capeList[t].isSuperior = true;
        capeList[t++].reqClassGroup = CharacterClassGroup.Magician;
        capeList[t].isSuperior = true;
        capeList[t++].reqClassGroup = CharacterClassGroup.Thief;
        capeList[t].isSuperior = true;
        capeList[t++].reqClassGroup = CharacterClassGroup.Pirate;

        #endregion



        #region 20.기계심장
        t = 0;

        heartList.Add(new Item(ItemType.Heart, "아다만티움 하트", 30, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 3, 0));
        heartList.Add(new Item(ItemType.Heart, "골드 하트", 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0));
        heartList.Add(new Item(ItemType.Heart, "리튬 하트", 30, 3, 3, 3, 3, 50, 0, 0, 0, 0, 0, 0, 8, 0));
        heartList.Add(new Item(ItemType.Heart, "티타늄 하트", 100, 3, 3, 3, 3, 50, 0, 0, 0, 0, 0, 0, 10, 0));
        heartList.Add(new Item(ItemType.Heart, "페어리 하트", 100, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 10, 0));
        heartList.Add(new Item(ItemType.Heart, "리퀴드메탈 하트", 120, 3, 3, 3, 3, 100, 0, 0, 0, 0, 0, 0, 10, 0));
        heartList.Add(new Item(ItemType.Heart, "블랙 하트", 120, 10, 10, 10, 10, 100, 77, 77, 0, 0, 0, 0, 0, -1));


        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;


        heartList[t].setName = SetName.BlackBossTrinket;
        heartList[t].upPotentialGrade = OptionGrade.Epic;
        heartList[t].upPotential1 = "보스 몬스터 공격 시 데미지 : +30%";
        heartList[t].upPotential2 = "몬스터 방어율 무시 : +30%";
        heartList[t].upPotentialPossible = false;
        heartList[t].downPotentialPossible = false;
        heartList[t].isAdditionalOption = false;
        heartList[t++].isStarForce = false;

        #endregion


    }
}




[System.Serializable]
public class ItemSettingData
{
    public string settingName;

    public CharacterClassGroup charaacterClassGroup;
    public CharacterClass charaacterClass;

    public Item[] items = new Item[25];
    public List<Item> Inventory = new List<Item>();
    /*
    public Item m_Ring4;        0
    public Item m_Ring3;        1
    public Item m_Ring2;        2
    public Item m_Ring1;        3
    public Item m_Pocket;       4
    public Item m_Pendant2;     5
    public Item m_Pendant1;     6
    public Item m_Weapon;       7
    public Item m_Belt;         8
    public Item m_Helmet;       9
    public Item m_Face;         10
    public Item m_Eye;          11
    public Item m_Shirt;        12
    public Item m_Pants;        13
    public Item m_Shoes;        14
    public Item m_Earring;      15
    public Item m_Shoulder;     16
    public Item m_Gloves;       17
    public Item m_Android;      18
    public Item m_Emblem;       19
    public Item m_Badge;        20
    public Item m_Medal;        21
    public Item m_SubWeapon;    22
    public Item m_Cape;         23
    public Item m_Heart;        24
    */
    public ItemSettingData(string _name, CharacterClassGroup _charaacterClassGroup, CharacterClass _charaacterClass)
    {
        settingName = _name;

        charaacterClassGroup = _charaacterClassGroup;
        charaacterClass = _charaacterClass;
    }

    public ItemSettingData(string _name, CharacterClassGroup _charaacterClassGroup, CharacterClass _charaacterClass, Item[] _items)
    {
        settingName = _name;

        charaacterClassGroup = _charaacterClassGroup;
        charaacterClass = _charaacterClass;

        for(int i =0; i< items.Length; i++)
        {
            items[i] = _items[i];
        }
    }

    public void SetItem(Item item)
    {
        switch (item.type)
        {
            case ItemType.Ring:
                break;

            default:
                break;
        }
    }
}

[System.Serializable]
public class Item
{
    // 요구 레벨
    public ItemType type;
    public string name;
    public int reqLev;
    public CharacterClassGroup reqClassGroup;
    public CharacterClass reqClass;
    // (기본 옵션, 추가 옵션, 주문서 옵션, 강화 옵션)
    public int basicSTR,    additionalSTR,              amazingSTR;
    public int basicDEX,    additionalDEX,              amazingDEX;
    public int basicINT,    additionalINT,              amazingINT;
    public int basicLUK,    additionalLUK,              amazingLUK;
    public int basicMaxHP,  additionalMaxHP,    spellMaxHP, amazingMaxHP;
    public int basicMaxMP,  additionalMaxMP,    spellMaxMP,     starforceMaxMP;
    public int basicMaxHP_Per;
    public int basicMaxMP_Per;
    public int basicATK,    additionalATK,      spellATK,       amazingATK;
    public int basicMAG,    additionalMAG,      spellMAG,       amazingMAG;

    public int basicBossATK,     additionalBossATK,  spellBossATK,   starforceBossATK;
    public int basicIgnoreDF,    additionalIgnoreDF, spellIgnoreDF,  starforceIgnoreDF;
    public int basicAllStats,    additionalAllStats, spellAllStats,  starforceAllStats;
    public int basicDamage,      additionalDamage,   spellDamage,    starforceDamage;

    public int maxDF = 0;
    public int arc = 0;

    public int basicCriPro, basicCriDamage;

    public int spellSTR, spellDEX, spellINT, spellLUK;

    public int _starforceSTR, _starforceDEX, _starforceINT, _starforceLUK, _starforceMaxHP, _starforceATK, _starforceMAG;
    public int starforceSTR
    {
        get { return _starforceSTR + amazingSTR; }
        set { _starforceSTR = value; }
    }

    public int starforceDEX
    {
        get { return _starforceDEX + amazingDEX; }
        set { _starforceDEX = value; }
    }

    public int starforceINT
    {
        get { return _starforceINT + amazingINT; }
        set { _starforceINT = value; }
    }

    public int starforceLUK
    {
        get { return _starforceLUK + amazingLUK; }
        set { _starforceLUK = value; }
    }

    public int starforceMaxHP
    {
        get { return _starforceMaxHP + amazingMaxHP; }
        set { _starforceMaxHP = value; }
    }

    public int starforceATK
    {
        get { return _starforceATK + amazingATK; }
        set { _starforceATK = value; }
    }

    public int starforceMAG
    {
        get { return _starforceMAG + amazingMAG; }
        set { _starforceMAG = value; }
    }


    public int growthSTR, growthDEX, growthINT, growthLUK;

    public int remainingUpgrade, totalUpgrade;
    private int completedUpgrade = 0;
    public int remainingScissors, totalScissors;
    /* totalScissors
     * 999              99              0               -1
     * 무한 교환 가능, (무교)1회 교환 가능, 장착시 교환 불가, 교환 불가
     */
    public OptionGrade upPotentialGrade, downPotentialGrade;
    public bool upPotentialPossible = true, downPotentialPossible = true;
    public string upPotential1 = "", upPotential2 = "", upPotential3 = "";
    public string downPotential1 = "", downPotential2 = "", downPotential3 = "";
    public int upPotentialN1 = 0, upPotentialN2 = 0, upPotentialN3 = 0;
    public int downPotentialN1 = 0, downPotentialN2 = 0, downPotentialN3 = 0;
    public string soul = "";
    public string soulOption = "";
    public string exceptionalOption = "";
    public SetName setName = SetName.NULL;
    public bool isAdditionalOption = true;
    public bool isBasicGrowth = false;
    public bool isYggdrasil = false;
    public bool isStarForce = true;
    public bool isAmazing = false;
    public bool isNormalAdditional = false;
    public bool isSuperior = false;
    public bool isLucky = false;

    public int starforce;

    public Item()
    {
        type = ItemType.NULL;
    }

    public Item(ItemType _type, string _name)
    {
        type = _type;
        name = _name;
    }

    public Item(ItemType _type, string _name, int _reqLev, int _basicSTR, int _basicDEX, int _basicINT, int _basicLUK, int _basicMaxHP, int _basicATK, int _basicMAG
        , int _basicBossATK, int _basicIgnoreDF, int _basicAllStats, int _basicDamage, int _totalUpgrade, int _totalScissors)
    {
        if(_type == ItemType.SubWeapon || _type == ItemType.Emblem)
        {
            isAdditionalOption = false;
            isStarForce = false;
        }
        else if (_type == ItemType.Blade || _type == ItemType.Shield || _type == ItemType.Shoulder 
            || _type == ItemType.Ring || _type == ItemType.Heart)
        {
            isAdditionalOption = false;
        }
        else if (_type == ItemType.Android || _type == ItemType.Badge || _type == ItemType.Medal)
        {
            isAdditionalOption = false;
            isStarForce = false;
            upPotentialPossible = false;
            downPotentialPossible = false;
        }
        else if (_type == ItemType.Pocket)
        {
            isStarForce = false;
            upPotentialPossible = false;
            downPotentialPossible = false;
        }

        type = _type;
        name = _name;
        reqLev = _reqLev;
        basicSTR = _basicSTR;
        basicDEX = _basicDEX;
        basicINT = _basicINT;
        basicLUK = _basicLUK;
        basicMaxHP = _basicMaxHP;
        basicATK = _basicATK;
        basicMAG = _basicMAG;
        basicBossATK = _basicBossATK;
        basicIgnoreDF = _basicIgnoreDF;
        basicAllStats = _basicAllStats;
        basicDamage = _basicDamage;
        totalUpgrade = _totalUpgrade;
        remainingUpgrade = _totalUpgrade;
        totalScissors = _totalScissors;
        remainingScissors = _totalScissors;
    }

    public Item DeepCopy()
    {
        using (var memStream = new MemoryStream())
        {
            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(memStream, this);
            memStream.Position = 0;

            return (Item)bFormatter.Deserialize(memStream);
        }
    }

    public void SetAdditionalToZero()
    {
        additionalSTR = 0;
        additionalDEX = 0;
        additionalINT = 0;
        additionalLUK = 0;
        additionalMaxHP = 0;
        additionalMaxMP = 0;
        additionalATK = 0;
        additionalMAG = 0;

        additionalBossATK = 0;
        additionalIgnoreDF = 0;
        additionalAllStats = 0;
        additionalDamage = 0;
    }

    public void SetSpellToZero()
    {
        spellSTR = growthSTR;
        spellDEX = growthDEX;
        spellINT = growthINT;
        spellLUK = growthLUK;
        spellMaxHP = 0;
        spellMaxMP = 0;
        spellATK = 0;
        spellMAG = 0;

        spellBossATK = 0;
        spellIgnoreDF = 0;
        spellAllStats = 0;
        spellDamage = 0;

        isYggdrasil = false;

        remainingUpgrade = totalUpgrade;
    }

    public int GetCompletedUpgrade()
    {
        if (totalUpgrade == 0)
            return completedUpgrade;
        return totalUpgrade - remainingUpgrade;
    }

    public void SetCompletedUpgrade(int _completedUpgrade)
    {
        if (totalUpgrade == 0)
            completedUpgrade = _completedUpgrade;
    }

    public int Get3STR()
    {
        return basicSTR + additionalSTR + spellSTR;
    }

    public int Get3DEX()
    {
        return basicDEX + additionalDEX + spellDEX;
    }

    public int Get3INT()
    {
        return basicINT + additionalINT + spellINT;
    }

    public int Get3LUK()
    {
        return basicLUK + additionalLUK + spellLUK;
    }

    public int Get3MaxHP()
    {
        return basicMaxHP + additionalMaxHP + spellMaxHP;
    }

    public int Get3MaxMP()
    {
        return basicMaxMP + additionalMaxMP + spellMaxMP;
    }

    public int Get3ATK()
    {
        return basicATK + additionalATK + spellATK;
    }

    public int Get3MAG()
    {
        return basicMAG + additionalMAG + spellMAG;
    }

    public int Get2STR()
    {
        return basicSTR + spellSTR;
    }

    public int Get2DEX()
    {
        return basicDEX + spellDEX;
    }

    public int Get2INT()
    {
        return basicINT + spellINT;
    }

    public int Get2LUK()
    {
        return basicLUK + spellLUK;
    }

    public int Get2MaxHP()
    {
        return basicMaxHP + spellMaxHP;
    }

    public int Get2MaxMP()
    {
        return basicMaxMP + spellMaxMP;
    }

    public int Get2ATK()
    {
        return basicATK + spellATK;
    }
    
    public int Get2MAG()
    {
        return basicMAG + spellMAG;
    }
}


public enum ItemType : sbyte
{
    NULL = -1,

    Ring = 0,
    Pocket,
    Pendant,
    Weapon,
    Belt,
    Helmet,
    Face,
    Eye,
    Shirt,
    Pants,
    Shoes,
    Earring,
    Shoulder,
    Gloves,
    Android,
    Emblem,
    Badge,
    Medal,
    SubWeapon,
    Cape,
    Heart,
    Blade,
    Lapis,
    Shield,
    ShirtAndPants,
    SubWeapon2
}

public enum Exchange : byte
{
    FreeX = 0,
    Free = 1,
    X = 2,
    XX = 3
}

public enum OptionGrade
{
    None = 0,
    Rare,
    Epic,
    Unique,
    Legendary
}

public enum PotentialOption : byte
{
    None = 0,
    STR,
    DEX,
    INT,
    LUK,
    MaxHP,
    MaxMP,
    ATK,
    MAG,
    CriticalPct,
    CriticalDamage,
    Damage,
    AllStats,
    IgnoreDF,
    BossATK,
    CooldownReduction,
    MesoAcquiredRate,
    ItemDropRate
}

public enum PP : byte
{
    Percent = 0,
    Plus
}

[System.Serializable]
public class Potential
{
    public PotentialOption potentialOption;
    public int potentialValue;
    public PP percentOrPlus;

    public Potential() { }

    public Potential(PotentialOption _potentialOption, int _potentialValue, PP _percentOrPlus)
    {
        potentialOption = _potentialOption;
        potentialValue = _potentialValue;
        percentOrPlus = _percentOrPlus;
    }

    public override string ToString()
    {
        string str = "";
        switch (potentialOption)
        {
            case PotentialOption.None:
                return "";
            case PotentialOption.STR:
            case PotentialOption.DEX:
            case PotentialOption.INT:
            case PotentialOption.LUK:
            case PotentialOption.MaxHP:
            case PotentialOption.MaxMP:
                str += potentialOption.ToString() + " : +";
                break;
            case PotentialOption.ATK:
                str += "공격력 : +";
                break;
            case PotentialOption.MAG:
                str += "마력 : +";
                break;
            case PotentialOption.CriticalPct:
                str += "크리티컬 확률 : +";
                break;
            case PotentialOption.CriticalDamage:
                str += "크리티컬 데미지 : +";
                break;
            case PotentialOption.Damage:
                str += "데미지 : +";
                break;
            case PotentialOption.AllStats:
                str += "올스탯 : +";
                break;
            case PotentialOption.IgnoreDF:
                str += "몬스터 방어율 무시 : +";
                break;
            case PotentialOption.BossATK:
                str += "보스 몬스터 공격 시 데미지 : +";
                break;
            case PotentialOption.CooldownReduction:
                return "모든 스킬의 재사용 대기시간 : -" + potentialValue.ToString() + "초(10초 이하는 5%감소, 5초 미만으로 감소 불가)";
            case PotentialOption.MesoAcquiredRate:
                str += "메소 획득량 : +";
                break;
            case PotentialOption.ItemDropRate:
                str += "아이템 드롭률 : +";
                break;
        }
        str += potentialValue.ToString();
        if (percentOrPlus == PP.Percent)
            str += "%";
        return str;
    }
}


public enum SetName
{
    NULL = 0,
    BossTrinket,
    DawnBoss,
    BlackBossTrinket,

    SevenDays,
    Meister,
    ImmortalHero,
    ImmortalMeisterHero,
    EternalHero,
    EternalMeisterHero,

    Rootabis_Warrior,
    Rootabis_Magician,
    Rootabis_Bowman,
    Rootabis_Thief,
    Rootabis_Pirate,

    Absolute_Warrior,
    Absolute_Magician,
    Absolute_Bowman,
    Absolute_Thief,
    Absolute_Pirate,

    Arcane_Warrior,
    Arcane_Magician,
    Arcane_Bowman,
    Arcane_Thief,
    Arcane_Pirate,

    Eternel_Warrior,
    Eternel_Magician,
    Eternel_Bowman,
    Eternel_Thief,
    Eternel_Pirate
}

public enum CharacterClassGroup : byte
{
    NULL = 0,
    Warrior = 1,
    Magician = 2,
    Bowman = 3,
    Thief = 4,
    Pirate = 5,
    Hybrid = 6,
    Fail
}


public enum CharacterClass
{
    NULL = 0,


    Hero = 1001,
    Paladin = 1002,
    DarkKnight = 1003,
    SoulMaster = 1004,
    Mihile = 1005,
    Blaster = 1006,
    DemonSlayer = 1007,
    DemonAvenger = 1008,
    Aran = 1009,
    Kaiser = 1010,
    Adele = 1011,
    Zero = 1012,


    ArchMage_FP = 2001,
    ArchMage_IL = 2002,
    Bishop = 2003,
    FlameWizard = 2004,
    BattleMage = 2005,
    Evan = 2006,
    Luminous = 2007,
    Illium = 2008,
    Lara = 2009,
    Kinesis = 2010,


    Bowmaster = 3001,
    Marksman = 3002,
    Pathfinder = 3003,
    WindBreaker = 3004,
    WildHunter = 3005,
    Mercedes = 3006,
    Kain = 3007,


    NightLord = 4001,
    Shadower = 4002,
    DualBlade = 4003,
    NightWalker = 4004,
    Phantom = 4005,
    Cadena = 4006,
    Khali = 4007,
    HoYoung = 4008,


    Viper = 5001,
    Captain = 5002,
    CannonShooter = 5003,
    Striker = 5004,
    Mechanic = 5005,
    Eunwol = 5006,
    AngelicBuster = 5007,
    Ark = 5008,


    Xenon = 6001
}