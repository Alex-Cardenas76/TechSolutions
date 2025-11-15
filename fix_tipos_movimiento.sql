-- =============================================
-- Script para INSERTAR Tipos de Movimiento
-- Sistema: TechSolutions
-- =============================================
-- Este script inserta los tipos de movimiento necesarios
-- para que las ventas funcionen correctamente
-- =============================================

USE TechSolutionsDB;
GO

PRINT 'Insertando Tipos de Movimiento...';
GO

-- Verificar si ya existen
IF NOT EXISTS (SELECT 1 FROM TipoMovimiento WHERE IdTipoMovimiento = 1)
BEGIN
    SET IDENTITY_INSERT TipoMovimiento ON;
    
    INSERT INTO TipoMovimiento (IdTipoMovimiento, NombreMovimiento) VALUES
    (1, 'Entrada'),
    (2, 'Salida');
    
    SET IDENTITY_INSERT TipoMovimiento OFF;
    
    PRINT '✓ Tipos de Movimiento insertados correctamente';
END
ELSE
BEGIN
    PRINT '⚠ Los Tipos de Movimiento ya existen';
END
GO

-- Verificar inserción
SELECT * FROM TipoMovimiento;
GO

PRINT '';
PRINT '===========================================';
PRINT 'TIPOS DE MOVIMIENTO CONFIGURADOS:';
PRINT '===========================================';
PRINT 'ID 1: Entrada (Compras, Devoluciones)';
PRINT 'ID 2: Salida  (Ventas, Ajustes)';
PRINT '===========================================';
GO
