namespace NecatiAkpinar.Misc
{
    public enum GameElementType
    {
        None = 0,
        NormalBrick = 41256,
        BoosterHorizontalBrick = 85761,
        BoosterVerticalBrick = 92345,
        BoosterNeighbourBrick = 54389,
    }

    public enum GameStateType
    {
        Starting,
        InGame,
        LevelEnd,
    }

    public enum TileDirectionType
    {
        Up,
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft
    }

    public enum BrickDamageType
    {
        Solid,
        Damaged,
        HighlyDamaged
    }
    
}