using System.Collections;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    public static StartArea Instance;

    [SerializeField] GameObject SummonEffect1;
    [SerializeField] GameObject SummonEffect2;
    [SerializeField] ChirnoManager ChirnoBallPrefab;
    [SerializeField] ChirnoObject ChirnoFacePrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    { 
        if(ChirnoManager.Instance != null) DestroyImmediate(ChirnoManager.Instance);
        if(ChirnoObject.Instance != null) DestroyImmediate(ChirnoObject.Instance);
        
        StartCoroutine(ChirnoSpawn());
    }

    public IEnumerator ChirnoSpawn()
    { 
        GameObject effect1 = Instantiate(SummonEffect1, transform);
        effect1.transform.position = transform.position;
        yield return new WaitForSeconds(0.3f);
        GameObject effect2 = Instantiate(SummonEffect2, transform);
        effect1.transform.position = transform.position + Vector3.up * 1.25f;
        yield return new WaitForSeconds(0.2f);
        ChirnoManager chirno = Instantiate<ChirnoManager>(ChirnoBallPrefab);
        ChirnoObject chFace = Instantiate<ChirnoObject>(ChirnoFacePrefab);
        chirno.ChirnoFace = chFace.GetComponent<SpriteRenderer>();
        chirno.transform.position = transform.position + Vector3.up * 1.5f;
        chFace.chirnoManager = chirno;
        CursorManager.Instance.chirno = chirno;
        UI_Mapper.Instance.Register();
        yield return new WaitForSeconds(0.2f);


        Destroy(effect1);
        Destroy(effect2);
    }

}
