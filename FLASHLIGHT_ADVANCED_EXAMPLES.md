# Ejemplos Avanzados - Linterna

## 1. Linterna con Batería/Energía

Extender `Flashlight.cs` para agregar un sistema de batería:

```csharp
public class FlashlightWithBattery : Flashlight
{
    [SerializeField]
    private float batteryCapacity = 100f;
    
    [SerializeField]
    private float batteryDrainRate = 10f; // % por segundo
    
    private float currentBattery;
    
    private void Awake()
    {
        currentBattery = batteryCapacity;
    }
    
    private void Update()
    {
        // Si la luz está encendida, consume batería
        if (flashlightLight != null && flashlightLight.enabled)
        {
            currentBattery -= batteryDrainRate * Time.deltaTime;
            
            // Si se agota, apagar
            if (currentBattery <= 0)
            {
                currentBattery = 0;
                flashlightLight.enabled = false;
            }
        }
    }
    
    private void OnGUI()
    {
        // Mostrar nivel de batería
        GUI.Label(new Rect(10, 10, 200, 30), 
            $"Batería: {currentBattery:F0}%");
    }
}
```

## 2. Linterna con Parpadeo

Agregar efecto de parpadeo a la linterna:

```csharp
public class FlashlightWithFlicker : Flashlight
{
    [SerializeField]
    private float flickerSpeed = 10f;
    
    [SerializeField]
    private float flickerIntensity = 0.2f;
    
    private float originalIntensity;
    
    private void Start()
    {
        if (flashlightLight != null)
            originalIntensity = flashlightLight.intensity;
    }
    
    private void Update()
    {
        if (flashlightLight != null && flashlightLight.enabled)
        {
            // Crear efecto de parpadeo
            float flicker = Mathf.Sin(Time.time * flickerSpeed) * flickerIntensity;
            flashlightLight.intensity = originalIntensity + flicker;
        }
    }
}
```

## 3. Linterna con Sonido

Agregar efectos de sonido al encender/apagar:

```csharp
public class FlashlightWithSound : Flashlight
{
    [SerializeField]
    private AudioClip turnOnSound;
    
    [SerializeField]
    private AudioClip turnOffSound;
    
    private AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }
    
    protected override void ToggleFlashlight()
    {
        if (flashlightLight == null)
            return;
        
        flashlightActive = !flashlightActive;
        flashlightLight.enabled = flashlightActive;
        
        // Reproducir sonido
        if (flashlightActive && turnOnSound != null)
            audioSource.PlayOneShot(turnOnSound);
        else if (!flashlightActive && turnOffSound != null)
            audioSource.PlayOneShot(turnOffSound);
    }
}
```

## 4. Linterna con Raycast Detecta Objetos

Ver qué hay iluminado:

```csharp
public class FlashlightWithDetection : Flashlight
{
    [SerializeField]
    private float raycastDistance = 50f;
    
    [SerializeField]
    private LayerMask detectionLayer;
    
    private void Update()
    {
        if (flashlightLight == null || !flashlightLight.enabled)
            return;
        
        // Raycast desde la luz
        if (Physics.Raycast(flashlightLight.transform.position, 
                           flashlightLight.transform.forward, 
                           out RaycastHit hit, 
                           raycastDistance, 
                           detectionLayer))
        {
            Debug.Log($"Flashlight ilumina: {hit.collider.gameObject.name}");
            
            // Hacer algo con lo detectado
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("¡Enemigo detectado!");
            }
        }
    }
}
```

## 5. Linterna Multicolor

Cambiar color de la luz con un botón:

```csharp
public class FlashlightMultiColor : Flashlight
{
    [SerializeField]
    private Color[] lightColors = new Color[]
    {
        Color.white,
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow
    };
    
    private int currentColorIndex = 0;
    
    public void CycleColor()
    {
        if (flashlightLight == null)
            return;
        
        currentColorIndex = (currentColorIndex + 1) % lightColors.Length;
        flashlightLight.color = lightColors[currentColorIndex];
    }
    
    public void SetColor(int colorIndex)
    {
        if (flashlightLight == null || colorIndex < 0 || colorIndex >= lightColors.Length)
            return;
        
        currentColorIndex = colorIndex;
        flashlightLight.color = lightColors[colorIndex];
    }
}
```

## 6. Linterna con Intensidad Variable

