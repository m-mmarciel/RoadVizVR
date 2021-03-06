﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPropBehavior : MonoBehaviour, ISceneUIMenu
{
    private GameObject propRef;
    private PropManager propManagerScript;

    public void init(params GameObject[] objRefs)
    {
        // catches the instance when we move a prop and then select another prop
        if (CurrentPropManager.Instance.getPropBeingMoved() == true)
        {
            CurrentPropManager.Instance.revertMovedProp();
        }

        propRef = objRefs[0];
        propManagerScript = propRef.GetComponent<Prop>().getPropManager();
        CurrentPropManager.Instance.setRotation(propRef.GetComponent<Prop>().getRotation());
    }

    public void handleMove()
    {
        Debug.Log("Move Button Pressed");

        ModifyController.Instance.setAddingProps(true);

        if (CurrentPropManager.Instance.getPropBeingMoved() == true)
        {
            propRef = CurrentPropManager.Instance.revertMovedProp();
            init(propRef);
        }

        CurrentPropManager.Instance.startMovingProp(propRef, propManagerScript);

        //setWorkingReference(CurrentPropManager.Instance.getCurrentPropObj());
    }

    public void handleCopy()
    {
        Debug.Log("Copy Button Pressed");

        ModifyController.Instance.setAddingProps(true);

        if (CurrentPropManager.Instance.getPropBeingMoved() == true)
        {
            propRef = CurrentPropManager.Instance.revertMovedProp();
            init(propRef);
        }
        CurrentPropManager.Instance.setCurrentPropObj(propRef);
    }

    public void handleDelete()
    {
        Debug.Log("Delete Button Pressed");

        propManagerScript.removeProp(propRef);
        ModifyController.Instance.setAddingProps(false);
        CurrentPropManager.Instance.setPropBeingMoved(false);

        StartCoroutine(CurrentPropManager.Instance.clearErrantPropObjects());

        UIManager.Instance.closeCurrentUI();
    }

    public void handleRotateCCW()
    {
        Debug.Log("CCW Button Pressed");
        if (CurrentPropManager.Instance.getPropBeingMoved() == true)
        {
            CurrentPropManager.Instance.rotateCCW();
        }
        else
        {
            propRef.GetComponent<Prop>().rotateCCW();
        }
    }

    public void handleRotateCW()
    {
        Debug.Log("CW Button Pressed");
        if (CurrentPropManager.Instance.getPropBeingMoved() == true)
        {
            CurrentPropManager.Instance.rotateCW();
        }
        else
        {
            propRef.GetComponent<Prop>().rotateCW();
        }
    }

    public void handleClose()
    {
        if (CurrentPropManager.Instance.getPropBeingMoved() == true)
        {
            propRef = CurrentPropManager.Instance.revertMovedProp();
            init(propRef);
            CurrentPropManager.Instance.clearCurrentPropObj();
        }
        ModifyController.Instance.setAddingProps(false);
        UIManager.Instance.closeCurrentUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
