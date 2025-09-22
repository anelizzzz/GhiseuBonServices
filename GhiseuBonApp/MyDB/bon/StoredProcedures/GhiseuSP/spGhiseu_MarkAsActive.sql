CREATE PROCEDURE [dbo].[spGhiseu_MarkAsActive]
	@Id Int
AS
begin
	update dbo.Ghiseu set activ = 1 
	where Id = @Id;
end
