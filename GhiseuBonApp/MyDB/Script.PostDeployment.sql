if not exists ( select 1 from [dbo].[Ghiseu])
begin
	insert into dbo.[Ghiseu] ( Cod, Denumire, Descriere, Icon, Activ )
	values ('1', 'Taxe si Impozite', 'Plată taxe', 'tax', 1)
end