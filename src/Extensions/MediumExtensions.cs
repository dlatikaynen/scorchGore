using ScorchGore.Constants;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Extensions;

internal static class MediumExtensions
{
    public static string GetTranslatedName(this Medium medium)
    {
        switch (medium)
        {
            case Medium.Berg:
                return Xlat.µ(53); // Rock (hard yet destructible material, supported against direction of gravity from the bottom)

            case Medium.Cave:
                return Xlat.µ(54); // Cave ceiling (hard yet destructible material, suspended towards direction of gravity from the top)

            case Medium.Rubber:
                return Xlat.µ(55); // Rubber (soft destructible material which will reflect projectiles with almost no loss of kinetic energy)

            case Medium.Player1:
                return Xlat.µ(56); // Player 1 (vulnerable to attacks, including their own)

            case Medium.Player2:
                return Xlat.µ(57); // Player 2 (vulnerable to attacks, including their own)

            case Medium.Stahl:
                return Xlat.µ(58); // Craticulum (hard indestructible material which will not budge, and can only be circumvented or tunneled through)

            case Medium.Nihilit:
                return Xlat.µ(59); // Nihilit (anti-material which will change its physical properties randomly over time)

            case Medium.Phosphor:
                return Xlat.µ(60); // Phosphorus (will ignite when exposed to air or water)

            case Medium.Fuel:
                return Xlat.µ(61); // Fuel (will ignite when it comes in contact with something hot)

            case Medium.Wasser:
                return Xlat.µ(62); // Water (a transparent, odorless liquid)

            case Medium.Mirror:
                return Xlat.µ(63); // Mirror (will easily break, but reflects laser almost perfectly without taking damage)

            case Medium.Lava:
                return Xlat.µ(0);

            case Medium.Himmel:
                return Xlat.µ(0);

            case Medium.Schnee:
                return Xlat.µ(0);

            case Medium.Gras:
                return Xlat.µ(0);

            case Medium.Eis:
                return Xlat.µ(0);

            case Medium.Erde:
                return Xlat.µ(0);

            case Medium.Sand:
                return Xlat.µ(0);
        }

        throw new ArgumentOutOfRangeException(nameof(medium), medium, "undefined value");
    }
}
