CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@PasswordHash nvarchar(255),
	@UserName nvarchar(50),
	@CreatedAt datetime,
	@RoleUser nvarchar(20)
AS
BEGIN
	update dbo.[User]
	set
	FirstName = @FirstName,
	LastName = @LastName,
	Email = @Email,
	PasswordHash = @PasswordHash,
	UserName = @UserName,
	CreatedAt = @CreatedAt,
	RoleUser = @RoleUser
	where Id = @Id;
END
