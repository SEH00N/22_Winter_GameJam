using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteCallback : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer = null;
    [SerializeField] Sprite onMuteSprite = null;
    [SerializeField] Sprite unMuteSprite = null;

    private Image buttonImage = null;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }

    private void Start()
    {
        bool isMute = DataManager.Instance.userSetting.isMute;
        buttonImage.sprite = isMute ? onMuteSprite : unMuteSprite;
        audioMixer.SetFloat("Master", isMute ? -80 : 0);
    }

    public void Mute()
    {
        bool isMute = DataManager.Instance.userSetting.isMute;
        isMute = !isMute;

        buttonImage.sprite = isMute ? onMuteSprite : unMuteSprite;
        audioMixer.SetFloat("Master", isMute ? -80 : 0);

        DataManager.Instance.userSetting.isMute = isMute;
    }
}
