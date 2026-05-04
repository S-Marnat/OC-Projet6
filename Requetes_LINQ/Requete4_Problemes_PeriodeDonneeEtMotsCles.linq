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
	
	// Date de début de période
	Console.WriteLine(
@"
Veuillez saisir la date de début de période au format YYYY-MM-DD ou laisser vide pour toutes les sélectionner.");	
	string date1 = Console.ReadLine();
	DateTime? dateDebut = null;
	if (DateTime.TryParse(date1, out DateTime parsedDate1))
	    dateDebut = parsedDate1;
	
	// Date de fin de période
	Console.WriteLine(
@"
Veuillez saisir la date de fin de période au format YYYY-MM-DD ou laisser vide pour toutes les sélectionner.");
	string date2 = Console.ReadLine();
	DateTime? dateFin = null;
	if (DateTime.TryParse(date2, out DateTime parsedDate2))
	    dateFin = parsedDate2;
	
	// Mots-clés
	Console.WriteLine(
@"
Veuillez saisir des mots clés séparés par des virgules ou laisser vide pour tous les sélectionner.");
	string motsCles = Console.ReadLine();
	List<string> listeMotsCles = new List<string>();
	if (!string.IsNullOrWhiteSpace(motsCles))
		listeMotsCles = motsCles.Split(',', StringSplitOptions.RemoveEmptyEntries)
			.Select(mc => mc.Trim().ToLower())
			.ToList();
	
	// Récapitulatif des paramètres sélectionnés
	Console.WriteLine(
@$"
Vous avez choisi :
	Produit = {idProduit}
	Version = {idVersion}
	Statut = {idStatut}
	Période commençant le : {dateDebut}
	Période se terminant le : {dateFin}
	Mots-clés = {motsCles}");
	
	
	// -- Construction de la requête --
	var problemes = Problemes.AsQueryable();
	
	if (idProduit != null)
		problemes = problemes.Where(p => p.IdProduit == idProduit);
	
	if (idVersion != null)
		problemes = problemes.Where(p => p.IdVersion == idVersion);
	
	if (idStatut != null)
		problemes = problemes.Where(p => p.IdStatut == idStatut);
	
	if (dateDebut != null)
		problemes = problemes.Where(p => p.Date >= dateDebut);
	
	if (dateFin != null)
		problemes = problemes.Where(p => p.Date <= dateFin);
	
	if (listeMotsCles.Any())
		problemes = problemes.Where(p => listeMotsCles.Any(lmc => p.Description.ToLower().Contains(lmc)));
	
	
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