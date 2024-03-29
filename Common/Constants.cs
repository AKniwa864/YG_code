﻿using UnityEngine;

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
        public static readonly string HORIZONTAL_DESTROY = "Prefabs/Skill/HorizontalDestroy";
        public static readonly string CENTER_CHANGE = "Prefabs/Skill/CenterChange";
        public static readonly string RANDOM_CHANGE = "Prefabs/Skill/RandomChange";
        public static readonly string POP_BOMB = "Prefabs/Skill/PopBomb";
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

    public static readonly float SELECT_FLICK_AMOUNT = 0.5f;

    public static readonly float BUTTON_ANIM_TIME = 0.2f;

    public static readonly int TSUMU_MAX = 30;

    public static readonly int TIME_MAX = 60;

    public static readonly int CONNECT_DIGIT_MAX = 2;

    public static readonly int CONNECT_MIN = 3;
    public static readonly int CONNECT_BOMB_MIN = 6;
    public static readonly float CONNECT_GAP_MIN = 0.2f;
    public static readonly float CONNECT_DISTANCE = 1.5f;

    public static readonly int SKILL_BOMB_AMOUNT = 2;
    public static readonly int SKILL_CHANGE_AMOUNT = 8;

    public static readonly float COMBO_LIMIT_TIME = 2.5f;

    public static readonly int FEVER_TSUMU_MIN = 15;
    public static readonly float FEVER_TIME = 4.0f;
    public static readonly Color32 FEVER_COLOR_DEFAULT = new Color32(229, 255, 88, 255);
    public static readonly Color32 FEVER_FRAME_COLOR = new Color32(100, 100, 100, 255);

    public static readonly int EFFECT_LINE_AMOUNT = 6;

    public static readonly float SCORE_UPDATE_TIME = 1.0f;

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
        Max
    }

    public enum SkillType
    {
        VerticalDestroy = 0,
        HorizontalDestroy,
        CenterChange,
        RandomChange,
        PopBomb,
    }
}
