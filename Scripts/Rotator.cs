using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour
{
    public Effect.EffectType effectType;
    public Effect.EffectLevel effectLevel;
    public ItemBar.ItemIndex index;
    public Button bt;
    public Image btImage;
    public Text btText;
    ItemBar.NBT nbt;
    public Color particleColor;
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Light>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Effect.EffectNBT enbt = new Effect.EffectNBT
            {
                el = effectLevel,
                et = effectType,
                color = particleColor,
                isNull = false
            };
            nbt = new ItemBar.NBT
            {
                effectNBT = enbt,
                canUse = true,
                nbtt = ItemBar.NBTType.Effect
            };
            ItemBar.AddItem(ItemBar.ReturnCanUsedPosition(), index);
            ItemBar.nowSelectNbt = nbt;
            bt.enabled = true;
            btImage.enabled = true;
            btText.enabled = true;
        }
    }
}
