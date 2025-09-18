CREATE PROCEDURE [dbo].[spGhiseu_Insert]
	@Cod nvarchar(10),
	@Denumire nvarchar(50),
	@Descriere nvarchar(50),
	@Icon nvarchar(10),
	@Activ bit
AS
begin
	insert into dbo.[Ghiseu](Cod, Denumire, Denumire, Icon, Activ)
	values (@Cod, @Denumire, @Descriere, @Icon, @Activ);
end

