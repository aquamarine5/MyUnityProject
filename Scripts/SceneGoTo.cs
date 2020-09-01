using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneGoTo : MonoBehaviour
{
    static string[] staticTips = new string[] {
        "注意带紫色颗粒的怪物，他们很可能是「超级传播者」！",
        "被雷劈到的感觉并不好...",
        "赶紧救治得病的患者！",
        "武汉加油，中国加油，世界加油！",
        "游戏使用Unity开发，别问我这个单词怎么念，因为我也不会。",
        "凉风凉风，这个bug怎么修复？",
        "war的ma呀，长颈鹿在吃儿童鞋垫！",
        "不信谣不传谣，钉钉不会开摄像头，无线宝才会（滑稽）",
        "八种草药的来源来自PPt，出现问题及时就医！",
        "没有什么bug是我解决不了的，如果有，那就算了。",
        "你知道吗？憨豆先生也在武汉。",
        "什么！你以为这个是Python编的？算了，Python的碰撞检测太难了！",
        "这得有人来看这些吗？",
        "里面的材质大多来自Minecraft，不要问我为什么，因为...",
        "物品栏总是有bug，有药水尽快喝，别到最后喝不下去QAQ",
        "Application.Quit();"};
    
    public static void LoadScene(string scene,
        Text staticText,
        Transform staticVillageTransform,
        GameObject staticGameobject)
    {
        /*
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        staticGameobject.SetActive(true);
        staticText.text = staticTips[Random.Range(0, staticTips.Length)];
        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < 0.9f)
        {
            yield return LoadProgress(staticVillageTransform);
        }
        yield return LoadProgress(staticVillageTransform);
        Time.timeScale = 1;
        Debug.Log(1);
        staticGameobject.SetActive(false);
        asyncOperation.allowSceneActivation = true;*/
        SceneManager.LoadScene(scene);
    }
    private static IEnumerator<WaitForSeconds> LoadProgress(
                                        Transform staticVillageTransform)
    {
        staticVillageTransform.rotation.Set(
            staticVillageTransform.rotation.x,
            staticVillageTransform.rotation.y + Time.deltaTime,
            staticVillageTransform.rotation.z,
            staticVillageTransform.rotation.w);
        yield return new WaitForSeconds(0.1f);
    }
}
