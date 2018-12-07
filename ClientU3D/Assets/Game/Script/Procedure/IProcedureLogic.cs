using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GameCore;

public abstract class IProcedureLogic<T> : MonoBehaviour where T : IProcedure
{
    public T procedure { get; set; }

    // procedure logic flow api
    protected abstract void OnInit();
    protected abstract void OnEnter();
    protected abstract void OnLeave();
    protected abstract void OnTick();

    // protected callback
    public void Awake()
    {
        try {
            procedure = (T)(GameContext.procedureSrv.GetCurProcedure());
            OnInit();
        } catch (Exception ex) {
            GameLog.Error("procedure logic init error.Exception:{0} StackTrace:{1}",
                ex.Message, ex.StackTrace);
        }
    }

    public void Start()
    {
        try {
            OnEnter();
        } catch (Exception ex) {
            GameLog.Error("procedure logic enter error.Exception:{0} StackTrace:{1}",
                ex.Message, ex.StackTrace);
        }
    }

    public void Update()
    {
        try {
            OnTick();
        } catch (Exception ex) {
            GameLog.Error("procedure logic tick error.Exception:{0} StackTrace:{1}",
                ex.Message, ex.StackTrace);
        }
    }

    public void OnDestroy()
    {
        try {
            OnLeave();
        } catch (Exception ex) {
            GameLog.Error("procedure logic leave error.Exception:{0} StackTrace:{1}",
                ex.Message, ex.StackTrace);
        }
    }
}
