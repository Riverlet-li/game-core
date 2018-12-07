using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using GameCore;

public class GameProcedureLogic : IProcedureLogic<GameProcedure>
{
    public Text _txtPercent = null;
    public Image _imgBackground = null;

    private int _targetPercent = 0;
    private int _curPercent = 0;
    private float _lastPercentTime = 0;


    private ConfigScene cfgScene = null;

    #region callback
    protected override void OnInit()
    {
        _lastPercentTime = Time.fixedTime;
        _SetLoadPercent(0);
        _EnableLoadingBar(true);
    }
    protected override void OnEnter()
    {
        cfgScene = GameContext.tableModule.GetConfigScene(procedure.sceneId);
        if (cfgScene != null) {
            StartCoroutine("SceneBuilder");
        }
    }
    protected override void OnLeave()
    {
    }
    protected override void OnTick()
    {
        // 仅供演示用
        if (_curPercent < _targetPercent && (Time.fixedTime - _lastPercentTime) > 0.01) {
            _curPercent += 1;
            _lastPercentTime = Time.fixedTime;
            _UpdateLoadPercent(_curPercent);
        }
        if (_targetPercent >= 100 && _curPercent == _targetPercent) {
            _EnableLoadingBar(false);
        }
    }
    #endregion

    #region loading bar
    private void _SetLoadPercent(int percent)
    {
        _targetPercent = Math.Max(percent, 0);
        _targetPercent = Math.Min(percent, 100);

        if (_targetPercent == 100) {
            procedure.isLoadDone = true;
        }
    }

    private void _UpdateLoadPercent(int percent)
    {
        if (_txtPercent != null) {
            _txtPercent.text = string.Format("{0}%", percent);
        }
    }

    private void _EnableLoadingBar(bool enable)
    {
        if (_imgBackground != null) {
            _imgBackground.gameObject.SetActive(enable);
        }
        if (_txtPercent != null) {
            _txtPercent.gameObject.SetActive(enable);
        }
    }
    #endregion

    #region build SceneObj
    IEnumerator SceneBuilder()
    {
        SceneService sceneSrv = GameContext.sceneSrv;
        sceneSrv.CreateSceneObj(cfgScene);
        _SetLoadPercent(5);
        yield return new WaitForSeconds(1);

        sceneSrv.LoadMapRes();
        _SetLoadPercent(20);
        yield return new WaitForSeconds(1);

        sceneSrv.LoadMapInfo();
        _SetLoadPercent(50);
        yield return new WaitForSeconds(1);
        UserObj user = null;
        sceneSrv.AddUserSelf(user);

        UserObj userOther = null;
        sceneSrv.AddUserOther(userOther);

        NpcObj npc = null;
        sceneSrv.AddNpcObj(npc);
        _SetLoadPercent(80);
        yield return new WaitForSeconds(1);

        sceneSrv.LoadStory();
        sceneSrv.LoadUI();
        _SetLoadPercent(100);
        yield return new WaitForSeconds(1);
    }
    #endregion
}
