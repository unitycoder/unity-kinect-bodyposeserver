using UnityEngine;
using UnityEngine.UI;
using com.rfilkov.components;
using System;

[RequireComponent(typeof(Toggle))]
public class ToggleMirror : MonoBehaviour {
    public StageAvatarController avatarController;

    private Toggle _toggle;

    private void Start() {
        if (avatarController == null) {
            avatarController = FindObjectOfType<StageAvatarController>();
        }
        _toggle = GetComponent<Toggle>();
        _toggle.SetIsOnWithoutNotify(avatarController.mirroredMovement);
        _toggle.onValueChanged.AddListener(_OnToggleValueChanged);
    }

    private void OnDestroy() {
        _toggle.onValueChanged.RemoveListener(_OnToggleValueChanged);
    }

    private void _OnToggleValueChanged(bool isOn) {
        avatarController.mirroredMovement = isOn;
    }    
}