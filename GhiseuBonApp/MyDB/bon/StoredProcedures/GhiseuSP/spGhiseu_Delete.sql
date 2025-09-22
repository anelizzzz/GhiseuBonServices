CREATE PROCEDURE [dbo].[spGhiseu_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Ghiseu]
	where Id = @Id;
end
