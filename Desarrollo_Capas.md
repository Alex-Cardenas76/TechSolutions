# Documentación por Capas – Orden de Construcción

## 📋 Introducción

La arquitectura del proyecto TechSolutions está basada en **N-Capas**, lo cual significa que cada capa tiene una responsabilidad clara y debe estar completamente lista antes de que la siguiente capa pueda desarrollarse.

## 🎯 Orden Correcto de Desarrollo

```
1️⃣ CapaEntidad → 2️⃣ CapaDatos (DAL) → 3️⃣ CapaNegocio (BLL) → 4️⃣ CapaPresentación (WPF)
```

---

## 🧩 1. CapaEntidad (Models)

### 📌 Primera capa del sistema — base de toda la arquitectura

#### ✔ Objetivo de la CapaEntidad
Representar estructuras de datos equivalentes a las tablas de la base de datos. Aquí no existe lógica, métodos ni validaciones: solo modelos.

#### ✔ Responsabilidades
- Crear las clases que reflejan la estructura de la BD
- Definir propiedades con tipos correctos
- Preparar relaciones opcionales para facilitar reportes o vinculación
- No se accede a la BD ni se realiza lógica de negocio

#### ✔ Archivos incluidos
- `Rol.cs`
- `Usuario.cs`
- `Cliente.cs`
- `Proveedor.cs`
- `Categoria.cs`
- `Producto.cs`
- `Venta.cs`
- `DetalleVenta.cs`
- `TipoMovimiento.cs`
- `TransaccionStock.cs`

#### ✔ Dependencias
- **Esta capa no depende de nadie**
- **Todas las otras capas dependen de ella**

#### ✔ Qué se debe dejar listo para la siguiente capa (DAL)
- Todos los modelos correctos y sin errores
- Propiedades con tipos equivalentes a SQL Server
- Nombres idénticos a la BD
- Clases completas y simples

> **👉 Cuando esta capa está terminada, la DAL puede iniciar**

---

## 🗄 2. CapaDatos (DAL)

### 📌 Segunda capa — conexión, CRUD y transacciones

#### ✔ Objetivo de la DAL
Acceder directamente a SQL Server mediante ADO.NET utilizando:
- `SqlConnection`
- `SqlCommand`
- `SqlDataReader`
- `SqlTransaction`
- Stored Procedures (opcionales)

#### ✔ Responsabilidades
- Realizar operaciones CRUD
- Ejecutar SP o consultas SQL
- Manejar transacciones de venta + stock
- Mapear datos de SQL → Modelos (CapaEntidad)
- Implementar patrón Singleton para la conexión

#### ✔ Archivos principales

**🔹 Database**
- `Conexion.cs` (patrón Singleton)

**🔹 Repositorios**
- `UsuarioDAL.cs`
- `ClienteDAL.cs`
- `ProveedorDAL.cs`
- `CategoriaDAL.cs`
- `ProductoDAL.cs`
- `VentaDAL.cs`
- `DetalleVentaDAL.cs`
- `TipoMovimientoDAL.cs`
- `TransaccionStockDAL.cs`
- `ReporteDAL.cs`

#### ✔ Dependencias
- **La DAL depende de:** CapaEntidad
- **La DAL no conoce** la capa de negocio ni la de presentación

#### ✔ Qué se debe dejar listo para la siguiente capa (BLL)
- Métodos CRUD funcionando
- Transacciones completas para ventas:
  - Insertar venta
  - Insertar detalle
  - Descontar stock
  - Confirmar o revertir
- Funciones para obtener datos listos (listas, filtros)
- Métodos que retornen `List<T>` o `T`, según el caso

> **👉 Cuando la DAL funciona, la BLL puede iniciarse**

---

## ⚙️ 3. CapaNegocio (BLL)

### 📌 Tercera capa — lógica, reglas y validaciones

