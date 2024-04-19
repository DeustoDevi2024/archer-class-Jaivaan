namespace Archer.Persistence
{
    public interface IGameStateProvider
    {

        GameState Load();

        void Save(GameState gameState);

    }
}
