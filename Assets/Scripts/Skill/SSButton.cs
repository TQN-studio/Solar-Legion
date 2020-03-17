using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSButton : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Text time;

    [SerializeField]
    private Image fill;

    private float cooldown_max;

    private float cooldown_current;

    private bool finish;

    public float Cooldown_max { get => cooldown_max; set => cooldown_max = value; }
    public Image Icon { get => icon; set => icon = value; }
    public bool Finish { get => finish;}

    // Update is called once per frame
    void Update()
    {
        Display();
    }

    public void Cooldown()
    {
        cooldown_current = cooldown_max;
        finish = false;
        StartCoroutine(Cooldown_Loading());
    }

    IEnumerator Cooldown_Loading()
    {
        while (cooldown_current > 0)
        {
            --cooldown_current;
            yield return new WaitForSeconds(1);
        }
        finish = true;
    }

    void Display()
    {
        if (cooldown_current != 0)
        {
            fill.gameObject.SetActive(true);
            fill.fillAmount = cooldown_current / cooldown_max;
            time.gameObject.SetActive(true);
            time.text = cooldown_current.ToString();
        }
        else
        {
            fill.gameObject.SetActive(false);
            time.gameObject.SetActive(false);
        }
    }
}
