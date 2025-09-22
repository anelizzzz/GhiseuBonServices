CREATE PROCEDURE [dbo].[spBon_Insert]
	@IdGhiseu int,
	@Stare nvarchar(10),
	@CreatedAt datetime,
	@ModifiedAt datetime
AS
BEGIN
	insert into dbo.[Bon](IdGhiseu, Stare, CreatedAt, ModifiedAt)
	values( @IdGhiseu, @Stare, @CreatedAt, @ModifiedAt);
END
