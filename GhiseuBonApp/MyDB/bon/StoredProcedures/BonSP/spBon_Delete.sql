CREATE PROCEDURE [dbo].[spBon_Delete]
	@Id int
AS
begin
	delete
	from bon.[Bon]
	where Id = @Id;
end