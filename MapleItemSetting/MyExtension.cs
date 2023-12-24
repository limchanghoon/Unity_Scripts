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
                return "반지";
            case ItemType.Pocket:
                return "포켓 아이템";
            case ItemType.Pendant:
                return "펜던트";
            case ItemType.Weapon:
                return "무기";
            case ItemType.Belt:
                return "벨트";
            case ItemType.Helmet:
                return "모자";
            case ItemType.Face:
                return "얼굴장식";
            case ItemType.Eye:
                return "눈장식";
            case ItemType.Shirt:
                return "상의";
            case ItemType.Pants:
                return "하의";
            case ItemType.Shoes:
                return "신발";
            case ItemType.Earring:
                return "귀고리";
            case ItemType.Shoulder:
                return "어깨장식";
            case ItemType.Gloves:
                return "장갑";
            case ItemType.Android:
                return "안드로이드";
            case ItemType.Emblem:
                return "엠블렘";
            case ItemType.Badge:
                return "뱃지";
            case ItemType.Medal:
                return "훈장";
            case ItemType.SubWeapon:
                return "보조무기";
            case ItemType.Cape:
                return "망토";
            case ItemType.Heart:
                return "기계심장";
            case ItemType.Blade:
                return "블레이드";
            case ItemType.Lapis:
                return "라피스";
            case ItemType.Shield:
                return "방패";
            case ItemType.ShirtAndPants:
                return "한벌옷";
            case ItemType.SubWeapon2:
                return "보조무기";
            default:
                return "NULL";
        }
    }

    public static string ToFriendlyString(this CharacterClassGroup _characterClassGroup)
    {
        if (_characterClassGroup == CharacterClassGroup.NULL)
            return "공용";
        else if (_characterClassGroup == CharacterClassGroup.Warrior)
            return "전사";
        else if (_characterClassGroup == CharacterClassGroup.Bowman)
            return "궁수";
        else if (_characterClassGroup == CharacterClassGroup.Magician)
            return "마법사";
        else if (_characterClassGroup == CharacterClassGroup.Thief)
            return "도적";
        else if (_characterClassGroup == CharacterClassGroup.Pirate)
            return "해적";
        else if (_characterClassGroup == CharacterClassGroup.Hybrid)
            return "제논(도적/해적)";
        else
            return "NULL";
    }

    public static string ToFriendlyString(this CharacterClass _characterClass)
    {
        if (_characterClass == CharacterClass.Hero)
            return "히어로";
        else if (_characterClass == CharacterClass.Paladin)
            return "팔라딘";
        else if (_characterClass == CharacterClass.DarkKnight)
            return "다크나이트";
        else if (_characterClass == CharacterClass.SoulMaster)
            return "소울마스터";
        else if (_characterClass == CharacterClass.Mihile)
            return "미하일";
        else if (_characterClass == CharacterClass.Blaster)
            return "블래스터";
        else if (_characterClass == CharacterClass.DemonSlayer)
            return "데몬슬레이어";
        else if (_characterClass == CharacterClass.DemonAvenger)
            return "데몬어벤져";
        else if (_characterClass == CharacterClass.Aran)
            return "아란";
        else if (_characterClass == CharacterClass.Kaiser)
            return "카이저";
        else if (_characterClass == CharacterClass.Adele)
            return "아델";
        else if (_characterClass == CharacterClass.Zero)
            return "제로";

        else if (_characterClass == CharacterClass.ArchMage_FP)
            return "아크메이지(불,독)";
        else if (_characterClass == CharacterClass.ArchMage_IL)
            return "아크메이지(썬,콜)";
        else if (_characterClass == CharacterClass.Bishop)
            return "비숍";
        else if (_characterClass == CharacterClass.FlameWizard)
            return "플레임위자드";
        else if (_characterClass == CharacterClass.BattleMage)
            return "배틀메이지";
        else if (_characterClass == CharacterClass.Evan)
            return "에반";
        else if (_characterClass == CharacterClass.Luminous)
            return "루미너스";
        else if (_characterClass == CharacterClass.Illium)
            return "일리움";
        else if (_characterClass == CharacterClass.Lara)
            return "라라";
        else if (_characterClass == CharacterClass.Kinesis)
            return "키네시스";

        else if (_characterClass == CharacterClass.Bowmaster)
            return "보우마스터";
        else if (_characterClass == CharacterClass.Marksman)
            return "신궁";
        else if (_characterClass == CharacterClass.Pathfinder)
            return "패스파인더";
        else if (_characterClass == CharacterClass.WindBreaker)
            return "윈드브레이커";
        else if (_characterClass == CharacterClass.WildHunter)
            return "와일드헌터";
        else if (_characterClass == CharacterClass.Mercedes)
            return "메르세데스";
        else if (_characterClass == CharacterClass.Kain)
            return "카인";

        else if (_characterClass == CharacterClass.NightLord)
            return "나이트로드";
        else if (_characterClass == CharacterClass.Shadower)
            return "섀도어";
        else if (_characterClass == CharacterClass.DualBlade)
            return "듀얼블레이드";
        else if (_characterClass == CharacterClass.NightWalker)
            return "나이트워커";
        else if (_characterClass == CharacterClass.Phantom)
            return "팬텀";
        else if (_characterClass == CharacterClass.Cadena)
            return "카데나";
        else if (_characterClass == CharacterClass.Khali)
            return "칼리";
        else if (_characterClass == CharacterClass.HoYoung)
            return "호영";

        else if (_characterClass == CharacterClass.Viper)
            return "바이퍼";
        else if (_characterClass == CharacterClass.Captain)
            return "캡틴";
        else if (_characterClass == CharacterClass.CannonShooter)
            return "캐논슈터";
        else if (_characterClass == CharacterClass.Striker)
            return "스트라이커";
        else if (_characterClass == CharacterClass.Mechanic)
            return "메카닉";
        else if (_characterClass == CharacterClass.Eunwol)
            return "은월";
        else if (_characterClass == CharacterClass.AngelicBuster)
            return "엔젤릭버스터";
        else if (_characterClass == CharacterClass.Ark)
            return "아크";

        else if (_characterClass == CharacterClass.Xenon)
            return "제논";

        else
            return "NULL";
    }

    public static string ToFriendlyString(this OptionGrade _optionGrade)
    {
        if (_optionGrade == OptionGrade.None)
            return "잠재능력 없음";
        else if (_optionGrade == OptionGrade.Rare)
            return "레어";
        else if (_optionGrade == OptionGrade.Epic)
            return "에픽";
        else if (_optionGrade == OptionGrade.Unique)
            return "유니크";
        else if (_optionGrade == OptionGrade.Legendary)
            return "레전더리";
        else
            return "NULL";
    }

    public static string ToFriendlyString(this SetName _setName)
    {
        if (_setName == SetName.NULL)
            return "NULL";
        else if (_setName == SetName.BossTrinket)
            return "보스 장신구 세트";
        else if (_setName == SetName.DawnBoss)
            return "여명의 보스 세트";
        else if (_setName == SetName.BlackBossTrinket)
            return "칠흑의 보스 세트";
        else if (_setName == SetName.SevenDays)
            return "칠요 세트";
        else if (_setName == SetName.Meister)
            return "마이스터 세트";
        else if (_setName == SetName.ImmortalHero)
            return "임모탈 히어로 세트";
        else if (_setName == SetName.ImmortalMeisterHero)
            return "임모탈 마이스터 히어로 세트";
        else if (_setName == SetName.EternalHero)
            return "이터널 히어로 세트";
        else if (_setName == SetName.EternalMeisterHero)
            return "이터널 마이스터 히어로 세트";

        else if (_setName == SetName.Rootabis_Warrior)
            return "루타비스 세트(전사)";
        else if (_setName == SetName.Rootabis_Magician)
            return "루타비스 세트(마법사)";
        else if (_setName == SetName.Rootabis_Bowman)
            return "루타비스 세트(궁수)";
        else if (_setName == SetName.Rootabis_Thief)
            return "루타비스 세트(도적)";
        else if (_setName == SetName.Rootabis_Pirate)
            return "루타비스 세트(해적)";

        else if (_setName == SetName.Absolute_Warrior)
            return "앱솔랩스 세트(전사)";
        else if (_setName == SetName.Absolute_Magician)
            return "앱솔랩스 세트(마법사)";
        else if (_setName == SetName.Absolute_Bowman)
            return "앱솔랩스 세트(궁수)";
        else if (_setName == SetName.Absolute_Thief)
            return "앱솔랩스 세트(도적)";
        else if (_setName == SetName.Absolute_Pirate)
            return "앱솔랩스 세트(해적)";

        else if (_setName == SetName.Arcane_Warrior)
            return "아케인셰이드 세트(전사)";
        else if (_setName == SetName.Arcane_Magician)
            return "아케인셰이드 세트(마법사)";
        else if (_setName == SetName.Arcane_Bowman)
            return "아케인셰이드 세트(궁수)";
        else if (_setName == SetName.Arcane_Thief)
            return "아케인셰이드 세트(도적)";
        else if (_setName == SetName.Arcane_Pirate)
            return "아케인셰이드 세트(해적)";

        else if (_setName == SetName.Eternel_Warrior)
            return "에테르넬 세트(전사)";
        else if (_setName == SetName.Eternel_Magician)
            return "에테르넬 세트(마법사)";
        else if (_setName == SetName.Eternel_Bowman)
            return "에테르넬 세트(궁수)";
        else if (_setName == SetName.Eternel_Thief)
            return "에테르넬 세트(도적)";
        else if (_setName == SetName.Eternel_Pirate)
            return "에테르넬 세트(해적)";

        else
            return "NULL";
    }
}
