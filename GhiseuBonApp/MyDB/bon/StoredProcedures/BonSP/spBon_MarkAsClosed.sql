CREATE PROCEDURE [dbo].[spBon_MarkAsClosed]
	@Id int
AS
begin
	update bon.[Bon]
	set Stare = "inchis",
		ModifiedAt = GETDATE()
	where Id = @Id;
end
