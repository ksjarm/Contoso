using System.ComponentModel;

namespace Contoso.Data;
public enum Grade {
    [Description("Excellent")] A = 5,
    [Description("Very good")] B = 4,
    [Description("Good")] C = 3,
    [Description("Satisfactory")] D = 2,
    [Description("Poor")] E = 1,
    [Description("Failed")] F = 0
}