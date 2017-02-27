using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject[] spells;
    public Image image;
    public Sprite defIcon;
    public Text spellLable;
    private GameObject curSpell;
    public GameObject targetPoint;
    private int id = 0;

    BaseCharacter  bc;

    [SerializeField]
    private bool combatMode;

    // Use this for initialization
    void Start()
    {
        bc = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BaseCharacter>();

        //StartCoroutine("Test");

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bc.mana);
        CombatMode();
        MouseFunc();
        SpellRotation();
        //SpellSwitch();

    }

    void MouseFunc()
    {
        if (Input.GetMouseButtonDown(0) && combatMode && curSpell != null && !(bc.mana < curSpell.GetComponent<SpellDatabase>().ManaConsumption))
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(screenCenterPoint);

            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {

                Vector3 targetPosition = hit.point + hit.normal * 0.01f;
                Quaternion bulletHoleRotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);
                GameObject target = (GameObject)GameObject.Instantiate(targetPoint, targetPosition, bulletHoleRotation);
                curSpell.GetComponent<EffectSettings>().Target = target;
                
                bc.AdjMP(-curSpell.GetComponent<SpellDatabase>().ManaConsumption);
                Debug.Log("Потребление маны " + -curSpell.GetComponent<SpellDatabase>().ManaConsumption);
                //CameraShake.Instance.Shake(.1f, .5f);
                //Debug.DrawLine(this.transform.position, hit.point);
                GameObject copySpell = (GameObject)Instantiate(curSpell, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation);
                if (curSpell.GetComponent<EffectSettings>().DeactivateAfterCollision)
                {
                    Destroy(copySpell, 5);
                    Destroy(target, 5);
                }
                // A collision was detected please deal with it

            }

        }
    }

    //Включение боевого режима, когда по указателю можно совершать атаку
    void CombatMode()
    {
        if (Input.GetKeyDown(KeyCode.F) && !combatMode)
        {
            combatMode = !combatMode;
        }
        else if (Input.GetKeyDown(KeyCode.F) && combatMode)
        {
            combatMode = !combatMode;
        }

    }

    void SpellRotation()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            curSpell = spells[id];
            image.sprite = spells[id].GetComponent<SpellDatabase>().icon;
            spellLable.text = spells[id].GetComponent<SpellDatabase>().itemName;
            id++;
        }
        if (id == spells.Length)
        {
            id = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            curSpell = null;
            image.sprite = defIcon;
        }
    }

    void SpellSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curSpell = spells[0];
            image.sprite = spells[0].GetComponent<SpellDatabase>().icon;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curSpell = spells[1];
            image.sprite = spells[1].GetComponent<SpellDatabase>().icon;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curSpell = spells[2];
            image.sprite = spells[2].GetComponent<SpellDatabase>().icon;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curSpell = spells[3];
            image.sprite = spells[3].GetComponent<SpellDatabase>().icon;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            curSpell = null;
            image.sprite = defIcon;
        }
    }

    //IEnumerator Test() {
    //    yield return new WaitForSeconds(1);
    //    for (int i = 0; i < spells.Length; i++)
    //    {
    //        Debug.Log(spells[i].GetComponent<SpellDatabase>().MaxDamage);
    //    }
    //}
}
