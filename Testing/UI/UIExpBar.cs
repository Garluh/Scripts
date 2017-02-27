using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIExpBar : MonoBehaviour {

    public GameEntity entity;
    public RectTransform expBarArea;
    public RectTransform expBarFill;
    public Text expBarValues;

    // Use this for initialization
    void Awake () {

        entity.EntityLevel.OnEntityExpGain += OnExpGain;
        UpdateUI();
    }

    void OnExpGain(object sender, ExpGainEventArgs args)
    {
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI ()
    {
        float expprecent = Mathf.Clamp((float)entity.EntityLevel.ExpCurrent / (float)entity.EntityLevel.ExpRequire, 0f, 1f);
        float newRightOffset = -expBarArea.rect.width + expBarArea.rect.width * expprecent;
        expBarFill.offsetMax = new Vector2(newRightOffset, expBarFill.offsetMax.y);
        expBarValues.text = string.Format("{0} / {1} (Level {2})", entity.EntityLevel.ExpCurrent, entity.EntityLevel.ExpRequire, entity.EntityLevel.Level);
    }
}
