using UnityEngine;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour
{
    private const string Master = nameof(Master);
    private const string Background = nameof(Background);
    private const string SoundBar = nameof(SoundBar);

    private const int MaxVolume = 0;
    private const int MinVolume = -80;

    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isMasterMuted;
    private float _masterVolume;

    public void SetMasterVolume(float volume)
    {
        _masterVolume = volume;

        if (_isMasterMuted)
        {
            return;
        }

        _mixer.audioMixer.SetFloat(Master, Mathf.Lerp(MinVolume, MaxVolume, _masterVolume));
    }

    public void MuteMasterSound(bool enambled)
    {
        _isMasterMuted = enambled;

        if (enambled)
        {
            _mixer.audioMixer.SetFloat(Master, MinVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(Master, Mathf.Lerp(MinVolume, MaxVolume, _masterVolume));
        }
    }

    public void SetBackgroundVolume(float volume)
    {
        _masterVolume = volume;

        if (_isMasterMuted)
        {
            return;
        }

        _mixer.audioMixer.SetFloat(Background, Mathf.Lerp(MinVolume, MaxVolume, _masterVolume));
    }

    public void SetSoundBarVolume(float volume)
    {
        _masterVolume = volume;

        if (_isMasterMuted)
        {
            return;
        }

        _mixer.audioMixer.SetFloat(SoundBar, Mathf.Lerp(MinVolume, MaxVolume, _masterVolume));
    }
}
