CREATE PROCEDURE [dbo].[spBon_Get]
	@Id int
AS
begin
	select Id, IdGhiseu, Stare, CreatedAt, ModifiedAt
	from bon.[Bon]
	where Id = @Id;
end
