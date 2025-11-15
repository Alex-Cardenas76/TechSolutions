# 🔐 Sistema de Control de Acceso por Roles - TechSolutions

## Descripción
Este documento describe el sistema de permisos implementado en TechSolutions, que controla qué funcionalidades puede acceder cada tipo de usuario según su rol.

---

## 👥 Roles del Sistema

### 1. 👑 **Administrador** (IdRol = 1)
**Acceso:** TOTAL al sistema

#### Permisos:
- ✅ Gestionar Clientes (Ver, Crear, Editar, Eliminar)
- ✅ Gestionar Proveedores (Ver, Crear, Editar, Eliminar)
- ✅ Gestionar Categorías (Ver, Crear, Editar, Eliminar)
- ✅ Gestionar Productos (Ver, Crear, Editar, Eliminar)
- ✅ Registrar y Ver Ventas
- ✅ Gestionar Movimientos de Stock
- ✅ Ver Reportes Completos
- ✅ Modificar Precios
- ✅ Eliminar Ventas
- ✅ Gestionar Usuarios (Crear, Editar, Eliminar usuarios)

#### Credenciales de Prueba:
```
Usuario: admin
Contraseña: admin123
```

---

### 2. 👨‍💼 **Supervisor** (IdRol = 2)
**Acceso:** Gestión operativa del negocio

#### Permisos:
- ✅ Gestionar Clientes
- ✅ Gestionar Proveedores
- ✅ Gestionar Categorías
- ✅ Gestionar Productos
- ✅ Registrar y Ver Ventas
- ✅ Gestionar Movimientos de Stock
- ✅ Ver Reportes
- ✅ Modificar Precios
- ❌ NO puede Eliminar Ventas
- ❌ NO puede Gestionar Usuarios

#### Credenciales de Prueba:
```
Usuario: supervisor
Contraseña: super123
```

---

### 3. 🛒 **Vendedor** (IdRol = 3)
**Acceso:** Operaciones de punto de venta

#### Permisos:
- ✅ Gestionar Clientes (para registrar ventas)
- ✅ Registrar Ventas
- ✅ Ver Productos (solo consulta)
- ❌ NO puede Gestionar Proveedores
- ❌ NO puede Gestionar Categorías
- ❌ NO puede Gestionar Productos
- ❌ NO puede Ver Movimientos de Stock
- ❌ NO puede Ver Reportes
- ❌ NO puede Modificar Precios
- ❌ NO puede Eliminar Ventas
- ❌ NO puede Gestionar Usuarios

#### Credenciales de Prueba:
```
Usuario: vendedor
Contraseña: vende123
```

---

## 🎯 Funcionalidades del Sistema de Permisos

### 1. **Menú Dinámico**
El menú principal muestra solo los botones a los que el usuario tiene acceso:
- Los botones no permitidos se **ocultan automáticamente**
- Los botones visibles se **reorganizan** para mejor visualización

### 2. **Validación Doble**
- **Nivel 1:** Ocultar botones (UI)
- **Nivel 2:** Validar permisos al hacer clic (Seguridad)

### 3. **Mensajes Claros**
Si un usuario intenta acceder a una función sin permisos:
```
"No tiene permisos para acceder a esta funcionalidad."
```

### 4. **Identificación Visual**
El menú muestra el rol del usuario:
```
Usuario: admin (Administrador)
Usuario: supervisor (Supervisor)
Usuario: vendedor (Vendedor)
```

---

## 📋 Matriz de Permisos

| Funcionalidad | Administrador | Supervisor | Vendedor |
|--------------|---------------|------------|----------|
| Clientes | ✅ | ✅ | ✅ |
| Proveedores | ✅ | ✅ | ❌ |
| Categorías | ✅ | ✅ | ❌ |
| Productos | ✅ | ✅ | ❌ |
| Ventas | ✅ | ✅ | ✅ |
| Movimientos Stock | ✅ | ✅ | ❌ |
| Reportes | ✅ | ✅ | ❌ |
| Modificar Precios | ✅ | ✅ | ❌ |
| Eliminar Ventas | ✅ | ❌ | ❌ |
| Gestionar Usuarios | ✅ | ❌ | ❌ |

---

## 🔧 Implementación Técnica

### Clase: `PermisosPorRol.cs`
Ubicación: `CapaNegocio/Seguridad/PermisosPorRol.cs`

Esta clase centraliza toda la lógica de permisos:

```csharp
// Ejemplo de uso
if (PermisosPorRol.PuedeGestionarProductos(usuario.IdRol))
{
    // Permitir acceso
}
else
{
    // Denegar acceso
}
```

### Métodos Disponibles:
- `PuedeGestionarClientes(int idRol)`
- `PuedeGestionarProveedores(int idRol)`
- `PuedeGestionarCategorias(int idRol)`
- `PuedeGestionarProductos(int idRol)`
- `PuedeRegistrarVentas(int idRol)`
- `PuedeGestionarMovimientosStock(int idRol)`
- `PuedeVerReportes(int idRol)`
- `PuedeGestionarUsuarios(int idRol)`
- `PuedeModificarPrecios(int idRol)`
- `PuedeEliminarVentas(int idRol)`
- `ObtenerNombreRol(int idRol)`

---

## 🚀 Cómo Probar

1. **Ejecutar los scripts SQL:**
   - `fix_usuarios.sql` (para actualizar contraseñas)
   - `fix_tipos_movimiento.sql` (para habilitar ventas)

2. **Iniciar sesión con cada rol:**
   - Probar con `admin` / `admin123`
   - Probar con `supervisor` / `super123`
   - Probar con `vendedor` / `vende123`

3. **Verificar:**
   - Cada usuario ve solo sus botones permitidos
   - El menú se reorganiza automáticamente
   - El rol se muestra en la parte superior

---

## 📝 Notas Importantes

1. **Seguridad:** Los permisos se validan tanto en la UI como en el código
2. **Extensibilidad:** Fácil agregar nuevos permisos o roles
3. **Mantenibilidad:** Toda la lógica está centralizada en una clase
4. **Usabilidad:** Los usuarios solo ven lo que pueden usar

---

## 🔄 Futuras Mejoras Sugeridas

- [ ] Agregar rol "Contador" (solo lectura de reportes)
- [ ] Implementar permisos granulares (por ejemplo: ver pero no editar)
- [ ] Agregar log de auditoría de accesos
- [ ] Permitir configuración de permisos desde la UI
- [ ] Implementar permisos a nivel de datos (usuarios ven solo sus ventas)

---

**Fecha de Implementación:** 2024  
**Sistema:** TechSolutions v1.0  
**Desarrollado por:** Kiro AI Assistant
