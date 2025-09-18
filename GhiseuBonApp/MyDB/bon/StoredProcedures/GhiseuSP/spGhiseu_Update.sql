CREATE PROCEDURE [dbo].[spGhiseu_Update]
	@Id int,
	@Cod nvarchar(10),
	@Denumire nvarchar(50),
	@Descriere nvarchar(50),
	@Icon nvarchar(10),
	@Activ bit 
AS
begin
	update bon.[Ghiseu]
	set Cod = @Cod, Denumire = @Denumire, Descriere = @Descriere, Icon = @Icon, Activ = @Activ
	where Id = @Id;
end