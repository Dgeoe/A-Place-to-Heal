using UnityEngine;

public class NoxyaFaceScript : MonoBehaviour
{
    public float offset;

    Renderer m_ObjectRenderer;
    void Start()
    {
        //Fetch the GameObject's Renderer component
        m_ObjectRenderer = GetComponent<Renderer>();



        m_ObjectRenderer.materials[2].mainTextureOffset = new Vector2(offset, 1);
    }
    void Update()
    {
        //Fetch the GameObject's Renderer component
        m_ObjectRenderer = GetComponent<Renderer>();


        // m_ObjectRenderer.materials[0].SetTextureOffset("_TextureName", new Vector2(offset, 0));
        //m_ObjectRenderer.materials[0].SetFloat(1, 1);
        //m_ObjectRenderer.materials[0].color = Color.red;
        m_ObjectRenderer.materials[2].mainTextureOffset = new Vector2(offset, 1);
    }
}
