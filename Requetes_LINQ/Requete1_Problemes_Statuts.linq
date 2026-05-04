<Query Kind="Program">
  <Connection>
    <ID>dd43d91e-f195-4e16-9d51-395b38a2b892</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>localhost</Server>
    <Database>NexaWorks</Database>
    <DisplayName>NexaWorks Database</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	// -- Lecture des paramètres --
	// Produits
	Console.WriteLine(
@"Veuillez saisir l'ID d'un produit ou laisser vide pour tous les sélectionner.
Liste des produits :");
	foreach (var p in Produits)
	    Console.WriteLine($"{p.Id} = {p.Nom}");
	
	string produit = Console.ReadLine();
	int? idProduit = null;
	if (int.TryParse(produit, out int parsedProduit))
	    idProduit = parsedProduit;
	
	// Versions
	Console.WriteLine(
@"
Veuillez saisir l'ID d'une version ou laisser vide pour toutes les sélectionner.
Liste des versions :");
	foreach (var v in Versions)
		Console.WriteLine($"{v.Id} = {v.Numero}");
	
	string version = Console.ReadLine();
	int? idVersion = null;
	if (int.TryParse(version, out int parsedVersion))
	    idVersion = parsedVersion;
	
	// Statuts
	Console.WriteLine(
@"
Veuillez saisir l'ID d'un statut ou laisser vide pour tous les sélectionner.
Liste des statuts :");
	foreach (var s in Statuts)
		Console.WriteLine($"{s.Id} = {s.Nom}");
	
	string statut = Console.ReadLine();
	int? idStatut = null;
	if (int.TryParse(statut, out int parsedStatut))
	    idStatut = parsedStatut;
	
	// Récapitulatif des paramètres sélectionnés
	Console.WriteLine(
@$"
Vous avez choisi :
	Produit = {idProduit}
	Version = {idVersion}
	Statut = {idStatut}");
	
	
	// -- Construction de la requête --
	var problemes = Problemes.AsQueryable();
	
	if (idProduit != null)
		problemes = problemes.Where(p => p.IdProduit == idProduit);
	
	if (idVersion != null)
		problemes = problemes.Where(p => p.IdVersion == idVersion);
	
	if (idStatut != null)
		problemes = problemes.Where(p => p.IdStatut == idStatut);
	
	
	// -- Affichage du résultat de la requête --
	Console.WriteLine("");
	Console.WriteLine("Voici le résultat de votre requête :");
	problemes
		.AsEnumerable()
		.Select(p => {
			var resolution = p.IdProblemeResolutions.FirstOrDefault();

			return new {
				IdProbleme = p.Id,
				DateProbleme = p.Date.ToString("dd/MM/yyyy"),
				Probleme = p.Description,
				Produit = p.IdProduitProduits.Nom,
				Version = p.IdVersionVersions.Numero,
				Systeme = p.IdSystemeSystemes.Nom,
				Statut = p.IdStatutStatuts.Nom,
				IdResolution = resolution?.Id,
				DateResolution = resolution?.Date.ToString("dd/MM/yyyy"),
				Resolution = resolution?.Description
			};
		})
		.Dump();
}

// You can define other methods, fields, classes and namespaces here
