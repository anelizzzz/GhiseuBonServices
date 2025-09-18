CREATE PROCEDURE [dbo].[spGhiseu_MarkAsInActive]
	@Id Int
AS
begin
	update bon.Ghiseu set activ = 0
	where Id = @Id;
end
