CREATE PROCEDURE [dbo].[spGhiseu_GetAll]
AS
begin
	select Id, Cod, Denumire, Descriere, Icon, Activ
	from dbo.[Ghiseu]

end
