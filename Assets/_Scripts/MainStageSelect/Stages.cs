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
    [SerializeField]
    private LineRenderer lineRenderer;

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
        
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, model.position);
        
        var closest = new StarModel
        {
            position = new Vector3(99999f,99999f,0f)
        };
        
        Debug.Log($"{clearedStages.Remove(model)}, pos : {model.position}");

        for (int i = 0; i < clearedStages.Count; i++)
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
