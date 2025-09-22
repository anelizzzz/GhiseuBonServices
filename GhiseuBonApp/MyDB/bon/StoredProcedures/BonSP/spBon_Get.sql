CREATE PROCEDURE [dbo].[spBon_Get]
	@Id int
AS
begin
	select Id, IdGhiseu, Stare, CreatedAt, ModifiedAt
	from dbo.[Bon]
	where Id = @Id;
end
