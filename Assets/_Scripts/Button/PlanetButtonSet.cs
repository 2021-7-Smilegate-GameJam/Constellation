using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetButtonSet : MonoBehaviour
{
    private float mapLength;        //맵 총 길이
    private float radius;           //행성 반지름

    private float currZAngle;       //현재 z회전각도
    private float currFill;         //현재 fillamount;
  
    private List<double> obstaclePosList = new List<double>();         //오브젝트 x리스트
    private RectTransform buttonRect;
    
    [SerializeField] private GameObject renderImg;
    [SerializeField] private StageModel temp;
    [SerializeField] private Image gageAmount;
    public obstruction obs;
    [SerializeField] private RectTransform playerIcon;

    private List<obstruction_struct> obstaclceList = new List<obstruction_struct>();
    private Coroutine rotate = null;

    public GameObject stageSelect;

    private void Awake()
    {
        //스테이지 모델에서 정보 받아오기
        GetStageModelObstaclePos(temp);

        buttonRect = GetComponent<RectTransform>();
        radius = buttonRect.rect.width / 2;

        currZAngle = 0;
        currFill = 0;

        gageAmount.fillAmount = 0;

        playerIcon.position = buttonRect.position + Vector3.up * radius;
    }

    private void Start()
    {
        obstaclceList = obs.SpawnData;
        RenderObstacle();
        rotate = StartCoroutine(Rotate());
    }

    private void RenderObstacle()
    {

        for(int i = 0; i < obstaclePosList.Count; i++)
        {
            var newObj = Instantiate(renderImg, this.transform);
            //위치 조정
            newObj.GetComponent<RectTransform>().localPosition = SetObstacleOnPlanet(obstaclePosList[i]);
            //이미지 변경
            newObj.GetComponent<Image>().sprite = obstaclceList[i].monster.GetComponent<SpriteRenderer>().sprite;
            //회전 추가
            newObj.GetComponent<RectTransform>().Rotate(Vector3.forward * GetTheta(obstaclePosList[i]) * -1f);

        }
    }

    //직선 좌표를 원좌표(? 말이 이상하긴 한데 )로 변환
    //기준은 장애물의 중앙
    private Vector2 SetObstacleOnPlanet(double _previousX)
    {
        float theta = GetTheta(_previousX);
        float xPos = radius * Mathf.Sin(theta * Mathf.Deg2Rad);
        float yPos = radius * Mathf.Cos(theta * Mathf.Deg2Rad);

        return new Vector2(xPos, yPos);
    }

    private float GetTheta(double _previousX)
    {
        double ratio = (_previousX - 0) / 60;            //길이 비율
        float theta = (float)ratio * 360f;

        return theta;
    }

    public void GetStageModelObstaclePos(StageModel _stageModel)
    {
        foreach (var xPos in _stageModel.objectPositions)
        {
            obstaclePosList.Add(xPos);
        }
    }

    private IEnumerator Rotate()
    {
        //재시작시
        buttonRect.rotation = Quaternion.Euler(0, 0, currZAngle);
        gageAmount.fillAmount = currFill;

        while(gageAmount.fillAmount < 1)
        { 
            buttonRect.Rotate(Vector3.forward * 6 * Time.deltaTime);
            gageAmount.fillAmount += (1f / 60f) * Time.deltaTime;

            currZAngle = buttonRect.rotation.eulerAngles.z;
            currFill = gageAmount.fillAmount;

            yield return null;
        }

        buttonRect.rotation = Quaternion.identity;

        //transform.parent.GetChild(4).gameObject.SetActive(true);

        Instantiate(stageSelect);

        //게임 클리어
        GameObject.Find("Canvas(Clone)").SetActive(false);
        GameObject.Find("StageManager 1(Clone)").SetActive(false);
        
    }

    public void StopRotate()
    {
        StopCoroutine(rotate);
    }

}


