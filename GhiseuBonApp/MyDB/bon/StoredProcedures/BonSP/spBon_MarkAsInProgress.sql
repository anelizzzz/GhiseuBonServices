CREATE PROCEDURE [dbo].[spBon_MarkAsInProgress]
	@Id int
AS
begin
	update dbo.[Bon]
	set Stare = 'in process',
		ModifiedAt = GETDATE()
	where Id = @Id;
end
