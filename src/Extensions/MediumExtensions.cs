using ScorchGore.Constants;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Extensions;

internal static class MediumExtensions
{
    public static string GetTranslatedName(this Medium medium)
    {
        return medium switch
        {
            Medium.Berg => Xlat.µ(53),// Rock (hard yet destructible material, supported against direction of gravity from the bottom)
            Medium.Cave => Xlat.µ(54),// Cave ceiling (hard yet destructible material, suspended towards direction of gravity from the top)
            Medium.Rubber => Xlat.µ(55),// Rubber (soft destructible material which will reflect projectiles with almost no loss of kinetic energy)
            Medium.Player1 => Xlat.µ(56),// Player 1 (vulnerable to attacks, including their own)
            Medium.Player2 => Xlat.µ(57),// Player 2 (vulnerable to attacks, including their own)
            Medium.Stahl => Xlat.µ(58),// Craticulum (hard indestructible material which will not budge, and can only be circumvented or tunneled through)
            Medium.Nihilit => Xlat.µ(59),// Nihilit (anti-material which will change its physical properties randomly over time)
            Medium.Phosphor => Xlat.µ(60),// Phosphorus (will ignite when exposed to air or water)
            Medium.Fuel => Xlat.µ(61),// Fuel (will ignite when it comes in contact with something hot)
            Medium.Wasser => Xlat.µ(62),// Water (a transparent, odorless liquid)
            Medium.Mirror => Xlat.µ(63),// Mirror (will easily break, but reflects laser almost perfectly without taking damage)
            Medium.Lava => Xlat.µ(117),// Lava (molten rock)
            Medium.Himmel => Xlat.µ(118),// Sky (liminal zone at the outer edge of the atmosphere)
            Medium.Schnee => Xlat.µ(0),
            Medium.Gras => Xlat.µ(0),
            Medium.Eis => Xlat.µ(0),
            Medium.Erde => Xlat.µ(0),
            Medium.Sand => Xlat.µ(0),
            _ => throw new ArgumentOutOfRangeException(nameof(medium), medium, "undefined value"),
        };
    }
}
