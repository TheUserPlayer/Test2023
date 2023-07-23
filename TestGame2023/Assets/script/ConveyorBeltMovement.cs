using UnityEngine;

public class ConveyorBeltMovement : MonoBehaviour
{
    public float speed = 1.0f; // �������� �������� ��������
    private Renderer meshRenderer;
    private Material material;

    void Start()
    {
        // �������� ���������� Renderer � Material
        meshRenderer = GetComponent<Renderer>();
        material = meshRenderer.material;
    }

    void Update()
    {
        // �������� ������� ���������� ���������� ���������
        Vector2 offset = material.GetTextureOffset("_MainTex");

        // ��������� ����� ���������� ����������, ����������� �� ������� � ��������
        offset.x += speed * Time.deltaTime;

        // ��������� ����� ���������� ���������� � ���������
        material.SetTextureOffset("_MainTex", offset);
    }
}
