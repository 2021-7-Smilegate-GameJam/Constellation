using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct StarModel
{
    public Vector3 position;
    public string modifier;
    public int priority;
}

public class Stages : Singleton<Stages>
{
    public Button endButton;
    public StageButton[] stageButtons;
    private List<StarModel> clearedStages = new List<StarModel>();

    public void AddStar(StarModel starModel)
    {
        clearedStages.Add(starModel);
    }

    public StarModel SelectStartStar()
    {
        return clearedStages[Random.Range(0, clearedStages.Count)];
    }
    
    private void DrawLine(StarModel model)
    {
        if (clearedStages.Count <= 0) return;
        
        clearedStages.Remove(model);
        var closest = clearedStages[0];
        
        for (int i = 1; i < clearedStages.Count; i++)
        {
            var dir = model.position - clearedStages[i].position;
            var distance = dir.sqrMagnitude;

            if ((model.position - closest.position).sqrMagnitude > distance)
            {
                closest = clearedStages[i];
            }
        }
        DrawLine(closest);
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        endButton.onClick.AddListener(() => DrawLine(SelectStartStar()));
    }
}
