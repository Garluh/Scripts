using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Targetting : MonoBehaviour {
    [SerializeField]
    Transform target;
    public GameObject mobInfoPanel;
    public Text nameText;
    public Text damageText;
    public Text levelText;
    public Slider mobHp;
    

	// Use this for initialization
	void Start () {
        mobInfoPanel.SetActive(false);
        damageText.text = string.Empty;
        nameText.text = string.Empty;
        levelText.text = string.Empty;

    }
	
	// Update is called once per frame
	void Update () {
        UnLockTarget();
        LockTarget();

        if (target !=null)
        {
            mobHp.maxValue = target.GetComponent<EnemyManager>().maxHealth;
            mobHp.value = target.GetComponent<EnemyManager>().health;
        }


    }

    void UnLockTarget()
    {
        if (Input.GetMouseButtonDown(1) && target !=null )
        {
            target = null;
            damageText.text = string.Empty;
            nameText.text = string.Empty;
            levelText.text = string.Empty;
            mobInfoPanel.SetActive(false);
        }
    }

    void LockTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(screenCenterPoint);

            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                if (hit.transform.tag == "Enemy")
                {
                    string colorName = string.Empty;
                    Debug.DrawLine(this.transform.position, hit.point, Color.blue);
                    Debug.Log(hit.transform.name);
                    target = hit.transform;
                    mobInfoPanel.SetActive(true);
                    switch (target.GetComponent<EnemyManager>().Rarity)
                    {
                        case EnemyMobRarity.Unknown:
                            nameText.color = Color.white;
                            break;
                        case EnemyMobRarity.Normal:
                            nameText.color = Color.white;
                            break;
                        case EnemyMobRarity.Champion:
                            nameText.color = Color.yellow;
                            break;
                        case EnemyMobRarity.Legendary:
                            nameText.color = Color.magenta;
                            break;
                        case EnemyMobRarity.Boss:
                            nameText.color = Color.red;
                            break;
                    }
                    nameText.text = target.GetComponent<EnemyManager>().MobName;
                    damageText.text = target.GetComponent<EnemyManager>().damageDelta;
                    levelText.text = target.GetComponent<EnemyManager>().level.ToString();
                    mobHp.maxValue = target.GetComponent<EnemyManager>().maxHealth;
                    mobHp.value = target.GetComponent<EnemyManager>().health;

                }
                // A collision was detected please deal with it

            }

        }
    }

}
