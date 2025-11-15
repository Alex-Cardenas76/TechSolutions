# 💼 PDSD-437_TRABAJOFINAL — Tech Solutions

<div align="center">

![.NET](https://img.shields.io/badge/.NET-Framework_4.8-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)

### 📘 Proyecto Final: Aplicación Empresarial en Microsoft Visual Studio .NET

**Sistema completo de gestión empresarial con arquitectura N-Capas**

[Sobre el Proyecto](#-sobre-el-proyecto) •
[Características](#-características-principales) •
[Instalación](#-instalación) •
[Arquitectura](#-arquitectura) •
[Documentación](#-documentación-adicional)

</div>

---
Link Para Documentacion de diagramas UML y Figma:
https://docs.google.com/document/d/1_NxNg9JveCqfa_HxinFtjvEBBJlT_9jbBiLbW6wxc7c/edit?usp=sharing

## 📋 Tabla de Contenidos

- [Sobre el Proyecto](#-sobre-el-proyecto)
  - [Contexto Académico](#contexto-académico)
  - [Caso de Negocio](#caso-de-negocio)
  - [Requisitos del Entregable](#requisitos-del-entregable)
- [El Sistema TechSolutions](#-el-sistema-techsolutions)
  - [¿Qué es TechSolutions?](#qué-es-techsolutions)
  - [Problemática que Resuelve](#problemática-que-resuelve)
  - [Módulos del Sistema](#módulos-del-sistema)
- [Características Principales](#-características-principales)
- [Tecnologías Utilizadas](#-tecnologías-utilizadas)
- [Requisitos del Sistema](#-requisitos-del-sistema)
- [Instalación](#-instalación)
- [Configuración](#-configuración)
- [Uso del Sistema](#-uso-del-sistema)
- [Arquitectura](#-arquitectura)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Base de Datos](#-base-de-datos)
- [Sistema de Permisos](#-sistema-de-permisos)
- [Documentación Adicional](#-documentación-adicional)
- [Autores](#-autores)

---

## 💼 Caso de Negocio

**TechSolutions** es una empresa ficticia dedicada a la comercialización de productos tecnológicos (laptops, periféricos, componentes, smartphones, tablets, etc.). La empresa enfrenta los siguientes desafíos:

### Problemática Actual
- 📊 **Control manual de inventario** que genera errores y pérdidas
- 📝 **Registro de ventas en papel** difícil de auditar
- 👥 **Falta de control de acceso** - todos los empleados tienen los mismos permisos
- 📉 **Sin reportes automatizados** para toma de decisiones
- ⚠️ **Descontrol de stock** - productos agotados sin aviso previo
- 🔄 **Procesos lentos** en punto de venta

### Solución Propuesta
Desarrollar un **sistema de gestión empresarial integral** que permita:
- ✅ Automatizar el control de inventario en tiempo real
- ✅ Registrar ventas de forma rápida y segura
- ✅ Implementar roles y permisos diferenciados
- ✅ Generar reportes automáticos para análisis
- ✅ Alertar sobre niveles críticos de stock
- ✅ Agilizar las operaciones diarias

---

## 🖥 El Sistema TechSolutions

El sistema desarrollado es una **aplicación de escritorio** construida con tecnología .NET que implementa todas las funcionalidades necesarias para resolver la problemática de la empresa.

### ¿Qué hace el sistema?

**Para el Administrador:**
- Gestiona usuarios, productos, clientes y proveedores
- Configura precios y categorías
- Accede a todos los reportes del sistema
- Supervisa todas las operaciones

**Para el Supervisor:**
- Administra el inventario y productos
- Registra ventas y gestiona clientes
- Genera reportes operativos
- Controla movimientos de stock

**Para el Vendedor:**
- Registra ventas de forma rápida
- Consulta disponibilidad de productos
- Gestiona información de clientes
- Visualiza precios actualizados

### Beneficios Clave
- 🚀 **Eficiencia:** Reduce el tiempo de operación en un 70%
- 🎯 **Precisión:** Elimina errores humanos en el inventario
- 🔒 **Seguridad:** Control de acceso basado en roles
- 📊 **Visibilidad:** Reportes en tiempo real para decisiones informadas
- 💰 **Rentabilidad:** Mejor control de stock = menos pérdidas

---

## 🎓 Sobre el Proyecto

### Contexto Académico

Este proyecto corresponde al **Trabajo Final de la materia PDSD-437**, donde se requiere el diseño e implementación de una aplicación empresarial completa utilizando **Microsoft Visual Studio (.NET)**.

**Objetivo del Proyecto:**  
Desarrollar una solución de software empresarial que demuestre el dominio de conceptos avanzados de programación, arquitectura de software, patrones de diseño y mejores prácticas de desarrollo en el ecosistema .NET.

### Caso de Negocio

**Tech Solutions** es una empresa ficticia dedicada a la comercialización de productos tecnológicos (computadoras, periféricos, smartphones, tablets, accesorios, etc.). La empresa necesita un sistema integral que le permita:

- 📊 **Gestionar su inventario** de productos tecnológicos
- 👥 **Administrar clientes y proveedores** de manera eficiente
- 💰 **Registrar y controlar ventas** con seguimiento detallado
- 📦 **Controlar el stock** con movimientos de entrada y salida
- 📈 **Generar reportes** para la toma de decisiones
- 🔐 **Controlar el acceso** mediante roles y permisos

**Situación Actual:**  
La empresa actualmente maneja sus operaciones de forma manual o con sistemas desintegrados, lo que genera:
- ❌ Pérdida de información
- ❌ Errores en el control de inventario
- ❌ Dificultad para generar reportes
- ❌ Falta de trazabilidad en las operaciones
- ❌ Procesos lentos y propensos a errores

**Solución Propuesta:**  
Desarrollar **TechSolutions**, un sistema de gestión empresarial robusto, escalable y fácil de usar que centralice todas las operaciones de la empresa.

### Requisitos del Entregable

El proyecto debe cumplir con los siguientes requisitos técnicos y de arquitectura:

✅ **Patrones de Diseño:**
- Arquitectura **N-Capas** (Presentación, Negocio, Datos, Entidad)
- Patrón **Singleton** para gestión de conexiones

✅ **Seguridad:**
- **Autenticación** de usuarios con contraseñas hasheadas
- **Autorización** basada en roles (Administrador, Supervisor, Vendedor)

✅ **Base de Datos:**
- **Transacciones** con Commit/Rollback en SQL Server
- **Integridad referencial** con Foreign Keys
- **Procedimientos almacenados** para operaciones complejas

✅ **Consultas Avanzadas:**
- Uso de **LINQ** para consultas y filtrado de datos
- Operaciones complejas con múltiples tablas

✅ **Reportes:**
- Generación de **reportes** con parámetros
- Uso de **procedimientos almacenados** para reportes
- Exportación a diferentes formatos

✅ **Interfaz de Usuario:**
- Interfaz gráfica con **Windows Forms**
- Diseño intuitivo y responsivo
- Validaciones en tiempo real

✅ **Programación Avanzada:**
- Manejo de **Hilos (Threads)** para operaciones asíncronas
- Uso de **Timers** para actualización en tiempo real
- Programación orientada a eventos

✅ **Distribución:**
- Creación de **bibliotecas reutilizables** (.dll)
- **Proyecto de instalación** (Setup Project)
- Empaquetado profesional

✅ **Documentación:**
- Informe técnico detallado
- **Diagramas UML** completos
- Diagramas técnicos de arquitectura
- Manual de usuario

---

## 🖥 El Sistema TechSolutions

### ¿Qué es TechSolutions?

**TechSolutions** es un sistema integral de gestión empresarial desarrollado específicamente para empresas del sector tecnológico. El sistema permite administrar de manera eficiente todos los aspectos operativos del negocio, desde la gestión de inventario hasta el control de ventas y generación de reportes.

### Problemática que Resuelve

El sistema aborda los siguientes desafíos empresariales:

1. **Control de Inventario**
   - Seguimiento en tiempo real del stock de productos
   - Alertas de stock bajo
   - Historial completo de movimientos

2. **Gestión de Ventas**
   - Registro rápido y eficiente de ventas
   - Cálculo automático de totales
   - Descuento automático de inventario
   - Trazabilidad completa de cada transacción

3. **Administración de Clientes**
   - Base de datos centralizada de clientes
   - Historial de compras por cliente
   - Información de contacto actualizada

4. **Control de Proveedores**
   - Gestión de información de proveedores
   - Asociación de productos con proveedores
   - Seguimiento de relaciones comerciales

5. **Seguridad y Control de Acceso**
   - Diferentes niveles de acceso según el rol
   - Protección de información sensible
   - Auditoría de operaciones por usuario

6. **Reportes y Análisis**
   - Reportes de ventas por período
   - Productos más vendidos
   - Análisis de movimientos de stock
   - Información para toma de decisiones

### Módulos del Sistema

El sistema está dividido en los siguientes módulos funcionales:

#### 🔐 Módulo de Autenticación
- Login seguro con validación de credenciales
- Hash de contraseñas con SHA-256
- Control de sesiones activas
- Cierre de sesión seguro

#### 👥 Módulo de Gestión de Clientes
- Registro de nuevos clientes
- Actualización de información
- Búsqueda y filtrado
- Historial de compras
- Eliminación lógica de registros

#### 🏭 Módulo de Gestión de Proveedores
- Alta de proveedores
- Mantenimiento de información de contacto
- Asociación con productos
- Consulta de productos por proveedor

#### 📦 Módulo de Gestión de Productos
- Catálogo completo de productos
- Organización por categorías
- Control de precios
- Gestión de stock
- Asociación con proveedores
- Búsqueda avanzada

#### 🏷 Módulo de Categorías
- Clasificación de productos
- Creación de nuevas categorías
- Edición y eliminación
- Consulta de productos por categoría

#### 💰 Módulo de Ventas
- Registro de ventas con múltiples productos
- Selección de cliente
- Carrito de compras
- Cálculo automático de totales
- Validación de stock disponible
- Generación de comprobante
- Transacciones seguras con rollback

#### 📊 Módulo de Movimientos de Stock
- Registro de entradas de mercancía
- Registro de salidas (ventas, mermas, etc.)
- Historial completo de movimientos
- Consulta por producto
- Consulta por fecha
- Observaciones y notas

#### 📈 Módulo de Reportes
- Reporte de ventas por fecha
- Reporte de productos más vendidos
- Reporte de movimientos de stock
- Reporte de ventas por cliente
- Reporte de ventas por usuario
- Reporte de inventario actual
- Exportación a PDF

#### 👤 Módulo de Gestión de Usuarios (Solo Admin)
- Creación de nuevos usuarios
- Asignación de roles
- Activación/desactivación de usuarios
- Cambio de contraseñas
- Gestión de permisos

---

## ✨ Características Principales


### 🔐 Seguridad Robusta
- **Autenticación segura** con contraseñas hasheadas (SHA-256)
- **Sistema de roles** jerárquico (Administrador, Supervisor, Vendedor)
- **Control de acceso** granular basado en permisos
- **Validación de sesiones** activas
- **Protección contra SQL Injection** mediante parámetros

### 📦 Gestión Completa de Inventario
- Registro y actualización de productos
- **Control de stock en tiempo real**
- Categorización flexible de productos
- Gestión de proveedores
- **Historial completo** de movimientos de stock
- Alertas de stock bajo
- Búsqueda y filtrado avanzado

### 💼 Gestión Eficiente de Ventas
- Registro de ventas con **múltiples productos**
- Cálculo automático de totales y subtotales
- **Descuento automático de stock**
- **Transacciones seguras** con Commit/Rollback
- Validación de stock disponible
- Historial completo de ventas
- Asociación con clientes y usuarios

### 👥 Administración de Clientes y Proveedores
- Base de datos centralizada
- Información completa de contacto
- Búsqueda y filtrado rápido
- Historial de transacciones
- Actualización y eliminación segura

### 📊 Reportes Profesionales
- **Reportes parametrizados** por fecha
- Productos más vendidos
- Movimientos de stock detallados
- Ventas por cliente y usuario
- **Exportación a PDF**
- Visualización con Microsoft Report Viewer (RDLC)

### ⚡ Características Técnicas Avanzadas
- **Interfaz intuitiva** con Windows Forms
- **Operaciones asíncronas** con Threads
- **Reloj en tiempo real** con Timers
- **Validaciones en tiempo real** en formularios
- **Mensajes informativos** para el usuario
- **Manejo robusto de errores**
- **Consultas optimizadas** con LINQ

### 🏗 Arquitectura Profesional
- **Arquitectura N-Capas** bien definida
- **Patrón Singleton** para conexiones
- **Separación de responsabilidades**
- **Código reutilizable** en bibliotecas (.dll)
- **Fácil mantenimiento** y escalabilidad

---

## 🛠 Tecnologías Utilizadas

### Lenguajes y Frameworks
| Tecnología | Versión | Uso |
|-----------|---------|-----|
| **C#** | 10.0 | Lenguaje principal |
| **.NET Framework** | 4.8 | Framework de desarrollo |
| **ADO.NET** | 4.8 | Acceso a datos |
| **LINQ** | - | Consultas y filtrado |
| **Windows Forms** | 4.8 | Interfaz de usuario |

### Base de Datos
| Tecnología | Versión | Uso |
|-----------|---------|-----|
| **SQL Server** | 2019+ | Base de datos principal |
| **T-SQL** | - | Procedimientos almacenados |
| **SSMS** | 18+ | Administración de BD |

### Herramientas de Desarrollo
| Herramienta | Versión | Uso |
|------------|---------|-----|
| **Visual Studio** | 2022 | IDE principal |
| **Git** | 2.40+ | Control de versiones |
| **GitHub** | - | Repositorio remoto |
| **Report Viewer** | - | Generación de reportes |

### Patrones y Arquitectura
- ✅ **N-Capas (N-Tier)** - Separación en capas
- ✅ **Singleton** - Gestión de conexiones
- ✅ **Repository Pattern** - Acceso a datos
- ✅ **Service Layer** - Lógica de negocio
- ✅ **DTO Pattern** - Transferencia de datos

---

## 💻 Requisitos del Sistema

### Para Desarrollo

**Software Requerido:**
- Windows 10/11 (64-bit)
- Visual Studio 2022 Community o superior
- SQL Server 2019 o superior (Developer/Express Edition)
- SQL Server Management Studio (SSMS) 18+
- .NET Framework 4.8 SDK
- Git para control de versiones

**Hardware Recomendado:**
- Procesador: Intel Core i5 o superior
- RAM: 8 GB o más
- Disco: 10 GB de espacio libre
- Resolución: 1920x1080 o superior

### Para Uso (Usuario Final)

**Software Requerido:**
- Windows 10/11
- .NET Framework 4.8 Runtime
- SQL Server 2016+ (puede ser Express)

**Hardware Mínimo:**
- Procesador: Intel Core i3 o equivalente
- RAM: 4 GB
- Disco: 500 MB de espacio libre
- Resolución: 1366x768 o superior

---

## 📥 Instalación

### Opción 1: Instalación Rápida (Recomendado para Usuarios)

1. **Descargar el instalador**
   ```
   TechSolutions_Setup.msi (desde Releases)
   ```

2. **Ejecutar el instalador**
   - Doble clic en el archivo .msi
   - Seguir el asistente de instalación
   - Aceptar términos y condiciones
   - Seleccionar carpeta de destino
   - Esperar a que finalice la instalación

3. **Configurar la base de datos**
   - El instalador incluye el script SQL
   - Ejecutar `script.sql` en SQL Server
   - Configurar la cadena de conexión si es necesario

4. **Iniciar la aplicación**
   - Buscar "TechSolutions" en el menú de inicio
   - O ejecutar desde la carpeta de instalación

### Opción 2: Instalación desde Código Fuente (Para Desarrolladores)

#### Paso 1: Clonar el Repositorio

```bash
# Clonar el repositorio
git clone https://github.com/tu-usuario/TechSolutions.git

# Navegar al directorio
cd TechSolutions
```

#### Paso 2: Configurar la Base de Datos

1. **Abrir SQL Server Management Studio**

2. **Conectarse a tu instancia de SQL Server**

3. **Ejecutar el script de creación**
   ```sql
   -- Abrir y ejecutar: script.sql
   -- Esto creará:
   -- - Base de datos TechSolutionsDB
   -- - Todas las tablas con relaciones
   -- - Índices y constraints
   -- - Datos de prueba (usuarios, productos, etc.)
   ```

4. **Verificar la creación**
   ```sql
   USE TechSolutionsDB;
   GO
   
   -- Verificar tablas
   SELECT * FROM INFORMATION_SCHEMA.TABLES;
   
   -- Verificar usuarios de prueba
   SELECT * FROM Usuario;
   ```

#### Paso 3: Configurar el Proyecto

1. **Abrir la solución en Visual Studio**
   ```
   Doble clic en: TechSolutions.sln
   ```

2. **Restaurar paquetes NuGet**
   ```
   Click derecho en la solución > Restaurar paquetes NuGet
   ```

3. **Configurar la cadena de conexión**
   
   Abrir: `Capa_Presentacion1/App.config`
   
   ```xml
   <configuration>
     <connectionStrings>
       <add name="TechSolutionsDB" 
            connectionString="Data Source=TU_SERVIDOR;Initial Catalog=TechSolutionsDB;Integrated Security=True" 
            providerName="System.Data.SqlClient"/>
     </connectionStrings>
   </configuration>
   ```
   
   **Ejemplos de cadenas de conexión:**
   
   ```xml
   <!-- SQL Server local con autenticación de Windows -->
   Data Source=localhost;Initial Catalog=TechSolutionsDB;Integrated Security=True
   
   <!-- SQL Server local con instancia nombrada -->
   Data Source=localhost\SQLEXPRESS;Initial Catalog=TechSolutionsDB;Integrated Security=True
   
   <!-- SQL Server con usuario y contraseña -->
   Data Source=localhost;Initial Catalog=TechSolutionsDB;User Id=sa;Password=tu_password
   
   <!-- SQL Server remoto -->
   Data Source=192.168.1.100;Initial Catalog=TechSolutionsDB;Integrated Security=True
   ```

#### Paso 4: Compilar y Ejecutar

1. **Establecer proyecto de inicio**
   ```
   Click derecho en "Capa_Presentacion1" > Establecer como proyecto de inicio
   ```

2. **Compilar la solución**
   ```
   Menú: Compilar > Compilar solución
   O presionar: Ctrl + Shift + B
   ```

3. **Ejecutar la aplicación**
   ```
   Presionar F5 o Click en "Iniciar"
   ```

4. **Iniciar sesión**
   ```
   Usuario: admin
   Contraseña: admin123
   ```

---

## ⚙️ Configuración

### Usuarios de Prueba Predefinidos

El sistema incluye 3 usuarios para pruebas con diferentes roles:

| Usuario | Contraseña | Rol | Descripción |
|---------|-----------|-----|-------------|
| `admin` | `admin123` | Administrador | Acceso total al sistema |
| `supervisor` | `super123` | Supervisor | Gestión operativa completa |
| `vendedor` | `vende123` | Vendedor | Solo registro de ventas |

### Datos de Prueba Incluidos

El script SQL incluye datos de prueba para facilitar las pruebas:

- ✅ **3 Roles** (Administrador, Supervisor, Vendedor)
- ✅ **3 Usuarios** (uno por cada rol)
- ✅ **50 Clientes** con información completa
- ✅ **15 Proveedores** de tecnología
- ✅ **10 Categorías** de productos
- ✅ **70 Productos** tecnológicos variados
- ✅ **2 Tipos de Movimiento** (Entrada, Salida)
- ✅ **Movimientos de stock** iniciales
- ✅ **20 Ventas** de ejemplo

### Configuración Avanzada

#### Cambiar el Puerto de SQL Server

Si tu SQL Server usa un puerto diferente:

```xml
<connectionString>
  Data Source=localhost,1433;Initial Catalog=TechSolutionsDB;...
</connectionString>
```

#### Habilitar Logs de Depuración

En `App.config`:

```xml
<appSettings>
  <add key="EnableDebugLogs" value="true"/>
  <add key="LogPath" value="C:\Logs\TechSolutions\"/>
</appSettings>
```

#### Configurar Timeout de Conexión

```xml
<connectionString>
  ...;Connection Timeout=30;...
</connectionString>
```

---

## 🚀 Uso del Sistema

### Inicio de Sesión

1. **Ejecutar la aplicación**
   - Doble clic en `TechSolutions.exe`
   - O presionar F5 en Visual Studio

2. **Pantalla de Login**
   ```
   ┌─────────────────────────────────┐
   │      TECHSOLUTIONS              │
   │                                 │
   │  Usuario:    [____________]     │
   │  Contraseña: [____________]     │
   │                                 │
   │      [ Iniciar Sesión ]         │
   └─────────────────────────────────┘
   ```

3. **Ingresar credenciales**
   - Usuario: `admin`
   - Contraseña: `admin123`

4. **Click en "Iniciar Sesión"**

### Menú Principal

Después del login, se muestra el menú principal con las opciones disponibles según el rol:

```
┌──────────────────────────────────────────────────┐
│  TechSolutions - Sistema de Gestión             │
│  Usuario: admin (Administrador)    [Salir]      │
├──────────────────────────────────────────────────┤
│                                                  │
│  [👥 Clientes]    [🏭 Proveedores]              │
│                                                  │
│  [🏷 Categorías]  [📦 Productos]                │
│                                                  │
│  [💰 Ventas]      [📊 Movimientos Stock]        │
│                                                  │
│  [📈 Reportes]    [👤 Usuarios]                 │
│                                                  │
│  📅 Fecha: 15/11/2025  🕐 Hora: 14:30:45       │
└──────────────────────────────────────────────────┘
```

### Gestionar Clientes

1. Click en **"Clientes"**
2. Se abre el formulario de gestión
3. Opciones disponibles:
   - **Nuevo:** Registrar un nuevo cliente
   - **Editar:** Modificar cliente seleccionado
   - **Eliminar:** Eliminar cliente
   - **Buscar:** Filtrar por nombre
   - **Actualizar:** Recargar lista

### Gestionar Productos

1. Click en **"Productos"**
2. Ver lista completa de productos
3. Acciones:
   - **Agregar producto:** Completar formulario
   - **Editar producto:** Seleccionar y modificar
   - **Eliminar producto:** Confirmar eliminación
   - **Buscar:** Por nombre o categoría
   - **Filtrar:** Por categoría o proveedor

### Registrar una Venta

1. Click en **"Ventas"**

2. **Seleccionar cliente**
   - Buscar en la lista
   - O crear uno nuevo

3. **Agregar productos al carrito**
   - Seleccionar producto del catálogo
   - Ingresar cantidad deseada
   - Click en "Agregar al carrito"
   - Repetir para más productos

4. **Verificar el carrito**
   - Ver lista de productos agregados
   - Verificar cantidades y precios
   - Ver subtotales
   - Ver total general

5. **Registrar la venta**
   - Click en "Registrar Venta"
   - El sistema automáticamente:
     - ✅ Valida stock disponible
     - ✅ Registra la venta
     - ✅ Guarda los detalles
     - ✅ Descuenta el stock
     - ✅ Registra movimientos
     - ✅ Muestra confirmación

6. **Comprobante**
   - Se genera automáticamente
   - Opción de imprimir
   - Opción de exportar

### Ver Movimientos de Stock

1. Click en **"Movimientos Stock"**
2. Ver historial completo
3. Filtros disponibles:
   - Por producto
   - Por tipo (Entrada/Salida)
   - Por rango de fechas
   - Por observación

### Generar Reportes

1. Click en **"Reportes"**

2. **Seleccionar tipo de reporte:**
   - Ventas por fecha
   - Productos más vendidos
   - Movimientos de stock
   - Ventas por cliente
   - Ventas por usuario
   - Inventario actual

3. **Configurar parámetros:**
   - Fecha inicio
   - Fecha fin
   - Filtros adicionales

4. **Generar reporte:**
   - Click en "Generar"
   - Esperar procesamiento
   - Ver resultado en pantalla

5. **Opciones de exportación:**
   - Exportar a PDF
   - Imprimir directamente
   - Guardar en archivo

### Gestionar Usuarios (Solo Administrador)

1. Click en **"Usuarios"**
2. Ver lista de usuarios del sistema
3. Acciones:
   - **Crear usuario:** Asignar rol y contraseña
   - **Editar usuario:** Cambiar rol o estado
   - **Activar/Desactivar:** Control de acceso
   - **Cambiar contraseña:** Seguridad

---

## 🏗 Arquitectura


### Arquitectura N-Capas Implementada

El proyecto sigue una arquitectura de **4 capas** bien definidas, cada una con responsabilidades específicas:

```
┌─────────────────────────────────────────────────────────┐
│         CAPA DE PRESENTACIÓN (UI Layer)                 │
│  Proyecto: Capa_Presentacion1                          │
│  Tecnología: Windows Forms                             │
│  ─────────────────────────────────────────────────────  │
│  Responsabilidades:                                     │
│  • Interfaz gráfica de usuario                         │
│  • Captura de eventos del usuario                      │
│  • Validaciones visuales                               │
│  • Presentación de datos                               │
│  • Navegación entre formularios                        │
│  • Manejo de hilos para UI responsiva                  │
│  • Timers para actualización en tiempo real            │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│         CAPA DE NEGOCIO (Business Logic Layer)          │
│  Proyecto: CapaNegocio                                 │
│  Tecnología: C# Class Library                          │
│  ─────────────────────────────────────────────────────  │
│  Responsabilidades:                                     │
│  • Lógica empresarial y reglas de negocio             │
│  • Validaciones de datos                               │
│  • Cálculos y procesamiento                            │
│  • Consultas LINQ                                      │
│  • Coordinación entre DAL y UI                         │
│  • Control de permisos por rol                         │
│  • Hash de contraseñas                                 │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│         CAPA DE DATOS (Data Access Layer)               │
│  Proyecto: CapaDatos                                   │
│  Tecnología: ADO.NET                                   │
│  ─────────────────────────────────────────────────────  │
│  Responsabilidades:                                     │
│  • Acceso directo a la base de datos                   │
│  • Operaciones CRUD (Create, Read, Update, Delete)     │
│  • Ejecución de procedimientos almacenados             │
│  • Manejo de transacciones (Commit/Rollback)           │
│  • Gestión de conexiones (Patrón Singleton)            │
│  • Mapeo de datos SQL a objetos                        │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│         CAPA DE ENTIDAD (Entity Layer)                  │
│  Proyecto: CapaEntidad                                 │
│  Tecnología: C# POCOs (Plain Old CLR Objects)          │
│  ─────────────────────────────────────────────────────  │
│  Responsabilidades:                                     │
│  • Definición de modelos de datos                      │
│  • Propiedades que representan tablas                  │
│  • DTOs para transferencia de datos                    │
│  • Sin lógica de negocio                               │
│  • Reutilizable en todas las capas                     │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│              BASE DE DATOS (Database)                   │
│  Motor: Microsoft SQL Server 2019+                     │
│  Base de Datos: TechSolutionsDB                        │
│  ─────────────────────────────────────────────────────  │
│  Componentes:                                           │
│  • 10 Tablas principales                               │
│  • Relaciones con Foreign Keys                         │
│  • Índices para optimización                           │
│  • Constraints para integridad                         │
│  • Procedimientos almacenados                          │
│  • Triggers (opcional)                                 │
└─────────────────────────────────────────────────────────┘
```

### Flujo de Datos en el Sistema

#### Ejemplo: Registro de una Venta

```
1. USUARIO
   └─> Completa formulario de venta
       └─> Selecciona cliente
       └─> Agrega productos
       └─> Click en "Registrar"

2. CAPA DE PRESENTACIÓN (VentasForm.cs)
   └─> Captura evento del botón
       └─> Valida datos visuales
       └─> Crea objetos Venta y DetalleVenta
       └─> Llama a VentaBLL.RegistrarVenta()

3. CAPA DE NEGOCIO (VentaBLL.cs)
   └─> Recibe objetos de venta
       └─> Valida reglas de negocio:
           • Stock suficiente
           • Datos completos
           • Cliente válido
       └─> Calcula totales con LINQ
       └─> Llama a VentaDAL.RegistrarVenta()

4. CAPA DE DATOS (VentaDAL.cs)
   └─> Obtiene conexión (Singleton)
       └─> Inicia transacción SQL
       └─> Ejecuta operaciones:
           • INSERT en tabla Venta
           • INSERT en tabla DetalleVenta
           • UPDATE stock en Producto
           • INSERT en TransaccionStock
       └─> Si todo OK: COMMIT
       └─> Si error: ROLLBACK
       └─> Retorna resultado

5. BASE DE DATOS (SQL Server)
   └─> Ejecuta operaciones
       └─> Valida constraints
       └─> Mantiene integridad referencial
       └─> Actualiza índices
       └─> Retorna resultado

6. RESPUESTA AL USUARIO
   └─> Mensaje de confirmación
       └─> Actualización de interfaz
       └─> Opción de imprimir comprobante
```

### Patrón Singleton Implementado

**Ubicación:** `CapaDatos/Database/Conexion.cs`

**Propósito:** Garantizar una única instancia de gestión de conexiones a la base de datos.

```csharp
public class Conexion
{
    // Instancia única (Singleton)
    private static Conexion _instancia = null;
    private string _cadenaConexion;
    
    // Constructor privado (no se puede instanciar desde fuera)
    private Conexion()
    {
        _cadenaConexion = ConfigurationManager
            .ConnectionStrings["TechSolutionsDB"]
            .ConnectionString;
    }
    
    // Propiedad para obtener la instancia única
    public static Conexion Instancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = new Conexion();
            }
            return _instancia;
        }
    }
    
    // Método para obtener una conexión
    public SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_cadenaConexion);
    }
}
```

**Uso en los repositorios:**

```csharp
// En cualquier clase DAL
using (SqlConnection conn = Conexion.Instancia.ObtenerConexion())
{
    conn.Open();
    // Operaciones con la base de datos
}
```

### Ventajas de la Arquitectura N-Capas

✅ **Separación de Responsabilidades**
- Cada capa tiene un propósito específico
- Fácil de entender y mantener

✅ **Reutilización de Código**
- Las capas inferiores son reutilizables
- Las bibliotecas (.dll) pueden usarse en otros proyectos

✅ **Facilidad de Pruebas**
- Cada capa se puede probar independientemente
- Facilita el unit testing

✅ **Escalabilidad**
- Fácil agregar nuevas funcionalidades
- Posibilidad de distribuir en diferentes servidores

✅ **Mantenibilidad**
- Cambios en una capa no afectan a las demás
- Código organizado y estructurado

✅ **Seguridad**
- La UI no accede directamente a la BD
- Validaciones en múltiples niveles

---

## 📁 Estructura del Proyecto

### Vista General de la Solución

```
TechSolutions/
│
├── 📂 CapaEntidad/                    # CAPA 1: Modelos de Datos
│   ├── Models/
│   │   ├── Rol.cs                    # Modelo de roles
│   │   ├── Usuario.cs                # Modelo de usuarios
│   │   ├── Cliente.cs                # Modelo de clientes
│   │   ├── Proveedor.cs              # Modelo de proveedores
│   │   ├── Categoria.cs              # Modelo de categorías
│   │   ├── Producto.cs               # Modelo de productos
│   │   ├── Venta.cs                  # Modelo de ventas
│   │   ├── DetalleVenta.cs           # Detalle de ventas
│   │   ├── TipoMovimiento.cs         # Tipos de movimiento
│   │   └── TransaccionStock.cs       # Movimientos de stock
│   ├── DTOs/
│   │   └── DetalleVentaParametro.cs  # DTO para ventas
│   ├── Properties/
│   │   └── AssemblyInfo.cs
│   └── CapaEntidad.csproj
│
├── 📂 CapaDatos/                      # CAPA 2: Acceso a Datos
│   ├── Database/
│   │   └── Conexion.cs               # ⭐ Patrón Singleton
│   ├── Repositorio/
│   │   ├── RolDAL.cs                 # CRUD de roles
│   │   ├── UsuarioDAL.cs             # CRUD de usuarios
│   │   ├── ClienteDAL.cs             # CRUD de clientes
│   │   ├── ProveedorDAL.cs           # CRUD de proveedores
│   │   ├── CategoriaDAL.cs           # CRUD de categorías
│   │   ├── ProductoDAL.cs            # CRUD de productos
│   │   ├── VentaDAL.cs               # ⭐ Transacciones de venta
│   │   ├── DetalleVentaDAL.cs        # Detalle de ventas
│   │   ├── TipoMovimientoDAL.cs      # Tipos de movimiento
│   │   ├── TransaccionStockDAL.cs    # Movimientos de stock
│   │   └── ReporteDAL.cs             # ⭐ Consultas para reportes
│   ├── Properties/
│   │   └── AssemblyInfo.cs
│   └── CapaDatos.csproj
│
├── 📂 CapaNegocio/                    # CAPA 3: Lógica de Negocio
│   ├── Servicios/
│   │   ├── RolBLL.cs                 # Lógica de roles
│   │   ├── UsuarioBLL.cs             # ⭐ Autenticación
│   │   ├── ClienteBLL.cs             # Lógica de clientes
│   │   ├── ProveedorBLL.cs           # Lógica de proveedores
│   │   ├── CategoriaBLL.cs           # Lógica de categorías
│   │   ├── ProductoBLL.cs            # ⭐ Validación de stock
│   │   ├── VentaBLL.cs               # ⭐ Lógica de ventas + LINQ
│   │   ├── DetalleVentaBLL.cs        # Detalle de ventas
│   │   ├── TipoMovimientoBLL.cs      # Tipos de movimiento
│   │   ├── TransaccionStockBLL.cs    # Movimientos de stock
│   │   └── ReporteBLL.cs             # ⭐ Generación de reportes
│   ├── Seguridad/
│   │   ├── PermisosPorRol.cs         # ⭐ Control de acceso
│   │   └── PasswordHasher.cs         # ⭐ Hash SHA-256
│   ├── Properties/
│   │   └── AssemblyInfo.cs
│   └── CapaNegocio.csproj
│
├── 📂 Capa_Presentacion1/             # CAPA 4: Interfaz de Usuario
│   ├── Forms/
│   │   ├── Login.cs                  # ⭐ Formulario de login
│   │   ├── Login.Designer.cs
│   │   ├── Login.resx
│   │   ├── MenuPrincipal.cs          # ⭐ Menú principal + Timer
│   │   ├── MenuPrincipal.Designer.cs
│   │   ├── MenuPrincipal.resx
│   │   ├── ClientesForm.cs           # Gestión de clientes
│   │   ├── ClientesForm.Designer.cs
│   │   ├── ClientesForm.resx
│   │   ├── ProveedoresForm.cs        # Gestión de proveedores
│   │   ├── ProveedoresForm.Designer.cs
│   │   ├── ProveedoresForm.resx
│   │   ├── CategoriasForm.cs         # Gestión de categorías
│   │   ├── CategoriasForm.Designer.cs
│   │   ├── CategoriasForm.resx
│   │   ├── ProductosForm.cs          # ⭐ Gestión de productos
│   │   ├── ProductosForm.Designer.cs
│   │   ├── ProductosForm.resx
│   │   ├── VentasForm.cs             # ⭐ Registro de ventas
│   │   ├── VentasForm.Designer.cs
│   │   ├── VentasForm.resx
│   │   ├── MovimientosStockForm.cs   # Historial de stock
│   │   ├── MovimientosStockForm.Designer.cs
│   │   ├── MovimientosStockForm.resx
│   │   ├── ReportesForm.cs           # ⭐ Generación de reportes
│   │   ├── ReportesForm.Designer.cs
│   │   ├── ReportesForm.resx
│   │   ├── UsuariosForm.cs           # Gestión de usuarios
│   │   └── UsuariosForm.Designer.cs
│   ├── Reportes/
│   │   ├── VentasPorFecha.rdlc       # Reporte de ventas
│   │   ├── ProductosMasVendidos.rdlc # Reporte de productos
│   │   └── MovimientosStock.rdlc     # Reporte de movimientos
│   ├── Resources/
│   │   └── (Imágenes, iconos, etc.)
│   ├── Properties/
│   │   ├── AssemblyInfo.cs
│   │   ├── Resources.resx
│   │   └── Settings.settings
│   ├── App.config                    # ⭐ Configuración + ConnectionString
│   ├── Program.cs                    # Punto de entrada
│   └── Capa_Presentacion1.csproj
│
├── 📂 Instalador/                     # Proyecto de Instalación
│   ├── Instalador.vdproj             # ⭐ Setup Project
│   └── (Archivos de configuración)
│
├── 📂 .vs/                            # Configuración de Visual Studio
├── 📂 packages/                       # Paquetes NuGet
│
├── 📄 TechSolutions.sln              # ⭐ Solución de Visual Studio
├── 📄 README.md                       # Este archivo
├── 📄 PERMISOS_POR_ROL.md            # Sistema de permisos
├── 📄 .gitignore                      # Archivos ignorados por Git
└── 📄 LICENSE                         # Licencia del proyecto
```

### Archivos Clave del Proyecto

| Archivo | Ubicación | Descripción |
|---------|-----------|-------------|
| **Conexion.cs** | CapaDatos/Database/ | Implementación del patrón Singleton |
| **VentaBLL.cs** | CapaNegocio/Servicios/ | Lógica de ventas con LINQ |
| **VentaDAL.cs** | CapaDatos/Repositorio/ | Transacciones con Commit/Rollback |
| **PermisosPorRol.cs** | CapaNegocio/Seguridad/ | Control de acceso por roles |
| **PasswordHasher.cs** | CapaNegocio/Seguridad/ | Hash de contraseñas SHA-256 |
| **MenuPrincipal.cs** | Capa_Presentacion1/Forms/ | Menú con Timer en tiempo real |
| **App.config** | Capa_Presentacion1/ | Cadena de conexión |
| **script.sql** | Raíz del proyecto | Creación de BD completa |

---
