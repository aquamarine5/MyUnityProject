using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookChange : MonoBehaviour
{
    readonly string page1 = @"第 1 页 / 共 3 页

游戏素材大多来自Minecraft（如你当前看到的书架）
剩下的还有几个是来自
survival shooter.unitypackage资源包
没有版权，自动默认可以cc-by-sa 3.0非商业用途
但是代码都是我自己写的 QAQ

疫情期间少出门，不暴饮暴食，少吃油腻食品
不熬夜工作，体温超过37.3℃尽快上报企业/社区";
    readonly string page2 = @"第 2 页 / 共 3 页

玩家可以通过在疫情模式里面
攻击手持草药的病原体（就是怪物）来获得草药
或者在任何模式里面通过分数兑换草药（有商人）
最后合成迷之炖菜，可以救治旁边得病的三个村民
最后救三个村民之后就通关了！";
    readonly string page3 = @"第 3 页 / 共 4 页
有bug别生气  TuT

经典模式里面有药水！黄色药水（附魔之瓶）
可以让你的分数加倍！

武汉加油！中国加油！意大利加油！日本加油！
韩国加油！伊朗加油！
1806 石一泽";
    readonly string page4 = @"
什么！你都看到了这里！
还是再说一遍吧：少吃野味，别吃蝙蝠！
目前存在的bug：
1.场景跳转时候的内存溢出问题
（已禁用部分场景异步跳转）
2.商人兑换物品不显示动画
3.触摸角色扭头的问题
（全部场景禁用角色扭头旋转）";
    public GameObject left;
    public Text text;
    public GameObject right;
    int index=1;
    public void Leftpage()
    {
        switch (index)
        {
            case 1:
                text.text = page1;
                left.SetActive(false);
                right.SetActive(true);
                index = 1;
                break;
            case 2:
                text.text = page1;
                left.SetActive(false);
                right.SetActive(true);
                index = 1;
                break;
            case 3:
                text.text = page2;
                left.SetActive(true);
                right.SetActive(true);
                index = 2;
                break;
            case 4:
                text.text = page3;
                left.SetActive(true);
                right.SetActive(false);
                index = 3;
                break;

        }
    }
    public void Rightpage()
    {
        switch (index)
        {
            case 1:
                text.text = page2;
                left.SetActive(true);
                right.SetActive(true);
                index = 2;
                break;
            case 2:
                text.text = page3;
                left.SetActive(true);
                right.SetActive(true);
                index = 3;
                break;
            case 3:
                text.text = page4;
                left.SetActive(true);
                right.SetActive(false);
                index = 4;
                break;
            case 4:
                text.text = page4;
                left.SetActive(true);
                right.SetActive(false);
                index = 4;
                break;
        }
    }
}
