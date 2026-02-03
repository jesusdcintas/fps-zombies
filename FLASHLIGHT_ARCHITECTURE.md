# Diagrama de Funcionamiento - Linterna

## Flujo de Entrada

```
Presiona Tecla F
        ↓
InputActionAsset detecta "Flashlight" action
        ↓
InputManager suscribe y pasa al callback
        ↓
Flashlight.OnToggleFlashlight() se ejecuta
        ↓
ToggleFlashlight() alterna el estado
        ↓
Light.enabled = true/false
        ↓
La luz se enciende/apaga visualmente
```

## Estructura de Componentes en la Escena

```
PlayerGameObject (GameObject del Jugador)
├── Character (Component) ← Controlador principal
├── CharacterKinematics (Component)
├── Rigidbody (Component)
├── PlayerInput (Component) ← Maneja el InputActionAsset
├── InputManager (Component) ✨ NUEVO ← Conecta los callbacks
├── Flashlight (Component) ✨ NUEVO ← Controla la linterna
│
└── CameraHolder (Objeto Hijo)
    ├── MainCamera (Componente)
    │
    └── FlashlightObject (Objeto Hijo) ✨ NUEVO
        └── Light (Component Spotlight/Point Light) ← La luz física
```

## Ciclo de Vida

### Inicialización
1. **Escena se carga**
2. **PlayerGameObject Awake():**
   - Character se inicializa
   - InputManager se inicializa
   - Flashlight se inicializa
3. **PlayerGameObject Start():**
   - InputManager busca el componente Flashlight
   - InputManager busca la acción "Flashlight"
   - InputManager suscribe `flashlight.OnToggleFlashlight` al evento

### En Juego
1. **Usuario presiona F**
2. **PlayerInput detecta la acción "Flashlight"**
3. **InputManager notifica a Flashlight**
4. **Flashlight.OnToggleFlashlight() verifica:**
   - ¿El cursor está bloqueado?
   - ¿Fue presionado (Performed)?
5. **Si es válido, ejecuta ToggleFlashlight():**
   - `flashlightActive = !flashlightActive`
   - `flashlightLight.enabled = flashlightActive`
6. **La luz se enciende o apaga**

### Limpieza
1. **Escena se descarga o GameObject se destruye**
2. **InputManager.OnDestroy() se ejecuta**
3. **Se desuscribe el callback para evitar memory leaks**

## Configuración de Archivos

### IA_Player.inputactions (JSON)
```json
{
  "actions": [
    // ... otras acciones ...
    {
      "name": "Flashlight",     ← Nombre de la acción
      "type": "Button",
      "id": "f7a8c9d0-1e2f...",
      "expectedControlType": "Button"
    }
  ],
  "bindings": [
    // ... otros bindings ...
    {
      "path": "<Keyboard>/f",    ← La tecla F
      "action": "Flashlight"
    }
  ]
}
```

## Variables de Control

### Flashlight.cs
- `flashlightLight` → Reference al componente Light
- `flashlightActive` → Estado actual (true = encendido, false = apagado)
- `playerCharacter` → Reference al personaje para verificar si el cursor está bloqueado

### InputManager.cs
- `playerInput` → Reference al componente PlayerInput
- `flashlight` → Reference al componente Flashlight

## Métodos Principales

### Flashlight.OnToggleFlashlight(InputAction.CallbackContext context)
Punto de entrada desde el Input System. Verifica que sea válido y llama a ToggleFlashlight()

### Flashlight.ToggleFlashlight()
Alterna el estado de la luz (encendida/apagada)

### InputManager.Start()
Conecta automáticamente el callback de input

### InputManager.OnDestroy()
Desconecta el callback para evitar fugas de memoria

## Debugging

Para verificar que todo funciona, puedes agregar logs:

```csharp
// En Flashlight.OnToggleFlashlight()
Debug.Log("Flashlight Toggle Attempted");

// En Flashlight.ToggleFlashlight()
Debug.Log($"Flashlight is now: {(flashlightActive ? "ON" : "OFF")}");
```
