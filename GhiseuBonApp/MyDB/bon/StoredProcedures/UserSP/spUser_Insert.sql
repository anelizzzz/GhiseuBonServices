CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@PasswordHash nvarchar(255),
	@UserName nvarchar(50),
	@CreatedAt datetime,
	@RoleUser nvarchar(20)
AS
BEGIN
	insert into dbo.[User]( FirstName, LastName, Email, PasswordHash, UserName, CreatedAt, RoleUser)
	values( @FirstName, @LastName, @Email, @PasswordHash, @UserName, @CreatedAt, @RoleUser);
END
