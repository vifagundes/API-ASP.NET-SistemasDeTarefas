using System.ComponentModel;

namespace SistemasDeTarefas.Enums
{
    public enum Status
    {
        [Description("ToDo")]
        ToDo = 1,

        [Description("InProgress")]
        InProgress = 2,

        [Description("Done")]
        Done = 3
    }
}
