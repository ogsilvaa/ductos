USE [Ducto]
GO
/****** Object:  StoredProcedure [dbo].[uspGetListOleoductosByNombre]    Script Date: 08/12/2016 09:11:47 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspGetListOleoductosByNombre]
	@TipoDucto VARCHAR(50) ='OLB',
	@Nombre varchar(50)=''
AS


	SELECT top 50
	Id, 
	VersionId,
	Cliente, 
	Codigo,  
	ISNULL(Descripcion,'') Descripcion, 
	ISNULL(Ubicacion,'') Ubicacion,
	ISNULL(NoLamina,'') NoLamina,
	ISNULL(FechaInspeccion,'') FechaInspeccion,	
	ISNULL(Presion, 0) Presion,	
	ISNULL(Temperatura, 0) Temperatura,
	ISNULL(BLPD, 0) BLPD,
	ISNULL(Schedule1,0) Schedule1,
	ISNULL(Schedule2, 0) Schedule2,
	ISNULL(Schedule3, 0) Schedule3,
	ISNULL(Material1, '') Material1,
	ISNULL(Material2, '') Material2,
	ISNULL(Material3, '') Material3,
	ISNULL(BSW, '') BSW,
	dbo.ufnGetLongitudOleoducto(id) LongitudTotal,
	Observaciones,
	RowState, 
	LastUpdate
FROM            Oleoductos
WHERE        
(Codigo LIKE @TipoDucto +'%' +  @Nombre + '%') and(
(Descripcion LIKE '%' + @Nombre + '%') OR
(Ubicacion  LIKE '%' + @Nombre + '%'))
	ORDER BY 1 asc