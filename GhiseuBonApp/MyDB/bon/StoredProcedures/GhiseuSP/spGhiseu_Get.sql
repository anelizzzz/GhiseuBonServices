CREATE PROCEDURE [dbo].[spGhiseu_Get]
	@Id int
AS
begin
	select Id, Cod, Denumire, Descriere, Icon, Activ 
	from dbo.[Ghiseu]
	where Id = @Id;
end
