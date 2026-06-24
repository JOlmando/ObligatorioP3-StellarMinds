# 🌌 StellarMinds – Sistema de Gestión de Observatorio Astronómico

> Obligatorio – Diseño Web Asistido por IA  
> Facultad de Ingeniería – Universidad ORT Uruguay  
> Fecha de entrega: 11/06/2026

---

## 👥 Integrantes

| Nombre | Nº Estudiante |
|--------|--------------|
| _Jeremias Olmando_ | _350065_ |
| _Camilo Paisani_ | _207448_ |

---

## 📋 Descripción

Sistema web para el observatorio astronómico y club de aficionados **StellarMinds** que permite gestionar socios, equipos de observación en préstamo y sesiones de observación/astrofotografía.

Integra la **API de Google Gemini** para evaluar la adecuación del equipamiento al objeto celeste que se desea observar o fotografiar.

---

## 🛠️ Tecnologías utilizadas

- **.NET 10** – Web API y Web MVC
- **C#** – Lenguaje de programación
- **Entity Framework 10** – Acceso a base de datos
- **LINQ** (sintaxis de método) – Consultas
- **SQL Server** – Base de datos (desplegada en SOMEE)
- **Swagger / OpenAPI** – Documentación de la Web API
- **Google Gemini API** – Evaluación de adecuación de equipos
- **Clean Architecture + DDD** – Organización del código
- **Principios SOLID**

---

## 🏗️ Arquitectura

El proyecto sigue los lineamientos de **Clean Architecture** y **Domain Driven Design (DDD)**, separado en dos soluciones:

```
StellarMinds/
├── StellarMinds.API/          # Web API RESTful
│   ├── Controllers/
│   └── ...
├── StellarMinds.Domain/       # Entidades, Value Objects, Interfaces
├── StellarMinds.Application/  # Casos de uso, Servicios
├── StellarMinds.Infrastructure/ # EF, Repositorios, Gemini API
│
StellarMinds.Web/              # Aplicación MVC (solución separada)
│   ├── Controllers/
│   ├── Views/
│   └── ...
```

---

## ✅ Requerimientos funcionales

| RF | Descripción | Rol |
|----|-------------|-----|
| RF01 | Login / Logout de usuarios | Todos |
| RF02 | Alta de socios | Administrador |
| RF03 | CRUD de equipos (Telescopios, Monturas, Cámaras, Oculares) | Administrador |
| RF04 | Alta de préstamo con validaciones de negocio | Coordinador |
| RF05 | Devolución de préstamo | Coordinador |
| RF06 | Auditoría de préstamos (automático) | Sistema |
| RF07 | Alta de observación con evaluación vía Gemini API | Socio |
| RF08 | Listado de préstamos entre fechas | Socio |
| RF09 | Listado de socios que solicitaron un telescopio dado | Admin / Coordinador |
| RF10 | Ranking de objetos celestes observados | Todos |
| RF11 | Información de auditoría de préstamos | Administrador |

---

## 🔭 Entidades principales

- **Usuario** (Administrador, Coordinador, Socio)
- **Telescopio** – apertura, distancia focal, relación focal, peso
- **Montura** – tipo (Ecuatorial / AltAzimutal / Híbrida), carga útil, GoTo
- **Cámara** – sensor CMOS/CCD, resolución, tamaño de píxel
- **Ocular** – diámetro, ángulo de visión
- **Préstamo** – estados: `EN PRÉSTAMO` / `DEVUELTO`
- **Observación** – vinculada a un préstamo y un objeto celeste
- **Objeto celeste** – nombre, tipo, magnitud aparente (precargados con IA)

---

## 🤖 Integración con Google Gemini

Para el RF07, el sistema consulta la API de Gemini para evaluar si el equipo es adecuado para observar un objeto celeste. La respuesta indica:

- `IDEAL`
- `ADECUADO`
- `NO RECOMENDABLE` + detalle (máx. 300 caracteres)

**Ejemplo de request:**
```json
{
  "telescopio": { "apertura_mm": 203, "focal_mm": 2032, "relacion_focal": 10 },
  "camara": { "sensor": "CMOS", "resolucion_px": "3840x2160", "pixel_size_um": 1.45 },
  "objeto_celeste": { "nombre": "Saturno", "tipo": "Planeta" }
}
```

---

## 🚀 Cómo ejecutar el proyecto

### Requisitos previos
- .NET 10 SDK
- SQL Server (local o SOMEE)
- API Key de Google Gemini

### Pasos

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/Prog-DW-2026-1/Obligatorio-ABC-xxxxx-xxxxx.git
   ```

2. Configurar el archivo `appsettings.json` en la Web API:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "tu_cadena_de_conexion"
     },
     "GeminiApiKey": "tu_api_key"
   }
   ```

3. Aplicar migraciones y ejecutar el script SQL de precarga:
   ```bash
   dotnet ef database update
   ```

4. Ejecutar la Web API:
   ```bash
   cd StellarMinds.API
   dotnet run
   ```

5. Ejecutar la aplicación MVC (en otra terminal):
   ```bash
   cd StellarMinds.Web
   dotnet run
   ```

6. Acceder a Swagger en: `https://localhost:{puerto}/swagger`

---

## 🌐 Despliegue

| Componente | URL |
|------------|-----|
| Web MVC | _(link SOMEE)_ |
| Web API | _(link SOMEE)_ |
| Swagger | _(link SOMEE/swagger)_ |

---

## 📁 Estructura del repositorio

```
/
├── StellarMinds.API/
├── StellarMinds.Domain/
├── StellarMinds.Application/
├── StellarMinds.Infrastructure/
├── StellarMinds.Web/
├── docs/
│   └── documentacion.pdf
├── sql/
│   └── script_datos.sql
└── README.md
```

---

## 📅 Cronograma de pre-entregas

| Tarea | Fecha |
|-------|-------|
| Diagrama de arquitectura + estructura solución | 09/04 |
| RF01 y RF02 | 16/04 |
| RF03 | 23/04 |
| RF04, RF05 y RF06 | 30/04 |
| RF07 | 14/05 |
| RF08 y RF09 | 28/05 |
| RF10 y RF11 | 04/06 |
| **Entrega final en Gestión** | **11/06** |

---

## 📄 Documentación

La documentación completa (PDF) incluye:
- Carátula con integrantes
- Tabla de contenido
- Diagrama de casos de uso
- Descripción narrativa: RF07 y RF08
- Casos de prueba para RF10
- Diagrama de clases UML (capa de dominio completa + RF07 en demás capas)
- Documentación de precarga de datos con IA generativa
- https://chatgpt.com/gg/v/6a20accc9cb481918ec5752d6e59f06f?token=tMu7nuB102IyO_W4Jlrmrg
- Investigación sobre configuración y uso de la API de Gemini

---

## ⚠️ Uso de IA generativa

Este proyecto hace uso de herramientas de IA generativa como apoyo en el proceso de desarrollo. Todo uso está debidamente citado en la documentación, indicando la herramienta utilizada y el contexto de uso (generación de código, precarga de datos, etc.), conforme a las pautas institucionales.

---

*Universidad ORT Uruguay – Facultad de Ingeniería – 2026*
