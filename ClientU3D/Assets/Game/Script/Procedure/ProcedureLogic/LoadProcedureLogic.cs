using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using GameCore;

public class LoadProcedureLogic : IProcedureLogic<LoadProcedure>
{
    public Text _txtPercent = null;

    // 仅供演示使用
    private int _percent = 0;
    private float _lastPercentTime = 0;

    #region callback
    protected override void OnInit()
    {
        _lastPercentTime = Time.fixedTime;
        _SetLoadPercent(0);
    }
    protected override void OnEnter()
    {
        GameContext.tableModule = new TableModule();
        GameContext.tableModule.Load();
    }
    protected override void OnLeave()
    {
    }
    protected override void OnTick()
    {
        // 仅供演示用
        if ((Time.fixedTime - _lastPercentTime) > 0.01) {
            _percent += 5;
            _lastPercentTime = Time.fixedTime;
            _SetLoadPercent(_percent);
        }

        if (procedure.isLoadDone) {
            string nextProcedure = GameContext.gameConfig.targetProcedure;
            int nextSceneId = GameContext.gameConfig.targetSceneId;
            if (!string.IsNullOrEmpty(nextProcedure)) {
                GameContext.procedureSrv.ChangeProcedure(nextProcedure, nextSceneId);
            }
        }
    }
    #endregion

    #region loading bar
    private void _SetLoadPercent(int percent)
    {
        percent = Math.Max(percent, 0);
        percent = Math.Min(percent, 100);
        if (_txtPercent != null) {
            _txtPercent.text = string.Format("{0}%", percent);
        }
        if (percent == 100) {
            procedure.isLoadDone = true;
        }
    }
    #endregion
}
