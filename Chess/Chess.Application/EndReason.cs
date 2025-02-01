namespace Chess.Application;

public enum EndReason
{
    Checkmate,
    Stalemate,
    FiftyMoveRule,
    InsufficientMaterial,
    ThreefoldRepetition
}