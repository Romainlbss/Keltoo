using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components;
using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Kelto.Components.Class
{
    [Table("Utilisateurs")]
    public class Utilisateur : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("nom")] 
        public string Nom { get; set; } = string.Empty;

        [Column("prenom")] 
        public string Prenom { get; set; } = string.Empty;

        [Column("nom_utilisateur")] 
        public string NomUtilisateur { get; set; } = string.Empty;


        [Column("photo_profil")] 
        public string PhotoProfil { get; set; } = string.Empty;


        [Column("mail")] 
        public string Mail { get; set; } = string.Empty;


        [Column("mot_de_passe")] 
        public string MotDePasse { get; set; } = string.Empty;

        public Utilisateur() {}
        public Utilisateur(string nom, string prenom, string nom_utilisateur, string photo_profil, string mail, string mot_de_passe) 
        {
            Nom = nom;
            Prenom = prenom;
            NomUtilisateur = nom_utilisateur;
            PhotoProfil = photo_profil;
            Mail = mail;
            MotDePasse = mot_de_passe;
        }

        public static async Task<List<Utilisateur>> GetUtilisateurs()
        {
            Client supabase = Global.GetClient();

            await supabase.InitializeAsync();
            var result = await supabase.From<Utilisateur>().Get();
            return result.Models;
        }

        public static async void DeleteUtilisateurs(Utilisateur user)
        {
            Client supabase = Global.GetClient();
            await supabase.InitializeAsync();
            await supabase
                .From<Utilisateur>()
                .Where(x => x.Id == user.Id)
                .Delete();
        }

        public static async void InsertUtilisateurs(Utilisateur new_user)
        {
            Client supabase = Global.GetClient();
            await supabase.InitializeAsync();
            await supabase.From<Utilisateur>().Insert(new_user);
        }
    }
    
}
