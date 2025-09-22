CREATE PROCEDURE [dbo].[spBon_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Bon]
	where Id = @Id;
end