#### ✔ Objetivo de la BLL
Encargarse de la lógica empresarial:
- Validar datos
- Aplicar reglas antes del acceso a BD
- Controlar el flujo entre la UI y la DAL
- Convertir errores técnicos en mensajes comprensibles
- Usar LINQ para filtrados y cálculos

#### ✔ Responsabilidades
- Verificar que los datos estén completos
- Confirmar permisos según roles
- Validar stock suficiente antes de vender
- Preparar objetos para DAL
- Usar LINQ para cálculos como:
  - Productos más vendidos
  - Totales por fecha
  - Filtros dinámicos

#### ✔ Archivos principales
- `UsuarioBLL.cs`
- `ClienteBLL.cs`
- `ProveedorBLL.cs`
- `CategoriaBLL.cs`
- `ProductoBLL.cs`
- `VentaBLL.cs`
- `DetalleVentaBLL.cs`
- `TipoMovimientoBLL.cs`
- `TransaccionStockBLL.cs`
- `ReporteBLL.cs`
- `PasswordHasher.cs`

#### ✔ Dependencias
- **La BLL depende de:** CapaDatos, CapaEntidad
- **Pero no depende de WPF**, lo que permite reutilizarla en APIs o servicios

#### ✔ Qué se debe dejar listo para la siguiente capa (WPF)
- Métodos claros que devuelvan datos procesados para la UI
- Validaciones listas para mostrar en mensajes
- Procesos de ventas listos para ejecutarse desde un botón
- Listas filtradas usando LINQ (para DataGrids)

> **👉 Cuando la BLL está completa, se puede construir la interfaz WPF**

---

## 🖥 4. CapaPresentación (WPF)

### 📌 Última capa — interfaz gráfica del usuario

#### ✔ Objetivo de la UI
Proporcionar la vista gráfica que interactúa con la BLL para:
- Mostrar datos
- Registrar clientes, productos y ventas
- Controlar navegación
- Mostrar reportes
- Ejecutar procesos con timers y threads

#### ✔ Responsabilidades
- Formularios de registro
- DataGrids para listar entidades
- Llamadas a métodos BLL
- Validaciones visuales
- Uso de Threads para carga de datos sin congelar la UI
- Reloj en tiempo real con DispatcherTimer
- Visualización de RDLC

#### ✔ Archivos principales
- `Login.xaml`
- `MenuPrincipal.xaml`
- `ClientesForm.xaml`
- `ProveedoresForm.xaml`
- `CategoriasForm.xaml`
- `ProductosForm.xaml`
- `VentasForm.xaml`
- `MovimientosStockForm.xaml`
- `ReportesForm.xaml`

#### ✔ Dependencias
- **La UI depende de:** CapaNegocio, CapaEntidad
- **La UI no debe interactuar** con DAL directamente

#### ✔ Qué se debe dejar listo después de construir esta capa
- El ejecutable del sistema
- Actualizaciones de interfaz
- Funcionalidad completamente integrada

> **👉 Con esto, la aplicación está lista para uso y pruebas**

---

## 📦 BONUS: Orden Sugerido de Desarrollo en el Proyecto Real

### ✔ 1° Construir CapaEntidad
- Modelos listos
- Nombres y tipos correctos

### ✔ 2° Construir base de datos SQL Server
- Tablas
- Relaciones
- Constraints

### ✔ 3° Construir CapaDatos (DAL)
- Conexión Singleton
- CRUD
- Transacciones
- Reportes DAL

### ✔ 4° Construir CapaNegocio (BLL)
- Validaciones
- Métodos que coordinen varias DAL
- LINQ
- Control de roles

### ✔ 5° Construir CapaPresentación (WPF)
- Login
- CRUDs
- Ventas
- Stock
- Reportes
- Hilos
- Timers

### ✔ 6° Construir instalador (Setup Project)

🎯 Resultado final
Con esta documentación, tu proyecto queda:
Totalmente explicado


Ordenado por capas


Listo para informe técnico


Listo para exposición


Listo para tu repositorio en GitHub



