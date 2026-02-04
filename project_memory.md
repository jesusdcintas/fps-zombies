# Project Memory: FPS Zombies

## Hitos del Proyecto

### 1. Configuración del Proyecto y Diseño del Terreno
- Configurar el proyecto Unity.
- Crear el terreno base con Unity Terrain.
- Diseñar un layout con al menos 3 zonas diferenciadas y caminos alternativos.

### 2. Implementación de Controles FPS
- Movimiento básico (WASD).
- Cámara controlada con el ratón.
- Sprint (Shift), salto (Space) y agacharse (Ctrl).

### 3. Sistema de Interacción
- Crear un sistema para interactuar con objetos (tecla E).
- Mostrar un indicador en la UI cuando un objeto sea interactuable.

### 4. IA Básica de Zombis
- Implementar un zombi básico con detección, persecución y ataque.
- Configurar NavMesh para la navegación de los zombis.

### 5. Sistema de Oleadas
- Crear un sistema de oleadas con incremento de dificultad.
- Incluir fases de respiro entre oleadas.

### 6. Sistema de Armas
- Implementar 3 armas jugables con diferentes comportamientos.
- Incluir munición, recarga y detección de impactos.

### 7. Diseño de UI/HUD
- Diseñar la interfaz con los elementos requeridos:
  - Vida.
  - Munición.
  - Arma actual.
  - Oleada actual.
  - Puntuación.
  - Mensajes de estado.

### 8. Audio y Feedback Visual
- Añadir música de fondo y efectos de sonido:
  - Disparos, recarga, daño, etc.
- Implementar feedback visual para daño y confirmación de impactos.

### 9. Menús y Flujo de Juego
- Crear un menú principal con opciones de jugar, salir y controles.
- Implementar un menú de pausa.
- Crear una pantalla de Game Over.

### 10. Mecánicas Extra
- Implementar al menos 3 de las siguientes:
  - Sistema de economía.
  - Zonas seguras o puertas activables.
  - Power-ups temporales.

---

## Reglas de Trabajo con Git

### Ramas
1. **`main`**:
   - **Protegida**: No se permiten commits directos.
   - Contiene únicamente versiones estables y listas para producción.

2. **`develop`**:
   - **Rama de integración**: No se permiten commits directos.
   - Se utiliza para integrar cambios de las ramas de trabajo.

3. **Ramas de trabajo**:
   - **`feature/<nombre>`**: Para nuevas funcionalidades (ejemplo: `feature/player-controller`).
   - **`fix/<nombre>`**: Para corrección de errores.

### Reglas Generales
1. **Prohibido**:
   - Hacer commits directos en `main` o `develop`.
2. **Flujo de cambios**:
   - Todo cambio debe realizarse en una rama de trabajo (`feature/*` o `fix/*`).
   - Los cambios se integran mediante Pull Requests:
     - `feature/*` → `develop`
     - `develop` → `main` (solo cuando el proyecto esté estable).
3. **Mensajes de commit**:
   - Usa un estilo claro y consistente:
     - `feat: descripción breve` (para nuevas funcionalidades).
     - `fix: descripción breve` (para correcciones de errores).
     - `chore: descripción breve` (para tareas menores, como actualizaciones de dependencias).
     - `refactor: descripción breve` (para cambios en el código sin alterar la funcionalidad).

### Reglas Específicas para Unity
1. **Escenas**:
   - No modificar escenas que pertenezcan a otros compañeros.
   - Evitar trabajar en paralelo sobre la misma escena `.unity` para prevenir conflictos.
2. **Commits**:
   - Realizar cambios pequeños y coherentes con mensajes claros.
   - **Nunca** incluir en los commits:
     - Carpetas: `Library/`, `Build/`, `Temp/`.
     - Configuraciones de IDE (como `.vscode/` o `.idea/`).
3. **Conflictos**:
   - Si es necesario editar una escena compartida, coordinar con el equipo para evitar conflictos.

---

## Requisitos del Proyecto: FPS Zombies

## 📌 Requisitos Obligatorios

### A) Perspectiva y Control (FPS)
- **Cámara en primera persona real.**
- **Movimiento:** WASD + ratón.
- **Sprint:** Shift con stamina o cooldown.
- **Salto:** Space.
- **Agacharse:** Ctrl.
- **Interacción:**
  - Interactuar con objetos (E).
  - Indicador en la UI cuando algo es interactuable.

