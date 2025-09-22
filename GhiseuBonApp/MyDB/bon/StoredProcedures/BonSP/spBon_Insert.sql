CREATE PROCEDURE [dbo].[spBon_Insert]
	@Id int,
	@IdGhiseu int,
	@Stare nvarchar(10),
	@CreatedAt datetime,
	@ModifiedAt datetime
AS
BEGIN
	insert into dbo.[Bon](IdGhiseu, Stare, CreatedAt, ModifiedAt)
	values( @IdGhiseu, @Stare, @CreatedAt, @ModifiedAt);
END
