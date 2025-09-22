CREATE PROCEDURE [dbo].[spBon_Update]
	@Id int,
	@IdGhiseu int,
	@Stare nvarchar(10),
	@CreatedAt datetime,
	@ModifiedAt datetime
AS
begin
	update dbo.[Bon]
	set 
		IdGhiseu = @IdGhiseu,
		Stare = @Stare,
		CreatedAt = @CreatedAt,
		ModifiedAt = @ModifiedAt
	where Id = @Id;

end