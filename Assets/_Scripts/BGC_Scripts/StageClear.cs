using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public static StageClear StageCleardata;
    // Start is called before the first frame update
    public List<StageModel> stages = new List<StageModel>();
    void Awake()
    {
        if (StageCleardata == null)
        {
            DontDestroyOnLoad(gameObject);
            StageCleardata = this;
        }
        else if (StageCleardata != this)
        {
            Destroy(gameObject);
        }
    }



}
