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

    [SerializeField]
    private List<Quest> questList = new List<Quest>();
    public List<Quest> QuestList { get { return questList; } }

    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach(Character c in members)
        {
            c.charInit(VFXManager.Instance,UIManager.instance,InventoryManager.instance);
        }
        SelectSingleHero(0);

        members[0].MagicSkills.Add(new Magic(VFXManager.Instance.MagicData[0]));
        members[1].MagicSkills.Add(new Magic(VFXManager.Instance.MagicData[1]));

        InventoryManager.instance.AddItem(members[0], 0); //Potion
        InventoryManager.instance.AddItem(members[0], 1); //Sword
        InventoryManager.instance.AddItem(members[0], 2); //ShieldA
        InventoryManager.instance.AddItem(members[0], 3); //Axe
        InventoryManager.instance.AddItem(members[0], 4); //Spear

        InventoryManager.instance.AddItem(members[1], 10); //Pie
        InventoryManager.instance.AddItem(members[1], 4); //Spear
        InventoryManager.instance.AddItem(members[1], 1); //Sword
        InventoryManager.instance.AddItem(members[1], 3); //Axe
        InventoryManager.instance.AddItem(members[1], 11); //ShieldB
        //InventoryManager.instance.AddItem(members[1], 12); //Mana potion

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

    public int FindIndexFromClass(Character hero)
    {
        for (int i = 0; i < members.Count; i++)
        {
            return i;
        }
        return 0;
    }
    public void SelectSingleHeroByToggle(int i)
    {
        //Debug.Log($"Select {i}");

        if (selectChars.Contains(members[i]))
        {
            members[i].ToggleRingSelection(true);
            UIManager.instance.ShowMagicToggles();
        }
        else
        {
            selectChars.Add(members[i]);
            members[i].ToggleRingSelection(true);
            UIManager.instance.ShowMagicToggles();
        }
    }

    public void UnSelectSingleHeroByToggle(int i)
    {
        //if (selectChars.Count <= 1)
        //{
        //    UIManager.instance.ToggleAvatar[i].isOn = true;
        //    return;
        //}

        if (selectChars.Contains(members[i]))
        {
            selectChars.Remove(members[i]);
            members[i].ToggleRingSelection(false);   
        }
    }

    public void RemoveHeroFromParty(int id)
    {
        if (id == -1 || id == 0)
            return;
        if(selectChars.Contains(members[id]))
            selectChars.Remove(members[id]);

        members.Remove(members[id]);
    }

}
