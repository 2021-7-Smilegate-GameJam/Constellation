using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public Image img;
    
    public StageModel model;
    private Button button;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(PassModel);
        button.onClick.AddListener(ClearStage);
        button.onClick.AddListener(PassModel);
    }

    private void PassModel()
    {
        var stageManager = Instantiate(Stages.instance.stageManagerPrefab);
        stageManager.GetComponent<obstruction>().stage = stageManager.GetComponent<TilemapLoop>().stage = model;
    }

    private void ClearStage()
    {
        Stages.instance.AddStar(new StarModel
        {
            modifier = model.modifier,
            position = transform.position,
            priority = model.priority
        });
    }
}
