using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Transform orbitCenter; // L'objet autour duquel cet objet va orbiter
    public float orbitLength = 5f; // La longueur (rayon) de l'orbite
    public float orbitWidth = 5f; // La largeur de l'orbite
    public float orbitSpeed = 50f; // La vitesse de l'orbite
    public float inclinationAngle = 0f; // L'angle d'inclinaison de l'orbite
    [Range(0, 100)] public float startPercentage = 0f; // Le pourcentage de départ de l'animation d'orbite
    public Vector3 additionalRotation = Vector3.zero; // Rotation additionnelle pour orienter correctement l'objet

    private float orbitAngle = 0f; // L'angle actuel de l'objet dans l'orbite

    void Start()
    {
        // Calcule l'angle de départ basé sur le pourcentage donné
        orbitAngle = (360f * startPercentage) / 100f;
    }

    void Update()
    {
        if (orbitCenter == null)
        {
            Debug.LogError("Orbit center not set for " + gameObject.name);
            return;
        }

        // Incrémente l'angle pour simuler le mouvement de l'orbite
        orbitAngle += orbitSpeed * Time.deltaTime;
        orbitAngle %= 360f; // Garde l'angle entre 0 et 360

        // Calcule la nouvelle position de l'objet en orbite en tenant compte de l'inclinaison
        float radianOrbitAngle = orbitAngle * Mathf.Deg2Rad;
        float radianInclinationAngle = inclinationAngle * Mathf.Deg2Rad;

        // Applique l'inclinaison
        float xPosition = Mathf.Cos(radianOrbitAngle) * orbitLength;
        float yPosition = Mathf.Sin(radianOrbitAngle) * Mathf.Sin(radianInclinationAngle) * orbitWidth;
        float zPosition = Mathf.Sin(radianOrbitAngle) * Mathf.Cos(radianInclinationAngle) * orbitWidth;

        // Définit la position de l'objet en orbite relative au centre de l'orbite
        transform.position = orbitCenter.position + new Vector3(xPosition, yPosition, zPosition);

        // Oriente l'objet pour qu'il regarde toujours vers le centre de l'orbite
        transform.LookAt(orbitCenter.position);

        // Applique la rotation additionnelle pour orienter correctement l'objet
        transform.Rotate(additionalRotation, Space.Self);
    }
}