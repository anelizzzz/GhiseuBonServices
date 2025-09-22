CREATE PROCEDURE [dbo].[spBon_MarkAsClosed]
	@Id int
AS
begin
	update dbo.[Bon]
	set Stare = 'inchis',
		ModifiedAt = GETDATE()
	where Id = @Id;
end
