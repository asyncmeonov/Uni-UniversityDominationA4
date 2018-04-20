using System;
using System.Collections.Generic;
using EffectImpl;

public static class CardFactory
{
    #region Private Fields

    /// <summary>
    /// Contains a mapping of <see cref="CardType"/> to the constructor function
    /// for the relavent effect.
    /// </summary>
    readonly static Dictionary<CardType, Func<object[], Effect>> _cardBuilder =
        new Dictionary<CardType, Func<object[], Effect>>
    {
        { CardType.Graduate, data => new GraduateEffect() },
        { CardType.AdderallSupply, data => new ActionIncreaseEffect() },
        { CardType.Kuda, data => new UnitStatsEffect(CardType.Kuda) },
        { CardType.Breadcrumbs, data => new UnitStatsEffect(CardType.Breadcrumbs) },
        { CardType.FirstYearInTheLibrary, data => new UnitStatsEffect(CardType.FirstYearInTheLibrary) },
        { CardType.NightBeforeExams, data => new UnitStatsEffect(CardType.NightBeforeExams) }
    };

    /// <summary>
    /// A list of all of the cards that can be selected at random.
    /// </summary>
    readonly static CardType[] _availableRandomPool =
    {
        CardType.Graduate,
        CardType.Kuda,
        CardType.Breadcrumbs,
        CardType.FirstYearInTheLibrary,
        CardType.NightBeforeExams
    };

    #endregion

    #region Factory Methods

    /// <summary>
    /// Creates the effect of the given type.
    /// </summary>
    /// <returns>The effect.</returns>
    /// <param name="type">The type of the effect.</param>
    /// <param name="data">The data the effect might need to be created with.</param>
    public static Effect CreateEffect(CardType type, params object[] data) => _cardBuilder[type](data);

    /// <summary>
    /// Creates a random effect from the allowed pool. Data defaults to empty list.
    /// </summary>
    /// <returns>The random effect.</returns>
    public static Effect GetRandomEffect() => CreateEffect(_availableRandomPool.Random());

    #endregion
}