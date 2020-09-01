using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    public Image[] images;
    public Image[] selectImages;
    public Sprite[] sprites;
    public static Image[] staticImages;
    public static int selectIndex=0;
    public static NBT nowSelectNbt=new NBT();
    public static Sprite[] staticSprites;
    public static Image[] staticSelectImages;
    public static bool[] bools = new bool[11] { false, false, false, false, false, false, false, false, false, false, false };
    private void Awake()
    {
        staticImages = images;
        staticSelectImages = selectImages;
        staticSprites = sprites;
    }
    public enum NBTType
    {
        Classic=0,
        Effect=100
    }
    public class NBT
    {
        public NBTType nbtt=NBTType.Classic;
        public bool canUse;
        public Effect.EffectNBT effectNBT=Effect.nullEffectNBT;
    }
    public static void AddItem(ItemPosition itemPosition,ItemIndex itemIndex)
    {
        staticImages[(int)itemPosition].sprite = staticSprites[(int)itemIndex];
    }
    public static ItemIndex ReturnIndexThing(ItemPosition ip)
    {
        Sprite sprite = staticImages[(int)ip].sprite;
        if (sprite == staticSprites[0])      { return ItemIndex.NOTHING; }
        else if (sprite == staticSprites[1]) { return ItemIndex.hpUpEffect; }
        else if (sprite == staticSprites[2]) { return ItemIndex.jumpEffect; }
        else if (sprite == staticSprites[3]) { return ItemIndex.scoreEffect; }
        else { return ItemIndex.NOTHING; }
    }
    public static ItemIndex ReturnNowSelectThing()
    {
        return ReturnIndexThing((ItemPosition)selectIndex);
    }
    public static ItemGroups ItemIndexToGroups(ItemIndex ii)
    {
        if (ii == ItemIndex.NOTHING) { return ItemGroups.NOTHING; }
        else if (0 < (int)ii && (int)ii < 4)
        { return ItemGroups.effect; }
        else { return ItemGroups.NOTHING; }
    }
    public static ItemPosition ReturnCanUsedPosition()
    {
        if      (!bools[0]) { bools[0] = true; 
              return ItemPosition.ip1;  }
        else if (!bools[1]) { bools[1] = true; 
              return ItemPosition.ip2;  }
        else if (!bools[2]) { bools[2] = true; 
              return ItemPosition.ip3;  }
        else if (!bools[3]) { bools[3] = true; 
              return ItemPosition.ip4;  }
        else if (!bools[4]) { bools[4] = true; 
              return ItemPosition.ip5;  }
        else if (!bools[5]) { bools[5] = true; 
              return ItemPosition.ip6;  }
        else if (!bools[6]) { bools[6] = true; 
              return ItemPosition.ip7;  }
        else if (!bools[7]) { bools[7] = true; 
              return ItemPosition.ip8;  }
        else if (!bools[8]) { bools[8] = true; 
              return ItemPosition.ip9;  }
        else if (!bools[9]) { bools[9] = true; 
              return ItemPosition.ip10; }
        else if(!bools[10]) { bools[10] = true; 
              return ItemPosition.ip11; }
        else { bools[0] = true; 
              return ItemPosition.ip1; }

    }
    public static void DeleteItem(ItemPosition itemPosition)
    {
        staticImages[(int)itemPosition].sprite = staticSprites[0];
        bools[(int)itemPosition] = false;
    }
    public static void UseItem()
    {
        DeleteItem((ItemPosition)selectIndex);
    }
    public enum ItemPosition
    {
        ip1=0,
        ip2=1,
        ip3=2,
        ip4=3,
        ip5=4,
        ip6=5,
        ip7=6,
        ip8=7,
        ip9=8,
        ip10=9,
        ip11=10
    }
    public enum ItemIndex
    {
        NOTHING=0,
        hpUpEffect=1,
        jumpEffect=2,
        scoreEffect=3,
        mzdc=4
    }
    public enum ItemGroups
    {
        NOTHING=0,
        effect=100,
        zcy=130
    }
}
