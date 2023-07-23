using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public TMP_Text taskText;
    public TMP_Text taskTextEnd;
    private string[] fruitTypes = { "Apples", "Pears", "Peaches" };
    private int[] requiredFruits = new int[3];
    private int[] collectedFruits = new int[3];
    public Camera[] cameras; // ������ ���� ����� � �����
    public static TaskManager Instance { get; private set; }
    private static int currentCameraIndex = 0;
    public GameObject Obj;
    public GameObject ObjSpawn;
    public GameObject MainCam;
    public GameObject Cam;
    public GameObject BT;
    public IKController Ik;
    public ObjectMover Move;


    // ���������� ��� ������ ���� ��� ��������� �������
    private void Start()
    {
        GenerateTask();
        UpdateTaskText();
    }

    // ����� ��� ��������� ������ �������
    private void GenerateTask()
    {
        for (int i = 0; i < fruitTypes.Length; i++)
        {
            requiredFruits[i] = Random.Range(1, 6);
            collectedFruits[i] = 0;
        }
 
    }

    // ������ ��� ���������� �������� ��������� �������
    public void AddFruit(int index)
    {
        collectedFruits[index]++;
        CheckCompletion();
        UpdateTaskText();
    }

    // ����� ��� ���������� ������ � ������� ��������
    private void UpdateTaskText()
    {
        string taskDescription = "Collect:\n";
        for (int i = 0; i < fruitTypes.Length; i++)
        {
            taskDescription += string.Format("{0} {1}/{2}\n", fruitTypes[i], collectedFruits[i], requiredFruits[i]);
        }

        taskText.text = taskDescription;
    }

    // ����� ��� �������� ���������� �������
    private void CheckCompletion()
    {
        for (int i = 0; i < fruitTypes.Length; i++)
        {
            if (collectedFruits[i] < requiredFruits[i])
                return;
        }

        Debug.Log("Task Completed!");
        OnTaskCompleted(); // �������� ������ �����, ����� ���������� ���������� �������
        GenerateTask();
    }

    // ��������� �����, ����������, ����� ������� ���������
    public void OnTaskCompleted()
    {
        taskText.enabled = false;
        taskTextEnd.enabled = true;
        BT.SetActive(true);
        Obj.SetActive(false);
        ObjSpawn.SetActive(false);
        MainCam.SetActive(false);
        Cam.SetActive(true);
        DeleteObjectsWithFruitTags();
        Move.MoveToTarget();
        Ik.AnimEnd();
    }
    public void DeleteObjectsWithFruitTags()
    {
        string[] fruitTags = { "Apple", "Peach", "pear" };
        DeleteObjectsWithTags(fruitTags);
    }

    private void DeleteObjectsWithTags(string[] tags)
    {
        foreach (string tag in tags)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
        }
    }
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}

