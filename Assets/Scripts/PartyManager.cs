using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    private List<Character> selectChars = new List<Character>();
    public List<Character> SelectChars { get { return selectChars; } }

    [SerializeField]
    private List<Character> members = new List<Character>();
    public List<Character> Members { get { return members; } }

    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach(Character c in members)
        {
            c.charInit(VFXManager.Instance,UIManager.instance);
        }
        SelectSingleHero(0);

        // Hero 1
        members[0].MagicSkills.Add(new Magic(0, "PowerDraw", 10f, 20, 3f, 1f, 0, 0));
        members[0].MagicSkills.Add(new Magic(1, "Lightning Strike", 8f, 25, 2f, 0.5f, 1, 1));
        members[0].MagicSkills.Add(new Magic(2, "Water pulse", 12f, 40, 4f, 1f, 2, 2));
        members[0].MagicSkills.Add(new Magic(3, "Ground Bomb", 9f, 22, 2.5f, 0.7f, 3, 3));

        // Hero 2
        members[1].MagicSkills.Add(new Magic(0, "Fireball", 10f, 30, 3f, 1f, 4, 4));
        members[1].MagicSkills.Add(new Magic(1, "Dark bolt", 6f, 20, 2f, 0.5f, 5, 5));
        members[1].MagicSkills.Add(new Magic(2, "Ninja Slash", 15f, 50, 5f, 1.5f, 6, 6));
        members[1].MagicSkills.Add(new Magic(3, "Wing Spear", 11f, 28, 3.5f, 0.8f, 7, 7));

        UIManager.instance.ShowMagicToggles();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (selectChars.Count > 0)
            {
                selectChars[0].IsMagicMode = true;
                selectChars[0].CurMagicCast = selectChars[0].MagicSkills[0];
            }
        }
    }

    public void SelectSingleHero(int i)
    {
        foreach (Character c in selectChars)
            c.ToggleRingSelection(false);

        selectChars.Clear();

        selectChars.Add(members[i]);
        selectChars[0].ToggleRingSelection(true);
    }

    public void HeroSelectMagicSkill(int i)
    {
        if (selectChars.Count <= 0)
            return;

        selectChars[0].IsMagicMode = true;
        selectChars[0].CurMagicCast = selectChars[0].MagicSkills[i];
    }


}
