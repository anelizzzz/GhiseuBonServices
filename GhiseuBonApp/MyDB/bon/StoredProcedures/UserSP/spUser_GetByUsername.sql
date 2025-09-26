CREATE PROCEDURE [dbo].[spUser_GetByUsername]
	@UserName NVARCHAR(50)
AS
Begin
	select * from [dbo].[User]
	where UserName = @UserName
end
