USE [Ducto]
GO
/****** Object:  StoredProcedure [dbo].[uspGetInventarios]    Script Date: 08/12/2016 09:10:54 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oscar Silva
-- Create date: 08/12/2016
-- Description:	Obtiene los inventarios por cada prefijo de codigo
-- =============================================
ALTER PROCEDURE [dbo].[uspGetInventarios] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select distinct
		prefijo = substring(o.Codigo,1,3),
		t.AnioInspeccion
	from dbo.RegistroInspeccionVisual t
	inner join dbo.Oleoductos o
		on o.Id=t.OleoductoID
		and t.AnioInspeccion is not null
	order by prefijo, AnioInspeccion
END