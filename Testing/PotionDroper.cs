using UnityEngine;
using System.Collections;

public class PotionDroper : MonoBehaviour {
    BaseCharacter bs;
    public AudioClip clip;

    void Awake()
    {
        bs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BaseCharacter>();
    }

    void Start()
    {
        Destroy(gameObject, 120);
    }


    void OnTriggerEnter()
    {

        if (gameObject.tag == "HPPotion")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            bs.AdjHPPotion(1);
            Destroy(gameObject,0.3f);
        }

        if (gameObject.tag == "MPPotion")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            bs.AdjMPPotion(1);
            Destroy(gameObject, 0.3f);
        }
    }

}
