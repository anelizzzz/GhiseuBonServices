CREATE PROCEDURE [dbo].[spBon_GetAll]
AS
begin
	select IdGhiseu, Stare, CreatedAt, ModifiedAt
	from dbo.[Bon]
end