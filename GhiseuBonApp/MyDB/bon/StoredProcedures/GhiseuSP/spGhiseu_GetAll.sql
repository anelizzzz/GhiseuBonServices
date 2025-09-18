CREATE PROCEDURE [dbo].[spGhiseu_GetAll]
AS
begin
	select Cod, Denumire, Descriere, Icon, Activ
	from dbo.[Ghiseu]
end
