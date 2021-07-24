using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject stageManagerPrefab;
    
    [SerializeField]
    private Button endButton;
    
    [SerializeField]
    private LineRenderer lineRenderer; // 캔버스 하위에 달려있는 오브젝트는 안됨. 일반 오브젝트에 있는거 써야 렌더링 됨.

    [SerializeField]
    private Text name; // 별자리 이름 보여줄 그것.
    
    public StageButton[] stageButtons;
    private List<StarModel> clearedStages = new List<StarModel>();

    public void AddStar(StarModel starModel)
    {
        clearedStages.Add(starModel);
    }

    private StarModel SelectStartStar()
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

    private string MakeName()
    {
        var name = "Zodiac";
        var modifier = "Just";
        if (clearedStages.Count > 3)
        {
            name = "Lights";
        }
        if (clearedStages.Count > 6)
        {
            name = "Light of the night sky";
        }

        if (clearedStages.Count > 10)
        {
            name = "MILKY WAY";
        }

        var modifiers = clearedStages.OrderBy(stage => stage.priority).ToArray();
        var modifierStrings = modifiers.Where(stage => stage.priority == modifiers[0].priority).Select(stage => stage.modifier)
            .ToArray();
        modifier = modifierStrings[Random.Range(0, modifierStrings.Length)];

        return $"{modifier} {name}";
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        endButton.onClick.AddListener(() =>
        {
            name.text = MakeName();
            DrawLine(SelectStartStar());
        });
    }
}
