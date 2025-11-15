-- =============================================
-- Script para CORREGIR los usuarios existentes
-- Sistema: TechSolutions
-- =============================================
-- Este script actualiza los hashes de contraseña correctos
-- Ejecuta esto si ya insertaste los usuarios con hashes incorrectos
-- =============================================

USE TechSolutionsDB;
GO

PRINT 'Actualizando contraseñas de usuarios...';
GO

-- Actualizar usuario 'admin' con contraseña 'admin123'
UPDATE Usuario 
SET ContrasenaHash = 0x240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9
WHERE NombreUsuario = 'admin';

-- Actualizar usuario 'supervisor' con contraseña 'super123'
UPDATE Usuario 
SET ContrasenaHash = 0x4E4C56E4A15F89F05C2F4C72613DA2A18C9665D4F0D6ACCE16415EB06F9BE776
WHERE NombreUsuario = 'supervisor';

-- Actualizar usuario 'vendedor' con contraseña 'vende123'
UPDATE Usuario 
SET ContrasenaHash = 0x1AD6411C0C7D03159718FE5DB7230462688551A309AF849B5E03EDFC6650B030
WHERE NombreUsuario = 'vendedor';

GO

PRINT '✓ Contraseñas actualizadas correctamente';
PRINT '';
PRINT '===========================================';
PRINT 'CREDENCIALES DE ACCESO:';
PRINT '===========================================';
PRINT 'Usuario: admin      | Contraseña: admin123';
PRINT 'Usuario: supervisor | Contraseña: super123';
PRINT 'Usuario: vendedor   | Contraseña: vende123';
PRINT '===========================================';
GO

-- Verificar que los usuarios estén activos
SELECT 
    IdUsuario,
    NombreUsuario,
    IdRol,
    Estado,
    CASE 
        WHEN Estado = 1 THEN '✓ Activo'
        ELSE '✗ Inactivo'
    END AS EstadoTexto
FROM Usuario
WHERE NombreUsuario IN ('admin', 'supervisor', 'vendedor');
GO
