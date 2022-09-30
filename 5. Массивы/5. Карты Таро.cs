private static string
GetSuit(Suits suit)
{
    return suit == Suits.Wands ? "жезлов" : suit ==
           Suits.Coins ? "монет" : suit == Suits.Cups ? "кубков" : "мечей";
}