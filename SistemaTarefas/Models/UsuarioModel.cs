﻿using System.ComponentModel.DataAnnotations;

namespace SistemaTarefas.Models
{
    public class UsuarioModel
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
}
