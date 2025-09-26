CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select Id, FirstName, LastName, Email, PasswordHash, UserName, CreatedAt, RoleUser
	from dbo.[User]
end