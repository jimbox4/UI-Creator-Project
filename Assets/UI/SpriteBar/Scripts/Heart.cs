using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        TryGetComponent(out _image);
    }

    [ContextMenu(nameof(Destroy))]
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void ChangeSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
