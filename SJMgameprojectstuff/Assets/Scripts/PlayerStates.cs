using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName ="Assets/CharState")]
public class PlayerStates : ScriptableObject {

    [SerializeField]
    [HideInInspector]
    public GameObject body, lArm, rArm;

    [SerializeField]
    public Sprite bodySprite;
    [SerializeField]
    public Sprite lArmSprite;
    [SerializeField]
    public Sprite rArmSprite;

    public void AssignState(GameObject body = null,GameObject lArm = null,GameObject rArm = null)
    {
        if (body != null && lArm != null && rArm != null)
        {
            this.body = body;
            this.lArm = lArm;
            this.rArm = rArm;
            body.GetComponent<SpriteRenderer>().sprite = this.bodySprite;
            lArm.GetComponent<SpriteRenderer>().sprite = this.lArmSprite;
            rArm.GetComponent<SpriteRenderer>().sprite = this.rArmSprite;
        }
        else
        {
            Debug.LogError("variable not assigned");
        }
    }

    public void DeAssign()
    {
        body.GetComponent<SpriteRenderer>().sprite = null;
        lArm.GetComponent<SpriteRenderer>().sprite = null;
        rArm.GetComponent<SpriteRenderer>().sprite = null;
        body = null;
        lArm = null;
        rArm = null;
    }

}
