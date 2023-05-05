using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageIndicator : MonoBehaviour
{
    public Text text;
    public float lifetime = 6f;
    public float minDist = 0.5f;
    public float maxDist = 1f;
    public int yourFontSize = 24;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);

        float direction = UnityEngine.Random.rotation.eulerAngles.z;
        iniPos = transform.position;
        float dist = UnityEngine.Random.Range(minDist, maxDist);
        targetPos = iniPos + (Quaternion.Euler(0, 0, direction) * new Vector3(dist, dist, 0f));
        transform.localScale = Vector3.zero;
        text.fontSize = yourFontSize;

        iniPos = transform.position + Vector3.up * GetComponent<CapsuleCollider>().height;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float fraction = lifetime / 2f;

        if (timer > lifetime) Destroy(gameObject);
        else if (timer > fraction) text.color = Color.Lerp(text.color, Color.clear, (timer - fraction) / (lifetime - fraction));

        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / lifetime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer / lifetime));
    }

    public void SetDamageText(int damage)
    {
        text.text = damage.ToString();
    }
}
