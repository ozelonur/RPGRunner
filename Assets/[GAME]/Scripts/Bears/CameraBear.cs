using System.Collections.Generic;
using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Manager;
using _ORANGEBEAR_.EventSystem;
using Cinemachine;
using UnityEngine;

namespace _GAME_.Scripts.Bears
{
    public class CameraBear : Bear
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private CinemachineVirtualCamera[] virtualCameras;
        

        #endregion

        #region Private Variables

        private Dictionary<CameraTypes, CinemachineVirtualCamera> _virtualCameras = new();

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _virtualCameras.Add(CameraTypes.Main, virtualCameras[0]);
            _virtualCameras.Add(CameraTypes.Finish, virtualCameras[1]);
        }

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.SwitchCamera, SwitchCamera);
                Register(CustomEvents.GetCameraFollowTarget, GetCameraFollowTarget);
                Register(CustomEvents.OnFinishLine, OnFinishLine);
            }

            else
            {
                UnRegister(CustomEvents.SwitchCamera, SwitchCamera);
                UnRegister(CustomEvents.GetCameraFollowTarget, GetCameraFollowTarget);
                UnRegister(CustomEvents.OnFinishLine, OnFinishLine);
            }
        }

        private void OnFinishLine(object[] args)
        {
            virtualCameras[1].m_LookAt = PlayerManager.Instance.warrior.GetTransform();
            Switch(CameraTypes.Finish);
        }

        private void GetCameraFollowTarget(object[] args)
        {
            Transform cameraFollowTarget = (Transform)args[0];
            SetTarget(cameraFollowTarget);
        }

        private void SwitchCamera(object[] args)
        {
            CameraTypes cameraType = (CameraTypes)args[0];

            Switch(cameraType);
        }

        #endregion

        #region Private Methods

        private void Switch(CameraTypes cameraType)
        {
            foreach (KeyValuePair<CameraTypes, CinemachineVirtualCamera> vCamera in _virtualCameras)
            {
                vCamera.Value.Priority = vCamera.Key == cameraType ? 11 : 0;
            }
        }

        private void SetTarget(Transform target)
        {
            foreach (KeyValuePair<CameraTypes, CinemachineVirtualCamera> vCamera in _virtualCameras)
            {
                vCamera.Value.m_Follow = target;
            }
        }

        #endregion
    }
}