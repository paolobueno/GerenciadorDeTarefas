using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Models.Enums
{
    /// <summary>
    /// Tipos diferentes de status para tarefas
    /// </summary>
    public enum Statuses
    {
        // Enums não são diferentes de grupos de constantes
        // as utilizamos para organização
        // elas tem a vantagem de poderem ser passadas como parametro
        // e serem reconhecidas pelo Visual Studio
        // ex.: tente fazer um switch em cima de uma variavel de um tipo enum ;)

        // Internamente enums são ints ou outro tipo numérico inteiro

        // Definimos os valores explicitamente pois temos interesse que sejam sequenciais
        // Por padrão eles são sequenciais iniciando em 0, mas sempre que utilizamos seus valores
        // é boa prática defini-los explicitamente

        NaoIniciada = 1,
        EmAndamento = 2,
        Concluida = 3


        // Dica: Você também pode definir valores como potências de 2 para utilizá-los como bitmasks
        // http://stu.mp/2004/06/a-quick-bitmask-howto-for-programmers.html
    }
}
