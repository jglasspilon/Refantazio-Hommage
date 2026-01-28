using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Renderer))]
public class SpriteToMaterialComponent: MonoBehaviour
{
    [SerializeField]
    private Sprite m_sprite;

    public void ApplySprite()
    {
        Material targetMaterial = GetComponent<Renderer>().sharedMaterial;
        if (m_sprite == null || targetMaterial == null)
        {
            Debug.LogWarning("SpriteToMaterial: Missing sprite or material.");
            return;
        }

        Texture2D tex = m_sprite.texture;
        Rect r = m_sprite.textureRect;

        Vector2 scale = new Vector2(
            r.width / tex.width,
            r.height / tex.height
        );

        Vector2 offset = new Vector2(
            r.x / tex.width,
            r.y / tex.height
        );

        targetMaterial.SetTexture("_MainTex", tex);
        targetMaterial.SetVector("_UVScale", scale);
        targetMaterial.SetVector("_UVOffset", offset);
    }

}
