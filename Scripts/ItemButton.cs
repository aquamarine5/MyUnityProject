using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Button bt;
    public Image btImage;
    public Text btText;
    public void OnButtonClick()
    {
        ItemBar.NBT nowNBT = ItemBar.nowSelectNbt;
        if (nowNBT.nbtt == ItemBar.NBTType.Effect)
        {
            Effect.AddEffect(ItemBar.nowSelectNbt.effectNBT.et, ItemBar.nowSelectNbt.effectNBT.el);
            PlayerParticle.AddEffect(ItemBar.nowSelectNbt.effectNBT.color);
            ItemBar.nowSelectNbt = new ItemBar.NBT() { 
                canUse = false};
        }
        ItemBar.UseItem();
        bt.enabled = false;
        btImage.enabled = false;
        btText.enabled = false;
    }
    public void OnItemBarClick(int index)
    {
        ItemBar.staticSelectImages[ItemBar.selectIndex].enabled = false;
        ItemBar.staticSelectImages[index].enabled = true;
        ItemBar.selectIndex = index;
        if (ItemBar.nowSelectNbt.canUse)
        {
            bt.enabled = true;
            btImage.enabled = true;
            btText.enabled = true;
        }
        else
        {
            bt.enabled = false;
            btImage.enabled = false;
            btText.enabled = false;
        }
    }
}
