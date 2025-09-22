CREATE PROCEDURE [dbo].[spBon_GetAll]
AS
begin
	select Id, IdGhiseu, Stare, CreatedAt, ModifiedAt
	from dbo.[Bon]
end