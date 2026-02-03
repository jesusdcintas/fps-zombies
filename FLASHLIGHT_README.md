# Sistema de Linterna (Flashlight) - Resumen de Implementación

## ✅ Lo que se ha Implementado

Se ha agregado un sistema completo de linterna/antorcha que se controla presionando la tecla **F**. El usuario puede asignar cualquier componente `Light` de Unity para que actúe como linterna.

## 📁 Archivos Creados

### 1. **Flashlight.cs**
**Ubicación:** `Assets/Infima Games/Low Poly Shooter Pack - Free Sample/Code/Character/Flashlight.cs`

Componente que controla el encendido/apagado de la linterna:
- Recibe callbacks del sistema de input
- Alterna el estado de la luz
- Verifica que el juego esté en estado de juego activo (cursor bloqueado)
- Auto-detecta la luz si no está asignada en el Inspector

**Características:**
- ✓ Togglea la luz encendida/apagada
- ✓ Solo funciona cuando el cursor está bloqueado
- ✓ Auto-asignación de luz en hijos
- ✓ Integración con ServiceLocator

### 2. **InputManager.cs**
**Ubicación:** `Assets/Infima Games/Low Poly Shooter Pack - Free Sample/Code/Input/InputManager.cs`

Componente que automatiza la conexión de callbacks de input:
- Encuentra automáticamente el componente `PlayerInput`
- Busca el componente `Flashlight` en el GameObject
- Suscribe el callback de la acción "Flashlight"
- Desuscribe correctamente en OnDestroy para evitar memory leaks

**Características:**
- ✓ Conexión automática de callbacks
- ✓ Manejo seguro de referencias nulas
- ✓ Limpieza de memoria al destruir
- ✓ Compatible con el sistema de Input moderno de Unity

### 3. **IA_Player.inputactions** (Modificado)
**Ubicación:** `Assets/Infima Games/Low Poly Shooter Pack - Free Sample/Input/IA_Player.inputactions`

Archivo de configuración de input que ahora incluye:
- **Nueva Acción:** `Flashlight` (tipo Button)
- **Nuevo Binding:** Tecla `F` (<Keyboard>/f)

## 🚀 Uso Rápido

### Configuración Mínima
1. Crea una luz en la escena (Light component)
2. Agrega el componente `Flashlight` al GameObject del jugador
3. Asigna la luz al campo "Light" en el Inspector
4. Agrega el componente `InputManager` al GameObject del jugador
5. **¡Listo!** Presiona F para encender/apagar la linterna

### Configuración Alternativa (Manual)
Si prefieres no usar InputManager:
1. Sigue los pasos 1-3 anteriores
2. En el componente `PlayerInput`, suscribe manualmente el callback
3. Evento: `Flashlight` → Método: `Flashlight.OnToggleFlashlight()`

## 🔧 Personalización

### Cambiar la Tecla de Activación
Edita `IA_Player.inputactions` y reemplaza:
```json
"path": "<Keyboard>/f"
```
Con otra tecla, por ejemplo:
```json
"path": "<Keyboard>/l"        // Tecla L
"path": "<Keyboard>/x"        // Tecla X
"path": "<Gamepad>/buttonWest" // Botón del GamePad
```

### Ajustar la Luz
Una vez asignada, en el Inspector de la luz puedes modificar:
- **Intensity:** Brillo
- **Color:** Color de la luz
- **Range:** Rango de la luz
- **Spot Angle:** Ángulo (si es Spotlight)
- **Shadow Type:** Tipo de sombra

## 📊 Características Técnicas

### Sistema de Input
- Utiliza el nuevo Input System de Unity
- Integración con InputActionAsset
- Callbacks de evento basados en fases (Started, Performed, Canceled)

### Validación
- Solo funciona cuando el cursor del juego está bloqueado
- Verifica que la luz esté asignada
- Manejo seguro de referencias nulas

### Rendimiento
- Ligero (solo cambia el estado de enabled)
- Sin generación de garbage
- Desuscripción correcta de eventos

## 📚 Documentación Adicional

- **FLASHLIGHT_QUICKSTART.md:** Guía rápida de 3 pasos
- **FLASHLIGHT_SETUP.md:** Guía detallada de configuración
- **FLASHLIGHT_ARCHITECTURE.md:** Detalles técnicos y diagrama de flujo

## 🐛 Troubleshooting

| Problema | Solución |
|----------|----------|
| La linterna no funciona | Verifica que el Light esté asignado en el Inspector |
| La tecla F no responde | Comprueba que el PlayerInput tenga el InputActionAsset |
| La luz no cambia estado | Verifica que el componente Light esté enabled |
| Errores en consola | Asegúrate de que los paths de los archivos sean correctos |

## 🔍 Scripts Relacionados

El sistema integra con:
- **Character.cs:** Sistema de control del jugador
- **MovementBehaviour.cs:** Comportamiento de movimiento
- **CharacterBehaviour.cs:** Interfaz base del personaje
- **PlayerInput:** Sistema de input de Unity

## 📝 Notas de Desarrollo

- Ambos scripts siguen el patrón de código del proyecto (namespaces, regiones, comments)
- Compatible con Editor y Build
- Sin dependencias externas
- Totalmente documentado

## ✨ Versión

- **Versión:** 1.0
- **Fecha:** Febrero 2026
- **Namespace:** `InfimaGames.LowPolyShooterPack`

---

**¡El sistema está listo para usar!** Agrega los componentes al jugador y asigna la luz. 🔦
