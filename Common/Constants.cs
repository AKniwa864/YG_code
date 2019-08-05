using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public struct Data
    {
        public static readonly string LEO = "Prefabs/Tsumu/Leo";
        public static readonly string YUKARI = "Prefabs/Tsumu/Yukari_Saotome";
        public static readonly string RANPHA = "Prefabs/Tsumu/Ranpha";
        public static readonly string MARIA = "Prefabs/Tsumu/Maria";
        public static readonly string JENNIFER = "Prefabs/Tsumu/Jennifer";
        public static readonly string RAKSHATA = "Prefabs/Tsumu/Rakshata";
        public static readonly string REBECCA = "Prefabs/Tsumu/Rebecca";
        public static readonly string EMMA = "Prefabs/Tsumu/Emma";
        public static readonly string ISABELLA = "Prefabs/Tsumu/Isabella";

        public static readonly string VERTICAL_DESTROY = "Prefabs/Skill/VerticalDestroy";
    }

    public struct Name
    {
        public static readonly string LEO = "レオ";
        public static readonly string YUKARI = "早乙女 紫";
        public static readonly string RANPHA = "蘭花";
        public static readonly string MARIA = "マリア";
        public static readonly string JENNIFER = "ジェニファー";
        public static readonly string RAKSHATA = "ラクシャータ";
        public static readonly string REBECCA = "レベッカ";
        public static readonly string EMMA = "エマ";
        public static readonly string ISABELLA = "イザベラ";
    }

    public static readonly float SELECT_FLICK_AMOUNT = 40.0f;

    public static readonly int CONNECT_MIN = 3;
    public static readonly int CONNECT_BOMB_MIN = 6;
    public static readonly float CONNECT_DISTANCE = 1.5f;

    public static readonly float COMBO_LIMIT_TIME = 2.5f;

    public static readonly int FEVER_TSUMU_MIN = 15;
    public static readonly float FEVER_TIME = 4.0f;
    public static readonly float FEVER_WIDTH_MAX = 300.0f;

    public static readonly int EFFECT_LINE_AMOUNT = 6;

    public enum Tsumu
    {
        Leo = 0,
        Yukari_Saotome,
        Ranpha,
        Maria,
        Jennifer,
        Rakshata,
        Rebecca,
        Emma,
        Isabella,
        Max
    }

    public enum TitlePageType
    {
        Title = 0,
        TsumuSelect,
    }

    public enum SkillType
    {
        VerticalDestroy = 0,
    }
}
