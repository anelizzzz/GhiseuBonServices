CREATE PROCEDURE [dbo].[spGhiseu_Delete]
	@Id int
AS
begin
	delete
	from bon.[Ghiseu]
	where Id = @Id;
end
