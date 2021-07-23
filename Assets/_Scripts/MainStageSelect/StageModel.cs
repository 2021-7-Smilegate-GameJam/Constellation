using UnityEngine;

[CreateAssetMenu(fileName = "StageModel", menuName = "ScriptableObject/StageModel", order = 0)]
public class StageModel : ScriptableObject
{
    public float rollingSpeed; // 장애물이 화면 밖에서 나타나는 속도
    public double[] objectPositions;
    // 맵은 처음 시작 지점이 0이고, 끝 지점을 60으로 정의합니다.
    // 또한, 모든 스테이지는 딱 1분간 달리는 것으로 정의합니다.
    // objectPositions 배열에는 해당 맵에 들어가는 장애물의 위치를 0에서 60 사이의 값으로 저장함.
    // ex) objectPositions = new [] {10, 20, 30, 40, 50};
    // 위와 같은 경우 10초에 한번씩 장애물이 맵에서 등장한다는 것을 의미합니다.
    public string modifier;
    public int priority;
    // modifier는 해당 맵을 클리어하면 별자리에 들어갈 수 있는 수식어를 의미합니다.
    // priority는 해당 수식어의 우선순위를 뜻합니다. 낮을수록 우선순위가 높습니다.
}