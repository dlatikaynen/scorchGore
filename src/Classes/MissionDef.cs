using System.ComponentModel;

namespace ScorchGore.Classes;

public class MissionDef
{
    [Browsable(false)]
    public bool IsBuiltin { get; set; } = false;

    [Browsable(false)]
    public int MissionsNummer { get; set; } = 0;

    #region Editable Properties
    public string NameEn { get; set; } = string.Empty;

    public string NameDe { get; set; } = string.Empty;

    public string NameFi { get; set; } = string.Empty;

    public string NameUa { get; set; } = string.Empty;
    #endregion
}
