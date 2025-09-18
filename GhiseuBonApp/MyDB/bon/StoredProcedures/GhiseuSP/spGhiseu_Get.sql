CREATE PROCEDURE [dbo].[spGhiseu_Get]
	@Id int
AS
begin
	select Id, Cod, Denumire, Descriere, Icon, Activ 
	from bon.[Ghiseu]
	where Id = @Id;
end
