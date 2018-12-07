using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GameCore;

public class MainProcedureLogic : IProcedureLogic<MainProcedure>
{
    protected override void OnInit()
    {
        GameLog.Debug("MainProcedureLogic.OnInit");
    }
    protected override void OnEnter()
    {
        GameLog.Debug("MainProcedureLogic.OnEnter");
    }
    protected override void OnLeave()
    {
        GameLog.Debug("MainProcedureLogic.OnLeave");
    }
    protected override void OnTick()
    {
        //GameLog.Debug("MainProcedureLogic.OnTick");
    }
}
