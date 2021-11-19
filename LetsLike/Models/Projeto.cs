using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Models
{
    [Table("PROJETO")]
    public class Projeto
    {
        [Column("ID"), Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public string Imagem { get; set; }
        public int LikeContador { get; set; }
        public Usuario UsuarioCadastro { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public virtual ICollection<UsuarioLikeProjeto> ProjetoLikeUsuario { get; set; }

    }
}