### B) Mapa y Nivel
- **Terrain creado desde cero:**
  - Sculpt (no plano).
  - Pintado de texturas.
  - Vegetación y props.
- **Diseño del nivel:**
  - Mínimo 3 zonas diferenciadas (ejemplo: campamento, edificio-túneles, zona abierta).
  - Al menos 2 rutas alternativas o atajos.
  - Buen “flow”:
    - Choke points.
    - Zonas abiertas con flanqueo.
- **Spawners:**
  - Colocados a mano.
  - Evitar spawns en la cara del jugador.

### C) Enemigos (IA + Oleadas)
- **Zombi básico:**
  - Detecta al jugador.
  - Persigue usando NavMesh.
  - Ataque cuerpo a cuerpo con cooldown.
- **Sistema de oleadas:**
  - Oleadas numeradas con dificultad creciente.
  - Descanso entre oleadas (10–30 segundos).
- **Reglas de spawn:**
  - Puntos configurables.
  - Límite de enemigos activos simultáneos.
  - Evitar spawn en el campo de visión cercano del jugador.
- **Variantes de zombis:**
  - Rápido (poca vida).
  - Tanque (mucha vida).

### D) Combate y Armas
- **Armas:**
  - 3 armas distintas:
    - Rifle automático.
    - Pistola.
    - Francotirador.
  - Cambio de arma (1/2/3 o rueda del ratón).
- **Munición:**
  - Cargador + reserva total.
  - Recarga (R) con tiempo.
  - No disparar con cargador vacío.
- **Disparo:**
  - Raycast o proyectil.
  - Sonidos: disparo, recarga, click sin balas.
  - Feedback de impacto.
- **Daño:**
  - Enemigos reciben daño y mueren.
  - Contador de bajas.

### E) Vida y Estados del Jugador
- **Sistema de vida (HP):**
  - Game Over al llegar a 0.
- **Curación:**
  - Botiquín (limitado).
- **Estados visuales:**
  - Pantalla roja al recibir daño o con HP bajo.
  - Opción alternativa: armadura.

### F) UI / HUD
- **Elementos obligatorios:**
  - Vida.
  - Munición (cargador / reserva).
  - Arma actual.
  - Oleada actual + progreso.
  - Puntuación (bajas / tiempo).
- **Mensajes dinámicos:**
  - “Oleada X iniciando”.
  - “Recargando”.
  - “Sin munición”.

### G) Audio y Feedback
- **Música o ambiente.**
- **Sonidos:**
  - Disparo.
  - Recarga.
  - Daño al jugador.
  - Zombis (gruñidos y muerte).
- **Feedback visual:**
  - Daño al jugador.
  - Impactos confirmados.

### H) Menús y Flujo
- **Menú principal:**
  - Jugar.
  - Salir.
  - Controles.
- **Pausa (Esc):**
  - Reanudar.
  - Reiniciar.
  - Menú principal.
- **Game Over:**
  - Mostrar oleada alcanzada, score y tiempo.
  - Opciones: Reiniciar / Menú principal.

---

## 🔥 Extras Seleccionados (4)

### 1️⃣ Headshots
- **Collider en la cabeza.**
- **Multiplicador de daño.**
- **Feedback claro:** sonido y UI.

### 2️⃣ Power-ups Temporales
- **Pickups en el mapa:**
  - Ejemplo: daño x2 (10 segundos), velocidad x2 (10 segundos).
- **Temporizador:**
  - Mensaje en la UI.

### 3️⃣ Loot Aleatorio
- **Al morir un zombi:**
  - Probabilidad de soltar:
    - Munición.
    - Botiquín.
- **Boss:**
  - Suelta loot garantizado.

### 4️⃣ Mini-boss Cada X Oleadas
- **Cada X oleadas (ejemplo: 5):**
  - Aparece un zombi boss.
  - Mucha vida y más daño.
  - Mensaje especial en la UI.
  - Cuenta como enemigo de la oleada.

---

## 📦 Entregables

1. **Proyecto Unity ordenado.**
2. **Build ejecutable.**
3. **Documento (1–2 páginas):**
   - Roles del equipo.
   - Checklist de requisitos.
   - Controles.
   - 3 capturas del mapa.
   - 2 capturas de la UI.