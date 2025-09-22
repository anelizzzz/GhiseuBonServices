CREATE PROCEDURE [dbo].[spBon_MarkAsReceived]
	@Id int
AS
begin
	update dbo.[Bon]
	set Stare = 'preluat',
		ModifiedAt = GETDATE()
	where Id = @Id;
end
