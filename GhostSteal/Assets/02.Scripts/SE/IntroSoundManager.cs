using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSoundManager : MonoBehaviour
{
    [SerializeField]
    private Image SoundButton, effectButton;

    [SerializeField]
    private Sprite soundOn, soundOff;
    [SerializeField]
    private Sprite effectOn, effectOff;

    private bool sound = true, effect = true;

    public void Sound()
    {
        sound = !sound;

        if (sound)
        {
            SoundButton.sprite = soundOn;
        }
        else
        {
            SoundButton.sprite = soundOff;
        }
    }

    public void Effect()
    {
        effect = !effect;

        if (effect)
        {
            effectButton.sprite = effectOn;
        }
        else
        {
            effectButton.sprite= effectOff;
        }
    }
}
