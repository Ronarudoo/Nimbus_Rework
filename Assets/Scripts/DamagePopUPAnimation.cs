using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DamagePopUPAnimation : MonoBehaviour
{
    public AnimationCurve opacityCurve;
    public AnimationCurve scaleCurve;
    public AnimationCurve HeightCurve;

    private TextMeshProUGUI tmp;
    private float time = 0f;
    private Vector3 origin;

    private void Awake()
    {
        tmp = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        origin = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        tmp.color = new Color(1, 1, 1, opacityCurve.Evaluate(time));
        transform.localScale = Vector3.one * scaleCurve.Evaluate(time);
        transform.position = origin + new Vector3(0, 1 + HeightCurve.Evaluate(time), 0);
        time += Time.deltaTime;
    }
}
