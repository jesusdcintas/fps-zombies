# Configuración de la Linterna (Flashlight)

## Descripción
Se ha agregado la funcionalidad de una linterna que se puede encender/apagar presionando la tecla **F**.

## Archivos Modificados/Creados

### 1. **Flashlight.cs** (Nuevo)
- **Ubicación**: `Assets/Infima Games/Low Poly Shooter Pack - Free Sample/Code/Character/Flashlight.cs`
- Componente que controla el encendido/apagado de la linterna
- Maneja el input de teclado (tecla F)
- Interactúa con un componente `Light` asignable en el Inspector

### 2. **InputManager.cs** (Nuevo)
- **Ubicación**: `Assets/Infima Games/Low Poly Shooter Pack - Free Sample/Code/Input/InputManager.cs`
- Componente que automáticamente conecta los callbacks de input
- Suscribe el evento "Flashlight" al método `OnToggleFlashlight()` del componente Flashlight
- Recomendado agregarlo al GameObject del jugador para automatizar la configuración

### 3. **IA_Player.inputactions** (Modificado)
- **Ubicación**: `Assets/Infima Games/Low Poly Shooter Pack - Free Sample/Input/IA_Player.inputactions`
- Se agregó la acción `"Flashlight"` (tipo Button)
- Se agregó el binding para la tecla `<Keyboard>/f`

## Cómo Configurar

### Paso 1: Crear/Asignar una Luz
1. En la escena, selecciona el GameObject del jugador (el que tiene el componente `Character`)
2. En el Inspector, busca o crea un objeto con un componente `Light` (puede ser un hijo del jugador)
   - Si no tienes una luz, crea un objeto vacío como hijo del jugador
   - Haz clic derecho en el GameObject → 3D Object → Light (selecciona el tipo de luz que prefieras: Spotlight, Point Light, etc.)
3. Nota el nombre del GameObject que contiene la luz

### Paso 2: Agregar los Componentes
1. **InputManager** (recomendado para automatización):
   - En el GameObject del jugador (que tiene `Character`), haz clic en "Add Component"
   - Busca y agrega el script `InputManager`
   - Este script automáticamente conectará la entrada de la linterna

2. **Flashlight**:
   - En el GameObject del jugador, haz clic en "Add Component"
   - Busca y agrega el script `Flashlight`
   - En el Inspector, verás un campo "Light"
   - Arrastra y suelta el GameObject que contiene el componente `Light` al campo, o selecciona la luz

### Paso 3: Verificar la Configuración
- El `InputManager` debería automatizar todo
- Si prefieres conectar manualmente el callback:
  1. En el Inspector del GameObject del jugador, selecciona el componente `PlayerInput`
  2. En el apartado de eventos, busca la acción "Flashlight"
  3. Haz clic en el "+" para agregar un listener
  4. Arrastra el GameObject con el script `Flashlight` al campo de referencia
  5. En el dropdown de función, selecciona `Flashlight.OnToggleFlashlight()`

## Uso en Juego
- Presiona **F** para encender/apagar la linterna
- La linterna solo funcionará si el cursor del juego está bloqueado (durante el juego)
- La luz se encenderá/apagará según el componente Light que hayas asignado

## Personalización

### Cambiar la Tecla de la Linterna
1. Abre el archivo `IA_Player.inputactions`
2. Busca el binding para "Flashlight"
3. Cambia la ruta del binding (por ejemplo, de `<Keyboard>/f` a `<Keyboard>/l`)
4. Guarda y Unity recompilará automáticamente

### Cambiar Propiedades de la Luz
Una vez que la luz esté asignada en el componente Flashlight, puedes ajustar en el Inspector:
- Intensidad de la luz
- Color de la luz
- Rango de la luz
- Tipo de sombra

## Estructura del Código

### Flashlight.cs
```csharp
public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private Light flashlightLight;  // La luz a controlar
    
    private bool flashlightActive;  // Estado actual
    
    public void OnToggleFlashlight(InputAction.CallbackContext context)
    {
        // Maneja el evento de input
    }
    
    private void ToggleFlashlight()
    {
        // Alterna el estado de la luz
    }
}
```

## Troubleshooting

**La linterna no funciona:**
- Verifica que el componente Light esté asignado en el script Flashlight
- Comprueba que el cursor del juego esté bloqueado (presiona ESC para cerrar el menú si es necesario)
- Asegúrate de que el script Flashlight esté en el GameObject correcto o en un hijo
- Verifica que el InputManager esté presente en el GameObject del jugador

**La tecla F no funciona:**
- Verifica que el InputActionAsset esté correctamente configurado
- Comprueba que no haya otra acción que esté usando la tecla F
- Asegúrate de que el PlayerInput component esté habilitado

**El InputManager no conecta el callback:**
- Verifica que el PlayerInput component tenga un InputActionAsset asignado
- Comprueba que exista una acción llamada "Flashlight" en el asset
- Asegúrate de que el componente Flashlight esté en el mismo GameObject o en sus hijos

**La luz no cambia de estado:**
- Verifica que el componente Light tenga la propiedad `enabled` correctamente
- Comprueba que la luz no esté siendo controlada por otro script
- Intenta cambiar manualmente el estado de la luz en el Inspector para verificar que funciona
