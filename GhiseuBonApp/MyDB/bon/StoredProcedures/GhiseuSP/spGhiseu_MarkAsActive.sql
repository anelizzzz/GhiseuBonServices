CREATE PROCEDURE [dbo].[spGhiseu_MarkAsActive]
	@Id Int
AS
begin
	update bon.Ghiseu set activ = 1 
	where Id = @Id;
end
