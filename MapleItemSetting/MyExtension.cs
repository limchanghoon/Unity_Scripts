using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtension
{
    public static string ToFriendlyString(this ItemType _itemType)
    {
        switch (_itemType)
        {
            case ItemType.Ring:
                return "����";
            case ItemType.Pocket:
                return "���� ������";
            case ItemType.Pendant:
                return "���Ʈ";
            case ItemType.Weapon:
                return "����";
            case ItemType.Belt:
                return "��Ʈ";
            case ItemType.Helmet:
                return "����";
            case ItemType.Face:
                return "�����";
            case ItemType.Eye:
                return "�����";
            case ItemType.Shirt:
                return "����";
            case ItemType.Pants:
                return "����";
            case ItemType.Shoes:
                return "�Ź�";
            case ItemType.Earring:
                return "�Ͱ�";
            case ItemType.Shoulder:
                return "������";
            case ItemType.Gloves:
                return "�尩";
            case ItemType.Android:
                return "�ȵ���̵�";
            case ItemType.Emblem:
                return "����";
            case ItemType.Badge:
                return "����";
            case ItemType.Medal:
                return "����";
            case ItemType.SubWeapon:
                return "��������";
            case ItemType.Cape:
                return "����";
            case ItemType.Heart:
                return "������";
            case ItemType.Blade:
                return "���̵�";
            case ItemType.Lapis:
                return "���ǽ�";
            case ItemType.Shield:
                return "����";
            case ItemType.ShirtAndPants:
                return "�ѹ���";
            case ItemType.SubWeapon2:
                return "��������";
            default:
                return "NULL";
        }
    }

    public static string ToFriendlyString(this CharacterClassGroup _characterClassGroup)
    {
        if (_characterClassGroup == CharacterClassGroup.NULL)
            return "����";
        else if (_characterClassGroup == CharacterClassGroup.Warrior)
            return "����";
        else if (_characterClassGroup == CharacterClassGroup.Bowman)
            return "�ü�";
        else if (_characterClassGroup == CharacterClassGroup.Magician)
            return "������";
        else if (_characterClassGroup == CharacterClassGroup.Thief)
            return "����";
        else if (_characterClassGroup == CharacterClassGroup.Pirate)
            return "����";
        else if (_characterClassGroup == CharacterClassGroup.Hybrid)
            return "����(����/����)";
        else
            return "NULL";
    }

    public static string ToFriendlyString(this CharacterClass _characterClass)
    {
        if (_characterClass == CharacterClass.Hero)
            return "�����";
        else if (_characterClass == CharacterClass.Paladin)
            return "�ȶ��";
        else if (_characterClass == CharacterClass.DarkKnight)
            return "��ũ����Ʈ";
        else if (_characterClass == CharacterClass.SoulMaster)
            return "�ҿ︶����";
        else if (_characterClass == CharacterClass.Mihile)
            return "������";
        else if (_characterClass == CharacterClass.Blaster)
            return "������";
        else if (_characterClass == CharacterClass.DemonSlayer)
            return "���󽽷��̾�";
        else if (_characterClass == CharacterClass.DemonAvenger)
            return "������";
        else if (_characterClass == CharacterClass.Aran)
            return "�ƶ�";
        else if (_characterClass == CharacterClass.Kaiser)
            return "ī����";
        else if (_characterClass == CharacterClass.Adele)
            return "�Ƶ�";
        else if (_characterClass == CharacterClass.Zero)
            return "����";

        else if (_characterClass == CharacterClass.ArchMage_FP)
            return "��ũ������(��,��)";
        else if (_characterClass == CharacterClass.ArchMage_IL)
            return "��ũ������(��,��)";
        else if (_characterClass == CharacterClass.Bishop)
            return "���";
        else if (_characterClass == CharacterClass.FlameWizard)
            return "�÷������ڵ�";
        else if (_characterClass == CharacterClass.BattleMage)
            return "��Ʋ������";
        else if (_characterClass == CharacterClass.Evan)
            return "����";
        else if (_characterClass == CharacterClass.Luminous)
            return "��̳ʽ�";
        else if (_characterClass == CharacterClass.Illium)
            return "�ϸ���";
        else if (_characterClass == CharacterClass.Lara)
            return "���";
        else if (_characterClass == CharacterClass.Kinesis)
            return "Ű�׽ý�";

        else if (_characterClass == CharacterClass.Bowmaster)
            return "���츶����";
        else if (_characterClass == CharacterClass.Marksman)
            return "�ű�";
        else if (_characterClass == CharacterClass.Pathfinder)
            return "�н����δ�";
        else if (_characterClass == CharacterClass.WindBreaker)
            return "����극��Ŀ";
        else if (_characterClass == CharacterClass.WildHunter)
            return "���ϵ�����";
        else if (_characterClass == CharacterClass.Mercedes)
            return "�޸�������";
        else if (_characterClass == CharacterClass.Kain)
            return "ī��";

        else if (_characterClass == CharacterClass.NightLord)
            return "����Ʈ�ε�";
        else if (_characterClass == CharacterClass.Shadower)
            return "������";
        else if (_characterClass == CharacterClass.DualBlade)
            return "�����̵�";
        else if (_characterClass == CharacterClass.NightWalker)
            return "����Ʈ��Ŀ";
        else if (_characterClass == CharacterClass.Phantom)
            return "����";
        else if (_characterClass == CharacterClass.Cadena)
            return "ī����";
        else if (_characterClass == CharacterClass.Khali)
            return "Į��";
        else if (_characterClass == CharacterClass.HoYoung)
            return "ȣ��";

        else if (_characterClass == CharacterClass.Viper)
            return "������";
        else if (_characterClass == CharacterClass.Captain)
            return "ĸƾ";
        else if (_characterClass == CharacterClass.CannonShooter)
            return "ĳ����";
        else if (_characterClass == CharacterClass.Striker)
            return "��Ʈ����Ŀ";
        else if (_characterClass == CharacterClass.Mechanic)
            return "��ī��";
        else if (_characterClass == CharacterClass.Eunwol)
            return "����";
        else if (_characterClass == CharacterClass.AngelicBuster)
            return "������������";
        else if (_characterClass == CharacterClass.Ark)
            return "��ũ";

        else if (_characterClass == CharacterClass.Xenon)
            return "����";

        else
            return "NULL";
    }

    public static string ToFriendlyString(this OptionGrade _optionGrade)
    {
        if (_optionGrade == OptionGrade.None)
            return "����ɷ� ����";
        else if (_optionGrade == OptionGrade.Rare)
            return "����";
        else if (_optionGrade == OptionGrade.Epic)
            return "����";
        else if (_optionGrade == OptionGrade.Unique)
            return "����ũ";
        else if (_optionGrade == OptionGrade.Legendary)
            return "��������";
        else
            return "NULL";
    }

    public static string ToFriendlyString(this SetName _setName)
    {
        if (_setName == SetName.NULL)
            return "NULL";
        else if (_setName == SetName.BossTrinket)
            return "���� ��ű� ��Ʈ";
        else if (_setName == SetName.DawnBoss)
            return "������ ���� ��Ʈ";
        else if (_setName == SetName.BlackBossTrinket)
            return "ĥ���� ���� ��Ʈ";
        else if (_setName == SetName.SevenDays)
            return "ĥ�� ��Ʈ";
        else if (_setName == SetName.Meister)
            return "���̽��� ��Ʈ";
        else if (_setName == SetName.ImmortalHero)
            return "�Ӹ�Ż ����� ��Ʈ";
        else if (_setName == SetName.ImmortalMeisterHero)
            return "�Ӹ�Ż ���̽��� ����� ��Ʈ";
        else if (_setName == SetName.EternalHero)
            return "���ͳ� ����� ��Ʈ";
        else if (_setName == SetName.EternalMeisterHero)
            return "���ͳ� ���̽��� ����� ��Ʈ";

        else if (_setName == SetName.Rootabis_Warrior)
            return "��Ÿ�� ��Ʈ(����)";
        else if (_setName == SetName.Rootabis_Magician)
            return "��Ÿ�� ��Ʈ(������)";
        else if (_setName == SetName.Rootabis_Bowman)
            return "��Ÿ�� ��Ʈ(�ü�)";
        else if (_setName == SetName.Rootabis_Thief)
            return "��Ÿ�� ��Ʈ(����)";
        else if (_setName == SetName.Rootabis_Pirate)
            return "��Ÿ�� ��Ʈ(����)";

        else if (_setName == SetName.Absolute_Warrior)
            return "�ۼַ��� ��Ʈ(����)";
        else if (_setName == SetName.Absolute_Magician)
            return "�ۼַ��� ��Ʈ(������)";
        else if (_setName == SetName.Absolute_Bowman)
            return "�ۼַ��� ��Ʈ(�ü�)";
        else if (_setName == SetName.Absolute_Thief)
            return "�ۼַ��� ��Ʈ(����)";
        else if (_setName == SetName.Absolute_Pirate)
            return "�ۼַ��� ��Ʈ(����)";

        else if (_setName == SetName.Arcane_Warrior)
            return "�����μ��̵� ��Ʈ(����)";
        else if (_setName == SetName.Arcane_Magician)
            return "�����μ��̵� ��Ʈ(������)";
        else if (_setName == SetName.Arcane_Bowman)
            return "�����μ��̵� ��Ʈ(�ü�)";
        else if (_setName == SetName.Arcane_Thief)
            return "�����μ��̵� ��Ʈ(����)";
        else if (_setName == SetName.Arcane_Pirate)
            return "�����μ��̵� ��Ʈ(����)";

        else if (_setName == SetName.Eternel_Warrior)
            return "���׸��� ��Ʈ(����)";
        else if (_setName == SetName.Eternel_Magician)
            return "���׸��� ��Ʈ(������)";
        else if (_setName == SetName.Eternel_Bowman)
            return "���׸��� ��Ʈ(�ü�)";
        else if (_setName == SetName.Eternel_Thief)
            return "���׸��� ��Ʈ(����)";
        else if (_setName == SetName.Eternel_Pirate)
            return "���׸��� ��Ʈ(����)";

        else
            return "NULL";
    }
}
