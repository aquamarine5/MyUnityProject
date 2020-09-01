using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    #region PUBLIC
    public enum EffectLevel
    {
        nothing = 0,
        lv1 = 1,
        lv2 = 2,
        lv3 = 3,
        lv4 = 4,
    }
    public struct EffectNBT
    {
        public bool isNull;
        public EffectType et;
        public EffectLevel el;
        public EffectNBT SetNull()
        {
            isNull = true;
            return this;
        }
        public Color color;
    }
    public static EffectNBT nullEffectNBT = (new EffectNBT().SetNull());
    public enum EffectType
    {
        hpUp = 1,
        jumpHigher = 2,
        scoreDouble = 3,
    }
    public static void ClearEffect()
    {
        isScoreDouble = EffectLevel.nothing;
    }
    public static void AddEffect(EffectType effectType,EffectLevel effectLevel)
    {
        switch (effectType)
        {
            case EffectType.scoreDouble:
                {
                    isScoreDouble = effectLevel;
                    return;
                }
            case EffectType.jumpHigher:
                {
                    isJumpHigher = effectLevel;
                    return;
                }
            case EffectType.hpUp:
                {
                    isJumpHigher = effectLevel;
                    return;
                }
        }
    }
    #endregion
    #region HpUp
    public static EffectLevel isHpUp = EffectLevel.nothing;
    public static int HpUp
    {
        get
        {
            switch (isHpUp)
            {
                case EffectLevel.lv1:
                    {
                        return 1;
                    }
                case EffectLevel.lv2:
                    {
                        return 2;
                    }
                case EffectLevel.lv3:
                    {
                        return 3;
                    }
                case EffectLevel.lv4:
                    {
                        return 5;
                    }
                case EffectLevel.nothing:
                    {
                        return 0;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
    #endregion
    #region ScoreDouble
    public static EffectLevel isScoreDouble = EffectLevel.nothing;
    public static int ScoreUp
    {
        get
        {
            switch (isScoreDouble)
            {
                case EffectLevel.lv1:
                    {
                        return 2;
                    }
                case EffectLevel.lv2:
                    {
                        return 3;
                    }
                case EffectLevel.lv3:
                    {
                        return 4;
                    }
                case EffectLevel.lv4:
                    {
                        return 5;
                    }
                case EffectLevel.nothing:
                    {
                        return 1;
                    }
                default:
                    {
                        return 1;
                    }
            }
        }
    }
    #endregion
    #region JumpHigher
    public static EffectLevel isJumpHigher = EffectLevel.nothing;
    public static float JumpUp
    {
        get
        {
            switch (isJumpHigher)
            {
                case EffectLevel.lv1:
                    {
                        return 300f;
                    }
                case EffectLevel.lv2:
                    {
                        return 350f;
                    }
                case EffectLevel.lv3:
                    {
                        return 400f;
                    }
                case EffectLevel.lv4:
                    {
                        return 450f;
                    }
                case EffectLevel.nothing:
                    {
                        return 200f;
                    }
                default:
                    {
                        return 200f;
                    }
            }
        }
    }
    #endregion
}
