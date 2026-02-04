# Referencia Rápida - Linterna

## ¿Qué es?
Sistema de linterna que se controla con la tecla **F**. Enciende/apaga una luz asignable.

## Instalación (2 minutos)

```
1. Crea una Light en la escena
   → Haz clic derecho en Player → 3D Object → Light

2. Agrega scripts al Player:
   → Add Component → InputManager
   → Add Component → Flashlight

3. Asigna la luz:
   → En Flashlight → arrastrar la Light al campo
```

## Archivos Principales

| Archivo | Para Qué | Ubicación |
|---------|----------|-----------|
| **Flashlight.cs** | Controla la luz | `/Code/Character/` |
| **InputManager.cs** | Conecta input | `/Code/Input/` |
| **IA_Player.inputactions** | Config de tecla | `/Input/` |

## Uso en Juego

```
Presiona F → Linterna enciende/apaga
```

## Cambiar Tecla

Edita `IA_Player.inputactions`:
```json
"path": "<Keyboard>/f"  ← Cambiar aquí
```

Opciones: `e`, `l`, `x`, `g`, etc.

## Personalizar la Luz

En el Inspector de la luz:
- **Intensity:** 0-3 (brillo)
- **Range:** 5-50 (alcance)
- **Color:** Blanco/Amarillo
- **Shadows:** On/Off

## Funciones Principales

```csharp
// En Flashlight.cs
public void OnToggleFlashlight(InputAction.CallbackContext context)
    // Callback del input

private void ToggleFlashlight()
    // Alterna la luz

// En InputManager.cs
private void Start()
    // Conecta automáticamente el callback
```

## Estados

```
Inicialización → Apagado (OFF)
         ↓
    Presiona F
         ↓
    Encendido (ON) 💡
         ↓
    Presiona F
         ↓
    Apagado (OFF)
```

## Validaciones

- ✓ Solo funciona con cursor bloqueado
- ✓ Solo se activa en fases "Performed"
- ✓ Auto-detecta luz en hijos
- ✓ Manejo seguro de referencias nulas

## Debugging

Abre la consola (Ctrl + `)

Si no funciona:
```
Verifica:
1. Light asignada en Inspector ✓
2. PlayerInput tiene IA_Player ✓
3. InputManager presente ✓
4. Flashlight presente ✓
5. Cursor bloqueado en juego ✓
```

## Estructura en Jerarquía

```
Player
├── Head
├── Weapon
├── Character (component)
├── InputManager (component) ← Nuevo
├── Flashlight (component) ← Nuevo
└── Flashlight_Light (GameObject)
    └── Light (component) ← La luz
```

## Componentes Necesarios

En el **Player GameObject** necesitas:
- ✓ PlayerInput
- ✓ Character
- ✓ InputManager (nuevo)
- ✓ Flashlight (nuevo)

En un **Light GameObject**:
- ✓ Transform
- ✓ Light component

## Métodos Útiles

```csharp
// Acceder a la luz
flashlight.flashlightLight

// Saber si está encendida
flashlight.flashlightLight.enabled

// Cambiar intensidad
flashlight.flashlightLight.intensity = 2.5f

// Cambiar color
flashlight.flashlightLight.color = Color.red
```

## Problemas Comunes

| Error | Causa | Solución |
|-------|-------|----------|
| Linterna no funciona | Light no asignada | Arrastra la luz en Inspector |
| F no responde | PlayerInput sin asset | Asigna IA_Player.inputactions |
| Luz no cambia | Component deshabilitado | Habilita el script |
| Consola con errores | Path incorrecto | Verifica los paths |

## Combinaciones Útiles

Puedes usar la linterna con:
- Sonidos de encendido/apagado
- Sistema de batería
- Múltiples colores
- Parpadeo/flicker
- Detectar enemigos

Ver: `FLASHLIGHT_ADVANCED_EXAMPLES.md`

## Teclas Relacionadas

```
F    → Linterna ON/OFF
ESC  → Menú/Desbloquear cursor
W/A/S/D → Movimiento
Shift → Correr
RMB  → Apuntar
```

## Propiedades de Luz Recomendadas

```
Type: Spotlight
Intensity: 1.0-1.5
Range: 20
Color: RGB(255, 255, 200)
Shadows: Soft Shadows
```

## Rendimiento

- **CPU:** Mínimo impacto
- **GPU:** Depende de la luz y sombras
- **Memoria:** <1 MB adicional
- **FPS:** Sin cambios notables

## Compatibilidad

- ✓ Unity 2020.3+
- ✓ Input System moderno
- ✓ Desktop y Consolas
- ✓ Editor y Build

## ¿Necesitas ayuda?

Consulta:
1. `FLASHLIGHT_QUICKSTART.md` - Inicio rápido
2. `FLASHLIGHT_SETUP.md` - Configuración detallada
3. `FLASHLIGHT_ARCHITECTURE.md` - Detalles técnicos
4. `FLASHLIGHT_VISUAL_GUIDE.md` - Guía visual
5. `FLASHLIGHT_ADVANCED_EXAMPLES.md` - Ejemplos avanzados

## Resumen de Archivos Creados

```
✨ Scripts creados:
   - Flashlight.cs (98 líneas)
   - InputManager.cs (74 líneas)

📝 Documentación:
   - FLASHLIGHT_README.md
   - FLASHLIGHT_QUICKSTART.md
   - FLASHLIGHT_SETUP.md
   - FLASHLIGHT_ARCHITECTURE.md
   - FLASHLIGHT_VISUAL_GUIDE.md
   - FLASHLIGHT_ADVANCED_EXAMPLES.md
   - FLASHLIGHT_REFERENCE.md (este archivo)

🔧 Archivos modificados:
   - IA_Player.inputactions (+1 acción, +1 binding)
```

---

**¡Listo para usar!** Cualquier duda, consulta la documentación. 🔦
