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

        #region 0.����

        t = 0;

        ringList.Add(new Item(ItemType.Ring, "���ݼ����� ����", 10, 1, 1, 1, 1, 150, 0, 0, 0, 0, 0, 0, 2, 999));
        t++;

        ringList.Add(new Item(ItemType.Ring, "����Ŀ�� �Ӹ�Ż ��", 30, 5, 5, 5, 5, 0, 2, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalHero;
        ringList.Add(new Item(ItemType.Ring, "������� �Ӹ�Ż ��", 30, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalHero;
        ringList.Add(new Item(ItemType.Ring, "����Ŀ�� ���̽��� �Ӹ�Ż ��", 90, 5, 5, 5, 5, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalMeisterHero;
        ringList.Add(new Item(ItemType.Ring, "������� ���̽��� �Ӹ�Ż ��", 90, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.ImmortalMeisterHero;

        ringList.Add(new Item(ItemType.Ring, "��ũ�ε��� ���ͳ� ��", 30, 5, 5, 5, 5, 0, 0, 2, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalHero;
        ringList.Add(new Item(ItemType.Ring, "����Ŭ�� ���ͳ� ��", 30, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalHero;
        ringList.Add(new Item(ItemType.Ring, "��ũ�ε��� ���̽��� ���ͳ� ��", 90, 5, 5, 5, 5, 0, 0, 3, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalMeisterHero;
        ringList.Add(new Item(ItemType.Ring, "����Ŭ�� ���̽��� ���ͳ� ��", 90, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        ringList[t++].setName = SetName.EternalMeisterHero;

        ringList.Add(new Item(ItemType.Ring, "�ø���Ƽ��", 30, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 3, 99));
        t++;
        ringList.Add(new Item(ItemType.Ring, "���̽��� �ø���Ƽ��", 75, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 3, 99));
        t++;

        ringList.Add(new Item(ItemType.Ring, "���̽��͸�", 140, 5, 5, 5, 5, 200, 1, 1, 0, 0, 0, 0, 2, 99));
        ringList[t].setName = SetName.Meister;
        ringList[t++].basicMaxMP = 200;

        ringList.Add(new Item(ItemType.Ring, "�ǹ����� ��", 110, 5, 5, 5, 5, 0, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t++].setName = SetName.BossTrinket;
        ringList.Add(new Item(ItemType.Ring, "����� ���Ǿ��� ����", 120, 5, 5, 5, 5, 100, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t].setName = SetName.BossTrinket;
        ringList[t++].basicMaxMP = 100;
        ringList.Add(new Item(ItemType.Ring, "����� ���� ��", 160, 5, 5, 5, 5, 200, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t].setName = SetName.BossTrinket;
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "������ ����� ���� ��", 160, 5, 5, 5, 5, 200, 2, 2, 0, 0, 0, 0, 3, 10));
        ringList[t].setName = SetName.DawnBoss;
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "�Ŵ��� ����", 200, 5, 5, 5, 5, 250, 4, 4, 0, 0, 0, 0, 3, 5));
        ringList[t].setName = SetName.BlackBossTrinket;
        ringList[t++].basicMaxMP = 250;


        ringList.Add(new Item(ItemType.Ring, "���������� �ε� ��", 100, 7, 7, 7, 7, 200, 2, 0, 0, 0, 0, 0, 2, 99));
        t++;
        ringList.Add(new Item(ItemType.Ring, "���������� ������ ��", 100, 7, 7, 7, 7, 0, 0, 2, 0, 0, 0, 0, 2, 99));
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "����ȣ�� ȥ�ɹ���", 100, 7, 7, 7, 7, 200, 2, 0, 0, 0, 0, 0, 2, 99));
        t++;
        ringList.Add(new Item(ItemType.Ring, "����ȣ�� �ּ�����", 100, 7, 7, 7, 7, 0, 0, 2, 0, 0, 0, 0, 2, 99));
        ringList[t++].basicMaxMP = 200;
        ringList.Add(new Item(ItemType.Ring, "��Į�� ��", 135, 4, 4, 4, 4, 150, 1, 1, 0, 0, 0, 0, 2, 99));
        ringList[t].isLucky = true;
        ringList[t++].basicMaxMP = 150;


        ringList.Add(new Item(ItemType.Ring, "����Ʈ����Ʈ ��", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "�������� ��", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "��Ƽ��� ��", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "����ũ����Ŀ ��", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;
        ringList.Add(new Item(ItemType.Ring, "��Ƽ���̴� ��", 110, 4, 4, 4, 4, 0, 4, 4, 0, 0, 0, 0, 0, 0));
        ringList[t].isStarForce = false;
        ringList[t].upPotentialPossible = false;
        ringList[t++].downPotentialPossible = false;


        //�̺�Ʈ ��

        ringList.Add(new Item(ItemType.Ring, "���н� ��(STR)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
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
        ringList[t++].upPotential1 = "ũ��Ƽ�� ������ : +5%";

        ringList.Add(new Item(ItemType.Ring, "���н� ��(DEX)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
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
        ringList[t++].upPotential1 = "ũ��Ƽ�� ������ : +5%";

        ringList.Add(new Item(ItemType.Ring, "���н� ��(INT)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
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
        ringList[t++].upPotential1 = "ũ��Ƽ�� ������ : +5%";

        ringList.Add(new Item(ItemType.Ring, "���н� ��(LUK)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
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
        ringList[t++].upPotential1 = "ũ��Ƽ�� ������ : +5%";

        ringList.Add(new Item(ItemType.Ring, "���н� ��(MaxHP)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
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
        ringList[t++].upPotential1 = "ũ��Ƽ�� ������ : +5%";

        ringList.Add(new Item(ItemType.Ring, "���н� ��(�ý���)", 30, 3, 3, 3, 3, 30, 0, 0, 0, 0, 0, 0, 0, -1));
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
        ringList[t++].upPotential1 = "ũ��Ƽ�� ������ : +5%";

        ringList.Add(new Item(ItemType.Ring, "����Ʈ ���н� ��", 30, 23, 23, 23, 23, 1030, 0, 0, 0, 0, 0, 0, 0, -1));
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
        ringList[t++].upPotential1 = "ũ��Ƽ�� ������ : +5%";


        ringList.Add(new Item(ItemType.Ring, "������ ��", 120, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
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

        ringList.Add(new Item(ItemType.Ring, "����Ʈ ������ ��", 120, 20, 20, 20, 20, 2000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 2000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "�ڽ��� ��", 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
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

        ringList.Add(new Item(ItemType.Ring, "����Ʈ �ڽ��� ��", 50, 20, 20, 20, 20, 2000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 2000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "SS�� ������ ���", 120, 30, 30, 30, 30, 3000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 3000;
        ringList[t++].isStarForce = false;

        ringList.Add(new Item(ItemType.Ring, "����� ����(Ǯ ��Ʈ)", 120, 5, 5, 5, 5, 500, 10, 10, 0, 0, 0, 0, 0, -1));
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


        ringList.Add(new Item(ItemType.Ring, "��庥�� ����ũ ũ��Ƽ�ø�", 130, 20, 20, 20, 20, 1500, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 1500;
        ringList[t].basicCriPro = 15;
        ringList[t].basicCriDamage = 5;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "ī���� ��", 130, 30, 30, 30, 30, 3000, 20, 20, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 3000;
        // �߿�!
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "�׳׺긮�� ������ ����", 120, 10, 10, 10, 10, 1000, 10, 10, 0, 0, 0, 0, 0, -1));
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

        ringList.Add(new Item(ItemType.Ring, "����Ʈ �׳׺긮�� ������ ����", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "�۷θ��� ��(������)", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "�����ũ ��", 120, 10, 10, 10, 10, 1000, 10, 10, 0, 0, 0, 0, 0, -1));
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

        ringList.Add(new Item(ItemType.Ring, "����Ʈ �����ũ ��", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t++].isStarForce = false;


        ringList.Add(new Item(ItemType.Ring, "���ͳ� �÷��� ��", 120, 40, 40, 40, 40, 4000, 25, 25, 0, 0, 0, 0, 0, -1));
        ringList[t].basicMaxMP = 4000;
        ringList[t].upPotentialGrade = OptionGrade.Unique;
        ringList[t].upPotential1 = "����ɷ��� ���εǾ� �ֽ��ϴ�.";
        ringList[t++].isStarForce = false;


        #endregion



        #region 1.����
        t = 0;

        pocketList.Add(new Item(ItemType.Pocket, "������ ��", 0, 3, 3, 3, 3, 0, 3, 3, 0, 0, 0, 0, 0, -1));
        pocketList[t++].setName = SetName.BossTrinket;
        pocketList.Add(new Item(ItemType.Pocket, "��ũ�� ����", 140, 5, 5, 5, 5, 50, 5, 5, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BossTrinket;
        pocketList[t++].basicMaxMP = 50;
        pocketList.Add(new Item(ItemType.Pocket, "���ֹ��� ���� ������", 160, 20, 10, 10, 10, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;
        pocketList.Add(new Item(ItemType.Pocket, "���ֹ��� û�� ������", 160, 10, 10, 20, 10, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;
        pocketList.Add(new Item(ItemType.Pocket, "���ֹ��� ���� ������", 160, 10, 20, 10, 10, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;
        pocketList.Add(new Item(ItemType.Pocket, "���ֹ��� Ȳ�� ������", 160, 10, 10, 10, 20, 100, 10, 10, 0, 0, 0, 0, 0, 0));
        pocketList[t].setName = SetName.BlackBossTrinket;
        pocketList[t++].basicMaxMP = 100;


        #endregion



        #region 2.���Ʈ
        t = 0;

        pendantList.Add(new Item(ItemType.Pendant, "�׸��� ���Ʈ", 75, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 7, -1));
        pendantList[t++].isNormalAdditional = true;
        pendantList.Add(new Item(ItemType.Pendant, "��� �׸� ���Ʈ", 100, 4, 0, 0, 0, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;
        pendantList.Add(new Item(ItemType.Pendant, "������ �׸� ���Ʈ", 100, 0, 4, 0, 0, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;
        pendantList.Add(new Item(ItemType.Pendant, "�ƿｺ �׸� ���Ʈ", 100, 0, 0, 4, 0, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;
        pendantList.Add(new Item(ItemType.Pendant, "���۽� �׸� ���Ʈ", 100, 0, 0, 0, 4, 45, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 45;

        pendantList.Add(new Item(ItemType.Pendant, "��� ���� ���Ʈ", 110, 8, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;
        pendantList.Add(new Item(ItemType.Pendant, "������ ���� ���Ʈ", 110, 0, 8, 0, 0, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;
        pendantList.Add(new Item(ItemType.Pendant, "�ƿｺ ���� ���Ʈ", 110, 0, 0, 8, 0, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;
        pendantList.Add(new Item(ItemType.Pendant, "���۽� ���� ���Ʈ", 110, 0, 0, 0, 8, 90, 0, 0, 0, 0, 0, 0, 4, 999));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 90;

        pendantList.Add(new Item(ItemType.Pendant, "ȥ������ �����", 120, 7, 7, 7, 7, 0, 0, 0, 0, 0, 0, 0, 3, 99));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t++].isNormalAdditional = true;
        pendantList.Add(new Item(ItemType.Pendant, "��Ŀ������ ���Ʈ", 120, 10, 10, 10, 10, 250, 1, 1, 0, 0, 0, 0, 3, 10));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t++].basicMaxMP = 250;
        pendantList.Add(new Item(ItemType.Pendant, "ī���� ȥ������ �����", 120, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 3, 99));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t].isNormalAdditional = true;
        pendantList[t].basicMaxHP_Per = 10;
        pendantList[t++].basicMaxMP_Per = 10;

        pendantList.Add(new Item(ItemType.Pendant, "��� ��ũ ���Ʈ", 120, 12, 0, 0, 0, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;
        pendantList.Add(new Item(ItemType.Pendant, "������ ��ũ ���Ʈ", 120, 0, 12, 0, 0, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;
        pendantList.Add(new Item(ItemType.Pendant, "�ƿｺ ��ũ ���Ʈ", 120, 0, 0, 12, 0, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;
        pendantList.Add(new Item(ItemType.Pendant, "���۽� ��ũ ���Ʈ", 120, 0, 0, 0, 12, 135, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 135;

        pendantList.Add(new Item(ItemType.Pendant, "��� ���� ���Ʈ", 130, 16, 0, 0, 0, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "������ ���� ���Ʈ", 130, 0, 16, 0, 0, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "�ƿｺ ���� ���Ʈ", 130, 0, 0, 16, 0, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "���۽� ���� ���Ʈ", 130, 0, 0, 0, 16, 180, 0, 0, 0, 0, 0, 0, 4, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;

        pendantList.Add(new Item(ItemType.Pendant, "����¡ �� ���Ʈ", 130, 16, 16, 16, 16, 180, 2, 2, 0, 0, 0, 0, 5, 10));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].basicMaxMP = 180;
        pendantList.Add(new Item(ItemType.Pendant, "�Ǿ�� ���Ʈ", 130, 20, 20, 20, 20, 150, 3, 3, 0, 0, 0, 0, 5, 99));
        pendantList[t].isNormalAdditional = true;
        pendantList[t++].isBasicGrowth = true;


        pendantList.Add(new Item(ItemType.Pendant, "���̺극��ũ ���Ʈ", 140, 8, 8, 8, 8, 0, 2, 2, 0, 0, 0, 0, 6, 10));
        pendantList[t].setName = SetName.DawnBoss;
        pendantList[t++].basicMaxHP_Per = 5;
        pendantList.Add(new Item(ItemType.Pendant, "���̳����� ���Ʈ", 140, 20, 20, 20, 20, 0, 3, 3, 0, 0, 0, 0, 6, 10));
        pendantList[t].setName = SetName.BossTrinket;
        pendantList[t].basicMaxHP_Per = 10;
        pendantList[t++].basicMaxMP_Per = 10;
        pendantList.Add(new Item(ItemType.Pendant, "������ �ٿ�", 160, 10, 10, 10, 10, 0, 3, 3, 0, 0, 0, 0, 6, 5));
        pendantList[t].setName = SetName.BlackBossTrinket;
        pendantList[t++].basicMaxHP_Per = 5;

        pendantList.Add(new Item(ItemType.Pendant, "������ ���Ʈ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        pendantList[t].isStarForce = false;
        pendantList[t].isAdditionalOption = false;
        pendantList[t].upPotentialPossible = false;
        pendantList[t++].downPotentialPossible = false;
        pendantList.Add(new Item(ItemType.Pendant, "�غ�� ������ ���Ʈ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        pendantList[t].isStarForce = false;
        pendantList[t].isAdditionalOption = false;
        pendantList[t].upPotentialPossible = false;
        pendantList[t++].downPotentialPossible = false;



        #endregion



        #region 3.����
        t = 0;

        //����
        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �� ����ƾ", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���� ��", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ������", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ������", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �����긵��", 150, 40, 0, 0, 0, 2000, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �������", 160, 60, 0, 0, 0, 2250, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �������", 200, 100, 0, 0, 0, 2500, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� �������", 200, 150, 0, 0, 0, 2800, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellMaxHP = 1600;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�ع�� ī�̼�����", 150, 200, 200, 0, 0, 0, 400, 0, 0, 0, 0, 0, 2, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����ٽþ�", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��ε弼�̹�", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���ڵ�ҵ�", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���ڵ�ҵ�", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ��ƲŬ����", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��ε忢��", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���ڵ忢��", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���ڵ忢��", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����Ʈ�׾�", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��ε��ظ�", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���ڵ��ظ�", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���ڵ��ظ�", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �����ũ", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �Ǿ�̽��Ǿ�", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���Ǿ�", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���Ǿ�", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "���� 7��", 170, 40, 40, 0, 0, 0, 169, 0, 30, 10, 0, 0, 9, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t].reqClass = CharacterClass.Zero;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���� 8��", 180, 60, 60, 0, 0, 0, 203, 0, 30, 10, 0, 0, 9, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t].reqClass = CharacterClass.Zero;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���� 9��", 200, 100, 100, 0, 0, 0, 293, 0, 30, 20, 0, 0, 9, -1));
        weaponList[t].isNormalAdditional = true;
        weaponList[t].reqClass = CharacterClass.Zero;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ����", 200, 150, 150, 0, 0, 0, 337, 0, 30, 20, 0, 0, 0, -1));
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


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �����Ͻ�", 150, 40, 40, 0, 0, 0, 171, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� Ʃ��", 160, 60, 60, 0, 0, 0, 205, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� Ʃ��", 200, 100, 100, 0, 0, 0, 295, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� Ʃ��", 200, 150, 150, 0, 0, 0, 340, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ���۷��̺�", 150, 40, 40, 0, 0, 0, 153, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �۹���", 160, 60, 60, 0, 0, 0, 184, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ����", 200, 100, 100, 0, 0, 0, 264, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ����", 200, 150, 150, 0, 0, 0, 304, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �̽�ƿ����", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���̹�", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���̹�", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���̹�", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� Ʈ��Ŭ����", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ����", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ����", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ����", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �����ظ�", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��Ʈ�ظ�", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �ظ�", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� �ظ�", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Warrior;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;




        // �ü�
        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ���������", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��󺸿��", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ��󺸿��", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ��󺸿��", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����Ʈü�̼�", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �극�� ����", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �극�� ����", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� �극�� ����", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����������", 150, 40, 40, 0, 0, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ũ�ν�����", 160, 60, 60, 0, 0, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ũ�ν�����", 200, 100, 100, 0, 0, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ũ�ν�����", 200, 150, 150, 0, 0, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ���μ�Ʈ ����", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���μ�Ʈ ����", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���μ�Ʈ ����", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���μ�Ʈ ����", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����ü�̼�", 150, 40, 40, 0, 0, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���ú���", 160, 60, 60, 0, 0, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ����", 200, 100, 100, 0, 0, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ����", 200, 150, 150, 0, 0, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Bowman;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;



        // ������
        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ESP������", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ESP������", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ESP������", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ESP������", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ���� ��Ʋ��", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���� ��Ʋ��", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���� ��Ʋ��", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���� ��Ʋ��", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����ũ����", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���̴׷ε�", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���̴׷ε�", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���̴׷ε�", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����ũ���", 150, 0, 0, 40, 40, 0, 126, 204, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���縵������", 160, 0, 0, 60, 60, 0, 151, 245, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ������", 200, 0, 0, 100, 100, 0, 218, 353, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ������", 200, 0, 0, 150, 150, 0, 251, 406, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ��������Ŀ", 150, 0, 0, 40, 40, 0, 119, 201, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ���縵�ϵ�", 160, 0, 0, 60, 60, 0, 143, 241, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �ϵ�", 200, 0, 0, 100, 100, 0, 206, 347, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� �ϵ�", 200, 0, 0, 150, 150, 0, 237, 400, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellMAG = 72;
        weaponList[t].spellINT = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Magician;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Magician;



        // ����
        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �ٸ���Ŀ��", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ������", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ���", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ���", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �뼱", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ����", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �ʼ�", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� â����", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����ũȦ��", 150, 0, 40, 0, 40, 0, 86, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ����������", 160, 0, 60, 0, 60, 0, 103, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ����", 200, 0, 100, 0, 100, 0, 149, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ����", 200, 0, 150, 0, 150, 0, 172, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ü��", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ü��", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ü��", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ü��", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� Ŭ�����ÿ�", 150, 0, 40, 0, 40, 0, 164, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��������", 160, 0, 60, 0, 60, 0, 197, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ����", 200, 0, 100, 0, 100, 0, 283, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ����", 200, 0, 150, 0, 150, 0, 326, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ��ũ��", 150, 0, 40, 0, 40, 0, 160, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��ũ��", 160, 0, 60, 0, 60, 0, 192, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ��ũ��", 200, 0, 100, 0, 100, 0, 276, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ��Ŭ����", 200, 0, 150, 0, 150, 0, 318, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Thief;



        // ����
        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ÿ����ī", 150, 40, 40, 0, 0, 0, 125, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �����ð�", 160, 60, 60, 0, 0, 0, 150, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �ǽ���", 200, 100, 100, 0, 0, 0, 216, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� �ǽ���", 200, 150, 150, 0, 0, 0, 249, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� �渮��Ż��", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ��ο��Ŭ", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� Ŭ��", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� Ŭ��", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ����������", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �ҿｴ��", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �ҿｴ��", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� �ҿｴ��", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellDEX = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ������ĳ��", 150, 40, 40, 0, 0, 0, 175, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� ����Ʈĳ��", 160, 60, 60, 0, 0, 0, 210, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� �����", 200, 100, 100, 0, 0, 0, 302, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� �����", 200, 150, 150, 0, 0, 0, 348, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellSTR = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;






        // ����
        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ���ø�����(����)", 150, 0, 40, 0, 40, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �������ҵ�(����)", 160, 0, 60, 0, 60, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ������ü��(����)", 200, 0, 100, 0, 100, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ������ü��(����)", 200, 0, 150, 0, 150, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Thief;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;


        weaponList.Add(new Item(ItemType.Weapon, "�����ϸ� ���ø�����(����)", 150, 40, 40, 0, 0, 0, 128, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Rootabis_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "�ۼַ��� �������ҵ�(����)", 160, 60, 60, 0, 0, 0, 154, 0, 30, 10, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Absolute_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "�����μ��̵� ������ü��(����)", 200, 100, 100, 0, 0, 0, 221, 0, 30, 20, 0, 0, 9, 10));
        weaponList[t].setName = SetName.Arcane_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        weaponList.Add(new Item(ItemType.Weapon, "���׽ý� ������ü��(����)", 200, 150, 150, 0, 0, 0, 255, 0, 30, 20, 0, 0, 0, -1));
        weaponList[t].spellATK = 72;
        weaponList[t].spellLUK = 32;
        weaponList[t].SetCompletedUpgrade(8);
        weaponList[t].starforce = 22;
        weaponList[t].isStarForce = false;
        weaponList[t].isLucky = true;
        weaponList[t].setName = SetName.Eternel_Pirate;
        weaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;

        #endregion



        #region 4.��Ʈ

        t = 0;

        beltList.Add(new Item(ItemType.Belt, "��� Ŭ�ι� ��Ʈ", 140, 15, 15, 15, 15, 150, 1, 1, 0, 0, 0, 0, 4, 10));
        beltList[t].setName = SetName.BossTrinket;
        beltList[t++].basicMaxMP = 150;
        beltList.Add(new Item(ItemType.Belt, "�г��� ������ ��Ʈ", 150, 18, 18, 18, 18, 150, 1, 1, 0, 0, 0, 0, 4, 10));
        beltList[t].setName = SetName.BossTrinket;
        beltList[t++].basicMaxMP = 150;
        beltList.Add(new Item(ItemType.Belt, "��ȯ�� ��Ʈ", 200, 50, 50, 50, 50, 150, 6, 6, 0, 0, 0, 0, 4, 5));
        beltList[t].setName = SetName.BlackBossTrinket;
        beltList[t++].basicMaxMP = 150;

        beltList.Add(new Item(ItemType.Belt, "Ÿ�Ϸ�Ʈ ���Ƶ��� ��Ʈ", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        beltList.Add(new Item(ItemType.Belt, "Ÿ�Ϸ�Ʈ ���̷� ��Ʈ", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        beltList.Add(new Item(ItemType.Belt, "Ÿ�Ϸ�Ʈ �츣�޽� ��Ʈ", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Magician;
        beltList.Add(new Item(ItemType.Belt, "Ÿ�Ϸ�Ʈ ��ī�� ��Ʈ", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Thief;
        beltList.Add(new Item(ItemType.Belt, "Ÿ�Ϸ�Ʈ ���׾� ��Ʈ", 150, 50, 50, 50, 50, 0, 25, 25, 0, 0, 0, 0, 2, 10));
        beltList[t].isSuperior = true;
        beltList[t++].reqClassGroup = CharacterClassGroup.Pirate;

        #endregion



        #region 5.����

        t = 0;

        helmetList.Add(new Item(ItemType.Helmet, "ī���� �ݹ� ����", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 11, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;
        helmetList.Add(new Item(ItemType.Helmet, "ī���� ���� Ƽ�ƶ�", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 11, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;
        helmetList.Add(new Item(ItemType.Helmet, "ī���� �ǿ��� ����", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 11, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;
        helmetList.Add(new Item(ItemType.Helmet, "ī���� ������ �︧", 140, 23, 23, 23, 23, 0, 1, 1, 0, 0, 0, 0, 12, 10));
        helmetList[t].isLucky = true;
        helmetList[t++].isNormalAdditional = true;



        helmetList.Add(new Item(ItemType.Helmet, "���̳׽� �������︧", 150, 40, 40, 0, 0, 360, 2, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���̳׽� ����������", 150, 40, 40, 0, 0, 360, 2, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���̳׽� ����ġ��", 150, 0, 0, 40, 40, 360, 0, 2, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���̳׽� ����ź���", 150, 0, 40, 0, 40, 360, 2, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���̳׽� ��������", 150, 40, 40, 0, 0, 360, 2, 0, 0, 10, 0, 0, 12, 10));

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




        helmetList.Add(new Item(ItemType.Helmet, "�ۼַ��� ����Ʈ�︧", 160, 45, 45, 0, 0, 0, 3, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�ۼַ��� ��ó�ĵ�", 160, 45, 45, 0, 0, 0, 3, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�ۼַ��� ������ũ���", 160, 0, 0, 45, 45, 0, 0, 3, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�ۼַ��� ����ĸ", 160, 0, 45, 0, 45, 0, 3, 0, 0, 10, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�ۼַ��� ���̷��䵵��", 160, 45, 45, 0, 0, 0, 3, 0, 0, 10, 0, 0, 12, 10));

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




        helmetList.Add(new Item(ItemType.Helmet, "�����μ��̵� ����Ʈ��", 200, 65, 65, 0, 0, 0, 7, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�����μ��̵� ��ó��", 200, 65, 65, 0, 0, 0, 7, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�����μ��̵� ��������", 200, 0, 0, 65, 65, 0, 0, 7, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�����μ��̵� ������", 200, 0, 65, 0, 65, 0, 7, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "�����μ��̵� ���̷���", 200, 65, 65, 0, 0, 0, 7, 0, 0, 15, 0, 0, 12, 10));


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




        helmetList.Add(new Item(ItemType.Helmet, "���׸��� ����Ʈ�︧", 250, 80, 80, 0, 0, 0, 10, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���׸��� ��ó��", 250, 80, 80, 0, 0, 0, 10, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���׸��� ��������", 250, 0, 0, 80, 80, 0, 0, 10, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���׸��� �����ݴٳ�", 250, 0, 80, 0, 80, 0, 10, 0, 0, 15, 0, 0, 12, 10));
        helmetList.Add(new Item(ItemType.Helmet, "���׸��� ���̷���", 250, 80, 80, 0, 0, 0, 10, 0, 0, 15, 0, 0, 12, 10));


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



        #region 6.�����
        t = 0;

        faceList.Add(new Item(ItemType.Face, "���� ������ ���̽��� �ɺ�", 100, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���� ��ó ���̽��� �ɺ�", 100, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���� ������ ���̽��� �ɺ�", 100, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���� ���� ���̽��� �ɺ�", 100, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���� ���̷� ���̽��� �ɺ�", 100, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 99));

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



        faceList.Add(new Item(ItemType.Face, "���̴� ���� ������ ���̽��� �ɺ�", 130, 3, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���̴� ���� ��ó ���̽��� �ɺ�", 130, 3, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���̴� ���� ������ ���̽��� �ɺ�", 130, 0, 0, 3, 3, 0, 0, 3, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���̴� ���� ���� ���̽��� �ɺ�", 130, 0, 3, 0, 3, 0, 3, 0, 0, 0, 0, 0, 2, 99));
        faceList.Add(new Item(ItemType.Face, "���̴� ���� ���̷� ���̽��� �ɺ�", 130, 3, 3, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 99));

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



        faceList.Add(new Item(ItemType.Face, "����� ���� ������", 110, 5, 5, 5, 5, 0, 5, 5, 0, 0, 0, 0, 6, 10));
        faceList[t++].setName = SetName.BossTrinket;
        faceList.Add(new Item(ItemType.Face, "Ʈ���϶���Ʈ ��ũ", 140, 5, 5, 5, 5, 0, 5, 5, 0, 0, 0, 0, 4, 10));
        faceList[t++].setName = SetName.DawnBoss;
        faceList.Add(new Item(ItemType.Face, "���� ��Ʈ�� �ӽ� ��ũ", 160, 10, 10, 10, 10, 0, 10, 10, 0, 0, 0, 0, 6, 5));
        faceList[t++].setName = SetName.BlackBossTrinket;

        #endregion



        #region 7.�����
        t = 0;


        eyeList.Add(new Item(ItemType.Eye, "��ī���� �� �Ȱ�", 75, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 6, 99));
        eyeList[t++].isNormalAdditional = true;
        eyeList.Add(new Item(ItemType.Eye, "��ī������ �� �Ȱ�", 75, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 0, 6, 99));
        eyeList[t++].isNormalAdditional = true;
        eyeList.Add(new Item(ItemType.Eye, "�����ƽ ���� �����", 100, 6, 6, 6, 6, 0, 1, 1, 0, 0, 0, 0, 4, 10));
        eyeList[t++].setName = SetName.BossTrinket;
        eyeList.Add(new Item(ItemType.Eye, "���� ��ũ", 135, 7, 7, 7, 7, 0, 1, 1, 0, 0, 0, 0, 6, 10));
        eyeList[t++].setName = SetName.BossTrinket;
        eyeList.Add(new Item(ItemType.Eye, "��Ǯ������ ��ũ", 145, 8, 8, 8, 8, 0, 1, 1, 0, 0, 0, 0, 6, 10));
        eyeList[t++].setName = SetName.BossTrinket;
        eyeList.Add(new Item(ItemType.Eye, "������ ��� �ȴ�", 160, 15, 15, 15, 15, 0, 3, 3, 0, 0, 0, 0, 4, 5));
        eyeList[t++].setName = SetName.BlackBossTrinket;

        #endregion



        #region 8.����
        t = 0;

        shirtList.Add(new Item(ItemType.Shirt, "�̱۾��� ������Ƹ�", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "�̱۾��� �������ĵ�", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "�̱۾��� ����ġ�κ�", 150, 0, 0, 30, 30, 0, 0, 2, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "�̱۾��� ����ż���", 150, 0, 30, 0, 30, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "�̱۾��� ��������Ʈ", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));

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


        shirtList.Add(new Item(ItemType.Shirt, "���׸��� ����Ʈ�Ƹ�", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "���׸��� ��ó�ĵ�", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "���׸��� �������κ�", 250, 0, 0, 50, 50, 0, 0, 6, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "���׸��� ��������", 250, 0, 50, 0, 50, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        shirtList.Add(new Item(ItemType.Shirt, "���׸��� ���̷���Ʈ", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));


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



        #region 9.����
        t = 0;

        pantsList.Add(new Item(ItemType.Pants, "Ʈ������ ����������", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "Ʈ������ ����������", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "Ʈ������ ����ġ����", 150, 0, 0, 30, 30, 0, 0, 2, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "Ʈ������ ���������", 150, 0, 30, 0, 30, 0, 2, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "Ʈ������ ����������", 150, 30, 30, 0, 0, 0, 2, 0, 0, 5, 0, 0, 8, 10));

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


        pantsList.Add(new Item(ItemType.Pants, "���׸��� ����Ʈ����", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "���׸��� ��ó����", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "���׸��� ����������", 250, 0, 0, 50, 50, 0, 0, 6, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "���׸��� ��������", 250, 0, 50, 0, 50, 0, 6, 0, 0, 5, 0, 0, 8, 10));
        pantsList.Add(new Item(ItemType.Pants, "���׸��� ���̷�����", 250, 50, 50, 0, 0, 0, 6, 0, 0, 5, 0, 0, 8, 10));

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



        #region 10.�Ź�
        t = 0;

        shoesList.Add(new Item(ItemType.Shoes, "�ۼַ��� ����Ʈ����", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�ۼַ��� ��ó����", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�ۼַ��� ����������", 160, 0, 0, 20, 20, 0, 0, 5, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�ۼַ��� ��������", 160, 0, 20, 0, 20, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�ۼַ��� ���̷�����", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));


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




        shoesList.Add(new Item(ItemType.Shoes, "�����μ��̵� ����Ʈ����", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�����μ��̵� ��ó����", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�����μ��̵� ����������", 200, 0, 0, 40, 40, 0, 0, 9, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�����μ��̵� ��������", 200, 0, 40, 0, 40, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        shoesList.Add(new Item(ItemType.Shoes, "�����μ��̵� ���̷�����", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));

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



        shoesList.Add(new Item(ItemType.Shoes, "Ÿ�Ϸ�Ʈ ���Ƶ��� ����", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "Ÿ�Ϸ�Ʈ ���̷� ����", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "Ÿ�Ϸ�Ʈ �츣�޽� ����", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "Ÿ�Ϸ�Ʈ ��ī�� ����", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        shoesList.Add(new Item(ItemType.Shoes, "Ÿ�Ϸ�Ʈ ���׾� ����", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));

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



        #region 11.�Ͱ�
        t = 0;

        earringList.Add(new Item(ItemType.Earring, "���� �̾", 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 999));
        earringList[t++].isNormalAdditional = true;
        earringList.Add(new Item(ItemType.Earring, "���� �õν� �̾", 130, 5, 5, 5, 5, 0, 2, 2, 0, 0, 0, 0, 7, 10));
        earringList[t++].setName = SetName.BossTrinket;
        earringList.Add(new Item(ItemType.Earring, "������ �Ҳ�", 130, 7, 7, 7, 7, 100, 2, 2, 0, 0, 0, 0, 6, 10));
        earringList[t].setName = SetName.BossTrinket;
        earringList[t++].basicMaxMP = 100;
        earringList.Add(new Item(ItemType.Earring, "��Į�� �̾", 135, 6, 6, 6, 6, 200, 3, 3, 0, 0, 0, 0, 7, 10));
        earringList[t].isLucky = true;
        earringList[t++].basicMaxMP = 200;
        earringList.Add(new Item(ItemType.Earring, "���� �̾", 140, 5, 5, 5, 5, 150, 0, 0, 0, 0, 0, 0, 7, 10));
        earringList[t++].basicMaxMP = 150;
        earringList.Add(new Item(ItemType.Earring, "���̽��� �̾", 140, 5, 5, 5, 5, 500, 4, 4, 0, 0, 0, 0, 7, 10));
        earringList[t].setName = SetName.Meister;
        earringList[t++].basicMaxMP = 500;
        earringList.Add(new Item(ItemType.Earring, "���� �۷ο� �̾", 150, 7, 7, 7, 7, 750, 5, 5, 0, 0, 0, 0, 8, 10));
        earringList[t++].basicMaxMP = 750;
        earringList.Add(new Item(ItemType.Earring, "�����ڶ� �̾", 160, 7, 7, 7, 7, 300, 2, 2, 0, 0, 0, 0, 7, 10));
        earringList[t].setName = SetName.DawnBoss;
        earringList[t++].basicMaxMP = 300;
        earringList.Add(new Item(ItemType.Earring, "Ŀ�Ǵ� ���� �̾", 200, 7, 7, 7, 7, 500, 5, 5, 0, 0, 0, 0, 7, 5));
        earringList[t].setName = SetName.BlackBossTrinket;
        earringList[t++].basicMaxMP = 500;


        #endregion



        #region 12.������
        t = 0;

        shoulderList.Add(new Item(ItemType.Shoulder, "�ξ� ����Ż ���", 120, 10, 10, 10, 10, 0, 6, 6, 0, 0, 0, 0, 2, 0));
        shoulderList[t++].setName = SetName.BossTrinket;
        shoulderList.Add(new Item(ItemType.Shoulder, "��Į�� ���", 135, 12, 12, 12, 12, 400, 7, 7, 0, 0, 0, 0, 2, 10));
        shoulderList[t].isLucky = true;
        shoulderList[t++].isAdditionalOption = true;
        shoulderList.Add(new Item(ItemType.Shoulder, "���̽��� ���", 140, 13, 13, 13, 13, 0, 9, 9, 0, 0, 0, 0, 2, 99));
        shoulderList[t++].setName = SetName.Meister;

        shoulderList.Add(new Item(ItemType.Shoulder, "�ۼַ��� ����Ʈ���", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�ۼַ��� ��ó���", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�ۼַ��� ���������", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�ۼַ��� �������", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�ۼַ��� ���̷����", 160, 14, 14, 14, 14, 0, 10, 10, 0, 0, 0, 0, 2, 99));

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



        shoulderList.Add(new Item(ItemType.Shoulder, "�����μ��̵� ����Ʈ���", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�����μ��̵� ��ó���", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�����μ��̵� ���������", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�����μ��̵� �������", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "�����μ��̵� ���̷����", 200, 35, 35, 35, 35, 0, 20, 20, 0, 0, 0, 0, 2, 99));

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




        shoulderList.Add(new Item(ItemType.Shoulder, "���׸��� ����Ʈ���", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "���׸��� ��ó���", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "���׸��� ���������", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "���׸��� �������", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));
        shoulderList.Add(new Item(ItemType.Shoulder, "���׸��� ���̷����", 250, 51, 51, 51, 51, 0, 28, 28, 0, 0, 0, 0, 2, 99));

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



        #region 13.�尩
        t = 0;

        glovesList.Add(new Item(ItemType.Gloves, "�ۼַ��� ����Ʈ�۷���", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�ۼַ��� ��ó�۷���", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�ۼַ��� �������۷���", 160, 0, 0, 20, 20, 0, 0, 5, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�ۼַ��� �����۷���", 160, 0, 20, 0, 20, 0, 5, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�ۼַ��� ���̷��۷���", 160, 20, 20, 0, 0, 0, 5, 0, 0, 0, 0, 0, 8, 10));

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



        glovesList.Add(new Item(ItemType.Gloves, "�����μ��̵� ����Ʈ�۷���", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�����μ��̵� ��ó�۷���", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�����μ��̵� �������۷���", 200, 0, 0, 40, 40, 0, 0, 9, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�����μ��̵� �����۷���", 200, 0, 40, 0, 40, 0, 9, 0, 0, 0, 0, 0, 8, 10));
        glovesList.Add(new Item(ItemType.Gloves, "�����μ��̵� ���̷��۷���", 200, 40, 40, 0, 0, 0, 9, 0, 0, 0, 0, 0, 8, 10));

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


        glovesList.Add(new Item(ItemType.Gloves, "Ÿ�Ϸ�Ʈ ���Ƶ��� �۷���", 150, 12, 12, 0, 0, 300, 15, 0, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "Ÿ�Ϸ�Ʈ ���̷� �۷���", 150, 12, 12, 0, 0, 300, 15, 0, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "Ÿ�Ϸ�Ʈ �츣�޽� �۷���", 150, 0, 0, 12, 12, 0, 0, 15, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "Ÿ�Ϸ�Ʈ ��ī�� �۷���", 150, 0, 12, 0, 12, 300, 15, 0, 0, 0, 0, 0, 3, 10));
        glovesList.Add(new Item(ItemType.Gloves, "Ÿ�Ϸ�Ʈ ���׾� �۷���", 150, 12, 12, 0, 0, 300, 15, 0, 0, 0, 0, 0, 3, 10));

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



        #region 14.�ȵ���̵�
        t = 0;

        androidList.Add(new Item(ItemType.Android, "�������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "��Ʈ�� ���̾ȷ��̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "��Ʈ�� �˸������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "��Ʈ�� ��õ���̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�ҷ�Ĺ���̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "���� ���ɷ��̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "��Ű���̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "���׷��̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "������ɷ��̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "���۽�Ÿ ��ũ����̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "���� ������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "���ڶ���̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�Ʊ� �������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�Ʊ� �������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�̽��� �̱״ϼǷ��̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "DJ ���������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�����̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "������̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "�׿� ���ǰָ����̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        androidList.Add(new Item(ItemType.Android, "ī�����̵�", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        t++;
        #endregion



        #region 15.����
        t = 0;

        emblemList.Add(new Item(ItemType.Emblem, "��� �����ø��� ����(���谡)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "��� �ñ׳ʽ� ����(�ñ׳ʽ�)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "��� ���������� ����(����������)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "��� ���� ����(����)", 100, 10, 10, 10, 10, 500, 2, 2, 0, 0, 0, 0, 0, -1));
        t++;
        emblemList.Add(new Item(ItemType.Emblem, "���̺긮�� ��Ʈ(����)", 100, 0, 0, 0, 0, 300, 2, 2, 0, 0, 0, 0, 0, 999));
        emblemList[t].reqClassGroup = CharacterClassGroup.Hybrid;
        emblemList[t++].basicMaxMP = 100;
        emblemList.Add(new Item(ItemType.Emblem, "��� ������� ����(�ƶ�)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "��� ������� ����(����)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "��� ������� ����(��̳ʽ�)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "��� ������� ����(�޸�������)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        emblemList.Add(new Item(ItemType.Emblem, "��� ������� ����(����)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "��� ������� ����(����)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        emblemList.Add(new Item(ItemType.Emblem, "�巡�� ����(ī����)", 100, 10, 10, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 999));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "��� ������Ʈ ����(ī����)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "���� ����(������������)", 100, 10, 10, 0, 0, 400, 2, 2, 0, 0, 0, 0, 0, 999));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        emblemList.Add(new Item(ItemType.Emblem, "��� ����Ʈ ����(�Ƶ�)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "��� ũ����Ż ����(�ϸ���)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "��� ü�̼� ����(Į��)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "��� ��� ����(��ũ)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        emblemList.Add(new Item(ItemType.Emblem, "�ݺ� ǳ���� ����(���)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "�ݺ� õ���� ����(ȣ��)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "���ͳ� Ÿ�� ����(����)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "��� Ű�׽ý� ����(Ű�׽ý�)", 100, 10, 10, 10, 10, 0, 2, 2, 0, 0, 0, 0, 0, -1));
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;

        emblemList.Add(new Item(ItemType.Emblem, "��Ʈ���� �г� - ����", 200, 40, 40, 0, 0, 700, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        emblemList.Add(new Item(ItemType.Emblem, "��Ʈ���� �г� - ������", 200, 0, 0, 40, 40, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Magician;
        emblemList.Add(new Item(ItemType.Emblem, "��Ʈ���� �г� - �ü�", 200, 40, 40, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        emblemList.Add(new Item(ItemType.Emblem, "��Ʈ���� �г� - ����", 200, 0, 40, 0, 40, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Thief;
        emblemList.Add(new Item(ItemType.Emblem, "��Ʈ���� �г� - ����", 200, 40, 40, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        emblemList[t].setName = SetName.BlackBossTrinket;
        emblemList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        #endregion



        #region 16.����
        t = 0;

        badgeList.Add(new Item(ItemType.Badge, "ĥ���� ����", 100, 7, 7, 7, 7, 0, 7, 7, 0, 10, 0, 0, 0, -1));
        badgeList[t++].setName = SetName.SevenDays;
        badgeList.Add(new Item(ItemType.Badge, "ũ����Ż ������ ����", 130, 10, 10, 10, 10, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        badgeList[t++].setName = SetName.BossTrinket;
        badgeList.Add(new Item(ItemType.Badge, "â���� ����", 200, 15, 15, 15, 15, 0, 10, 10, 0, 10, 0, 0, 0, 0));
        badgeList[t++].setName = SetName.BlackBossTrinket;

        #endregion



        #region 17.����
        t = 0;

        medalList.Add(new Item(ItemType.Medal, "ĥ���� ������Ŀ", 100, 7, 7, 7, 7, 0, 7, 7, 0, 10, 0, 0, 0, -1));
        medalList[t++].setName = SetName.SevenDays;
        medalList.Add(new Item(ItemType.Medal, "���ν� ç����", 110, 10, 10, 10, 10, 300, 10, 10, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 300;
        medalList.Add(new Item(ItemType.Medal, "�������� ģ��", 0, 10, 10, 10, 10, 500, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 500;
        medalList.Add(new Item(ItemType.Medal, "������ ģ��", 0, 15, 15, 15, 15, 1000, 5, 5, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "ī���� ���� ų��", 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "�츣�� ���Ŀ�", 100, 7, 7, 7, 7, 0, 7, 7, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "���� ��Ʈ�� ������", 100, 8, 8, 8, 8, 0, 8, 8, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "�츣�� SSS �÷���", 100, 7, 7, 7, 7, 0, 7, 7, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "�츣�� SSS ���� �÷���", 100, 8, 8, 8, 8, 0, 8, 8, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "�Ǹ��� ���� ������", 200, 15, 15, 15, 15, 1000, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "������ ��մ� ��", 200, 15, 15, 15, 15, 1000, 4, 4, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "�̱��� ���̸� �ƴ� ��", 200, 15, 15, 15, 15, 1000, 5, 5, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "�����̾� PC��", 0, 8, 8, 8, 8, 300, 10, 10, 0, 0, 0, 0, 0, -1));
        medalList[t].starforce = 15;
        medalList[t].arc = 30;
        medalList[t++].basicMaxMP = 300;
        medalList.Add(new Item(ItemType.Medal, "�� �� �� ���", 0, 3, 3, 3, 3, 0, 3, 3, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "�� �� �� ���̾�", 0, 5, 5, 5, 5, 500, 5, 5, 5, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 500;
        medalList.Add(new Item(ItemType.Medal, "�� �� �� ����", 0, 7, 7, 7, 7, 700, 7, 7, 5, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 700;
        medalList.Add(new Item(ItemType.Medal, "���¾� ��Ű���̡�", 10, 5, 5, 5, 5, 300, 5, 5, 0, 0, 0, 0, 0, 0));
        medalList[t++].basicMaxMP = 300;
        medalList.Add(new Item(ItemType.Medal, "�ڡ�13���� ���ڡ�", 13, 13, 13, 13, 13, 0, 13, 13, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "��15���� ������", 0, 15, 15, 15, 15, 750, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 750;
        medalList.Add(new Item(ItemType.Medal, "BURNING", 0, 5, 5, 5, 5, 250, 1, 1, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 250;
        medalList.Add(new Item(ItemType.Medal, "�ڳ��� �ٷ� ���߾ˡ�", 0, 5, 5, 5, 5, 0, 5, 5, 0, 0, 0, 0, 0, -1));
        t++;
        medalList.Add(new Item(ItemType.Medal, "��Ʈ�� �����", 0, 16, 16, 16, 16, 750, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 750;
        medalList.Add(new Item(ItemType.Medal, "ȣ�� ������ VIP ���", 0, 17, 17, 17, 17, 850, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 850;
        medalList.Add(new Item(ItemType.Medal, "������", 0, 6, 6, 6, 6, 613, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 613;
        medalList.Add(new Item(ItemType.Medal, "������ �����â�", 0, 18, 18, 18, 18, 950, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 950;
        medalList.Add(new Item(ItemType.Medal, "�������� ���Ʈ����", 0, 19, 19, 19, 19, 950, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 950;
        medalList.Add(new Item(ItemType.Medal, "�� õ��", 0, 12, 12, 12, 12, 1204, 4, 4, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1204;
        medalList.Add(new Item(ItemType.Medal, "�� �Ǹ�", 0, 12, 12, 12, 12, 1204, 4, 4, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1204;
        medalList.Add(new Item(ItemType.Medal, "BLACK", 0, 6, 6, 6, 6, 808, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 808;
        medalList.Add(new Item(ItemType.Medal, "PINK", 0, 6, 6, 6, 6, 808, 3, 3, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 808;
        medalList.Add(new Item(ItemType.Medal, "�ٸ������� ���Ϸ����", 0, 20, 20, 20, 20, 1000, 7, 7, 0, 0, 0, 0, 0, -1));
        medalList[t++].basicMaxMP = 1000;
        medalList.Add(new Item(ItemType.Medal, "HYPER BURNING", 200, 6, 6, 6, 6, 0, 6, 6, 0, 0, 0, 0, 0, -1));
        t++;

        #endregion



        #region 18.��������
        t = 0;

        // �����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "���� �޴�", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ���� �޴�", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �޴�", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� �޴�", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // �ȶ��
        subWeaponList.Add(new Item(ItemType.SubWeapon, "����ũ���� ���ڸ���", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ����ũ���� ���ڸ���", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���ڸ���", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ���ڸ���", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // ��ũ����Ʈ
        subWeaponList.Add(new Item(ItemType.SubWeapon, "����ũ ü��", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ����ũ ü��", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ü��", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ü��", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // ����(����)
        subWeaponList.Add(new Item(ItemType.Shield, "���̸� ������ �ǵ�", 130, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // ��ũ������(��,��)
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ �� (����)", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ������ �� (����)", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ �� (��)", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ �� (������ Ʈ����)", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ��ũ������(��,��)
        subWeaponList.Add(new Item(ItemType.SubWeapon, "û���� �� (����)", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� û���� �� (����)", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "û���� �� (��)", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "û���� �� (������ Ʈ����)", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ���
        subWeaponList.Add(new Item(ItemType.SubWeapon, "����� �� (����)", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ����� �� (����)", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "����� �� (��)", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "����� �� (������ Ʈ����)", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ����(������)
        subWeaponList.Add(new Item(ItemType.Shield, "Ÿ�Ӹ��� ��������", 120, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList.Add(new Item(ItemType.Shield, "�Ǿ�� ��������", 125, 0, 0, 10, 5, 0, 0, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Shield, "���̸� ������ �ǵ�", 130, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ���츶����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "���Ʈ ���", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ���Ʈ ���", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ���", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // �ű�
        subWeaponList.Add(new Item(ItemType.SubWeapon, "��������", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ��������", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ��������", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ��������", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // �н����δ�
        subWeaponList.Add(new Item(ItemType.SubWeapon, "����Ʈ ����", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ����Ʈ ����", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ����", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // ����Ʈ�ε�
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�Ļ��", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� �Ļ��", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �Ļ��", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� �Ļ��", 110, 0, 9, 0, 9, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // ������
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ ������", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ������ ������", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ������", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ������", 110, 0, 9, 0, 9, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // �����̵�
        subWeaponList.Add(new Item(ItemType.Blade, "�����ϸ� ���ǵ忧��", 150, 0, 0, 0, 30, 0, 81, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Blade, "�ۼַ��� ���̵�", 160, 0, 0, 0, 40, 0, 97, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Blade, "�����μ��̵� ���̵�", 200, 0, 0, 0, 65, 0, 140, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // ����(����)
        subWeaponList.Add(new Item(ItemType.Shield, "Ÿ�Ӹ��� ����Ʈ", 120, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList.Add(new Item(ItemType.Shield, "�Ǿ�� ����Ʈ", 125, 0, 5, 0, 10, 0, 0, 0, 0, 0, 0, 0, 9, 99));
        subWeaponList.Add(new Item(ItemType.Shield, "���̸� ��ũ�Ͻ� �ǵ�", 130, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 8, 0));
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t].isBasicGrowth = true;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // ������
        subWeaponList.Add(new Item(ItemType.SubWeapon, "����Ʈ �Ƹ�", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ����Ʈ �Ƹ�", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ����Ʈ �Ƹ�", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ����Ʈ�Ƹ�", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // ĸƾ
        subWeaponList.Add(new Item(ItemType.SubWeapon, "���ܾ���", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ���ܾ���", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���ܾ���", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ���ܾ���", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // ĳ����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ �������̾�", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ������ �������̾�", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �������̾�", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� �������̾�", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // �ñ׳ʽ� ����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�������� ����", 100, 10, 10, 10, 10, 0, 3, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� �������� ����", 100, 10, 10, 10, 10, 0, 5, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �������� ����", 100, 8, 8, 8, 8, 0, 5, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� �������� ����", 110, 9, 9, 9, 9, 0, 6, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.NULL;


        // ������
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ �ҿ�ǵ�", 100, 12, 12, 0, 0, 600, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ������ �ҿ�ǵ�", 100, 12, 12, 0, 0, 600, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �ҿ�ǵ�", 100, 10, 10, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� �ҿ�ǵ�", 110, 11, 11, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
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


        // ������
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�ͽ��÷νú� ��(3ȣ)", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� �ͽ��÷νú� ��(3ȣ)", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �ͽ��÷νú� ��", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // ��Ʋ������
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�ƽø����� ��", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� �ƽø����� ��", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �ƽø����� ��", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� �޸�����", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ���ϵ�����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "���ϵ� ��", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ���ϵ� ��", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���ϵ� ��", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ���ϵ��ũ", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // ��ī��
        subWeaponList.Add(new Item(ItemType.SubWeapon, "���ͳ� �ű׳�", 100, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ���ͳ� �ű׳�", 100, 0, 10, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �ű׳�", 100, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� �ű׳�", 110, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // ����
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "������ �����ǵ�", 100, 12, 12, 0, 0, 600, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "������ �����ǵ�(HP)", 100, 12, 0, 0, 0, 700, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "�̺��� ������ �����ǵ�", 100, 12, 12, 0, 0, 600, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "�̺��� ������ �����ǵ�(HP)", 100, 12, 0, 0, 0, 700, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "�� �����ǵ�", 100, 10, 10, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "���� �����ǵ�", 100, 10, 10, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "������ Ʈ���� �����ǵ�", 110, 11, 11, 0, 0, 560, 0, 0, 0, 0, 0, 0, 0, 0));
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


        // ����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "��Ÿ�ھ� ��Ʈ�ѷ�", 100, 2, 2, 2, 2, 900, 0, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ��Ÿ�ھ� ��Ʈ�ѷ�", 100, 2, 2, 2, 2, 900, 2, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ��Ÿ�ھ� ��Ʈ�ѷ�", 100, 2, 2, 2, 2, 800, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ��Ʈ�ѷ�", 110, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t].basicMaxMP = 500;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        subWeaponList[t].basicMaxMP = 500;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        subWeaponList[t].basicMaxMP = 450;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;
        subWeaponList[t].basicMaxMP = 450;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Hybrid;


        // �ƶ�
        subWeaponList.Add(new Item(ItemType.SubWeapon, "õ����", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� õ����", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� õ����", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� õ����", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // ����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�巡�︶������ ����", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� �巡�︶������ ����", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �巡�︶������ ����", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ������ ����", 110, 0, 0, 9, 9, 0, 0, 6, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ��̳ʽ�
        subWeaponList.Add(new Item(ItemType.SubWeapon, "ī���� ����", 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ī���� ����", 100, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ����", 100, 0, 0, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ����", 110, 0, 0, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // �޸�������
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ ���� ȭ��", 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ������ ���� ȭ��", 100, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���� ȭ��", 100, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ����ȭ��", 110, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // ����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�����Ͽ� ī��Ʈ", 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� �����Ͽ� ī��Ʈ", 100, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ī��Ʈ", 100, 0, 8, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ī��Ʈ", 110, 0, 9, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // ����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "Ȳ�ݺ� ���챸��", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� Ȳ�ݺ� ���챸��", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���챸��", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ���� ���챸��", 110, 9, 9, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // ī����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ ����� ����", 100, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ������ ����� ����", 100, 10, 10, 10, 10, 0, 2, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ����� ����", 100, 8, 8, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ Ʈ������ ����", 110, 9, 9, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // ī��
        subWeaponList.Add(new Item(ItemType.SubWeapon, "D100 Ŀ���� ���� ��Ʈ", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� D100 ���� ��Ʈ", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� D100 ���� ��Ʈ", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Bowman;


        // ī����
        subWeaponList.Add(new Item(ItemType.SubWeapon, "Ʈ�������� type_A", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� Ʈ�������� type_A", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� Ʈ��������", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // ������������
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "�׸� �ҿ︵", 100, 10, 10, 10, 10, 900, 0, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "�̺��� �׸� �ҿ︵", 100, 10, 10, 10, 10, 900, 2, 0, 0, 0, 0, 0, 0, -1));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "�� �ҿ︵", 100, 8, 8, 8, 8, 800, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList.Add(new Item(ItemType.SubWeapon2, "������ Ʈ���� �ҿ︵", 110, 9, 9, 9, 9, 800, 0, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // �Ƶ�
        subWeaponList.Add(new Item(ItemType.SubWeapon, "��� �극�̽���", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ��� �극�̽���", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���̴� �극�̽���", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Warrior;


        // �ϸ���
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�۷θ� ������", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� �۷θ� ������", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ������", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // Į��
        subWeaponList.Add(new Item(ItemType.SubWeapon, "���Ǵ�Ʈ ����Ŀ", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ���Ǵ�Ʈ ����Ŀ", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ���Ǵ�Ʈ ����Ŀ", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // ��ũ
        subWeaponList.Add(new Item(ItemType.SubWeapon, "��Ƽ�� �н�", 100, 10, 10, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ��Ƽ�� �н�", 100, 10, 10, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� �н�", 100, 8, 8, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Pirate;


        // ���
        subWeaponList.Add(new Item(ItemType.SubWeapon, "������ ��� �븮��", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ��� �븮��", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� ��� �븮��", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ȣ��
        subWeaponList.Add(new Item(ItemType.SubWeapon, "���弮 ����", 100, 0, 10, 0, 10, 0, 3, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ���弮 ����", 100, 0, 10, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�� Ȳ���� ����", 100, 0, 8, 0, 8, 0, 5, 0, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Thief;


        // Ű�׽ý�
        subWeaponList.Add(new Item(ItemType.SubWeapon, "ü���ǽ� �� ��", 100, 0, 0, 10, 10, 0, 0, 3, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "�̺��� ü���ǽ� �� ��", 100, 0, 0, 10, 10, 0, 0, 5, 0, 0, 0, 0, 0, 999));
        subWeaponList.Add(new Item(ItemType.SubWeapon, "ü���ǽ� �� ��", 100, 0, 0, 8, 8, 0, 0, 5, 0, 0, 0, 0, 0, 0));
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;
        subWeaponList[t++].reqClassGroup = CharacterClassGroup.Magician;


        // ����
        subWeaponList.Add(new Item(ItemType.Lapis, "���ǽ� 7��", 170, 40, 40, 0, 0, 0, 173, 0, 30, 10, 0, 0, 9, -1));
        subWeaponList.Add(new Item(ItemType.Lapis, "���ǽ� 8��", 180, 60, 60, 0, 0, 0, 207, 0, 30, 10, 0, 0, 9, -1));
        subWeaponList.Add(new Item(ItemType.Lapis, "���ǽ� 9��", 200, 100, 100, 0, 0, 0, 297, 0, 30, 20, 0, 0, 9, -1));
        subWeaponList.Add(new Item(ItemType.Lapis, "���׽ý� ���ǽ�", 200, 150, 150, 0, 0, 0, 342, 0, 30, 20, 0, 0, 0, -1));
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



        #region 19.����
        t = 0;

        capeList.Add(new Item(ItemType.Cape, "�ۼַ��� ����Ʈ������", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�ۼַ��� ��ó������", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�ۼַ��� ������������", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�ۼַ��� ����������", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�ۼַ��� ���̷�������", 160, 15, 15, 15, 15, 0, 2, 2, 0, 0, 0, 0, 8, 10));

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



        capeList.Add(new Item(ItemType.Cape, "�����μ��̵� ����Ʈ������", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�����μ��̵� ��ó������", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�����μ��̵� ������������", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�����μ��̵� ����������", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));
        capeList.Add(new Item(ItemType.Cape, "�����μ��̵� ���̷�������", 200, 35, 35, 35, 35, 0, 6, 6, 0, 0, 0, 0, 8, 10));

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




        capeList.Add(new Item(ItemType.Cape, "Ÿ�Ϸ�Ʈ ���Ƶ��� Ŭ��", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "Ÿ�Ϸ�Ʈ ���̷� Ŭ��", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "Ÿ�Ϸ�Ʈ �츣�޽� Ŭ��", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "Ÿ�Ϸ�Ʈ ��ī�� Ŭ��", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));
        capeList.Add(new Item(ItemType.Cape, "Ÿ�Ϸ�Ʈ ���׾� Ŭ��", 150, 50, 50, 50, 50, 0, 30, 30, 0, 0, 0, 0, 3, 10));

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



        #region 20.������
        t = 0;

        heartList.Add(new Item(ItemType.Heart, "�ƴٸ�Ƽ�� ��Ʈ", 30, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 3, 0));
        heartList.Add(new Item(ItemType.Heart, "��� ��Ʈ", 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0));
        heartList.Add(new Item(ItemType.Heart, "��Ƭ ��Ʈ", 30, 3, 3, 3, 3, 50, 0, 0, 0, 0, 0, 0, 8, 0));
        heartList.Add(new Item(ItemType.Heart, "ƼŸ�� ��Ʈ", 100, 3, 3, 3, 3, 50, 0, 0, 0, 0, 0, 0, 10, 0));
        heartList.Add(new Item(ItemType.Heart, "�� ��Ʈ", 100, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 10, 0));
        heartList.Add(new Item(ItemType.Heart, "�������Ż ��Ʈ", 120, 3, 3, 3, 3, 100, 0, 0, 0, 0, 0, 0, 10, 0));
        heartList.Add(new Item(ItemType.Heart, "�� ��Ʈ", 120, 10, 10, 10, 10, 100, 77, 77, 0, 0, 0, 0, 0, -1));


        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;
        heartList[t++].isAdditionalOption = false;


        heartList[t].setName = SetName.BlackBossTrinket;
        heartList[t].upPotentialGrade = OptionGrade.Epic;
        heartList[t].upPotential1 = "���� ���� ���� �� ������ : +30%";
        heartList[t].upPotential2 = "���� ����� ���� : +30%";
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
    // �䱸 ����
    public ItemType type;
    public string name;
    public int reqLev;
    public CharacterClassGroup reqClassGroup;
    public CharacterClass reqClass;
    // (�⺻ �ɼ�, �߰� �ɼ�, �ֹ��� �ɼ�, ��ȭ �ɼ�)
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
     * ���� ��ȯ ����, (����)1ȸ ��ȯ ����, ������ ��ȯ �Ұ�, ��ȯ �Ұ�
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
                str += "���ݷ� : +";
                break;
            case PotentialOption.MAG:
                str += "���� : +";
                break;
            case PotentialOption.CriticalPct:
                str += "ũ��Ƽ�� Ȯ�� : +";
                break;
            case PotentialOption.CriticalDamage:
                str += "ũ��Ƽ�� ������ : +";
                break;
            case PotentialOption.Damage:
                str += "������ : +";
                break;
            case PotentialOption.AllStats:
                str += "�ý��� : +";
                break;
            case PotentialOption.IgnoreDF:
                str += "���� ����� ���� : +";
                break;
            case PotentialOption.BossATK:
                str += "���� ���� ���� �� ������ : +";
                break;
            case PotentialOption.CooldownReduction:
                return "��� ��ų�� ���� ���ð� : -" + potentialValue.ToString() + "��(10�� ���ϴ� 5%����, 5�� �̸����� ���� �Ұ�)";
            case PotentialOption.MesoAcquiredRate:
                str += "�޼� ȹ�淮 : +";
                break;
            case PotentialOption.ItemDropRate:
                str += "������ ��ӷ� : +";
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