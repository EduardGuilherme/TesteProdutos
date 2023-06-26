using System.ComponentModel;

namespace TesteProdutos.Enums
{
    public enum ControladorProdutos
    {
        [Description("Não Perecível")]
        Naoperecivel = 1,
        [Description("Perecível")]
        Perecivel = 2,
       
    }
}
