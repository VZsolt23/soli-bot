namespace SoliBot.Games.CardGame;

public class CardSystem
{
    private readonly int[] _cardNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13];
    private readonly string[] _cardSuits = ["Spades", "Hearts", "Diamonds", "Clubs"];

    public int SelectedNumber { get; set; }
    public string SelectedCard { get; set; }

    public CardSystem()
    {
        var random = new Random();
        var numberIndex = random.Next(0, _cardNumbers.Length - 1);
        var suitIndex = random.Next(0, _cardSuits.Length - 1);

        SelectedNumber = _cardNumbers[numberIndex];
        SelectedCard = $"{_cardNumbers[numberIndex]} of {_cardSuits[suitIndex]}";
    }
}