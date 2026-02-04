# Guía Rápida - Linterna (Flashlight)

## Resumen
Se ha implementado un sistema de linterna que se controla presionando la tecla **F**.

## Instalación Rápida (3 pasos)

### 1. Crear una Luz
```
Haz clic derecho en el jugador → 3D Object → Light
(Selecciona Spotlight o Point Light según prefieras)
```

### 2. Agregar Scripts al Jugador
- Haz clic en "Add Component"
- Busca `InputManager` → Agregar
- Haz clic en "Add Component"  
- Busca `Flashlight` → Agregar
- Arrastra la luz al campo "Light" del componente Flashlight

### 3. ¡Listo!
- Presiona **F** en el juego para encender/apagar la linterna

## Archivos Creados

| Archivo | Ubicación |
|---------|-----------|
| Flashlight.cs | `/Code/Character/Flashlight.cs` |
| InputManager.cs | `/Code/Input/InputManager.cs` |
| IA_Player.inputactions | `/Input/IA_Player.inputactions` (modificado) |

## Cambiar la Tecla

Abre: `Assets/Infima Games/Low Poly Shooter Pack - Free Sample/Input/IA_Player.inputactions`

Busca:
```json
{
    "path": "<Keyboard>/f",
    "action": "Flashlight"
}
```

Cambia `<Keyboard>/f` por otra tecla, ej: `<Keyboard>/l`

## Preguntas Frecuentes

**¿Puedo cambiar el brillo de la luz?**
Sí, en el Inspector de la luz ajusta "Intensity"

**¿Puedo usar diferentes tipos de luz?**
Sí, funciona con cualquier tipo de luz (Spotlight, Point Light, Directional, etc.)

**¿La linterna consume batería?**
No, es solo una simulación. Puedes agregar eso manualmente si lo deseas.
