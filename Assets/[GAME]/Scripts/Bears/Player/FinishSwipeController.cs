using System.Collections.Generic;
using _GAME_.Scripts.Enums;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Manager;
using _GAME_.Scripts.Models;
using _ORANGEBEAR_.EventSystem;
using _ORANGEBEAR_.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Bears.Player
{
    public class FinishSwipeController : Bear
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private List<FinishPoint> finishPoints;

        #endregion

        #region Private Variables

        private BossManager _bossManager;
        private PlayerAnimateBear _playerAnimateBear;

        private bool _onFinish;

        private float _minSwipeDistance = 0.5f;

        private int index = -1;

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _onFinish = false;
            _playerAnimateBear = GetComponent<PlayerAnimateBear>();
        }

        private void Start()
        {
            _bossManager = BossManager.Instance;
        }

        private void Update()
        {
            if (!_onFinish)
            {
                return;
            }

            if (GameManager.Instance.isGameEnded || !GameManager.Instance.isGameStarted)
            {
                return;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 swipe = touch.deltaPosition / touch.deltaTime;

                    if (swipe.magnitude > _minSwipeDistance)
                    {
                        if (Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x))
                        {
                            if (swipe.y > 0)
                            {
                                // Swipe Right
                                if (index < finishPoints.Count - 1)
                                {
                                    index++;
                                    Move();
                                }
                            }

                            else
                            {
                                // Swipe Left
                                if (index > 0)
                                {
                                    index--;
                                    Move();
                                }

                                else
                                {
                                    index = finishPoints.Count - 1;
                                    Move();
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Event Methods

        protected override void CheckRoarings(bool status)
        {
            if (status)
            {
                Register(CustomEvents.OnFinishLine, OnFinishLine);
            }

            else
            {
                UnRegister(CustomEvents.OnFinishLine, OnFinishLine);
            }
        }

        private void OnFinishLine(object[] args)
        {
            _onFinish = true;
        }

        #endregion

        #region Private Methods

        private void Move()
        {
            Vector3 pos = finishPoints[0].point.position;
            Vector3 position = transform.position;
            pos.y = position.y;
            Roar(CustomEvents.PlayPlayerAnimation, AnimationTypes.Run);


            transform.DOMove(pos, 0.5f)
                .OnComplete(() => { _playerAnimateBear.PlayAttackAnimation(); }).SetLink(gameObject)
                .SetEase(Ease.Linear);
        }

        #endregion
    }
}