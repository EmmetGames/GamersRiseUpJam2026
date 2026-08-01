using UnityEngine;
using System.Collections.Generic;

public class PlayerVisualPopulate : MonoBehaviour
{
    [SerializeField] private Sprite[] Face;
    [SerializeField] private Color[] SkinTone;
    [SerializeField] private Color[] Pants;
    [SerializeField] private ClassWithScriptable[] classArray;

    private AdventurerView characterInfo;

    void Start()
    {
        characterInfo = GetComponent<AdventurerView>();
        PopulateVisuals(Class.Warrior);
    }

    void PopulateVisuals(Class adventurerClass)
    {
        print((int)adventurerClass);

        GetComponent<SpriteRenderer>().color = SkinTone[Random.Range(0, SkinTone.Length)];
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Face[Random.Range(0, Face.Length)];
        transform.GetChild(1).GetComponent<SpriteRenderer>().color = Pants[Random.Range(0, Pants.Length)];


        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = classArray[(int)adventurerClass].visual.Weapon;
        transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = classArray[(int)adventurerClass].visual.Armour;
        transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = classArray[(int)adventurerClass].visual.Hat;
    }
}
