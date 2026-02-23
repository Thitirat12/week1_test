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
            c.charInit(VFXManager.Instance);
            c.MagicSkills.Add(new Magic(0, "Fireball", 10f, 30, 3f, 1f, 0, 1));
        }
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
}
