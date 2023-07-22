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

    [SerializeField]
    private List<AudioSource> soundSource = new List<AudioSource>();
    [SerializeField]
    private List<AudioSource> effectSource = new List<AudioSource>();

    private bool sound = true, effect = true;

    public void Sound()
    {
        sound = !sound;

        if (sound)
        {
            SoundButton.sprite = soundOn;
            foreach (var s in soundSource)
            {
                s.volume = 1;
            }
        }
        else
        {
            SoundButton.sprite = soundOff;
            foreach (var s in soundSource)
            {
                s.volume = 0;
            }
        }
    }

    public void Effect()
    {
        effect = !effect;

        if (effect)
        {
            effectButton.sprite = effectOn;
            foreach (var s in effectSource)
            {
                s.volume = 1;
            }
        }
        else
        {
            effectButton.sprite= effectOff;
            foreach (var s in effectSource)
            {
                s.volume = 0;
            }
        }
    }
}
