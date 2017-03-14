using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exemplo_grafico.Models
{
    public class LogsViewModels
    {
        public long CodigoLog { get; set; }
        public int? QtdeAcessos { get; set; }
        public DateTime Dia { get; set; }
    }
}