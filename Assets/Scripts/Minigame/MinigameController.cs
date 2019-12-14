using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [Header("Win Condition")]
    [SerializeField]
    private float minMargin;
    [SerializeField]
    private float maxMargin;

    [Header("Arrow")]
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private float arrowMoveSpeed;
    [SerializeField]
    private List<float> arrowStartPositions = new List<float>();

    [SerializeField]
    private float imageWidth;

    private Player player;
    private Workbench workbench;

    private float currentArrowValue = 0.5f;
    private bool minigameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartMinigame(Player player, Workbench workbench)
    { 
        this.player = player;
        this.workbench = workbench;
        minigameActive = true;
        StartCoroutine(MoveArrow());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Player"+player.playerNum+"Interact"))
        {
            if(minigameActive)
            {
                FinishMinigame();
            }
        }
    }

    public void FinishMinigame()
    {
        minigameActive = false;

        if (currentArrowValue >= minMargin && currentArrowValue <= maxMargin)
        {
            //SUCCESS
        }
        else
        {
            //FAIL
        }

        Destroy(gameObject);
    }

    private IEnumerator MoveArrow()
    {
        float randomArrowDirection = Random.Range(-1, 1);
        int arrowDirection = (int)Mathf.Sign(randomArrowDirection);

        int randomArrowStartIndex = Random.Range(0, arrowStartPositions.Count - 1);
        currentArrowValue = arrowStartPositions[randomArrowStartIndex];

        Vector3 arrowPosition = new Vector3(arrow.transform.localPosition.x, arrow.transform.localPosition.y, arrow.transform.localPosition.z);

        float t = currentArrowValue;
        Debug.Log("1 " + t);
        float left = transform.position.x - (imageWidth / 2f);
        Debug.Log("2 " + left);
        float right = transform.position.x + (imageWidth / 2f);
        Debug.Log("3 " + right);
        float current = Mathf.Lerp(left, right, t);
        Debug.Log("4 " + current);

        while (minigameActive)
        {
            t += (Time.deltaTime * arrowMoveSpeed) * arrowDirection;

            current = Mathf.Lerp(left, right, t);
            arrowPosition.x = current;

            arrow.transform.localPosition = arrowPosition;

            if(t >= 1)
            {
                arrowDirection = -1;
            }
            else if(t <= 0)
            {
                arrowDirection = 1;
            }

            currentArrowValue = t;

            yield return null;
        }
    }
}
