using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public Image img;
    public static GameObject stageSelectionParent;
    public static GameObject circleRenderMiniMap;
    public StageModel model;
    private Button button;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(PassModel);
        button.onClick.AddListener(ClearStage);
        button.onClick.AddListener(PassModel);
        button.onClick.AddListener(() => stageSelectionParent.SetActive(false));
    }

    private void PassModel()
    {
        var stageManager = Instantiate(Stages.instance.stageManagerPrefab);
        var obs = stageManager.GetComponent<obstruction>();
        obs.stage = stageManager.GetComponent<TilemapLoop>().stage = model;
        var miniRenderer = Instantiate(circleRenderMiniMap);
        miniRenderer.GetComponentInChildren<PlanetButtonSet>().obs = obs;
        miniRenderer.GetComponentInChildren<PlanetButtonHandle>().playerAnim =
            stageManager.GetComponentInChildren<Animator>();
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
