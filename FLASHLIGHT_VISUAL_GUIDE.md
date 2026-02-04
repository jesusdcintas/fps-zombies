# Guía Visual de Instalación - Linterna

## Paso 1: Crear la Luz 💡

```
┌─────────────────────────────────────────┐
│ Jerarquía de la Escena                  │
├─────────────────────────────────────────┤
│ ▼ Player                                │
│   ├─ Head                              │
│   ├─ Weapon                            │
│   └─ Flashlight_Light ✨ (NUEVO)       │
│       └─ Light Component               │
│           • Type: Spotlight/Point Light│
│           • Intensity: 1.0             │
│           • Color: White               │
│           • Range: 20                  │
└─────────────────────────────────────────┘
```

**Cómo crear la luz:**
1. Haz clic derecho en "Player" → 3D Object → Light
2. Nombre el objeto "Flashlight_Light"
3. Configura el tipo de luz y parámetros

## Paso 2: Agregar Components 🔧

```
┌─────────────────────────────────────────┐
│ Inspector del Player GameObject         │
├─────────────────────────────────────────┤
│ ▼ Transform                             │
│ ▼ Character                             │
│ ▼ CharacterKinematics                   │
│ ▼ Rigidbody                             │
│ ▼ CapsuleCollider                       │
│ ▼ PlayerInput                           │
│   • Actions: IA_Player                  │
│   • UI Input Module: [reference]        │
│                                         │
│ ✨ ▼ InputManager (NUEVO)               │
│   • Player Input: [Auto]                │
│                                         │
│ ✨ ▼ Flashlight (NUEVO)                 │
│   • Flashlight Light: [Drag Here] 👈   │
│     (Arrastra el Light del paso 1)      │
│                                         │
│ + Add Component                         │
└─────────────────────────────────────────┘
```

**Botones que presionarás:**
1. "Add Component" → InputManager → Agregar
2. "Add Component" → Flashlight → Agregar
3. En el campo "Flashlight Light" → Arrastra "Flashlight_Light"

## Paso 3: Verificar Configuración ✅

```
┌─────────────────────────────────────────┐
│ Checklist de Verificación               │
├─────────────────────────────────────────┤
│                                         │
│ ☑ InputManager está agregado            │
│ ☑ Flashlight está agregado              │
│ ☑ Light está asignado en Flashlight     │
│ ☑ PlayerInput tiene IA_Player           │
│ ☑ InputActionAsset contiene "Flashlight"│
│                                         │
└─────────────────────────────────────────┘
```

## Paso 4: ¡Prueba! 🎮

```
En el juego:
┌──────────────────────────────┐
│ Presiona F                   │
├──────────────────────────────┤
│ La luz se enciende 💡         │
│ Presiona F de nuevo          │
│ La luz se apaga 🔦           │
└──────────────────────────────┘
```

## Flujo Completo de Datos 🔄

```
┌─────────────────────────────────────────────────────────────┐
│ Usuario presiona la tecla F                                 │
│ │                                                            │
│ ▼                                                            │
│ InputSystem (Unity) detecta <Keyboard>/f                    │
│ │                                                            │
│ ▼                                                            │
│ PlayerInput ejecuta acción "Flashlight"                    │
│ │                                                            │
│ ▼                                                            │
│ InputManager.OnToggleFlashlight() recibe el callback        │
│ │                                                            │
│ ▼                                                            │
│ ¿Cursor está bloqueado? (Si estamos en juego)              │
│ │─ Sí ──▶ ToggleFlashlight()                               │
│ │─ No ──▶ Ignorar (estamos en menú)                        │
│ │                                                            │
│ ▼                                                            │
│ flashlightActive = !flashlightActive                        │
│ (Se alterna: true → false → true → ...)                    │
│ │                                                            │
│ ▼                                                            │
│ flashlightLight.enabled = flashlightActive                 │
│ │                                                            │
│ ▼                                                            │
│ 💡 La luz se enciende o se apaga visualmente 💡            │
└─────────────────────────────────────────────────────────────┘
```

