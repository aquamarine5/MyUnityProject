using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geography_DINGTALK : MonoBehaviour
{
    public AudioSource ding;
    public AudioSource message;
    public AudioSource Video;
    float time_ding;
    float time_message;
    float time_video;
    private void Update()
    {
        time_ding += Time.deltaTime;
        time_message += Time.deltaTime;
        time_video += Time.deltaTime;
        if (time_ding >= 5)
        {
            ding.Play();
            time_ding = 0;
        }
        if (time_message >= 13)
        {
            message.Play();
            time_message = 0;
        }
        if (time_video >= 37)
        {
            Video.Play();
            time_video = 0;
        }
    }
}