Control de brillo con rueda del ratón:

```csharp
public class FlashlightAdjustableIntensity : Flashlight
{
    [SerializeField]
    private float minIntensity = 0.5f;
    
    [SerializeField]
    private float maxIntensity = 3f;
    
    private float currentIntensity;
    
    private void Start()
    {
        if (flashlightLight != null)
        {
            currentIntensity = flashlightLight.intensity;
        }
    }
    
    private void Update()
    {
        if (flashlightLight == null || !flashlightLight.enabled)
            return;
        
        // Cambiar intensidad con scroll del ratón
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta != 0)
        {
            currentIntensity += scrollDelta * 0.5f;
            currentIntensity = Mathf.Clamp(currentIntensity, minIntensity, maxIntensity);
            flashlightLight.intensity = currentIntensity;
        }
    }
}
```

## 7. Sistema de Múltiples Linernas

Cambiar entre diferentes tipos de luz:

```csharp
public class MultiFlashlight : MonoBehaviour
{
    [System.Serializable]
    public struct FlashlightOption
    {
        public Light light;
        public string name;
        public KeyCode activationKey;
    }
    
    [SerializeField]
    private FlashlightOption[] flashlights;
    
    private int activeIndex = 0;
    
    private void Start()
    {
        // Apagar todas excepto la primera
        for (int i = 1; i < flashlights.Length; i++)
            if (flashlights[i].light != null)
                flashlights[i].light.enabled = false;
    }
    
    private void Update()
    {
        for (int i = 0; i < flashlights.Length; i++)
        {
            if (Input.GetKeyDown(flashlights[i].activationKey))
            {
                // Apagar la anterior
                if (flashlights[activeIndex].light != null)
                    flashlights[activeIndex].light.enabled = false;
                
                // Activar la nueva
                activeIndex = i;
                if (flashlights[activeIndex].light != null)
                    flashlights[activeIndex].light.enabled = true;
                
                Debug.Log($"Linterna activa: {flashlights[activeIndex].name}");
            }
        }
    }
}
```

## 8. Integración con HUD

Mostrar estado de la linterna en la interfaz:

```csharp
public class FlashlightHUD : MonoBehaviour
{
    [SerializeField]
    private Flashlight flashlight;
    
    [SerializeField]
    private Image flashlightIndicator;
    
    [SerializeField]
    private Text statusText;
    
    private void Update()
    {
        if (flashlight.flashlightLight != null)
        {
            bool isOn = flashlight.flashlightLight.enabled;
            
            // Cambiar color del indicador
            flashlightIndicator.color = isOn ? Color.yellow : Color.gray;
            
            // Actualizar texto
            statusText.text = isOn ? "Linterna: ON" : "Linterna: OFF";
        }
    }
}
```

## 9. Linterna con Patrón de Luz

Proyectar un patrón con la linterna:

```csharp
public class FlashlightWithPattern : Flashlight
{
    [SerializeField]
    private float rotationSpeed = 45f;
    
    private void Update()
    {
        if (flashlightLight != null && flashlightLight.enabled)
        {
            // Rotar la luz
            flashlightLight.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
```

## 10. Linterna con Cooldown

Agregar tiempo de espera entre encendidos/apagados:

```csharp
public class FlashlightWithCooldown : Flashlight
{
    [SerializeField]
    private float toggleCooldown = 0.3f;
    
    private float lastToggleTime;
    
    protected override void OnToggleFlashlight(InputAction.CallbackContext context)
    {
        if (Time.time - lastToggleTime < toggleCooldown)
            return;
        
        base.OnToggleFlashlight(context);
        lastToggleTime = Time.time;
    }
}
```

## Cómo Usar Estos Ejemplos

1. **Copia el código** que te interese
2. **Crea un nuevo archivo** con el nombre sugerido
3. **Hereda de Flashlight** o modifica la clase base
4. **Agrega el componente** al GameObject
5. **Configura los valores** en el Inspector

## Notas Importantes

- Algunos ejemplos requieren componentes adicionales (AudioSource, etc.)
- Asegúrate de que el espacio de nombres sea correcto
- Prueba cada ejemplo en el Editor antes de hacer build
- Algunos ejemplos pueden ser combinados para obtener funcionalidades complejas

---

¿Deseas implementar alguno de estos ejemplos? ¡Avísame! 🚀
