using UnityEngine;

public class ConveyorBeltMovement : MonoBehaviour
{
    public float speed = 1.0f; // —корость движени€ текстуры
    private Renderer meshRenderer;
    private Material material;

    void Start()
    {
        // ѕолучаем компоненты Renderer и Material
        meshRenderer = GetComponent<Renderer>();
        material = meshRenderer.material;
    }

    void Update()
    {
        // ѕолучаем текущие текстурные координаты материала
        Vector2 offset = material.GetTextureOffset("_MainTex");

        // ¬ычисл€ем новые текстурные координаты, основыва€сь на времени и скорости
        offset.x += speed * Time.deltaTime;

        // ѕримен€ем новые текстурные координаты к материалу
        material.SetTextureOffset("_MainTex", offset);
    }
}
