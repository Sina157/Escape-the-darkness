using UnityEngine;

public class GlowySphere : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float pulseSpeed = 2f;
    public float minEmission = 1f;
    public float maxEmission = 4f;

    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        // چرخش آرام که حس زندگی بده
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // پالس درخشش
        float emission = Mathf.Lerp(minEmission, maxEmission,
            (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);

        Color baseColor = Color.yellow;
        mat.SetColor("_EmissionColor", baseColor * emission);
    }
}