## Estructura de Archivos 📂

```
fps-zombies-main/
├── Assets/
│   └── Infima Games/
│       └── Low Poly Shooter Pack - Free Sample/
│           ├── Code/
│           │   ├── Character/
│           │   │   └── Flashlight.cs ✨ (NUEVO)
│           │   │
│           │   └── Input/
│           │       └── InputManager.cs ✨ (NUEVO)
│           │
│           └── Input/
│               └── IA_Player.inputactions (MODIFICADO)
│
├── FLASHLIGHT_README.md ✨
├── FLASHLIGHT_QUICKSTART.md ✨
├── FLASHLIGHT_SETUP.md ✨
└── FLASHLIGHT_ARCHITECTURE.md ✨
```

## Estados de la Linterna 🔄

```
┌──────────────────────────────────────┐
│ Ciclo de Estados                     │
├──────────────────────────────────────┤
│                                      │
│ Inicialización                       │
│ │                                    │
│ ▼                                    │
│ flashlightActive = false             │
│ Light.enabled = false                │
│ (Apagado)                            │
│ │                                    │
│ ├─── Presiona F ────▶                │
│ │                    │               │
│ │                    ▼               │
│ │              flashlightActive = true
│ │              Light.enabled = true  │
│ │              (Encendido) 💡         │
│ │                    │               │
│ │ ◀────── Presiona F │               │
│ │        │                           │
│ │        ▼                           │
│ └─ flashlightActive = false          │
│    Light.enabled = false             │
│    (Apagado)                         │
│                                      │
│ (Sigue alternando...)                │
│                                      │
└──────────────────────────────────────┘
```

## Propiedades de la Luz 🌟

```
Light Component (en el Inspector)
├─ Type
│  ├─ Spotlight ⚡ (Recomendado)
│  ├─ Point Light 💡
│  └─ Directional (No recomendado)
│
├─ Intensity: 0.0 - 3.0
│  └─ Valor recomendado: 1.0 - 1.5
│
├─ Color: Blanco/Amarillo
│  └─ RGB (255, 255, 200) para color cálido
│
├─ Range: 5.0 - 50.0 unidades
│  └─ Valor recomendado: 20.0
│
└─ Shadows: On/Off
   └─ Recomendado: Soft Shadows
```

## Atajos de Teclado 🎮

```
En el juego:
┌────────────┬──────────────────────┐
│ Tecla      │ Acción               │
├────────────┼──────────────────────┤
│ F          │ Encender/Apagar luz  │
│ ESC        │ Desbloquear cursor   │
│ Otros      │ Controles normales   │
└────────────┴──────────────────────┘
```

## Diagrama de Clases 📊

```
┌─────────────────────────────────────┐
│ Flashlight.cs                       │
├─────────────────────────────────────┤
│ - flashlightLight: Light            │
│ - flashlightActive: bool            │
│ - playerCharacter: CharacterBehaviour
├─────────────────────────────────────┤
│ + OnToggleFlashlight()              │
│ - ToggleFlashlight()                │
└─────────────────────────────────────┘
          │ usa
          ▼
┌─────────────────────────────────────┐
│ InputManager.cs                     │
├─────────────────────────────────────┤
│ - playerInput: PlayerInput          │
│ - flashlight: Flashlight            │
├─────────────────────────────────────┤
│ + Start()                           │
│ + OnDestroy()                       │
└─────────────────────────────────────┘
          │ se conecta a
          ▼
┌─────────────────────────────────────┐
│ IA_Player.inputactions              │
├─────────────────────────────────────┤
│ • Acción: "Flashlight"              │
│ • Binding: <Keyboard>/f             │
└─────────────────────────────────────┘
```

---

**¡Todo listo para usar!** 🎉
