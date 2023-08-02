using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectCharacter : MonoBehaviour
{

    public Character character;
    Animator anim;
    SpriteRenderer sr;
    public SelectCharacter[] chars;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (DataManager.instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }

    private void OnMouseUpAsButton()
    {
        DataManager.instance.currentCharacter = character;
        OnSelect();
        for(int i=0; i<chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }
    private void OnDeSelect()
    {
        anim.SetBool("state", false);
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    private void OnSelect()
    {
        anim.SetBool("state", true);
        sr.color = new Color(1f,1f, 1f);
    }
}

