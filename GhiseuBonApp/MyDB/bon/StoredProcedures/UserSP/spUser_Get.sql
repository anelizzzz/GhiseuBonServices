CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
begin
	select Id, FirstName, LastName, Email, PasswordHash, UserName, CreatedAt, RoleUser
	from dbo.[User]
	where Id = @Id;
end